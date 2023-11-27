using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussInventoryCommandPattern
{
    public interface IInventoryCommand
    {
        void Do();
        void Undo();
    }
}
