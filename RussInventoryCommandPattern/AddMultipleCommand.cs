/*
 Programmer: Jerrell Russ
email:  jruss1@cnm.edu
This is P6. its supposed  to show and demonstrate operation for list boxes
 */


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


        public AddMultipleCommand(InventoryCommandPattern item, List<InventoryCommandPattern> targetList, int numberOfItemsToAdd)
        {
            Item = item;
            TargetList = targetList;
            number = numberOfItemsToAdd; // Set the number of items to add based on the provided argument
        }

        public void Do()//this is do.  supposed to generate a random number
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
