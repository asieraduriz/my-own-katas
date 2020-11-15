using System;

namespace InitialProject
{
    public class LeapYear
    {
        public bool Is(int leapYear)
        {
            if (YearIsMultipleOfOneHundred(leapYear))
            {
                return IsYearMultipleOfFourHundred(leapYear);
            }

            return IsYearMultipleOfFour(leapYear);
        }

        private static bool IsYearMultipleOfFour(int year)
        {
            return year % 4 == 0;
        }

        private static bool IsYearMultipleOfFourHundred(int year)
        {
            return (year % 400 == 0);
        }

        private static bool YearIsMultipleOfOneHundred(int year)
        {
            return year % 100 == 0;
        }
    }
}