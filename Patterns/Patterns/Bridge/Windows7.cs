using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Bridge
{
    public class Windows7: System
    {
        public override void GetTouchDown()
        {
            if (base.InputSystem != null)
                Program.Print("Windows7.GetTouchDown " + InputSystem.GetInputDeviceClick());
            Program.Print("Windows7 ");
        }

    }
}
