using System;
using System.IO;
using System.Globalization;
using System.Linq;

namespace RabotaCTextom
{
    internal class Program
    {
        public class Input
        {
            //Why do you need this.
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
                    //It reads only single line. You should use ReadToEnd()
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
                for (int i = inputstrok.Length - 1; i >= 0; i--)
                {
                    //What if there is more then 10Mb of text?What the problem we can face with?
                    outputstrok += inputstrok[i];
                }
            }
        }

        public class UpperStrok : IObrobotka
        {
            //Again, why do you need public variable, what is the purpose
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
                if (method == "1")
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

        private static void Main(string[] args)
        {
            var choice = GetUserChoice();

            // 1 Implementation using class
            var workflow = new Workflow();
            workflow.Run(choice.Retriever, choice.Flow);

            //2 Implementation using strategy method
            HanldeString(() =>
            {
                Console.WriteLine("Enter string");
                return Console.ReadLine();
            },
            str => new string(str.Reverse().ToArray())
            );
            //YourImplementation.Run();
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

            if (retrieverOption == "3")
            {
                dataRetriever = new ConsoleDataRetriever();
            }
            else
            {
                throw new NotImplementedException();
            }

            if (flowOption == "2")
            {
                flow = new UpperCaseDataWorkflow();
            }
            else
            {
                throw new NotImplementedException();
            }

            return (dataRetriever, flow);
        }

        private static class YourImplementation
        {
            public static void Run()
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
                    r.Vivod(m, data.strok);
                    Console.WriteLine("Vi xotite zaveshit rabotu?");
                    Console.WriteLine("1) Да");
                    Console.WriteLine("2) Net");
                    e = Console.ReadLine();
                } while (e != "1");
            }
        }
    }
}