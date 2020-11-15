using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class NormalStrategy : ItemStrategy
    {
        public override void Execute(Item item)
        {
            IncreaseQuality(item, -1);

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item, -1);
            }
        }
    }
}
