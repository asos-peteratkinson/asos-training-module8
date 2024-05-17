using NUnit.Framework;
using System;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That("foo", Is.EqualTo(Items[0].Name));
        }

        [Test]
        public void AgedBrie_Quality_SellInDecreases_QualtityIncreases()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
            Assert.That(Items[0].Quality, Is.EqualTo(6));
        }

        [Test]
        public void SulfurasHandOfRagnaros_SellIn_And_Quality_Should_Not_Change()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Items[0].SellIn, Is.EqualTo(10));
            Assert.That(Items[0].Quality, Is.EqualTo(5));
        }

        [Test]
        public void BackStagePasses_SellInDecreases_And_QualityIncreasesBy2()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
            Assert.That(Items[0].Quality, Is.EqualTo(7));
        }

        [Test]
        public void By1BackStagePasses_SellInDecreasesBy1_And_QualityIncreasesBy3()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Items[0].SellIn, Is.EqualTo(4));
            Assert.That(Items[0].Quality, Is.EqualTo(8));
        }

        [Test]
        public void ExlixirOfMongoose_SellIn_And_Quality_DecreaseBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
            Assert.That(Items[0].Quality, Is.EqualTo(4));
        }
    }
}
