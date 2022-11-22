using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace RabotaCTextom
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Choose a solution method");
            Console.WriteLine("1) Implementation using class");
            Console.WriteLine("2) Implementation using strategy method");
            string solutionChoise = Console.ReadLine();
            if (solutionChoise == "1")
            {
                var choice = GetUserChoice();
                // 1 Implementation using class
                var workflow = new Workflow();
                workflow.Run(choice.Retriever, choice.Flow);
            }
            if (solutionChoise == "2")
            {

                //2 Implementation using strategy method
                HanldeString(GetTextDeleagte, DelegateLogic);
            }



            static void HanldeString(Func<string> retriever, Func<string, string> handler)
            {
                
                var inputString = retriever();
                var handledString = handler(inputString);
                Console.WriteLine(handledString);
            }

            string GetTextDeleagte()
            {
                Console.WriteLine("Choose how to retrive string");
                Console.WriteLine("1) DataBase");
                Console.WriteLine("2) File");
                Console.WriteLine("3) Console");
                var retrieverChoice = Console.ReadLine();
                if (retrieverChoice == "1")
                {
                    string dbConnect = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\admin\\Desktop\\RabotaCTextom\\RabotaCTextom\\DatabaseTest.mdf; Integrated Security = True";
                    string queryString = "SELECT Items FROM TestTable";
                    string outputstring = null;
                    List<string> word = new List<string>();
                    SqlConnection connectionString = new SqlConnection(dbConnect);
                    connectionString.Open();
                    Console.WriteLine("Database connection open");
                    SqlCommand comand = new SqlCommand(queryString, connectionString);
                    SqlDataReader dataReader = comand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        word.Add(dataReader.GetString(0));
                    }
                    dataReader.Close();
                    return outputstring = string.Join(" ", word);

                }
                if (retrieverChoice == "2")
                {
                    string path = "C:\\Users\\admin\\Documents\\test.txt";
                    string fileline = null;
                    if (!File.Exists(path))
                    {
                        StreamWriter sw = File.CreateText(path);
                        sw.WriteLine("This is test message");
                        Console.WriteLine("Create new file - success");
                        return fileline = "This is test message";
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(path);
                        //It reads only single line. You should use ReadToEnd()
                        //fi.Length < 2048 - i use for check size file, if file size more than 2048 bytes i will issue exception
                        fileline = sr.ReadToEnd();
                        Console.WriteLine("Read from file - success");
                        return fileline;
                    }
                }
                if (retrieverChoice == "3")
                {
                    Console.WriteLine("Enter string");
                    return Console.ReadLine();
                }
                else
                {
                    throw new InvalidOperationException("Error");
                }
            }
            string DelegateLogic(string handler)
            {
                
                Console.WriteLine("Choose how to handle string");
                Console.WriteLine("1) Reverse string");
                Console.WriteLine("2) Upper case words");
                var flowChoice = Console.ReadLine();
                if (flowChoice == "1")
                {
                    string outputstring;
                    var words = handler.Split(" ");
                    var reverseWords = words.Reverse().Select(c => new string(c.Reverse().ToArray())); ;
                    return outputstring = string.Join(" ", reverseWords);
                }
                if(flowChoice == "2")
                {
                    var words = handler.Split(" ");

                    var upperWords = words.Select(x =>
                    {
                        var firstLetter = char.ToUpper(x[0]);
                        var word = $"{firstLetter}{x.Substring(1)}";
                        return word;
                    });

                    var outputString = string.Join(" ", upperWords);
                    return outputString;
                }
                else
                {
                    throw new InvalidOperationException("Error");
                }
            }

            static (IDataRetriever Retriever, IDataWorkflow Flow) GetUserChoice()
            {
                Console.WriteLine("Choose how to retrive string");
                Console.WriteLine("1) DataBase");
                Console.WriteLine("2) File");
                Console.WriteLine("3) Console");

                var retrieverChoice = Console.ReadLine();

                Console.WriteLine("Choose how to handle string");
                Console.WriteLine("1) Reverse string");
                Console.WriteLine("2) Upper case words");

                var flowChoice = Console.ReadLine();

                return GetDataHandlers(retrieverChoice, flowChoice);
            }

            static (IDataRetriever Retriever, IDataWorkflow Flow) GetDataHandlers(string retrieverOption, string flowOption)
            {
                IDataRetriever dataRetriever = null;
                IDataWorkflow flow = null;

                if (retrieverOption == "1")
                {
                    dataRetriever = new DatabaseDataRetriever();
                }
                if (retrieverOption == "2")
                {
                    dataRetriever = new FileDataRetriever();
                }
                if (retrieverOption == "3")
                {
                    dataRetriever = new ConsoleDataRetriever();
                }
                if (flowOption == "1")
                {
                    flow = new ReverseDataWorkflow();
                }
                if (flowOption == "2")
                {
                    flow = new UpperCaseDataWorkflow();
                }
                return (dataRetriever, flow);
            }
        }
    }
}