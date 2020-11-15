using System.Runtime.Serialization.Formatters;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        private readonly IPrinter printer;
        
        public FizzBuzz(IPrinter printer)
        {
            this.printer = printer;
        }

        private const string FIZZBUZZ = "FizzBuzz";
        private const string FIZZ = "Fizz";
        private const int DEFAULT_SEQUENCE_LENGTH = 100;
        private const string BUZZ = "Buzz";



        public string GetCheatSheet(int sequenceMaxNum = DEFAULT_SEQUENCE_LENGTH)
        {
            string sequence = "";
            for (int i = 1; i <= sequenceMaxNum; i++)
            {
                sequence += GetNumericalInterpretation(i) + " ";
            }
            return sequence.Trim();
        }
        
        public string GetNumericalInterpretation(int number)
        {
            if (number.IsDivisibleBy(15) || (number.ContainsDigit(5) && number.ContainsDigit(3)))
            {
                return FIZZBUZZ;
            }

            if (number.IsDivisibleBy(3) || number.ContainsDigit(3))
            {
                return FIZZ;
            }

            if (number.IsDivisibleBy(5) || number.ContainsDigit(5))
            {
                return BUZZ;
            }

            return $"{number}";
        }

        public void PrintSequence()
        {
            var sequence = GetCheatSheet();
            printer.Print(sequence);
        }
    }
}