using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Prototype
{
    public abstract class Prototype
    {
        string mvId;
        public string ID
        {
            get
            {
                return mvId;
            }
        }
        
        public Prototype(string id)
        {
            this.mvId = id;
        }

        public abstract Prototype Clone();
    }
}
