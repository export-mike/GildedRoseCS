using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class SellinTests
    {
        [TestCase(Items.Conjured)]
        [TestCase(Items.DexterityVest)]
        [TestCase(Items.ElixirOfTheMongoose)]
        [TestCase(Items.AgedBrie)]
        [TestCase(Items.BackstagePasses)]
        public void LowersSellinValueByOne(string testSubjectName)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = 20 };
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.SellIn, Is.EqualTo(19));
        }

        [TestCase(Items.SulfurasHandOfRagnaros)]
        public void SulfuraSellinNeverDecreases(string testSubjectName)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = 20 };

            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.SellIn, Is.EqualTo(20));
        }

    }
}