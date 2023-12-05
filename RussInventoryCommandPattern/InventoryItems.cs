/*
 Programmer: Jerrell Russ
email:  jruss1@cnm.edu
This is P6. its supposed  to show and demonstrate operation for list boxes
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussInventoryCommandPattern
{
    public class InventoryItems
    {

        public string Name{ get; set; }

        public InventoryItems(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
