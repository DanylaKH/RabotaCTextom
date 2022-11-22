using System;
using System.Linq;

namespace RabotaCTextom
{
    public class ReverseDataWorkflow : IDataWorkflow
    {
        public string DoOperation(string data)
        {
            string outputstring;
            return outputstring = string.Join(" ", data.Split(" ").Reverse().Select(c => new string(c.Reverse().ToArray())));
        }
        //str => new string(str.Reverse().ToArray()
    }
}