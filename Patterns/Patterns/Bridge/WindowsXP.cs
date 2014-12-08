using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Bridge
{
    public class WindowsXP: System
    {
        public override void GetTouchDown()
        {
            if (base.InputSystem != null)
                Program.Print("WindowsXP.GetTouchDown " + InputSystem.GetInputDeviceClick());
            Program.Print("WindowsXP");
        }
    }
}
