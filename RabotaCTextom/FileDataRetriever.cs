using System;
using System.IO;

namespace RabotaCTextom
{
    public class FileDataRetriever : IDataRetriever
    {
        private string fileline = null;
        public string GetData()
        {
            try
            {
                Config cfg = new Config();
                FileInfo fi = new FileInfo(cfg.path);
                if(!File.Exists(cfg.path))
                {
                    StreamWriter sw = File.CreateText(cfg.path);
                    sw.WriteLine("This is test message");
                    Console.WriteLine("Create new file - success");
                    return fileline = "This is test message";
                }
                else {
                    StreamReader sr = new StreamReader(cfg.path);
                    //It reads only single line. You should use ReadToEnd()
                    //fi.Length < 2048 - i use for check size file, if file size more than 2048 bytes i will issue exception
                    if (fi.Length < 2048)
                    {
                        fileline = sr.ReadToEnd();
                        Console.WriteLine("Read from file - success");
                        return fileline;
                    }
                    else
                        throw new InvalidOperationException("File size error");
                }
            }
            catch
            {
                throw new InvalidOperationException("Read from file - failed");
            }
        }
    }
}