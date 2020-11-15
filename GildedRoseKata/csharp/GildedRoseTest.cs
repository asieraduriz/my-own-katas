using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<InventoryProduct> Items = new List<InventoryProduct> { new InventoryProduct { ItemType = ItemType.NORMAL_ITEM, Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        
        [TestCase(1, 1, 0)]
        [TestCase(1, 3, 2)]
        [TestCase(0, 2, 0)]
        [TestCase(0, 5, 3)]
        [TestCase(0, 1, 0)]
        public void UpdateQuality_OnNormalItem_DecreasesQuality_WhenOnPositiveSellIn(int itemSellIn, int itemQuality, int expectedItemQuality)
        {
            InventoryProduct item = ItemBuilder.NormalItem().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedItemQuality, Items[0].Quality);
        }

        [TestCase(1, 0)]
        [TestCase(-1, 1)]
        public void UpdateQuality_OnNormalItem_QualityNeverDrops(int itemSellIn, int itemQuality)
        {
            InventoryProduct item = ItemBuilder.NormalItem().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestCase(1, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(1, 49, 50)]
        [TestCase(0, 49, 50)]
        public void UpdateQuality_OnAgedBrie_IncreasesQuality_WhenOnPositiveSellIn(int itemSellIn, int itemQuality, int expectedItemQuality)
        {
            InventoryProduct item = ItemBuilder.AgedBrie().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedItemQuality, Items[0].Quality);
        }

        [TestCase(1, 50)]
        [TestCase(-1, 50)]
        public void UpdateQuality_OnAgedBrie_QualityNeverIncreases(int itemSellIn, int itemQuality)
        {
            InventoryProduct item = ItemBuilder.AgedBrie().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [TestCase(1)]
        [TestCase(30)]
        public void UpdateQuality_OnSulfuras_QualityStaysSame(int amountOfUpdates)
        {
            int itemQuality = 5;
            int sellIn = 15;
            InventoryProduct item = ItemBuilder.Sulfuras().WithSellIn(sellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            for(int i = 0; i < amountOfUpdates; i++)
            {
                app.UpdateQuality();
            }
            Assert.AreEqual(itemQuality, Items[0].Quality);
            Assert.AreEqual(sellIn, Items[0].SellIn);
        }
        
        [TestCase(1, 5, 8)]
        [TestCase(5, 5, 8)]
        [TestCase(6, 5, 7)]
        [TestCase(10, 5, 7)]
        [TestCase(11, 5, 6)]
        public void UpdateQuality_OnBackstagePasses_IncreasesQuality_WhenOnPositiveSellIn(int itemSellIn, int itemQuality, int expectedItemQuality)
        {
            InventoryProduct item = ItemBuilder.BackstagePass().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedItemQuality, Items[0].Quality);
        }

        [Test]
        public void UpdateQuality_OnBackstagePasses_QualityBecomesZero_WhenOnNegativeSellIn()
        {
            int negativeSellIn = -1;
            int anyItemQuality = 17;
            InventoryProduct item = ItemBuilder.BackstagePass().WithSellIn(negativeSellIn).WithQuality(anyItemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestCase(1, 3, 1)]
        [TestCase(0, 4, 0)]
        [TestCase(0, 2, 0)]
        [TestCase(1, 1, 0)]
        public void UpdateQuality_OnConjuredItem_DecreasesQuality_WhenOnPositiveSellIn(int itemSellIn, int itemQuality, int expectedItemQuality)
        {
            InventoryProduct item = ItemBuilder.ConjuredItem().WithSellIn(itemSellIn).WithQuality(itemQuality).Build();
            IList<InventoryProduct> Items = new List<InventoryProduct> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedItemQuality, Items[0].Quality);
        }
    }
}