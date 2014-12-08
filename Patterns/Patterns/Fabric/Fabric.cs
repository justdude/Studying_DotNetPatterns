using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Fabric
{

    public abstract class Creator
    {
        public abstract Fruit FactoryMethdod();
    }

    public class AppleCreator : Creator
    {
        public override Fruit FactoryMethdod()
        {
            return new Apple(); 
        }
    }

    public class PineAplleCreator : Creator
    {
        public override Fruit FactoryMethdod()
        {
            return new PineAplle();
        }
    }

    public abstract class Fruit
    {
        public static string FruitName { get { return "Fruit"; } }
        //{
        //    return "Fruit";
        //}
        public virtual void PrintName()
        {
            Program.Print("Fruit");
        }

    }

    public class Apple: Fruit
    {
        public static new string FruitName
        {
            get
            {
                return "Apple";
            }
        }

        public override void PrintName()
        {
            Program.Print(FruitName);
        }
    }

    public class PineAplle : Fruit
    {
        public static new string FruitName
        {
            get
            {
                return "PineAplle";
            }
        }
        public override void PrintName()
        {
            Program.Print(FruitName);
        }
    }

}
