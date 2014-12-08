using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Composite
{
    public class ListItemWithoutChild : BaseItem
    {

        public ListItemWithoutChild(string id):base(id)
        { }

        public override void Display(int depth)
        {
            Program.Print(new String('-', depth) + name);
        }
    }
}
