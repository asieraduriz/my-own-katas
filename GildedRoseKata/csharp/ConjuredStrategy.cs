namespace csharp
{
    internal class ConjuredStrategy : ItemStrategy
    {
        public override void Execute(Item item)
        {
            IncreaseQuality(item, -1);
            IncreaseQuality(item, -1);

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item, -1);
                IncreaseQuality(item, -1);
            }
        }
    }
}