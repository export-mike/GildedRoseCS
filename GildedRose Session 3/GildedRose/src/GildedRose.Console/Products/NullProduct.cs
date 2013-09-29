using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class NullProduct : Product
    {
        public NullProduct(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
        }
    }
}
