﻿using System;
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
        public class RecipeItem
        {
            public IcrObject Stuff { get; private set; }
            public decimal Volume { get; private set; }
            public decimal BaseVolume { get; private set; }
            public RecipeItem(IcrObject iobj, decimal vol)
            {
                Stuff = iobj;
                Volume = vol;
                BaseVolume = vol;
            }
            public RecipeItem Multiply(decimal times) { Volume = BaseVolume * times; return this; }
            public RecipeItem Clone() =>  new RecipeItem(Stuff, Volume);
        }
        public class Recipe
        {
            public IcrObject Bench { get; private set; }
            public RecipeItem[] Items { get; private set; }
            private Recipe() { }

            static internal IEnumerable<Recipe> Decode(string recipe_str)
            {
                string[] spli(char del, string str) => str.Split(new char[] { del }, StringSplitOptions.RemoveEmptyEntries);
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
                    return rec;
                });
            }

            public (RecipeItem[] aggregated, string[] benches) FinalRequirements()
            {
                var gather = new List<RecipeItem>();
                var benches = new List<string>();
                foreach (var ri in Items ?? new RecipeItem[] { })
                {
                    var recipes = ri.Stuff.Recipes;
                    if (recipes != null && recipes.Length > 0)
                    {
                        var result = recipes[ri.Stuff.RecipeIndex].FinalRequirements();
                        gather.AddRange(result.aggregated.Select(xi => xi.Clone().Multiply(ri.Volume)));
                        benches.AddRange(result.benches);
                    }
                    else
                    {
                        gather.Add(ri.Clone());
                        benches.Add(Bench.Key);
                    }
                }
                var aggre = new List<RecipeItem>();
                foreach (var g in gather.GroupBy(ri => ri.Stuff.Key))
                {
                    var array = g.ToArray();
                    if (array.Length == 1) aggre.Add(array[0]);
                    else aggre.Add(new RecipeItem(new IcrObject(g.Key), g.Sum(ri => ri.Volume)));
                }
                return (aggre.ToArray(), benches.Distinct().ToArray());
            }

            public override string ToString()
            {
                var bench = Bench.Core.Name;
                var items = string.Join(",", Items.Select(ri => $"{ri.Stuff.Core.Name} x {ri.Volume}"));
                return $"{bench}({items})";
            }
        }
    }
}
