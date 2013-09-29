using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class BackstagePasses : Product
    {
        public BackstagePasses(Item item):base(item)
        {
        }

        public override void UpdateQuality()
        {
            _item.SellIn--;

            if (_item.SellIn < 0)
            {
                _item.Quality = 0;
            }
            else if (_item.SellIn < 5)
            {
                Increment‪ItemQualityBy(3);
            }
            else if (_item.SellIn < 10)
            {
                Increment‪ItemQualityBy(2);
            }
            else
            {
                Increment‪ItemQualityBy(1);
            }
        }
    }
}
