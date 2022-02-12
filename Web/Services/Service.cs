using System.Text.Json;
using Mvc.Exceptions;

namespace Mvc.Services
{
    public class Service
    {
        private static int DuplicatesThreshold = 3;

        public IEnumerable<int> FindDuplicates(string input)
        {
            var numbers = ParseInputText(input);

            return FindDuplicates(numbers);
        }

        private IEnumerable<int> FindDuplicates(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(number => number)
                .Where(numberGroup => numberGroup.Count() >= DuplicatesThreshold)
                .Select(numberGroup => numberGroup.Key)
                .OrderByDescending(number => number);
        }

        private IEnumerable<int> ParseInputText(string text)
        {
            try
            {
                return JsonSerializer.Deserialize<IEnumerable<int>>(text)!;
            }
            catch
            {
                throw new InvalidInputFormatException($"'{text}' format is invalid.");
            }
        }
    }
}