using System;

namespace FizzBuzzKata
{
    internal static class NumericalHelper
    {
        public static bool IsDivisibleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }

        public static bool ContainsDigit(this int number, int digit)
        {
            string stringifiedNumber = number.ToString();

            return stringifiedNumber.Contains(digit.ToString());
        }
    }
}
