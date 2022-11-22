using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RabotaCTextom
{
    public class DatabaseDataRetriever : IDataRetriever, IConfig
    {
        public string dbConnect = null;
        public string queryString = null;
        public string Connect()
        {
            return dbConnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Desktop\\RabotaCTextom\\RabotaCTextom\\DatabaseTest.mdf;Integrated Security=True";
        }

        public string GetData()
        {
            try
            {
                queryString = "SELECT Items FROM TestTable";
                string outputstring = null;
                List<string> word = new List<string>();
                SqlConnection connectionString = new SqlConnection(Connect());
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
            catch
            {
                throw new InvalidOperationException("Read from database - failed");
            }
        }
    }
}