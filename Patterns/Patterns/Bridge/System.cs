using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Bridge
{
    public abstract class System
    {
        public Input InputSystem
        { get; set; }

        public abstract void GetTouchDown();
    }
}
