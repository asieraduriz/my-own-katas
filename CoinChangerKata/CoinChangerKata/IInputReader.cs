namespace CoinChangerKata
{
    public interface IInputReader
    {
        int ReadAmount();
        int[] ReadCoinDenomination();
    }
}