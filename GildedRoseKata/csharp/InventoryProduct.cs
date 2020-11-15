using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public enum ItemType
    {
        AGED_BRIE,
        SULFURAS,
        BACKSTAGE_PASS,
        CONJURED,
        NORMAL_ITEM
    }

    public class InventoryProduct : Item
    {
        public ItemType ItemType { get; set; }


    }
}
