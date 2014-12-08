using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Decorator
{
    public class ControlAdditional: Decorator
    {
        public override void Show()
        {
            Program.Print("ControlAdditional Show");
            base.Show();
        }

    }
}
