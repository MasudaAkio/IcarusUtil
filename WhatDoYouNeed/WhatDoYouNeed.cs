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
            public string Name { get; private set; }

            public CategoryItem(IcrObject.IcrAttributes attr, string name, int count)
            {
                Name = name;
                Attr=attr;
                Count=count;
            } 

            public override string ToString() => $"{Name}({Count})";

            static public implicit operator IcrObject.IcrAttributes(CategoryItem i) => i.Attr;
        }

        private IcrObject[] can_be_crafted
            => (from k in IcrObject.Keys
               let io = new IcrObject(k)
               where io.Recipes.Any(r => r.IsNotEmpty)
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
                                    .Select(kv => new CategoryItem(kv.Key, IcrObject.GetName(kv.Key),  kv.Value))
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

            flpnlRecipes.Padding += new Padding(RecipePanelRightPadding, 0, 0, 0);
            pnlTotal.Padding += new Padding(RecipePanelRightPadding, 0, ResultOneMargine - RecipeViewBothPadding, 0); // recipe flowlayout-panel に合わせるためにちょっと面倒な計算をしている

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
            roTotal.Remove += RoTotal_Remove;
            ChangeView(View.SmallIcon);

            PresetMany.Default.Set2Menu(presetToolStripMenuItem, PresetMenuItem_Click, PresetMenuItem_MouseUp);
        }

        private void RoTotal_Remove(object sender, EventArgs e)
        {
            foreach (var ro in flpnlRecipes.Controls.OfType<ResultOne>().ToArray()) // イテレート対象をいじるので固定化は必要
                RemoveTarget(ro, new EventArgs());
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

        private void RecipeSelectedInner(IcrObject io, int rindex)
        {
            io.RecipeIndex = rindex;

            foreach (var ro in flpnlRecipes.Controls.OfType<EachRecipe>())
                if (ro.Target.SelectedRecipe.IsNotEmpty) ro.ReCalc(); else flpnlRecipes.Controls.Remove(ro);
            CalcTotal();
        }

        private void RecipeSelectedInner(ObjectItem oi, int rindex)
        {
            var io = new IcrObject(oi.Name);
            RecipeSelectedInner(io, rindex);
            if (oi != null)
                oi.ToolTipText = io.SelectedRecipe.ToString();
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

        private void exportToExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = svfDlog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                Export.ExportXlsx(svfDlog.FileName, flpnlRecipes.Controls.OfType<EachRecipe>(), roTotal);
                PrepareCenteringMessageBoxOnTheForm(this);
                MessageBox.Show(String.Format(Messages.ExcelFileIsSavedMessage, svfDlog.FileName));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

    }
}
