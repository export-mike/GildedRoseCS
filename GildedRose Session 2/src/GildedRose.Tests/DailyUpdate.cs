using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class DailyUpdate
    {
        public static void Run(Item dexteterityVest)
        {
            CreateAppAndItemList(dexteterityVest).UpdateQuality();
        }

        private static Program CreateAppAndItemList(Item item)
        {
            var app = new Program
                {
                    Items = new List<Item>
                        {
                            item
                        }
                };
            return app;

        }
    }
}