using System;
using System.IO;
using System.Globalization;
using System.Linq;

namespace RabotaCTextom
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            
            Console.WriteLine("Choose a solution method");
            Console.WriteLine("1) Implementation using class");
            Console.WriteLine("2) Implementation using strategy method");
            string solutionchoise = Console.ReadLine();
            var choice = GetUserChoice();
            if (solutionchoise == "1")
            {
                // 1 Implementation using class
                var workflow = new Workflow();
                workflow.Run(choice.Retriever, choice.Flow);
            }
            else 
            {
                //2 Implementation using strategy method
                HanldeString(() =>
                {
                    Console.WriteLine("Enter string");
                    return Console.ReadLine();
                },
                str => new string(str.Reverse().ToArray())
                );
            }

        }

        private static void HanldeString(Func<string> retriever, Func<string, string> handler)
        {
            Console.WriteLine("Do anything");
            var inputString = retriever();
            Console.WriteLine("Do anything");
            var handledString = handler(inputString);
            Console.WriteLine("Do anything");

            Console.WriteLine(handledString);
        }

        private static (IDataRetriever Retriever, IDataWorkflow Flow) GetUserChoice()
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

        private static (IDataRetriever Retriever, IDataWorkflow Flow) GetDataHandlers(string retrieverOption, string flowOption)
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