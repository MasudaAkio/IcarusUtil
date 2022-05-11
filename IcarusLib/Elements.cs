using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Drawing;
using IcarusLib.Properties;


namespace IcarusLib
{
    [Flags]
    public enum Attrs
    {
        Armors,
        BuildingPieces,
        Consumables,
        Deplyables,
        Environsuits,
        Modules,
        Resources,
        Tools,
        Weapons,
        Food,
        Drinks,
        Medicine,
        Benches,
        CraftingBenches,
        CookingBenches,
        ClimateControl, // 気候制御
    }

    public abstract class Object
    {
        public string keyname { get; private set; }
        public string name { get; private set; }

        public Bitmap image { get; private set; }
        internal Images x { get; set; }
       

        public Object(string key)
        {
            keyname = key;
            name = Resources.ResourceManager.GetString(key, Resources.Culture);
            if (string.IsNullOrEmpty(name)) string.Join(" ", new Regex("[A-Z][a-z]+").Matches(key).OfType<string>());

            image = (Bitmap)(Images.ResourceManager.GetObject(key) ?? Images.ResourceManager.GetObject("NoImage"));
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

    public class Bench : FinalProduct
    {
        public Bench(string key) : base(key) { }

    }

    public class InterMediate : Object, UsedToMake, MadeFromSomething
    {
        public InterMediate(string key) : base(key) { }

        public Recipe[] Recipes => throw new NotImplementedException();
    }

    public class Materials : KeyedCollection<string, Material>
    {
        public Materials()
        {
            var keynames = new string[]
            {
                "IronOre", "CopperOre", "GoldOre", "Coal", "AluminumOre", "PlatinumOre", "TitaniumOre", "ExoticOre", "Stone",
                "Ice", "Oxide", "SilicaOre", "Sulfur",
                "ReedFlower", "Lily", "Squash", "Yeast", "Wheat", "Cone", "WaterMelon", "SoyBean","Pumpkin", "WildBerry",
                "Carrot", "YoungCoconut", "Mushroom", "Wood",
                "SpoiledPlants", "SpoiledMeat",
                "Fiber", "Stick", "Leather", "Bone", "Fur",
                "RawFish", "RawMeat", "RawGiantSteak",　// 生の精肉
                "RawBacon", "RawFattyTbone", "RawGameMeat", "RawSoftMeat", "RawStringyMeat", "RawWhiteMeat",

            };
            foreach (var k in  keynames ) Add(new Material(k));
        }

        protected override string GetKeyForItem(Material item) => item.keyname;
    }

    public class Benches : KeyedCollection<string, Bench>
    {
        public Benches()
        {
            var keynames = new string[]
            {
                "AnyWhere", "CraftingBench", "AnvilBench", "CarpentryBench", "CookingStation", "HerbalismBench", // 製薬台
                "MasonryBench", "MortarAndPestle", // すり鉢
                "StoneFurnace", "TextilesBench", "TrophyBench", "CementMixdr", "ChemistryBench", "ElectricCarpentryBench", "ELectricMasonryBench",
                "Fabricator", "ClassworkingBench", "MachiningBench", "MaterialProcessor",
                "BiofuelStove", "Campfile", "CookingStation", "DryingRack","Firepit", "Fireplace", "KitchenBench", "PotbellyStove", // だるまストーブ

            };
            foreach (var k in keynames) Add(new Bench(k));
        }
        protected override string GetKeyForItem(Bench item) => item.name;
    }
}
