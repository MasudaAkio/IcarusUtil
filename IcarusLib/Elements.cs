using System;
using System.Linq;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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


    public class IcrObject
    {
        public class IcrObjectCore
        {
            public string Key { get; private set; }
            public string Name { get; private set; }
            public Bitmap Image { get; private set; }
            public Attrs Attributes { get; private set; }

            internal IcrObjectCore(string key)
            {
                Key = key;
                Name = ObjectNames.ResourceManager.GetString(key, ObjectNames.Culture);
                if (string.IsNullOrEmpty(Name)) string.Join(" ", new Regex("[A-Z][a-z]+").Matches(key).OfType<string>());

                Image = (Bitmap)(Images.ResourceManager.GetObject(key) ?? Images.ResourceManager.GetObject("NoImage"));

                // Recipes = Recipe.Decode(Properties.Recipes.ResourceManager.GetStream(key), 

            }
            private Recipe[] _recipes;
            public Recipe[] Recipes => _recipes ?? (_recipes = Recipe.Decode(Properties.Recipes.ResourceManager.GetString(Key)).ToArray());

            public bool HasAnyRecipes => Recipes.Length > 0;

            private static CultureInfo calture { get => CultureInfo.CurrentCulture; }
            public static IEnumerable<string> Keys
            {
                get => ObjectNames
                        .ResourceManager
                        .GetResourceSet(calture, true, true).Cast<DictionaryEntry>().Select(e => e.Key.ToString());
            }
        }
        private class IcrObjectCores : KeyedCollection<string, IcrObjectCore>
        {
            public IcrObjectCores()
            {
                var keynames = IcrObjectCore.Keys.ToArray();
                foreach (var k in keynames) Add(new IcrObjectCore(k));
            }

            protected override string GetKeyForItem(IcrObjectCore item) => item.Key;
        }

        static private IcrObjectCores Cores = new IcrObjectCores();

        static public IEnumerable<string> Keys => Cores.Select(obj => obj.Key);

        public string Key { get; private set; }
        public string Name => Core.Name;
        public Image Image => Core.Image;
        public Recipe[] Recipes => Core.Recipes;
        public IcrObject(string key)
        {
            Key = key;
        }

        private IcrObjectCore _core;
        private IcrObjectCore Core => _core ?? (_core = Cores[Key]);

        public class RecipeItem
        {
            public IcrObject Stuff { get; private set; }
            public decimal Volume { get; private set; }

            public RecipeItem(IcrObject iobj, decimal vol)
            {
                Stuff = iobj;
                Volume = vol;
            }
        }
        public class Recipe
        {
            public IcrObject Bench { get; private set; }
            public RecipeItem[] Items { get; private set; }
            private Recipe() { }

            static internal IEnumerable<Recipe> Decode(string recipe_str)
            {
                string[] spli(char del, string str) => str.Split(new char[] { del }, StringSplitOptions.RemoveEmptyEntries);
                // var s_v(string sv) { var sva = sv.Split(':'); return new { stuff = sva[0], vol = decimal.Parse(sva[1]) }; }
                //var rex = new Regex(@"^(\S+)\((\S+:\d+,\s*)*?(\S+:\d+)??\)$");
                var rex = new Regex(@"^(\S+)\((.*)\)$");
                return spli('|', recipe_str).Select(s =>
                { /* s CraftingBench(Fiber:20,Leather:30,Bone:8) */
                    var m = rex.Match(s);
                    var elems = m.Groups.Cast<Group>().Skip(1).Select(g => g.Value).ToArray(); /* [ "CraftingBench", "Fiber:20,Leather:30,Bone:8" ] */
                    var rec = new Recipe();
                    rec.Bench = new IcrObject(elems[0]);
                    if (elems[1] != "")
                    {
                        rec.Items = elems[1].Split(',').Select(ss =>
                        { /* Fiber:20 */
                            var sv = ss.Split(':');
                            return new RecipeItem(new IcrObject(sv[0]), decimal.Parse(sv[1].Trim()));
                        }).ToArray();
                    }

                    //rec.Items = elems.Skip(1)
                    //                .Where(e => e != "")
                    //                .Select(ss =>
                    //                { /* Fiber:20 */
                    //                    var sv = ss.Split(':');
                    //                    return new RecipeItem(new IcrObject(sv[0]), decimal.Parse(sv[1].Trim(',', ' ')));
                    //                }).ToArray();
                    return rec;
                });
            }
        }
        public static implicit operator IcrObjectCore(IcrObject icobj) => icobj.Core;
    }
}
