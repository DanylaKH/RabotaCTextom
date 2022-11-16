using System;
using System.IO;
using System.Globalization;

namespace RabotaCTextom
{
    class Program
    {
        

        public class Input
        {
            public string strok;
            public void DataBaseGet()
            {
                try
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine("Chtenie iz DataBase");
                    strok = Console.ReadLine();
                    Console.WriteLine("Chtenie iz DataBase - Uspex");
                }
                catch
                {
                    throw new InvalidOperationException("Oshibka podkuisheniya DataBase");
                }
            }
            public void FileGet()
            {
                try
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    using StreamReader sr = new StreamReader("C:\\Games\\test.txt");
                    strok = sr.ReadLine();
                    Console.WriteLine("Chtenie iz file - Uspex");
                }
                catch
                {
                    throw new InvalidOperationException("Oshibka podkuisheniya file");
                }
            }
        }

        public interface IObrobotka
        {

            void Obrobotka(string inputstrok);
        }

        public class ReverseStrok : IObrobotka
        {
            public string outputstrok;

            public void Obrobotka(string inputstrok)
            {
                for (int i = inputstrok.Length-1; i >= 0; i--)
                {
                    outputstrok += inputstrok[i];
                }
            }
        }

        public class UpperStrok : IObrobotka
        {
            public string outputstrok;

            public void Obrobotka(string inputstrok)
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                outputstrok = ti.ToTitleCase(inputstrok);
            }
        }

        public class Result
        {
            public void Vivod(string method, string data)
            {
                if(method == "1")
                {
                    ReverseStrok meth = new ReverseStrok();
                    meth.Obrobotka(data);
                    Console.WriteLine(meth.outputstrok);
                }
                else
                {
                    UpperStrok meth = new UpperStrok();
                    meth.Obrobotka(data);
                    Console.WriteLine(meth.outputstrok);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string e;
            do
            {
                string d, m;
                do
                {
                   
                    Console.WriteLine("Viberite metod polyucheniya dannix");
                    Console.WriteLine("1) DataBase");
                    Console.WriteLine("2) File");
                    d = Console.ReadLine();
                    if (d != "1" && d != "2")
                        throw new InvalidOperationException("Oshibka pri vibore methoda polucheniya dannix");
                } while (d == "1" && d == "2");
                var data = new Input();
                if (d == "1")
                    data.DataBaseGet();
                else
                    data.FileGet();
                do
                {
                    
                    Console.WriteLine("Viberite metod obrobotki dannix");
                    Console.WriteLine("1) Reverse");
                    Console.WriteLine("2) Perevod 1 bukvi slova v verxniy reestr");
                    m = Console.ReadLine();
                    if (d != "1" && d != "2")
                        throw new InvalidOperationException("Oshibka pri vibore methoda obrobotki");
                } while (m == "1" && m == "2");
                Result r = new Result();
                r.Vivod(m,data.strok);
                Console.WriteLine("Vi xotite zaveshit rabotu?");
                Console.WriteLine("1) Да");
                Console.WriteLine("2) Net");
                e = Console.ReadLine();
            } while (e != "1");

        }
    }
}
