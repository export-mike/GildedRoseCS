using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class ElixirOfMongoose : Product
    {
        public ElixirOfMongoose(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            DecrementItemQualityBy(1);

            _item.SellIn--;

            if (_item.SellIn < 0)
            {
                DecrementItemQualityBy(1);
            }
        }
    }
}
