using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;

namespace IcarusUtil
{

    public abstract class Object
    {
        public string keyname { get; private set; }
        public string name { get; private set; }

        public Object(string key)
        {
            this.keyname = key;
            name = ResourceLoader.GetForCurrentView().GetString(key);
        }
    }

    public class RecipeItem
    {
        public UsedToMake Stuff { get; private set; }
        public Decimal Volume { get; private set; }

    }


    public class Recipe
    {
        public RecipeItem[] Items { get; private set; }
    }



    public interface UsedToMake
    {
    }

    public interface MadeFromSomething
    {
        Recipe[] Recipes { get; }
    }

    public class Material : Object, UsedToMake
    {
        public Material(string key) : base(key) { }

    }



    public class FinalProduct : Object, MadeFromSomething
    {
       public FinalProduct(string key) : base(key) { }

        public Recipe[] Recipes => throw new NotImplementedException();
    }

    public class InterMediate : Object, UsedToMake, MadeFromSomething
    {
        public InterMediate(string key) : base(key) { }

        public Recipe[] Recipes => throw new NotImplementedException();
    }

    public class Materials : KeyedCollection<String, Material>
    {
        public Materials()
        {
            var keynames = new string[]
            {
                "IronOre", "CopperOre", "GoldOre", "Coal", "AluminumOre", "PlatinumOre", "TitaniumOre", "ExoticOre", "Stone",
                "Ice", "Oxide", "SilicaOre", "Sulfur",
                "ReedFlower", "Lily", "Squash", "Yeast", "Wheat", "Cone", "WaterMelon", "SoyBean", "RawFish", "RawMeat", "PepaSquash", "WildBerry",
                "Fiber", "Twig", "Leather", "Bone", "Fur",

            };
            foreach (var k in  keynames ) Add(new Material(k));
        }

        protected override string GetKeyForItem(Material item) => item.name;
    }
}
