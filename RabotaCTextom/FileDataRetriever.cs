using System;
using System.IO;

namespace RabotaCTextom
{
    public class FileDataRetriever : IDataRetriever, IConfig
    {
        private string fileline = null;
        public string path = null;

        public string Connect()
        {
            return path = "C:\\Users\\admin\\Documents\\test.txt";
        }

        public string GetData()
        {
            try
            {
                if(!File.Exists(Connect()))
                {
                    StreamWriter sw = File.CreateText(Connect());
                    sw.WriteLine("This is test message");
                    Console.WriteLine("Create new file - success");
                    return fileline = "This is test message";
                }
                else 
                {
                    StreamReader sr = new StreamReader(Connect());
                    //It reads only single line. You should use ReadToEnd()
                    //fi.Length < 2048 - i use for check size file, if file size more than 2048 bytes i will issue exception
                    fileline = sr.ReadToEnd();
                    Console.WriteLine("Read from file - success");
                    return fileline;
                }
            }
            catch
            {
                throw new InvalidOperationException("Read from file - failed");
            }
        }
    }
}