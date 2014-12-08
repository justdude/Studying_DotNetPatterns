using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedPatterns
{
    public abstract class CryptBase
    {
        public string value;
        public string key;
        public string result;

        public int[] code;

        public abstract void Crypt();
        public abstract void Decrypt();
    }

    public abstract class HashBase
    {
        public int HashSize
        {
            get { return Hash.Length; }
        }

        protected byte[] _hash = null;

        public byte[] Hash
        {
            get { return _hash; } 
        }

        public abstract void Clear();
        public abstract byte[] ComputeHash();
    }

    public abstract class AbstractCryptFactory
    {
        public abstract CryptBase CreateCrypt();
    }

    public abstract class AbstractHashFactory
    {
        public abstract HashBase CreateHash();
    }



    public class HashLogic
    {
        HashBase hash;
        public int HashSize
        {
            get { return hash.HashSize; }
        }

        public byte[] Hash
        {
            get { return hash.Hash; }
        }


        public HashLogic(AbstractHashFactory factory)
        {
            hash = factory.CreateHash();
        }

        public byte[] ComputeHash()
        {
            return hash.ComputeHash();
        }
        public void Clear()
        {
            hash.Clear();
        }
    }


    public class CryptLogic
    {
        CryptBase crypt;

        public char this[int index]
        {
            get
            {
                return crypt.value[index];
            }
        }

        public CryptLogic(AbstractCryptFactory factory)
        {
            this.crypt = factory.CreateCrypt();
        }

        public void Encode()
        {
            crypt.Crypt();
        }

        public void Decode()
        {
            crypt.Decrypt();
        }

        public string GetValue()
        {
            return this.crypt.value;
        }

        public string GetKey()
        {
            return this.crypt.key;
        }
        public int[] GetCode()
        {
            return this.crypt.code;
        }

        public override string ToString()
        {
            return this.crypt.result;
        }

    }




}
