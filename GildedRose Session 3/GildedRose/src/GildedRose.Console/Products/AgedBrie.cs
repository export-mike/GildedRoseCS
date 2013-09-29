using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class AgedBrie : Product
    {
        public AgedBrie(Item item):base(item)
        {
        }

        public override void UpdateQuality()
        {
            Increment‪ItemQualityBy(1);

            _item.SellIn--;

            if (_item.SellIn < 0)
            {
                Increment‪ItemQualityBy(1);
            }
        }
    }
}
