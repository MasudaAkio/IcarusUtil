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
using System.Deployment.Application;

using IcarusLib;
using IcarusLib.Properties;

namespace Icarus
{

    public partial class WhatDoYouNeed : Form
    {
        private readonly bool debug = false;

        private class CategoryItem
        {
            public IcrObject.IcrAttributes Attr { get; private set; }
            public int Count { get; private set; }

            public CategoryItem(IcrObject.IcrAttributes attr, int count)
            {
                Attr=attr;
                Count=count;
            } 

            public override string ToString() => $"{Attr.ToString()}({Count})";

            static public implicit operator IcrObject.IcrAttributes(CategoryItem i) => i.Attr;
        }

        private IcrObject[] can_be_crafted
            => (from k in IcrObject.Keys
               let io = new IcrObject(k)
               where !io.SelectedRecipe.IsEmpty
               select io)
            .OrderBy(io => io.Name)
            .ToArray();

        private void CountCategory()
        {
            var attrs = can_be_crafted.Select(io => io.Attribute).ToArray();
            var categories = Enum.GetValues(typeof(IcrObject.IcrAttributes))
                                    .OfType<IcrObject.IcrAttributes>()
                                    .Except(new[] { IcrObject.IcrAttributes.None });
            var x = from IcrObject.IcrAttributes a in categories
                    let cnt = attrs.Count(a2 => a2.HasFlag(a))
                    select (a, cnt);
            var dic = x.Where(kv => kv.cnt > 0).ToDictionary(xx => xx.a, xx => xx.cnt);
            clbxAttrs.Items.AddRange(dic
                                    .OrderBy(kv => kv.Key)
                                    .Select(kv => new CategoryItem(kv.Key, kv.Value))
                                    .ToArray());
        }
        private View _view = View.SmallIcon;
        private void ChangeView(View v)
        {
            _view = v;
            lvSouces.View = v;
            if (v != View.Tile) lvHavingBenches.View = v; // Tile View はチェックボックスをサポートしていないため
            foreach (ResultOne ro in flpnlRecipes.Controls)
                ro.ListViewStyle = v;
            roTotal.ListViewStyle = v;
        }

        void SetHavingBenches()
        {
            var benches = from io in can_be_crafted
                          where io.Attribute.HasFlag(IcrObject.IcrAttributes.Benches)
                          select new ObjectItem(io) { Checked = false};
            lvHavingBenches.Items.AddRange(benches.ToArray());
        }

        public WhatDoYouNeed()
        {
            InitializeComponent();

            Text = $"Survive ICARUS : What do you need";
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                var str_ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                Text += $" ({str_ver})";
            }

            lvSouces.Items.AddRange(can_be_crafted
                .Select(obj => new ObjectItem(obj, 0m, debug))
                .OrderBy(it => it.Text)
                .ToArray());

            foreach (var obj in IcrObject.Keys.Select(k => new IcrObject(k)))
            {
                ObjectImagesLarge.Images.Add(obj.Key, obj.Image);
                ObjectImagesSmall.Images.Add(obj.Key, obj.Image);
            }

            SetHavingBenches();
            CountCategory();
            roTotal.SetImageLists(ObjectImagesLarge, ObjectImagesSmall);
            ChangeView(View.SmallIcon);
        }

        void Filter(string s)
        {
            var all = string.IsNullOrEmpty(s);
            var selected = from CategoryItem li in clbxAttrs.CheckedItems
                      select (IcrObject.IcrAttributes)li;
            var attr_filter = (IcrObject.IcrAttributes)selected.Sum(a => (long)a);

            bool Match(IcrObject.IcrAttributes a, IcrObject.IcrAttributes b) => b == IcrObject.IcrAttributes.None || (a & b) != 0;

            var filtered = from obj in can_be_crafted
                    where (all || obj.Name.Contains(s)) && Match(obj.Attribute, attr_filter)
                    select obj;

            lvSouces.Items.AddRange(filtered
                .Select(m => new ObjectItem(m, 0m, debug))
                .OrderBy(it => it.Text)
                .ToArray());
        }

        private void RemoveTarget(object sender, EventArgs args)
        {
            flpnlRecipes.Controls.Remove((Control)sender);
            CalcTotal();
        }

        private void RecipeSelectedInner(ObjectItem oi, int rindex)
        {
            var io = new IcrObject(oi.Name);
            io.RecipeIndex = rindex;
            oi.ToolTipText = io.SelectedRecipe.ToString();
            foreach (var ro in flpnlRecipes.Controls.OfType<ResultOne>())
                ro.ReCalc();
            CalcTotal();
        }

        private void RecipeSelected(Object sender, EventArgs args)
        {
            var mi = (ToolStripMenuItem)sender;
            var oi = (ObjectItem)mi.Tag;
            var rindex = int.Parse(mi.Name);
            RecipeSelectedInner(oi, rindex);
        }

        private void CalcTotal()
        {
            var benches = new List<ObjectItem>();
            var stuffs = new List<ObjectItem>();
            foreach (var ro in flpnlRecipes.Controls.OfType<ResultOne>())
            {
                var rcp = ro.Recipe;
                benches.AddRange(rcp.benches);
                stuffs.AddRange(rcp.stuffs);
            }
            var b = benches
                    .Select(oi => oi.Name)
                    .Distinct()
                    .Select(k => new ObjectItem(new IcrObject(k)));
            var s = from oi in stuffs
                    group oi by oi.Name into g
                    select new ObjectItem(new IcrObject(g.Key), g.Sum(oi => oi.Volume));
            roTotal.Recipe = (b.ToArray(), s.ToArray());
        }
    }
}
