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

namespace Icarus
{
    public partial class WhatDoYouNeed : Form
    {

        private bool debug = false;

        public WhatDoYouNeed()
        {
            InitializeComponent();

            lvSouces.Items.AddRange(IcrObject.Keys
                .Select(k => {
                    var obj = new IcrObject(k);
                    ObjectImagesLarge.Images.Add(obj.Key, obj.Image);
                    ObjectImagesSmall.Images.Add(obj.Key, obj.Image);
                    return new ObjectItem(obj, 0m, debug);
                })
                .OrderBy(it => it.Text)
                .ToArray());

            clbxAttrs.Items.AddRange(Enum.GetNames(typeof(IcrObject.IcrAttributes)));
            ChangeView(View.SmallIcon);
        }

        private View _view = View.SmallIcon; 
        private void ChangeView(View v) {
            _view = v;
            lvSouces.View = v;
            foreach (ResultOne ro in flpnlRecipes.Controls)
                ro.ListViewStyle = v;
        }
        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.LargeIcon);

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.SmallIcon);

        // private void detailsToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Details;

        private void listToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.List);

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.Tile);

        void Filter(string s)
        {
            var all = string.IsNullOrEmpty(s);

            var attr_filter = IcrObject.ReconstAttrs(clbxAttrs.CheckedItems.Cast<string>());

            bool Match(IcrObject.IcrAttributes a, IcrObject.IcrAttributes b) => b == IcrObject.IcrAttributes.None || (a & b) != 0;

            var filtered = from k in IcrObject.Keys
                    select new IcrObject(k) into obj
                    where obj.Name.Contains(s) && Match(obj.Attribute, attr_filter)
                    select obj;

            lvSouces.Items.AddRange(filtered
                .Select(m => new ObjectItem(m, 0m, debug))
                .OrderBy(it => it.Text)
                .ToArray());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lvSouces.Items.Clear();
            Filter(tbxFilter.Text);
        }

        private void remove_target(object sender, EventArgs args)
        {
            flpnlRecipes.Controls.Remove((Control)sender);
        }

        private void lvSouces_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void WhatDoYouNeed_SizeChanged(object sender, EventArgs e)
        {
            foreach (ResultOne ro in flpnlRecipes.Controls)
                ro.Width = flpnlRecipes.Width;
        }

        private void clbxAttrs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => btnFilter.PerformClick()));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var mp = lvSouces.PointToClient( MousePosition);
            var oi = (ObjectItem)lvSouces.GetItemAt(mp.X, mp.Y);
            if (oi != null && oi.Recipes.Length > 1)
            {
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.AddRange(oi.Recipes
                    .Select((r, i) => new ToolStripMenuItem(r.ToString(), null, x, i.ToString()) { Tag = oi })
                    .ToArray());
            }
            else e.Cancel = true;
        }

        private void x(Object sender, EventArgs args)
        {
            var mi = (ToolStripMenuItem)sender;
            var oi = (ObjectItem)mi.Tag;
            new IcrObject(oi.Name).RecipeIndex = int.Parse(mi.Name);
        }

        private void lvSouces_MouseClick(object sender, MouseEventArgs e)
        {
            // ObjectItem CreateItem(string key, decimal vol = 0m) => new ObjectItem(new IcrObject(key), vol, false); // IcrObjectは軽量なのでバンバン作っても影響は小さい
            if (e.Button != MouseButtons.Right)
            {
                var selected = lvSouces.SelectedItems;
                if (selected.Count > 0)
                {
                    var obj = (ObjectItem)selected[0];
                    var key = obj.Name;
                    var exists = flpnlRecipes.Controls.OfType<ResultOne>().SingleOrDefault(o => o.Target.Key == key);
                    if (exists != null)
                        exists.Increment();
                    else
                    {
                        var ro = new ResultOne(ObjectImagesLarge, ObjectImagesSmall);
                        flpnlRecipes.Controls.Add(ro);
                        ro.Width = flpnlRecipes.Width;
                        ro.Target = new IcrObject(key);
                        ro.ListViewStyle = _view;
                        ro.Remove += remove_target;
                    }
                }
            }
        }
    }
}
