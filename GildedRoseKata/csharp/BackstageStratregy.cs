namespace csharp
{
    internal class BackstageStratregy : ItemStrategy
    {
        private const int MAX_ITEM_QUALITY = 50;
        private const int BACKSTAGE_PASS_SELLIN_FACTOR_THREE_THRESHOLD = 6;
        private const int BACKSTAGE_PASS_SELLIN_FACTOR_TWO_THRESHOLD = 11;

        public override void Execute(Item item)
        {
            if (item.Quality < MAX_ITEM_QUALITY)
            {
                IncreaseQuality(item, 1);
                if (item.SellIn < BACKSTAGE_PASS_SELLIN_FACTOR_TWO_THRESHOLD)
                {
                    IncreaseQuality(item, 1);

                }
                if (item.SellIn < BACKSTAGE_PASS_SELLIN_FACTOR_THREE_THRESHOLD)
                {
                    IncreaseQuality(item, 1);
                }
            }

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}