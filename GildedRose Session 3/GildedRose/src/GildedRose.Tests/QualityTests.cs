using System.Collections.Generic;
using NUnit.Framework;
using GildedRose.Console;

namespace GildedRose.Tests
{
    [TestFixture]
    public class QualityTests
    {
        [TestCase(Items.DexterityVest)]
        [TestCase(Items.ElixirOfTheMongoose)]
        public void LowerQualityByOne(string testSubjectName)
        {
            var testSubject = new Item {Name = testSubjectName, SellIn = 20, Quality = 20};
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(19));
        }

        [TestCase(Items.SulfurasHandOfRagnaros,20,20)]
        [TestCase(Items.SulfurasHandOfRagnaros,80,80)]
        public void SulfuraQualityNeverAlters(string testSubjectName,int startQuality, int expectedQuality)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = startQuality };

            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(Items.Conjured, 100, 98)]
        public void QualityDegradesTwiceAsFast(string testSubjectName, int startQuality, int expectedQuality)
        {

            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = startQuality };

            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(expectedQuality));

        }

        [TestCase(Items.AgedBrie, 10)]
        [TestCase(Items.AgedBrie, 20)]
        [TestCase(Items.AgedBrie, 30)]
        [TestCase(Items.AgedBrie, 40)]
        [TestCase(Items.AgedBrie, 49)]
        public void BrieQualityIncreasesByOne(string testSubjectName, int quality)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = quality };

            int expectedQuality = quality;
            
            DailyUpdate.Run(testSubject);

            expectedQuality++;

            Assert.That(testSubject.Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(Items.AgedBrie, 50, 50)]
        [TestCase(Items.BackstagePasses, 50, 50)]
        [TestCase(Items.SulfurasHandOfRagnaros, 50, 50)]
        [TestCase(Items.BackstagePasses, 49, 50)]
        public void AnyItemQualityDoesNotIncreaseOverExpectedMaximum(string testSubjectName, int quality, int expected)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 20, Quality = quality };

            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(expected));
        }

        [TestCase(Items.DexterityVest, 0)]
        [TestCase(Items.ElixirOfTheMongoose, 0)]
        public void WhenSellinPassesQualityDegradesTwiceAsFast(string testSubjectName, int sellinValue)
        {
            var testSubject = new Item { Name = testSubjectName, SellIn = 0, Quality = 20 };

            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(18));
        }

        [Test]
        public void BackstagePassesQualityIncreasesByOne()
        {
            var testSubject = new Item {Name = Items.BackstagePasses, SellIn = 20, Quality = 20};
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(21));
        }

        [Test]
        public void BackstagePassesQualityIncreasesByTwo()
        {
            var testSubject = new Item {Name = Items.BackstagePasses, SellIn = 10, Quality = 20};
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(22));
        }

        [Test]
        public void BackstagePassesQualityIncreasesByThree()
        {
            var testSubject = new Item {Name = Items.BackstagePasses, SellIn = 5, Quality = 20};
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(23));
        }

        [Test]
        public void BackstagePassesQualityDropToZero()
        {
            var testSubject = new Item {Name = Items.BackstagePasses, SellIn = 0, Quality = 20};
            DailyUpdate.Run(testSubject);

            Assert.That(testSubject.Quality, Is.EqualTo(0));
        }

    }
}