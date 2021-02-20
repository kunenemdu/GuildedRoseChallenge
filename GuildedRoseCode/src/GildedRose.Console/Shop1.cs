using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Application
{
    public static class Shop1
    {
        public static IList<Item> Items;

        public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Quality < 50)
                {
                    if (Items[i].Name.Equals("Conjured Mana Cake"))
                        Items[i].Quality -= 2;

                    if (Items[i].SellIn > 5)
                    {
                        if (Items[i].Name.Equals("Aged Brie"))
                            Items[i].Quality++;

                        if (Items[i].SellIn <= 10)
                        {
                            if (Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                            {
                                Items[i].Quality += 2;
                            }
                        }
                    }

                    else if (Items[i].SellIn <= 5)
                    {
                        //brie +1
                        if (Items[i].Name.Equals("Aged Brie"))
                            Items[i].Quality++;

                        //+3 quality when <= 5 days
                        if (Items[i].SellIn > 0 && Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                            Items[i].Quality += 3;

                        //passes are worthless after concert
                        else if (Items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert") && Items[i].SellIn < 0)
                            Items[i].Quality = 0;
                    }

                    //if past sell-by-date -2 quality
                    if (Items[i].SellIn < 0)
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Aged Brie" && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            Items[i].Quality -= 2;

                    //degrade normal items
                    if (Items[i].SellIn > 0)
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Aged Brie" && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            Items[i].Quality--;

                    //all items -1 sell-by-date except Sulfuras
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        Items[i].SellIn--;
                }

                //item never < 0
                if (Items[i].Quality < 0)
                    Items[i].Quality = 0;
            }
        }

        //item can have of 4 states depending on quality
        public static void UpdateStatus()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                int quality = Items[i].Quality;

                if (quality >= 30)
                    Items[i].Status = "Pristine";
                else if (quality >= 10)
                    Items[i].Status = "Good";
                else if (quality > 0)
                    Items[i].Status = "Poor";
                else
                    Items[i].Status = "Expired";
            }
        }

        //set status for new added items
        public static String setStatus(int Quantity)
        {
            if (Quantity >= 30)
                return "Pristine";
            else if (Quantity >= 10)
                return "Good";
            else if (Quantity > 0)
                return "Poor";
            else
                return "Expired";
        }
    }
}
