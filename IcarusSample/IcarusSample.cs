using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using IcarusLib;
using IcarusLib.Properties;

namespace IcarusSample
{
    public partial class IcarusSample : Form
    {
        private class ObjectItem : ListViewItem
        {
            public IcrObject.Recipe Recipe { get; set; }
            private decimal _volume = 0m;
            public decimal Volume {
                get => _volume;
                set { _volume = value; Text = basetext + $"{(value > 1 ? $" x {value}" : "")}"; } 
            }

            private string basetext { get; set; }

            private static string MakeTextWithVolume(IcarusLib.IcrObject obj, decimal volume, bool debug)
                => $"{obj.Name} {(volume > 0 ? $"x {volume}" : "")}";

            public ObjectItem() { }
            public ObjectItem(IcarusLib.IcrObject obj, decimal volume = 0m, bool debug = false)
                : base($"{obj.Name}{(debug ? $"-{obj.Key}" : "")}", obj.Key)
            {
                Name = obj.Key;
                basetext = Text;
                Volume = volume;
                Recipe = obj.Recipes.Length > 0 ? obj.Recipes[0] : null;
            }

            override public object Clone()
            {
                var c = (ObjectItem)base.Clone();
                c.basetext = basetext;
                c.Volume = Volume;
                c.Recipe = Recipe;
                return c;
            }

            public ObjectItem Copy() => (ObjectItem) Clone();
        }

        private bool debug = false;

        public IcarusSample()
        {
            InitializeComponent();

            lvSouces.Items.AddRange(IcrObject.Keys
                .OrderBy(k => k)
                .Select(k => {
                    var obj = new IcrObject(k);
                    ObjectImagesLarge.Images.Add(obj.Key, obj.Image);
                    ObjectImagesSmall.Images.Add(obj.Key, obj.Image);
                    return new ObjectItem(obj, 0m, debug);
                })
                .ToArray());
            ChangeView(View.SmallIcon);            
        }

        private void ChangeView(View v) { foreach (var lv in new[] { lvSouces, lvTarget, lvRecipe }) lv.View = v; }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.LargeIcon);

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.SmallIcon);

        // private void detailsToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Details;

        private void listToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.List);

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.Tile);

        void Filter(string s)
        {
            var all = string.IsNullOrEmpty(s);
            var filtered = IcrObject.Keys.Select(k => { var obj = new IcrObject(k); return obj.Name.Contains(s) ? obj : null; });
            lvSouces.Items.AddRange(filtered.Where(obj => !object.Equals(obj, null))
                .OrderBy(m => m.Name)
                .Select(m => new ObjectItem(m, 0m, debug))
                .ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvSouces.Items.Clear();
            Filter(tbxFilter.Text);
        }

        private void lvSouces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lvSouces.SelectedItems;
            if (selected.Count > 0)
            {
                var item = (ObjectItem)selected[0].Clone();
                lvTarget.Items.Clear();
                lvTarget.Items.Add(item);
                lvRecipe.Items.Clear();
                var r = item.Recipe;
                if (r != null)
                {
                    var b = lvSouces.Items.Find(r.Bench.Key, false);
                    if (b.Length > 0) lvRecipe.Items.Add((ObjectItem)b[0].Clone());
                    foreach (var i in r.Items ?? new IcrObject.RecipeItem[] { })
                    {
                        var ii = lvSouces.Items.Find(i.Stuff.Key, false);
                        if (ii.Length > 0)
                        {
                            var st = (ObjectItem)ii[0].Clone();
                            st.Volume = i.Volume;
                            lvRecipe.Items.Add(st);
                        }
                    }
                }
            }
        }
    }
}
