using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Decorator
{
    public class Decorator : BaseBehavior
    {
        private BaseBehavior behavior;

        public void Set(BaseBehavior behavior)
        {
            this.behavior = behavior;
        }

        public override void Show()
        {
            Program.Print("Decorator show");
            if (behavior != null)
                behavior.Show();
        }
    }
}
