using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Bridge
{
    class JoyStickInput: Input
    {

        public override bool GetInputDeviceClick()
        {
            return DateTime.Now.Millisecond % 3 == 0;
        }
    }
}
