namespace GildedRose
{
    public class GildedRose(IList<Item> Items)
    {
        IList<Item> Items = Items;
        private static int LOWEST_QUALITY_VALUE = 0;
        private static int HIGHEST_QUALITY_VALUE = 50;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];

                if (!currentItem.IsAgedBrie() && !currentItem.IsBackstagePasses())
                {
                    if (currentItem.IsNotLegendary())
                    {
                        currentItem.DecreaseQuality();
                    }
                }
                else
                {
                    if (currentItem.IsLessThanHighestQuality())
                    {
                        currentItem.IncreaseQuality();

                        if (currentItem.IsBackstagePasses()
                            && currentItem is { SellIn: < 11, Quality: < 50 })
                        {
                            currentItem.IncreaseQuality();

                            if (currentItem is { SellIn: < 6, Quality: < 50 })
                            {
                                currentItem.IncreaseQuality();
                            }
                        }
                    }
                }

                if (!currentItem.IsSulfuras())
                {
                    currentItem.DecreaseSellIn();
                }

                if (currentItem.SellIn < 0)
                {
                    if (currentItem.IsAgedBrie())
                    {
                        if (currentItem.IsLessThanHighestQuality())
                        {
                            currentItem.IncreaseQuality();
                        }

                        continue;
                    }

                    if (!currentItem.IsBackstagePasses())
                    {
                        if (currentItem.IsNotLegendary())
                        {
                            currentItem.DecreaseQuality();
                        }
                    }
                    else
                    {
                        currentItem.ResetQuality();
                    }
                }

                Items[i] = currentItem;
            }
        }

        private static bool IsItemQualityGreaterThanLowestQuality(int itemQuality)
        {
            return itemQuality > LOWEST_QUALITY_VALUE;
        }
    }
}
