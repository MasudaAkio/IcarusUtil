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
    public partial class IcrObject
    {
        private class IcrObjectCore
        {
            public string Key { get; private set; }
            public string Name { get; private set; }
            public Bitmap Image { get; private set; }
            public IcrAttributes Attribute { get; private set; }

            private IcrAttributes Reconst(string attr_str)
            {
                var elems = attr_str.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return IcrObject.ReconstAttrs(elems);
            }
            public IcrObjectCore(string key)
            {
                Key = key;
                Name = ObjectNames.ResourceManager.GetString(key, ObjectNames.Culture);
                if (string.IsNullOrEmpty(Name)) string.Join(" ", new Regex("[A-Z][a-z]+").Matches(key).OfType<string>());

                Image = (Bitmap)(Images.ResourceManager.GetObject(key) ?? Images.ResourceManager.GetObject("NoImage"));

                Attribute = Reconst(Attributes.ResourceManager.GetString(key));
            }
            private Recipe[] _recipes;
            public Recipe[] Recipes => _recipes ?? (_recipes = Recipe.Decode(Properties.Recipes.ResourceManager.GetString(Key)).ToArray());

            private int _recipeIndex = 0;
            public int RecipeIndex
            {
                get => Recipes.Length > _recipeIndex ? _recipeIndex : Recipes.Length - 1;
                set => _recipeIndex = value;
            }

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

    }
}
