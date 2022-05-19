﻿using System;
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
    public partial class WhatDoYouNeed
    {
        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.LargeIcon);
        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.SmallIcon);
        // private void detailsToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Details;
        private void listToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.List);
        private void tileToolStripMenuItem_Click(object sender, EventArgs e) => ChangeView(View.Tile);

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lvSouces.Items.Clear();
            Filter(tbxFilter.Text);
        }

        private void WhatDoYouNeed_SizeChanged(object sender, EventArgs e)
        {
            foreach (ResultOne ro in flpnlRecipes.Controls)
                ro.Width = flpnlRecipes.Width;
        }

        private void clbxAttrs_ItemCheck(object sender, ItemCheckEventArgs e)
            => BeginInvoke(new MethodInvoker(() => btnFilter.PerformClick()));

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var mp = lvSouces.PointToClient(MousePosition);
            var oi = (ObjectItem)lvSouces.GetItemAt(mp.X, mp.Y);
            if (oi != null && oi.Recipes.Length > 1)
            {
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.AddRange(oi.Recipes
                    .Select((r, i) => new ToolStripMenuItem(r.ToString(), null, RecipeSelected, i.ToString()) { Tag = oi })
                    .ToArray());
            }
            else e.Cancel = true;
        }

        private void Add2RecipeView(string key)
        {
            //var obj = (ObjectItem)selected[0];
            //var key = obj.Name;
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
                ro.Remove += RemoveTarget;
                ro.ValueChanged = () => CalcTotal();
            }
        }

        private void lvSouces_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                var selected = lvSouces.SelectedItems;
                if (selected.Count > 0)
                {
                    Add2RecipeView(selected[0].Name);
                    CalcTotal();
                }
            }
        }
        private bool toggle_all_or_none = false;
        private void btnHavingBenchesAllorNone_Click(object sender, EventArgs e)
        {
            foreach (var oi in lvHavingBenches.Items.OfType<ObjectItem>())
                oi.Checked = toggle_all_or_none;
            toggle_all_or_none = !toggle_all_or_none;
        }

    }
}
