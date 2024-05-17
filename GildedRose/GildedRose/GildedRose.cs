namespace GildedRose
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackStagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        private static int LOWEST_QUALITY_VALUE = 0;
        private static int HIGHEST_QUALITY_VALUE = 50;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!IsAgedBrie(Items[i].Name) && !IsBackstagePasses(Items[i].Name))
                {
                    if (IsNotLegendaryItem(Items[i]))
                    {
                        Items[i].Quality -= 1;
                    }
                }
                else
                {
                    if (Items[i].Quality < HIGHEST_QUALITY_VALUE)
                    {
                        Items[i].Quality += 1;

                        if (Items[i].Name == BackStagePasses 
                            && Items[i].SellIn < 11 
                            && Items[i].Quality < 50)
                        {
                            Items[i].Quality += 1;

                            if (Items[i].SellIn < 6 && Items[i].Quality < 50)
                            {
                                Items[i].Quality += 1;
                            }
                        }
                    }
                }

                if (Items[i].Name != Sulfuras)
                {
                    Items[i].SellIn -= 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (IsAgedBrie(Items[i].Name))
                    {
                        if (Items[i].Quality < HIGHEST_QUALITY_VALUE)
                        {
                            Items[i].Quality += 1;
                        }

                        continue;
                    }

                    if (!IsBackstagePasses(Items[i].Name))
                    {
                        if (IsNotLegendaryItem(Items[i]))
                        {
                            Items[i].Quality -= 1;
                        }
                    }
                    else
                    {
                        Items[i].Quality = 0;
                    }
                }
            }
        }
        
        private bool IsAgedBrie(string name)
        {
            return name == AgedBrie;
        }

        private bool IsBackstagePasses(string name)
        {
            return name == BackStagePasses;
        }

        private bool IsItemQualityGreaterThanLowestQuality(int itemQuality)
        {
            return itemQuality > LOWEST_QUALITY_VALUE;
        }

        private bool IsNotLegendaryItem(Item item)
        {
            return IsItemQualityGreaterThanLowestQuality(item.Quality) && item.Name != Sulfuras;
        }
    }
}
