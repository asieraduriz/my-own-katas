using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChangerKata
{
    public class CoinChanger
    {
        private readonly IInputReader inputReader;
        private int[] coinDenomination;
        private int amount;

        public CoinChanger(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        public int[] DetermineLeastNumberOfCoins()
        {
            var result = new int[coinDenomination.Length];
            if (amount == 0)
            {
                return result;
            }

            var currentAmount = amount;
            result[2] = Math.Floor(amount / coinDenomination[2]);
            for (int j = 1; j <= result[2]; j++)
            {
                var newAmount = (result[2] - j * coinDenomination[2]);
                GetResultForTwoCoins(newAmount, coinDenomination.ToList().RemoveAt(2));
            }
            for (var index = 2; index >= 0; index--)
            {
                var coin = coinDenomination[index];
                if (coin <= currentAmount)
                {
                    result[index] += 1;
                    currentAmount -= coin;
                    index++;
                }
                
            }
            return result;
        }

        private int[] GetResultForTwoCoins(int newAmount, List<int> newDistributionCoins)
        {
            var result = new int[newDistributionCoins.Count];
            if (newAmount == 0)
            {
                return result;
            }
            var currentAmount = newAmount;
            for (var index = newDistributionCoins.Count - 1; index >= 0; index--)
            {
                var coin = newDistributionCoins[index];
                if (coin <= currentAmount)
                {
                    result[index] += 1;
                    currentAmount -= coin;
                    index++;
                } 
            }
            return result;
        }

        public void requestChangeAmount()
        {
            amount = inputReader.ReadAmount();
        }

        public void requestCoinDenomination()
        {
            coinDenomination = inputReader.ReadCoinDenomination();
        }
    }
}
