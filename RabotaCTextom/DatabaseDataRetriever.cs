using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RabotaCTextom
{
    public class DatabaseDataRetriever : IDataRetriever
    {
        public string GetData()
        {
            try
            {
                string outputstring = null;
                List<string> word = new List<string>();
                Config cfg = new Config();
                SqlConnection connectionString = new SqlConnection(cfg.dbConnect);
                connectionString.Open();
                Console.WriteLine("Database connection open");
                SqlCommand comand = new SqlCommand(cfg.queryString, connectionString);
                SqlDataReader dataReader = comand.ExecuteReader();
                while (dataReader.Read())
                {
                    word.Add(dataReader.GetString(0));
                }
                dataReader.Close();
                return outputstring = string.Join(" ", word);
            }
            catch
            {
                throw new InvalidOperationException("Read from database - failed");
            }
        }
    }
}