using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Security.Cryptography;

namespace ExtendedPatterns
{
    class Program
    {

        public static void print(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {

            string value = "ATTACKATDAWN";
            string key = "LEMON";
            string result = "";

            string filename = @"value.txt";
            if (File.Exists(filename))
                value = File.ReadAllText(filename, Encoding.ASCII);
            else 
                File.WriteAllText(filename, value);

            TestViginer(value, key);

          /*  byte[] target = Encoding.UTF8.GetBytes(value);

            //TestViginer(value, key);
            var sha = System.Security.Cryptography.SHA1.Create();
            

            AbstractHashFactory hashFactory = new SHA1Factory(target);
            var hash_sha1 = hashFactory.CreateHash();
            byte[] answer = hash_sha1.ComputeHash();

            print("answer is: " + Encoding.UTF8.GetString(answer));


            var dsa = new DSACryptoServiceProvider();
            var privateKey = dsa.ExportParameters(true); // private key
            var publicKey = dsa.ExportParameters(false); // public key*/

            Console.Read();
        }

        private static void TestViginer(string value, string key)
        {
            AbstractCryptFactory factory = new ViginerFactory(value, key);
            CryptLogic logic = new CryptLogic(factory);

            logic.Encode();
            int[] code = logic.GetCode();
            string st = logic.ToString();

            factory = new ViginerFactory(st, key);
            logic = new CryptLogic(factory);

            logic.Decode();
            print(logic.GetValue());

            print("" + logic[1]);
        }
    }
}