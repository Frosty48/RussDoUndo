using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RussInventoryCommandPattern.InventoryCommandPattern;

namespace RussInventoryCommandPattern
{
    public class AddMultipleCommand:IInventoryCommand
    { 
        public InventoryCommandPattern Item { get; set; }
        public List<InventoryCommandPattern> TargetList { get; set; }
        private int number;

        public AddMultipleCommand(InventoryCommandPattern item, List<InventoryCommandPattern> targetList)
        { 
            Item = item;
            TargetList = targetList;
        }

        public void Do()
        {
            Random rand = new Random();
            number = rand.Next(1, 6);

            for (int i = 0; i < number; i++)
            {
                TargetList.Add(Item);
            }
        }

        public void Undo()
        {
            for (int i = 0; i < number; i++)
            {
                TargetList.Remove(Item);
            }
        }
    }
}
