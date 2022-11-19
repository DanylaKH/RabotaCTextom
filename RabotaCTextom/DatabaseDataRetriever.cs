using System;

namespace RabotaCTextom
{
    public class DatabaseDataRetriever : IDataRetriever
    {
        public string GetData()
        {
            try
            {
                Console.WriteLine("Read from database");
                string bdlines = Console.ReadLine();
                Console.WriteLine("Read from database - success");
                return bdlines;
            }
            catch
            {
                throw new InvalidOperationException("Read from database - failed");
            }
        }
    }
}