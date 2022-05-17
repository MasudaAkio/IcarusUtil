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

        public string Key { get; private set; }
        public string Name => Core.Name;
        public Image Image => Core.Image;
        public Recipe[] Recipes => Core.Recipes;
        public IcrAttributes Attribute => Core.Attribute;
        public IcrObject(string key) => Key = key;

        public int RecipeIndex { get => Core.RecipeIndex; set => Core.RecipeIndex = value; }

        private IcrObjectCore _core;
        private IcrObjectCore Core => _core ?? (_core = Cores[Key]); // singleton

        // public static implicit operator IcrObjectCore(IcrObject icobj) => icobj.Core;
    }
}
