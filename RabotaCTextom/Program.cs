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
        public delegate string GetText();
        public delegate string DoLogic(string input);
        private static void Main(string[] args)
        {

            Console.WriteLine("Choose a solution method");
            Console.WriteLine("1) Implementation using class");
            Console.WriteLine("2) Implementation using strategy method");
            string solutionChoise = Console.ReadLine();
            var choice = GetUserChoice();
            if (solutionChoise == "1")
            {
                // 1 Implementation using class
                var workflow = new Workflow();
                workflow.Run(choice.Retriever, choice.Flow);
            }
            if (solutionChoise == "2")
            {
                //2 Implementation using strategy method
                HanldeString(choice.Retriever.GetData , choice.Flow.DoOperation);
            }



            static void HanldeString(GetText retriever, DoLogic handler)
            {
                var inputString = retriever();
                var handledString = handler(inputString);
                Console.WriteLine(handledString);
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