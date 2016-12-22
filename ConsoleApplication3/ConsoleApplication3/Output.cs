using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace ConsoleApplication3
{
    class Output
    {      
        //Adds record to phone book
        internal static void addUser(Person p)
        {
            StringBuilder dataWrite = new StringBuilder();         
            dataWrite.Append(p.FirstName.ToString());
            dataWrite.Append(",");
            dataWrite.Append(p.LastName.ToString());
            dataWrite.Append(",");
            dataWrite.AppendLine(p.PhoneNumber.ToString());            
            string filepath = "D:\\test.csv";
            File.AppendAllText(filepath, dataWrite.ToString());
        }
        //Deletes record from phone book
        internal static void delete()
        {
            String input = "N";
            StringBuilder dataWrite = new StringBuilder();
            string filepath = "D:\\test.csv";
            StreamReader read = new StreamReader(filepath);
            string currentLine = "";
            Console.WriteLine("Enter in searchable data to find record");
            string dataInput = Console.ReadLine();
            List<String> list = new List<String>();
            while (string.IsNullOrEmpty(currentLine = read.ReadLine()) == false)
            {                
                var data = currentLine.Split(',');
                for (int i = 0; i < 3; i++)
                {
                    if (dataInput == data[i])
                    {
                        Console.WriteLine(currentLine.ToString());
                        Console.WriteLine("Is this the correct record?");
                        Console.Write("(y/n):");                        
                        input = Console.ReadLine();                       
                    }
                }
                if (input.Equals("y") || input.Equals("Y"))
                {
                    input = "F";
                }
                else
                {
                    list.Add(currentLine);
                }
            }
            read.Close();
            File.WriteAllText(filepath, "");
            foreach (var item in list)	
            {
                dataWrite.AppendLine(item.ToString());		 
	       }
           File.AppendAllText(filepath, dataWrite.ToString());
           if (input.Equals("y") || input.Equals("Y") || input.Equals("F"))
           {
               read.Close();               
           }
           else
           {
               read.Close();
               Console.WriteLine("Could not find record with matching data");
           }           
        }
        //Searches records in phone book
        internal static void searchRecord()
        {
            String input = "Y";           
            string filepath = "D:\\test.csv";
            StreamReader read = new StreamReader(filepath);
            string currentLine = "";
            Console.WriteLine("Enter in searchable data to find record");
            string dataInput = Console.ReadLine();
            while (string.IsNullOrEmpty(currentLine = read.ReadLine()) == false)
            {
                var data = currentLine.Split(',');
                for (int i = 0; i < 3; i++)
                {
                    if (dataInput == data[i])
                    {
                        Console.WriteLine(currentLine.ToString());
                        Console.WriteLine("Continue Searching?");
                        Console.Write("(y/n):");                        
                        input = Console.ReadLine();


                    }
                }
                if (input.Equals("n") || input.Equals("N"))
                {
                    break;
                }
                else
                {
                    input = "Y";

                }
            }
            if (input.Equals("Y") || input.Equals("y"))
            {
                Console.WriteLine("No records found");
            }
            read.Close();
        }
        //Edits Records in phone book
        internal static void editRecord()
        {
            String input = "N";
            String inputSwitch ="0";
            StringBuilder dataWrite = new StringBuilder();
            StringBuilder dataUpdate = new StringBuilder();
            string filepath = "D:\\test.csv";
            StreamReader read = new StreamReader(filepath);
            string currentLine = "";
            Console.WriteLine("Enter in searchable data to find record");
            string dataInput = Console.ReadLine();
            List<String> list = new List<String>();
            while (string.IsNullOrEmpty(currentLine = read.ReadLine()) == false)
            {
                
                var data = currentLine.Split(',');

                for (int i = 0; i < 3; i++)
                {
                    if (dataInput == data[i])
                    {
                        Console.WriteLine(currentLine.ToString());
                        Console.WriteLine("Is this the correct record?");
                        Console.Write("(y/n):");                        
                        input = Console.ReadLine();                      
                    }
                }
                if (input.Equals("y") || input.Equals("Y"))
                {
                    Console.WriteLine("Select field to update");
                    Console.WriteLine("1 - First Name");
                    Console.WriteLine("2 - Last Name");
                    Console.WriteLine("3 - Phone Number");
                    Console.Write("Select Option:");
                    inputSwitch = Console.ReadLine();
                    switch (inputSwitch)
                    {
                        case "1":
                            Console.WriteLine("Enter in the updated First Name");
                            dataUpdate.Append(Console.ReadLine());
                            dataUpdate.Append(",");
                            dataUpdate.Append(data[1]);
                            dataUpdate.Append(",");
                            dataUpdate.Append(data[2]);                            
                            break;
                        case "2":
                            Console.WriteLine("Enter in the updated Last Name");
                            dataUpdate.Append(data[0]);
                            dataUpdate.Append(",");
                            dataUpdate.Append(Console.ReadLine());
                            dataUpdate.Append(",");
                            dataUpdate.Append(data[2]);                            
                            break;
                        case "3":
                            Console.WriteLine("Enter in the updated Phone Number");
                            dataUpdate.Append(data[0]);
                            dataUpdate.Append(",");
                            dataUpdate.Append(data[1]);
                            dataUpdate.Append(",");
                            dataUpdate.Append(Console.ReadLine());
                            break;
                        default:
                            break;
                    }
                    list.Add(dataUpdate.ToString());
                    input = "F";
                }
                else
                {
                    
                    list.Add(currentLine);
                }
            }
            read.Close();
            File.WriteAllText(filepath, "");
            foreach (var item in list)
            {
                dataWrite.AppendLine(item.ToString());		 
	        }
            File.AppendAllText(filepath, dataWrite.ToString());
            if (input.Equals("y") || input.Equals("Y") || input.Equals("F"))
            {
               read.Close();               
            }
            else
            {
               read.Close();
               Console.WriteLine("Could not find record with matching data");
           }           
        }














            
        







    }
}
