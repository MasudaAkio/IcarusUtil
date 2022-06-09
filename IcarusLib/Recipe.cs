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
        public class Stuff
        {
            public IcrObject Item { get; private set; }
            public decimal Volume { get; private set; }
            public decimal BaseVolume { get; private set; }
            public Stuff(IcrObject iobj, decimal vol)
            {
                Item = iobj;
                Volume = vol;
                BaseVolume = vol;
            }
            public Stuff Multiply(decimal times) { Volume = BaseVolume * times; return this; }
            public Stuff Clone() =>  new Stuff(Item, Volume);
        }
        public class Recipe
        {
            public int Index { get; private set; }
            public IcrObject? Bench { get; private set; }
            public Stuff[] Stuffs { get; private set; } = new Stuff[0];
            private Recipe() { }

            public bool IsNotEmpty => Bench != null && Stuffs != null;

            public static readonly Recipe Empty = new Recipe();

            static internal IEnumerable<Recipe> Decode(string recipe_str) // recipe_str が "" なら空の列挙が返る
            {
                string[] spli(char del, string str) => str.Split(new char[] { del }, StringSplitOptions.RemoveEmptyEntries);
                var rex = new Regex(@"^(\S+)\((.*)\)$");
                return spli('|', recipe_str).Select((s, i) =>
                    { /* CraftingBench(Fiber:20,Leather:30,Bone:8) */
                        var m = rex.Match(s);
                        var elems = m.Groups.Cast<Group>().Skip(1).Select(g => g.Value).ToArray(); /* [ "CraftingBench", "Fiber:20,Leather:30,Bone:8" ] */
                        var rec = new Recipe();
                        rec.Index = i;
                        if (elems[0] != "NotToBeCrafted")
                        {
                            rec.Bench = new IcrObject(elems[0]);
                            if (elems[1] != "")
                            {
                                rec.Stuffs = elems[1].Split(',').Select(ss =>
                                { /* Fiber:20 */
                                    var sv = ss.Split(':');
                                    return new Stuff(new IcrObject(sv[0]), decimal.Parse(sv[1].Trim()));
                                }).ToArray();
                            }
                        } else { /* do nothing, rec is Empty */ }
                        return rec;
                    }).DefaultIfEmpty(Empty);

            }

            public (Stuff[] aggregated, string[] benches) FinalRequirements()
            {
                var gather = new List<Stuff>();
                var benches = new List<string>();
                if (Bench != null) benches.Add(Bench.Key);
                foreach (var st in Stuffs ?? new Stuff[] { })
                {
                    var recipe = st.Item.SelectedRecipe;
                    if (recipe.IsNotEmpty)
                    {
                        var result =recipe.FinalRequirements();
                        gather.AddRange(result.aggregated.Select(xi => xi.Clone().Multiply(st.Volume)));
                        benches.AddRange(result.benches);
                    }
                    else
                        gather.Add(st.Clone());
                }
                var aggre = new List<Stuff>();
                foreach (var g in gather.GroupBy(ri => ri.Item.Key))
                {
                    var array = g.ToArray();
                    if (array.Length == 1) aggre.Add(array[0]);
                    else aggre.Add(new Stuff(new IcrObject(g.Key), g.Sum(ri => ri.Volume)));
                }
                return (aggre.ToArray(), benches.Distinct().ToArray());
            }

            public override string ToString()
            {
                if (!IsNotEmpty)
                    return miscellaneous.ResourceManager.GetString("NotToBeCrafted");
                else
                {
                    var bench = Bench?.Core.Name ?? "(not spcified)";
                    var items = string.Join(",", Stuffs.Select(ri => $"{ri.Item.Core.Name} x {ri.Volume}"));
                    return $"{bench}({items})";
                }
            }
        }
    }
}
