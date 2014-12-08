using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedPatterns
{
    public static class StringHelper
    {

        public static char GetWithOffset(string str, int offset)
        {
            int n = offset % str.Length;
            return str[n];
        }

        public static string GetAsciTableInString()
        {
            StringBuilder builder = new StringBuilder();

            for (byte i = 32; i < 127; i++)
            {
                builder.Append(StringHelper.GetAsciRepresentation(i));
            }
            return builder.ToString();
        }

        public static int GetAsciNumber(char c)
        {
            return (int)c;
        }

        public static char GetAsciRepresentation(int n)
        {
            return (char)n;
        }

    }
}
