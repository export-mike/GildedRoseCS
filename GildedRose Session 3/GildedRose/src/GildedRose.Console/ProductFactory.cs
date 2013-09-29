using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class ProductFactory
    {
        public ProductFactory()
        {
        }

        public Product GetProduct(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasHandRagnaros(item);
            }
            else if (item.Name == "Aged Brie")
            {
                return new AgedBrie(item);
            }
            else if (item.Name.StartsWith("Backstage passes"))
            {
                return new BackstagePasses(item);
            }
            else if (item.Name == "+5 Dexterity Vest")
            {
                return new DexterityVest(item);
            }
            else if (item.Name == "Elixir of the Mongoose")
            {
                return new ElixirOfMongoose(item);
            }
            else if (item.Name == "Conjured")
            {
                return new Conjured(item);
            }
            else
            {
                return new NullProduct(item);
            }
        }
    }
}
