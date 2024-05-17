using NUnit.Framework;

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
        public void CheckWhatAgedBrieDoes()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.That(9, Is.EqualTo(Items[0].SellIn));
            Assert.That(6, Is.EqualTo(Items[0].Quality));
        }
    }
}
