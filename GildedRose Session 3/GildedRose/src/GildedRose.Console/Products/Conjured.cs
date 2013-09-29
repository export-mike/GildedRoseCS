using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class Conjured : Product
    {
        public Conjured(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            _item.SellIn--;
            DecrementItemQualityBy(2);
        }
    }
}
