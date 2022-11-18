using System.Linq;

namespace RabotaCTextom
{
    public class UpperCaseDataWorkflow : IDataWorkflow
    {
        public string DoOperation(string data)
        {
            var words = data.Split(" ");

            var upperWords = words.Select(x =>
            {
                var firstLetter = char.ToUpper(x[0]);
                var word = $"{firstLetter}{x.Substring(1)}";
                return word;
            });

            var outputString = string.Join(" ", upperWords);
            return outputString;
        }
    }
}