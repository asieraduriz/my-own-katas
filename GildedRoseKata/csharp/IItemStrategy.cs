using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public abstract class ItemStrategy
    {
        private const int MIN_ITEM_QUALITY = 0;
        private const int MAX_ITEM_QUALITY = 50;

        public abstract void Execute(Item item);

        public void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        public void IncreaseQuality(Item item, int qualityFactor)
        {
            if (item.Quality > MIN_ITEM_QUALITY && item.Quality < MAX_ITEM_QUALITY)
            {
                item.Quality += qualityFactor;
            }
        }
    }
}
