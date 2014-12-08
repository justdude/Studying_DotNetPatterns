using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Memento
{
    public interface IVector2
    {
        float X { get; set; }
        float Y { get; set; }
    }

    public class Vector2: IVector2
    {
        public float X
        {
            get; set;
        }

        public float Y
        {
            get;
            set;
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public MementoVector GetState()
        {
            return new MementoVector(this.X, this.Y);
        }

        public void SetMemento(MementoVector vect)
        {
            if (vect == null)
                return;
            this.X = vect.X;
            this.Y = vect.Y;
        }

    }

    public class MementoVector: IVector2
    {
        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public MementoVector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
