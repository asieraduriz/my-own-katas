namespace csharp
{
    internal class AgedBrieStrategy : ItemStrategy
    {
        private const int MAX_ITEM_QUALITY = 50;

        public override void Execute(Item item)
        {
            IncreaseQuality(item, 1);

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item, 1);
            }
        }
    }
}