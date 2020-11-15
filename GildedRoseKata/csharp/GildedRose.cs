using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<InventoryProduct> products;
        public GildedRose(IList<InventoryProduct> items)
        {
            this.products = items;
        }

        public void UpdateQuality()
        {
            foreach(var product in products)
            {
                ItemStrategy strategy = null;

                if (product.ItemType == ItemType.AGED_BRIE)
                {
                    strategy = new AgedBrieStrategy();
                }
                else if (product.ItemType == ItemType.SULFURAS)
                {
                    strategy = new SulfurasStrategy();
                }
                else if (product.ItemType == ItemType.BACKSTAGE_PASS)
                {
                    strategy = new BackstageStratregy();
                }
                else if (product.ItemType == ItemType.CONJURED)
                {
                    strategy = new ConjuredStrategy();
                }
                else
                {
                    strategy = new NormalStrategy();
                }
                strategy.Execute(product);
            }
        }
    }
}
