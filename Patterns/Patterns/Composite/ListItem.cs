using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Composite
{
    public class ListItem : BaseItem
    {
        private ArrayList children = new ArrayList();


        public ListItem(string name): base(name)
        {
          
        }

        public void Add(BaseItem component)
        {
            if (children != null)
            {
                children.Add(component);
            }
        }
        public void Remove(BaseItem component)
        {
            if (children != null)
            {
                children.Add(component);
            }
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            if (children != null)
            {
                foreach(BaseItem child in children)
                {
                    child.Display(depth);
                }
            }
        }

    }
}
