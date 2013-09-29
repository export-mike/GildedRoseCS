using System.Collections.Generic;
using NUnit.Framework;
using GildedRose.Console;
namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {

        [Test]
        public void LowersValueQualityAtEndOfDay()
        {
            var dexteterityVest = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            CreateAppAndItemList(dexteterityVest).UpdateQuality();

            Assert.That(dexteterityVest.Quality, Is.EqualTo(19));
        }

        [Test]
        public void LowersSellinValueAtEndOfDay()
        {
            var dexteterityVest = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            CreateAppAndItemList(dexteterityVest).UpdateQuality();
           
            Assert.That(dexteterityVest.SellIn, Is.EqualTo(9));
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