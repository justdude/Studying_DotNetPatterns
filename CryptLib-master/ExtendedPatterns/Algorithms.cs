using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedPatterns
{

    public class Viginer : CryptBase
    {

        public Viginer(string value, string key)
        {
            base.value = value;
            base.key = key;
            code = new int[value.Length];
            for(int i = 0; i< value.Length; i++)
            {

                code[i] = StringHelper.GetAsciNumber(value[i]);
            }
        }
        public Viginer(int[] code, string key)
        {
            base.code = code;
            base.key = key;
        }

        public override void Crypt()
        {
            code = new int[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                base.code[i] = (StringHelper.GetAsciNumber(value[i])
                    + StringHelper.GetAsciNumber(StringHelper.GetWithOffset(key, i))) % (127 - 32);
                base.result+= StringHelper.GetAsciRepresentation(code[i]);
            }
        }

        public override void Decrypt()
        {
            value = "";

            for (int i = 0; i < code.Length; i++)
            {
                int v = (code[i] - StringHelper.GetAsciNumber(StringHelper.GetWithOffset(key, i)) + (127 - 32)) % (127 - 32);
                 value += StringHelper.GetAsciRepresentation(v);
            }
        }

        public static string GetAlphabet()
        {
            return StringHelper.GetAsciTableInString();
        }

    }

    public class ViginerFactory : AbstractCryptFactory
    {
        private Viginer v = null;
        
        public ViginerFactory(string value, string key)
        {
            v = new Viginer(value, key);
        }

        public ViginerFactory(int[] code, string key)
        {
            v = new Viginer(code, key);
        }

        public override CryptBase CreateCrypt()
        {
            return v;
        }
    }


    public class SHA1: HashBase
    {
        private const uint h0 = 0x67452301;
        private const uint h1 = 0xEFCDAB89;
        private const uint h2 = 0x98BADCFE;
        private const uint h3 = 0x10325476;
        private const uint h4 = 0xC3D2E1F0;

        byte[] target = null;


        public SHA1(byte[] target)
        {
             this.target = target;
        }

        public override byte[] ComputeHash()
        {
            Prepeare(target);
            SolveStep(ref target);

            this._hash = target;

            return this._hash;
        }

        private static void Prepeare(byte[] target)
        {
            byte[] W;
            for (int i = 0; i < 15; i++)
            {

            }
        }

        private static void SolveStep(ref byte[] H)
        {
            byte A,B,C,D,E;

            for (int t = 0; t < 79; t++)
            {

            }

           /* H = new byte[]{ 
                           H[0] + A, 
                           H[1] + B, 
                           H[2] + C, 
                           H[3] + D, 
                           H[4] + E };*/
        }

        public override void Clear()
        {
        }


    }

    public class SHA1Factory : AbstractHashFactory
    {
        byte[] _tr;

        public SHA1Factory(byte[] target)
        {
            _tr = target;
        }

        public override HashBase CreateHash()
        {
            return new SHA1(_tr);
        }
    }

}
