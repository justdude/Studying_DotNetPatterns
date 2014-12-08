using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Prototype
{
    public class TestClass1 : Prototype
    {

        public TestClass1(string id) :base(id)
        {
        }

        public override Prototype Clone()
        {
            return (TestClass1)this.MemberwiseClone();
        }
    }
}
