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

        public bool IsLegendary() => IsLessThanHighestQuality() && IsSulfuras();

        public bool IsAgedBrie() => Name == ItemValues.AgedBrie;

        public bool IsBackstagePasses() => Name == ItemValues.BackStagePasses;

        public bool IsSulfuras() => Name == ItemValues.Sulfuras;

        public void IncreaseQuality() => Quality += 1;

        public void DecreaseQuality() => Quality -= 1;

        public void ResetQuality() => Quality = 0;

        public void DecreaseSellIn() => SellIn -= 1;

        public bool IsLessThanHighestQuality() => Quality < ItemValues.HighestQualtity;

        private bool IsGreaterThanLowestQualtity() => Quality > ItemValues.LowestQualtity;
    }
}
