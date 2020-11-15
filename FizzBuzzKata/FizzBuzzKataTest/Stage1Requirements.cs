using System;
using FizzBuzzKata;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FizzBuzzKataTest
{
    [TestFixture()]
    internal class Stage1Requirements
    {
        [Test]
        public void FizzBuzz_Composes_MathSequence()
        {
            const string CORRECT_SEQUENCE = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz Fizz 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 Fizz Fizz Buzz 26 Fizz 28 29 FizzBuzz";
            IPrinter printer = new Printer();
            FizzBuzz fizzBuzz = new FizzBuzz(printer);

            string actualSequence = fizzBuzz.GetCheatSheet(30);

            Assert.AreEqual(CORRECT_SEQUENCE, actualSequence);
        }
    }
}
