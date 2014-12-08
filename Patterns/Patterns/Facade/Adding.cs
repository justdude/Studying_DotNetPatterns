using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Facade
{
    public class Adding
    {
        public void DoOperation(int x, int y)
        {
            Program.Print((x + y).ToString());
        }

        public void DoOperation(float x, float y)
        {
            Program.Print((x + y).ToString());
        }


    }
}
