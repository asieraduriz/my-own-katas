using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class ItemBuilder
    {
        private InventoryProduct product;

        public ItemBuilder(ItemType itemType, string name)
        {
            product = new InventoryProduct
            {
                ItemType = itemType,
                Name = name
            };
        }

        public static ItemBuilder NormalItem()
        {
            return new ItemBuilder(ItemType.NORMAL_ITEM, "Elixir of the Mongoose");
        }

        public static ItemBuilder AgedBrie()
        {
            return new ItemBuilder(ItemType.AGED_BRIE, "Aged Brie");
        }

        public static ItemBuilder Sulfuras()
        {
            return new ItemBuilder(ItemType.SULFURAS, "Sulfuras, Hand of Ragnaros");
        }

        public static ItemBuilder BackstagePass()
        {
            return new ItemBuilder(ItemType.BACKSTAGE_PASS, "Backstage passes to a TAFKAL80ETC concert");
        }

        public static ItemBuilder ConjuredItem()
        {
            return new ItemBuilder(ItemType.CONJURED, "Conjured Mana Bread");
        }

        public ItemBuilder WithQuality(int quality)
        {
            product.Quality = quality;
            return this;
        }

        public ItemBuilder WithSellIn(int sellIn)
        {
            product.SellIn = sellIn;
            return this;
        }

        public InventoryProduct Build()
        {
            return product;
        }
    }

    public class ItemNames
    {
        public static string DEXTERITY_VEST = "+5 Dexterity Vest";
        public static string AGED_BRIE = "Aged Brie";
        public static string MONGOOSE_ELIXIR = "Elixir of the Mongoose";
        public static string SULFURAS = "Sulfuras, Hand of Ragnaros";
    }
}
