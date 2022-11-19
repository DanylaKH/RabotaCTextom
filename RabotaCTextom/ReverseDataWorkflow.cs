using System;

namespace RabotaCTextom
{
    public class ReverseDataWorkflow : IDataWorkflow
    {
        public string DoOperation(string data)
        {
            string outputstring = null;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                //What if there is more then 10Mb of text?What the problem we can face with?
                outputstring += data[i];
            }
            return outputstring;
        }
    }
}