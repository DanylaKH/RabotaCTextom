using System;
using System.IO;

namespace RabotaCTextom
{
    public class FileDataRetriever : IDataRetriever
    {
        public string GetData()
        {
            try
            {
                
                using StreamReader sr = new StreamReader("C:\\Users\\admin\\Documents\\test.txt");
                FileInfo fi = new FileInfo("C:\\Users\\admin\\Documents\\test.txt");
                //It reads only single line. You should use ReadToEnd()
                if(fi.Length < 2048)
                {
                    string fileLine = sr.ReadToEnd();
                    Console.WriteLine("Read from file - success");
                    return fileLine;
                }
                else
                    throw new InvalidOperationException("File size error");
            }
            catch
            {
                throw new InvalidOperationException("Read from file - failed");
            }
        }
    }
}