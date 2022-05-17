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
        [Flags]
        public enum IcrAttributes
        {
            None = 0,
            AnimalHead = 1 << 0,
            Armors = 1 << 1,
            Axe = 1 << 2,
            Benches = 1 << 3,
            Bow = 1 << 4,
            BuildingPieces = 1 << 5,
            ClimateControl = 1 << 6, // 気候制御
            Consumables = 1 << 7,
            CookingBenches = 1 << 8,
            CraftingBenches = 1 << 9,
            Deployables = 1 << 10,
            Drinks = 1 << 11,
            Environsuits = 1 << 12,
            Firearms = 1 << 13,
            Food = 1 << 14,
            Hammer = 1 << 15,
            Ingot = 1 << 16,
            Knife = 1 << 17,
            Materials = 1 << 18,
            Medicine = 1 << 19,
            Modules = 1 << 20,
            Ore = 1 << 21,
            Pickaxe = 1 << 22,
            Resources = 1 << 23,
            Sickle = 1 << 24,
            Spear = 1 << 25,
            Tools = 1 << 26,
            Weapons = 1 << 27,
            Workshop = 1 << 28,
            Ammo = 1 << 29,
        }
        public static IcrAttributes ReconstAttrs(IEnumerable<string> attr_strs)
        {
            var result = IcrAttributes.None;
            foreach (var str in attr_strs)
            {
                // IcrObjectAttributes attr;
                if (!Enum.TryParse<IcrAttributes>(str, out var attr))
#if DEBUG
                    throw new Exception($"{str} not found!!!!");
#else
                        /* do nothing */ ;
#endif
                else
                    result |= attr;
            }
            return result;
        }

    }
}
