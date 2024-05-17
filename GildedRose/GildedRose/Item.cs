namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public bool IsAgedBrie()
        {
            return Name == ItemNames.AgedBrie;
        }

        public bool IsBackstagePasses()
        {
            return Name == ItemNames.BackStagePasses;
        }

        public bool IsSulfuras()
        {
            return Name == ItemNames.Sulfuras;
        }

        public void IncreaseQuality()
        {
            Quality += 1;
        }

        public void DecreaseQuality()
        {
            Quality -= 1;
        }
    }
}
