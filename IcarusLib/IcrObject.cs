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
        static private IcrObjectCores Cores = new IcrObjectCores();
        static public IEnumerable<string> Keys => Cores.Select(obj => obj.Key);

        public string Key => Core.Key;
        public string Name => Core.Name;
        public Image Image => Core.Image;
        public Recipe[] Recipes => Core.Recipes;
        public IcrAttributes Attribute => Core.Attribute;

        private readonly string _key;
        public IcrObject(string key) => _key = key;

        public int RecipeIndex { get => Core.RecipeIndex; set => Core.RecipeIndex = value; }
        public Recipe SelectedRecipe => Core.SelectedRecipe;

        private IcrObjectCore? _core;
        private IcrObjectCore Core => _core ?? (_core = Cores[_key]); // singleton

        public override string ToString() => $"Key:{Key}(Name:{Name})";

        // public static implicit operator IcrObjectCore(IcrObject icobj) => icobj.Core;
    }
}
