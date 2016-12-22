using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



//Application is a personal phone book
//Allows users to add, delete, search and edit records
//Creates and updates a file "D:\\test.csv" 
namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = 1;//Flag to stop program
            String input = "";

            StringBuilder dataWrite = new StringBuilder();
            //Checks for file and creates if not found
            if (File.Exists("D:\\test.csv") == false)
            {
                dataWrite.AppendLine("First Name,Last Name,Phone Number");
            }            
            string filepath = "D:\\test.csv";
            File.AppendAllText(filepath, dataWrite.ToString());
        

            
            do
            {
                Console.WriteLine("PERSONAL PHONE BOOK");                
                Console.WriteLine("1 - Create New Record");
                Console.WriteLine("2 - Delete Record");
                Console.WriteLine("3 - Search For Record");
                Console.WriteLine("4 - Edit Record");
                Console.WriteLine("5 - Exit");
                Console.Write("Select Option:");
                input = Console.ReadLine();
                
                //Switch is to chose between the users input when deciding which option to enter
                switch (input)
                {   
                    case "1":
                        Console.Clear();
                    Person p = new Person();
                    Console.WriteLine("First Name?");
                    input = Console.ReadLine();
                    p.FirstName = input;
                    Console.WriteLine("Last Name?");
                    input = Console.ReadLine();
                    p.LastName = input;
                    Console.WriteLine("Phone Number?");
                    input = Console.ReadLine();
                    p.PhoneNumber = input;
                    Output.addUser(p);
                        break;
                    case "2":
                        Console.Clear();
                        Output.delete();
                        break;
                    case "3":
                        Console.Clear();
                        Output.searchRecord();
                        break;
                    case "4":
                        Console.Clear();
                        Output.editRecord();
                        break;
                    case "5":
                        Console.Clear();
                        count = 0;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Selection");
                        break;
                }               
            }
            while(count == 1);
        }
    }
}
