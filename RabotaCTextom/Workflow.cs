using System;

namespace RabotaCTextom
{
    public class Workflow
    {
        public void Run(IDataRetriever dataRetriever, IDataWorkflow flow)
        {
            var inputString = dataRetriever.GetData();
            var handledData = flow.DoOperation(inputString);

            Console.WriteLine(handledData);
            /// Do anything with handledData
        }
    }
}