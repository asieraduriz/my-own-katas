using System;
using CoinChangerKata;
using Moq;
using NUnit.Framework;

namespace CoinChangerKataTest
{
    [TestFixture]
    public class CoinChangerShould
    {
        private Mock<IInputReader> inputReader;
        private CoinChanger coinChanger;

        [SetUp]
        public void SetUp()
        {
            inputReader = new Mock<IInputReader>();

            coinChanger = new CoinChanger(inputReader.Object);
        }

        [Test]
        public void Read_Input_Amount()
        {
            GivenChangeAmount(123);
            CoinChanger coinChanger = new CoinChanger(inputReader.Object);
            coinChanger.requestChangeAmount();
            
            inputReader.Verify(x => x.ReadAmount(), Times.Once);
        }

        [Test]
        public void Read_Input_CoinDenomination()
        {
            GivenCoinDenomination(new int[] {1,2,3});
            CoinChanger coinChanger = new CoinChanger(inputReader.Object);
            coinChanger.requestCoinDenomination();
            
            inputReader.Verify(x => x.ReadCoinDenomination(), Times.Once);
        }

        [Test]
        public void OutputDistributionToZero_WhenChangeAmountIsZero_ForAny_Distribution()
        {
            GivenChangeAmount(0);
            GivenCoinDenomination(new int[] {1, 2});
            var leastNumberOfCoins = WhenDeterminingLeastNumberOfCoins();

            Assert.AreEqual(new int[] {0, 0}, leastNumberOfCoins);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(99)]
        [TestCase(12345)]
        public void Output_Least_Number_Of_Coins_For_One_Cent_Distribution(int amount)
        {
            GivenChangeAmount(amount);
            GivenCoinDenomination(new int[] {1});
            var leastNumberOfCoins = WhenDeterminingLeastNumberOfCoins();

            Assert.AreEqual(new int[] { amount }, leastNumberOfCoins);
        }

        [TestCase(new int[] {1,2}, 3, new int[] {1,1})]
        [TestCase(new int[] {1,2}, 4, new int[] {0,2})]
        [TestCase(new int[] {1,5}, 9, new int[] {4,1})]
        [TestCase(new int[] {1,3}, 2, new int[] {2,0})]
        [TestCase(new int[] { 1, 2, 5 }, 13, new int[] { 1, 1, 2 })]
        [TestCase(new int[] { 1, 2, 5 }, 19, new int[] { 0, 2, 3 })]
        [TestCase(new int[] { 1, 5, 25 }, 11, new int[] { 1, 2, 0 })]
        [TestCase(new int[] { 5, 10, 25 }, 65, new int[] { 1, 1, 2 })]
        public void Output_Least_Number_Of_Coins_For_TwoAndThree_Coins_Distribution(int[] coinDistribution, int amount, int[] result)
        {
            GivenChangeAmount(amount);
            GivenCoinDenomination(coinDistribution);
            var leastNumberOfCoins = WhenDeterminingLeastNumberOfCoins();
            Assert.AreEqual(result, leastNumberOfCoins);
        }
        
        [TestCase(new int[] { 1, 10, 25 }, 30, new int[] { 0, 3, 0 })]
        public void Output_Least_Number_Of_Coins_For_Three_Coins_Distribution_For_ExceptionalLeastAmountOfCoins(int[] coinDistribution, int amount, int[] result)
        {
            GivenChangeAmount(amount);
            GivenCoinDenomination(coinDistribution);
            var leastNumberOfCoins = WhenDeterminingLeastNumberOfCoins();
            Assert.AreEqual(result, leastNumberOfCoins);
        }

        private void GivenCoinDenomination(int[] coinDenomination)
        {
            inputReader.Setup(x => x.ReadCoinDenomination()).Returns(coinDenomination);
        }

        private void GivenChangeAmount(int amount)
        {
            inputReader.Setup(x => x.ReadAmount()).Returns(amount);
        }

        private int[] WhenDeterminingLeastNumberOfCoins()
        {
            coinChanger.requestChangeAmount();

            coinChanger.requestCoinDenomination();

            int[] leastNumberOfCoins = coinChanger.DetermineLeastNumberOfCoins();
            return leastNumberOfCoins;
        }
    }
}
