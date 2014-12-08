using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Composite
{
    public abstract class BaseItem
    {
        protected string name;
 
        // Constructor
        public BaseItem(string name)
        {
          this.name = name;
        }
 
        public abstract void Display(int depth);
    }
}
