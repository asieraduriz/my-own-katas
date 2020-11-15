using System.Linq;
using System.Security.Principal;

namespace InitialProject
{
    public class RomanConverter
    {
        private const int FIVE = 5;
        private const int TEN = 10;
        private const int FIFTY = 50;
        private const int HUNDRED = 100;
        private const int FIVE_HUNDRED = 500;
        private const int THOUSAND = 1000;

        public string Convert(int arabicNumber)
        {
            if (arabicNumber == 90)
                return "XC";
            string romanNumber = "";

            var divisionResult = arabicNumber / THOUSAND;
            romanNumber += string.Concat(Enumerable.Repeat("M", divisionResult));

            arabicNumber %= THOUSAND;

            if (arabicNumber >= FIVE_HUNDRED)
            {
                romanNumber += "D";
                arabicNumber -= FIVE_HUNDRED;
            }

            divisionResult = arabicNumber / HUNDRED;
            romanNumber += string.Concat(Enumerable.Repeat("C", divisionResult));

            arabicNumber %= HUNDRED;

            if (arabicNumber >= FIFTY)
            {
                romanNumber += "L";
                arabicNumber -= FIFTY;
            }
            if (arabicNumber >= 40)
            {
                romanNumber += "XL";
            }
            else
            {
                divisionResult = arabicNumber / TEN;
                romanNumber += string.Concat(Enumerable.Repeat("X", divisionResult));
            }

            arabicNumber %= TEN;

            if (arabicNumber >= FIVE)
            {
                romanNumber += "V";
                arabicNumber -= FIVE;
            }
            if (arabicNumber == 4)
            {
                romanNumber += "IV";
            }
            else
            {
                romanNumber += string.Concat(Enumerable.Repeat("I", arabicNumber));
            }

            return romanNumber;
        }
    }
}