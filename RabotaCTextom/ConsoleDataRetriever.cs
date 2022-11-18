using System;

namespace RabotaCTextom
{
    public class ConsoleDataRetriever : IDataRetriever
    {
        public string GetData()
        {
            Console.WriteLine("Enter string");
            return Console.ReadLine();
        }
    }
}