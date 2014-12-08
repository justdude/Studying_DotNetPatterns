using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Facade
{
    public static class Facade
    {
        static Multiply modMultiply = new Multiply();
        static Adding modAdding = new Adding();
        static float x, y;
        public static void PrintResult()
        {
            modAdding.DoOperation(x, y);
            modMultiply.DoOperation(x, y);
        }

        public static void ReadData(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

    }
}
