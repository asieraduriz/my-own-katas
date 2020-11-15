using System;
using FizzBuzzKata;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FizzBuzzKataTest
{
    [TestFixture]
    public class FizzBuzzShould
    {
        private const string FIZZ = "Fizz";
        private const string BUZZ = "Buzz";
        FizzBuzz maths;
        Mock<IPrinter> printer;

        [SetUp]
        public void SetUp()
        {
            printer = new Mock<IPrinter>();
            maths = new FizzBuzz(printer.Object);
        }

        [Test]
        public void Return_NonEmptySequence()
        {
            string mathsCheatSheet = maths.GetCheatSheet();

            Assert.IsNotEmpty(mathsCheatSheet);
        }

        [Test]
        public void ReturnFizz_WhenNumberDivisibleBy3()
        {
            var fizz = maths.GetNumericalInterpretation(3);

            Assert.AreEqual(FIZZ, fizz);
        }

        [Test]
        public void ReturnFizz_WhenNumberContains3()
        {
            var fizz = maths.GetNumericalInterpretation(32);

            Assert.AreEqual(FIZZ, fizz);
        }

        [Test]
        public void ReturnBuzz_WhenNumberDivisibleBy5()
        {
            var buzz = maths.GetNumericalInterpretation(5);

            Assert.AreEqual(BUZZ, buzz);
        }

        [Test]
        public void ReturnBuzz_WhenNumberContains5()
        {
            var buzz = maths.GetNumericalInterpretation(52);

            Assert.AreEqual(BUZZ, buzz);
        }

        [Test]
        public void Return_FizzBuzz_WhenNumberDivisibleBy5And3()
        {
            var fizzBuzz = maths.GetNumericalInterpretation(15);

            Assert.AreEqual("FizzBuzz", fizzBuzz);
        }

        [Test]
        public void Return_FizzBuzz_WhenNumberContains5And3()
        {
            var fizzBuzz = maths.GetNumericalInterpretation(53);

            Assert.AreEqual("FizzBuzz", fizzBuzz);
        }

        [TestCase(2, "2")]
        [TestCase(7, "7")]
        [TestCase(14, "14")]
        public void ReturnsStringifiedValue_WhenNumberNotDivisibleBy3Or5(int number, string expectedValue )
        {
            var result = maths.GetNumericalInterpretation(number);

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Return_1_2_Fizz_Sequence()
        {
            var cheatSheet = maths.GetCheatSheet(3);

            Assert.AreEqual("1 2 Fizz", cheatSheet);
        }

        [Test]
        public void Print_Sequence()
        {
            maths.PrintSequence();
                //"1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz 67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 Buzz Fizz 97 98 Fizz Buzz";

            printer.Verify(p => p.Print(It.IsAny<string>()), Times.Once);

        }
    }
}
