using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public abstract class Product
    {
        protected Item _item;

        public Product(Item item)
        {
            _item = item;
        }

        public abstract void UpdateQuality();

        protected void Increment‪ItemQualityBy(int increment)
        {
            if (_item.Quality < 50)
            {
                _item.Quality += increment;
            }
        }

        protected void DecrementItemQualityBy(int decrement)
        {
            if (_item.Quality > 0)
            {
                _item.Quality -= decrement;
            }
        }
    }
}
