using System;
using System.Linq;

namespace RabotaCTextom
{
    public class ReverseDataWorkflow : IDataWorkflow
    {
        public string DoOperation(string data)
        {
            string outputstring;
            var words = data.Split(" ");
            var reverseWords = words.Reverse().Select(c => new string(c.Reverse().ToArray())); ;
            return outputstring = string.Join(" ", reverseWords);
        }
    }
}