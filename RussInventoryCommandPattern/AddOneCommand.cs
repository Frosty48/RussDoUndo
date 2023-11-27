using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RussInventoryCommandPattern.InventoryCommandPattern;

namespace RussInventoryCommandPattern
{
    internal class AddOneCommand:IInventoryCommand
    {
        public InventoryItem Item { get; set; }
        public List<InventoryItem> TargetList { get; set; }

        public AddOneCommand(InventoryItem item, List<InventoryItem> targetList)
        {
            Item = item;
            TargetList = targetList;
        }

        public void Do()
        {
            TargetList.Add(Item);
        }

        public void Undo()
        {
            TargetList.Remove(Item);
        }
    }
}
