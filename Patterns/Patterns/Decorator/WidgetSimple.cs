using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Decorator
{
    public class WidgetSimple: BaseBehavior
    {
        public override void Show()
        {
            Program.Print("WidgetSimple show");
        }
    }
}
