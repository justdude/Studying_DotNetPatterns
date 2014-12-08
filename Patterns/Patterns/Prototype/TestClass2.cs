using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Prototype
{
    public class TestClass2 : Prototype
    {
        public TestClass2(string id) :base(id)
        {
        }

        public override Prototype Clone()
        {
            return (TestClass2)this.MemberwiseClone();
        }
    }
}
