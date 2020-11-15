using InitialProject;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class LeapYearShould
    {
        private LeapYear leapYear;

        [SetUp]
        public void Initialise()
        {
            leapYear = new LeapYear();
        }

        [TestCase(400)]
        [TestCase(800)]
        [TestCase(1200)]
        [TestCase(1600)]
        [TestCase(2000)]
        public void Be_MultipleOfFourHundred(int leapYear)
        {
            Assert.IsTrue(this.leapYear.Is(leapYear));
        }

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(1900)]
        public void NotBe_WhenYearIsMultipleOfOneHundred_ButNotOfFourHundred(int leapYear)
        {
            Assert.IsFalse(this.leapYear.Is(leapYear));
        }

        [TestCase(4)]
        [TestCase(16)]
        [TestCase(80)]
        [TestCase(284)]
        public void Be_MultipleOfFour(int leapYear)
        {
            Assert.IsTrue(this.leapYear.Is(leapYear));
        }
    }
}
