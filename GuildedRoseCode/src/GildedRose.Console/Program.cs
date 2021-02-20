using System;
using System.Collections.Generic;
using MarkdownLog;

namespace GildedRose.Application
{
    public static class Program
    {
        public static IList<Item> Items;

        static void Main(string[] args)
        {
            Console.WriteLine("*********WELCOME USER********\nPress 1 To Test.\nPress 2 To Add New Item.\nPress 3 to Remove An Item.");
            
            //get choice from user
            int input = int.Parse(Console.ReadLine());

            //initialise item list
            Shop1.Items = new List<Item>
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0  },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Status = "" }
                };

            //method to degrade items/cycle through days
            void CycleItems()
            {
                Console.Clear();

                //update the statuses programmatically
                Shop1.UpdateStatus();
                Shop1.UpdateQuality();

                Console.WriteLine(Shop1.Items.ToMarkdownTable());

                Console.WriteLine("Press 1 To Test.\nPress 2 To Add New Item.\nPress 3 To Remove An Item.");
                input = int.Parse(Console.ReadLine());

                //for consistency --errors if not present here?
                if (input == 2)
                {
                    AddItems();
                }
                if (input == 3)
                {
                    Console.WriteLine(Shop1.Items.ToMarkdownTable());
                    Console.WriteLine("Enter item to remove (e.g. elixir...): ");
                    int position = int.Parse(Console.ReadLine());
                    RemoveItem(position);
                }
            }

            //add new item to existing list
            void AddItems()
            {
                String Name;
                int SellIn, Quality;

                Console.WriteLine("**Enter Item Name: ");
                Name = Console.ReadLine();

                Console.WriteLine("***Enter Item Sell-By (Numeric): ");
                SellIn = int.Parse(Console.ReadLine());

                Console.WriteLine("****Enter Item Quality (Numeric): ");
                Quality = int.Parse(Console.ReadLine());

                //create object of Item and assign properties
                Item item = new Item { Name = Name, SellIn = SellIn, Quality = Quality, Status = Shop1.setStatus(Quality) };
                
                //add new item object to list
                Shop1.Items.Add(item);

                //display new list
                CycleItems();
            }

            //method to remove an item from list 
            void RemoveItem(int position)
            {
                Shop1.Items.RemoveAt(position);
                CycleItems();
            }

            while (input == 1)
            {
                CycleItems();

                if (input == 2)
                {
                    AddItems();
                }
                if (input == 3)
                {
                    //display list items for user to pick
                    Console.WriteLine(Shop1.Items.ToMarkdownTable());
                    Console.WriteLine("Enter item to remove (e.g. 0,1,2...): ");
                    int position = 0;

                    //error handling
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                        RemoveItem(position);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Please Enter a Numeric Character (0, 1, 2, 3...)!");
                    }
                }
            }

            //if 2 goto add page
            if (input == 2)
            {
                AddItems();
            }

            //if 3 goto remove page
            if (input == 3)
            {
                Console.WriteLine(Shop1.Items.ToMarkdownTable());
                Console.WriteLine("Enter item to remove (e.g. elixir...): ");
                int position = int.Parse(Console.ReadLine());
                RemoveItem(position);
            }
        }
    }
}
