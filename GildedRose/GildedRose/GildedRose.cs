namespace GildedRose
{
    public class GildedRose
    {
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
                if (Items[i].Name != "Aged Brie" 
                    && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
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

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" 
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

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn -= 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
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
                    else
                    {
                        if (Items[i].Quality < HIGHEST_QUALITY_VALUE)
                        {
                            Items[i].Quality += 1;
                        }
                    }
                }
            }
        }

        private bool IsItemQualityGreaterThanLowestQuality(int itemQuality)
        {
            return itemQuality > LOWEST_QUALITY_VALUE;
        }

        private bool IsNotLegendaryItem(Item item)
        {
            return IsItemQualityGreaterThanLowestQuality(item.Quality) && item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
