using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    public interface IITerator<T> where T : class
    {
        T First();
        T CurrentItem();
        T Next();
        int Count();
        bool IsDone();
    }

    public abstract class IterableCollectionBase<T> where T : class
    {

        protected List<T> modCollection = new List<T>();

        public T this[int index]
        {
            get
            {
                return modCollection[index];
            }
            set
            {
							modCollection.Insert(index, value);
            }
        }

        public abstract int Count();

        public abstract IITerator<T> CreateIterator();
    }

			public class IterableCollection<T> : IterableCollectionBase<T> where T : class
			{
			public override int Count()
        {
            return modCollection.Count<T>();
        }

				public override IITerator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }
    }

    public class Iterator<T>: IITerator<T> where T: class 
    {

        private IterableCollectionBase<T> Collection { get; set; }
        private int current = 0;

        public Iterator(IterableCollectionBase<T> collection)
        {
            Collection = collection;
            current = 0;
        }

        public T First()
        {
            if (Collection.Count() > 0)
                return Collection[0];
            return null;
        }

        public T CurrentItem()
        {
            return Collection[current];
        }

        public T Next()
        {
            current = Math.Min( current + 1, Collection.Count());
            return Collection[current];
        }

        public void Reset()
				{
					current = 0;
				}

        public int Count()
        {
            return Collection.Count();
        }

        public bool IsDone()
        {
					return current + 1 >= Collection.Count();
        }


    }


}
