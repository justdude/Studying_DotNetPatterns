using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Proxy
{

    public class ArrayCollection<T>
    {
        private object[] p;


        private T[] Items { get; set; }
        public System.Collections.IComparer comparer { get; set; }

        public ArrayCollection(IEnumerable<T> items)
        {
            Items = items.ToArray();
        }

        public ArrayCollection(T[] items)
        {
            Items = items;
        }

        public void Sort()
        {
            if (Items == null)
                return;

            System.Array.Sort(Items, comparer);
        }
        
        public object Get(int i)
        {
            return Items[i];
        }
    }

    public class ProxyArrayCollection<T>
    {
        private ArrayList Items { get; set; }

        private ArrayCollection<T> target;

        public System.Collections.IComparer comparer { get; set; }


        public ProxyArrayCollection(IEnumerable<T> items)
        {
            target = new ArrayCollection<T>(items);
            Items = new ArrayList(items.ToList());
            //Items.AddRange(items.ToList());
        }

        public void Sort()
        {
            if (Items == null)
                return;

            Items.Sort(0, Items.Count, comparer);
            var arr = new T[Items.Count];
            for (int i = 0; i < Items.Count; i++ )
            {
                arr[i] = (T)Items[i];
            }

            target = new ArrayCollection<T>(arr);
        }

        public object Get(int i)
        {
            if (target == null)
                return null;

            return target.Get(i);
        }
       
    }
}
