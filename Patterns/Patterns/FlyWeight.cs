using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patterns.Fabric;

namespace Patterns.FlyWeight
{
    public interface IFruitsFlyWeightCreator//<T> where T: class, new()
    {
        Creator ElementsCeator { get; }
        Dictionary<string, Fruit> ElementsCached { get; }
    }



    public class FlyWeight : IFruitsFlyWeightCreator//<Fruit>
    {
        private Creator modCreator = null;

        public FlyWeight()
        {
            //modCreator = new AppleCreator();
            ElementsCached = new Dictionary<string, Fruit>();
        }

        public Dictionary<string, Fruit> ElementsCached
        {
            get;
            private set;
        }

        public Creator ElementsCeator
        {
            get { return modCreator; }
            set { modCreator = value; }
        }

        public Fruit FactoryMethdod(string fruitType)
        {

            if (ElementsCached.ContainsKey(fruitType))
                return ElementsCached[fruitType];

            var cachedItem = modCreator.FactoryMethdod();

            ElementsCached.Add(fruitType, cachedItem);

            return cachedItem;
        }
    }





}
