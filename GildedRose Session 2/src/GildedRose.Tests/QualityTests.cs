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