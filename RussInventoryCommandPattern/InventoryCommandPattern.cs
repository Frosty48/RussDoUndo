using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussInventoryCommandPattern
{
    public class InventoryCommandPattern
    {
        // Inventory Item Class
        public class InventoryItem
        {
            public string Name { get; set; }

            public InventoryItem(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

    }
}
