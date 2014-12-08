using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Bridge
{
    public class MouseInput: Input
    {
        public override bool GetInputDeviceClick()
        {
            return DateTime.Now.Millisecond % 2 == 0;
        }
    }
}
