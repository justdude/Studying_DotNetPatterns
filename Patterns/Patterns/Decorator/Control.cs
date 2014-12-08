using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Decorator
{
    public class Control : Decorator
    {

        public override void Show()
        {
            Program.Print("Control Show");
            base.Show();
        }

    }
}
