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
    public partial class WhatDoYouNeed
    {
        private static int RecipeViewBothPadding = 15;
        private static int ResultOneMargine = RecipeViewBothPadding * 2 + 10; // 10: スクロールバーの幅のつもり
        private static int RecipePanelRightPadding = RecipeViewBothPadding;
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
                ro.Width = flpnlRecipes.Width - ResultOneMargine;
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
                e.Cancel = false;
            }
            else e.Cancel = true;
        }

        private void Add2RecipeView(string key)
        {
            var exists = flpnlRecipes.Controls.OfType<EachRecipe>().SingleOrDefault(o => o.Target.Key == key);
            if (exists != null)
                exists.Increment();
            else
            {
                var io = new IcrObject(key);
                if (io.SelectedRecipe.IsNotEmpty)
                {
                    var ro = new EachRecipe(io, ObjectImagesLarge, ObjectImagesSmall, !cbxNoRecursive.Checked);
                    flpnlRecipes.Controls.Add(ro);
                    ro.Width = flpnlRecipes.Width - ResultOneMargine;
                    ro.ListViewStyle = _view;
                    ro.Remove += RemoveTarget;
                    ro.ValueChanged = () => CalcTotal();
                } else
                {
                    PrepareCenteringMessageBoxOnTheForm(this);
                    MessageBox.Show(Messages.NotAddedRecipeMessage);
                }
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
        private IEnumerable<string> UnownedBenches =>
                                            from ObjectItem oi in lvHavingBenches.Items
                                            where !oi.Checked
                                            select oi.Name;

        private void btnConbine_Click(object sender, EventArgs e)
        {
            var added = 0;
            var unowned = UnownedBenches.ToArray();
            do
            {
                var ordered = flpnlRecipes.Controls
                                    .OfType<EachRecipe>()
                                    .Select(ro => ro.Target.Key).ToArray();
                var conbinings = roTotal.Recipe.benches
                                    .Select(oi => oi.Name)
                                    .Intersect(UnownedBenches)
                                    .Except(ordered);
                added = 0;
                foreach (var k in conbinings) { Add2RecipeView(k); added++; }
                CalcTotal();
            } while (added > 0);
        }

        private void ChangeWoodBuildingPieceRecipes(bool use_carpentry_bench = false)
        {
            foreach (var k in new[] { "WoodRoof", "WoodFloor", "WoodWall", "WoodWallAngled" })
            {
                var io = new IcrObject(k);
                var target = use_carpentry_bench ? "CarpentryBench" : "CharacterCrafting";
                int index = io.Recipes.SingleOrDefault(r => r.Bench?.Key == target)?.Index ?? 0;

                var oi = lvSouces.Items.OfType<ObjectItem>().FirstOrDefault(i => i.Name == k);
                if (oi != null) RecipeSelectedInner(oi, index);
                else RecipeSelectedInner(io, index);
            }
        }

        private void makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem_Click(object sender, EventArgs e)
            => ChangeWoodBuildingPieceRecipes(true);

        private void makingWoodBuildingPiecesByMyselfToolStripMenuItem_Click(object sender, EventArgs e)
            => ChangeWoodBuildingPieceRecipes();

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

        private void cbxNoRecursive_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var ro in flpnlRecipes.Controls.OfType<EachRecipe>())
                if (ro.Target.SelectedRecipe.IsNotEmpty) ro.ReCalc(!cbxNoRecursive.Checked); else flpnlRecipes.Controls.Remove(ro);
            CalcTotal();
        }
    }
}
