using InitialProject;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class RomanConverterShould
    {
        private RomanConverter romanConverter;

        [SetUp]
        public void SetUp()
        {
            romanConverter = new RomanConverter();
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(18, "XVIII")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(22, "XXII")]
        [TestCase(25, "XXV")]
        [TestCase(30, "XXX")]
        [TestCase(31, "XXXI")]
        [TestCase(50, "L")]
        [TestCase(51, "LI")]
        [TestCase(100, "C")]
        [TestCase(101, "CI")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(4, "IV")]
        [TestCase(14, "XIV")]
        [TestCase(24, "XXIV")]
        [TestCase(34, "XXXIV")]
        [TestCase(40, "XL")]
        [TestCase(90, "XC")]
        [TestCase(41, "XLI")]
        [TestCase(44, "XLIV")]

        public void ConvertArabicIntoRoman(int arabicNumber, string expectedRomanNumber)
        {
            var actualRomanNumber = romanConverter.Convert(arabicNumber);

            Assert.AreEqual(expectedRomanNumber, actualRomanNumber);
        }
    }
}
