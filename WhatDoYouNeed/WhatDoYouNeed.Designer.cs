
namespace Icarus
{
    partial class WhatDoYouNeed
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhatDoYouNeed));
            this.lvSouces = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ObjectImagesLarge = new System.Windows.Forms.ImageList(this.components);
            this.ObjectImagesSmall = new System.Windows.Forms.ImageList(this.components);
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbxNoRecursive = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makingWoodBuildingPiecesByMyselfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLower = new System.Windows.Forms.Panel();
            this.flpnlRecipes = new System.Windows.Forms.FlowLayoutPanel();
            this.clbxAttrs = new System.Windows.Forms.CheckedListBox();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.roTotal = new Icarus.RecipeTotal();
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlRightSide = new System.Windows.Forms.Panel();
            this.lvHavingBenches = new System.Windows.Forms.ListView();
            this.btnConbine = new System.Windows.Forms.Button();
            this.btnHavingBenchesAllorNone = new System.Windows.Forms.Button();
            this.lblHavingBenches = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.svfDlog = new System.Windows.Forms.SaveFileDialog();
            this.pnlUpper.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlLower.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlLeftSide.SuspendLayout();
            this.pnlRightSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSouces
            // 
            this.lvSouces.BackColor = System.Drawing.SystemColors.Window;
            this.lvSouces.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.lvSouces, "lvSouces");
            this.lvSouces.GridLines = true;
            this.lvSouces.HideSelection = false;
            this.lvSouces.LargeImageList = this.ObjectImagesLarge;
            this.lvSouces.Name = "lvSouces";
            this.lvSouces.ShowItemToolTips = true;
            this.lvSouces.SmallImageList = this.ObjectImagesSmall;
            this.lvSouces.UseCompatibleStateImageBehavior = false;
            this.lvSouces.View = System.Windows.Forms.View.List;
            this.lvSouces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvSouces_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ObjectImagesLarge
            // 
            this.ObjectImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ObjectImagesLarge, "ObjectImagesLarge");
            this.ObjectImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ObjectImagesSmall
            // 
            this.ObjectImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ObjectImagesSmall, "ObjectImagesSmall");
            this.ObjectImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlUpper
            // 
            this.pnlUpper.BackColor = System.Drawing.Color.DarkGray;
            this.pnlUpper.Controls.Add(this.tbxFilter);
            this.pnlUpper.Controls.Add(this.btnFilter);
            this.pnlUpper.Controls.Add(this.cbxNoRecursive);
            resources.ApplyResources(this.pnlUpper, "pnlUpper");
            this.pnlUpper.Name = "pnlUpper";
            // 
            // tbxFilter
            // 
            this.tbxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbxFilter, "tbxFilter");
            this.tbxFilter.Name = "tbxFilter";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightYellow;
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbxNoRecursive
            // 
            resources.ApplyResources(this.cbxNoRecursive, "cbxNoRecursive");
            this.cbxNoRecursive.BackColor = System.Drawing.Color.DimGray;
            this.cbxNoRecursive.ForeColor = System.Drawing.Color.White;
            this.cbxNoRecursive.Name = "cbxNoRecursive";
            this.cbxNoRecursive.UseVisualStyleBackColor = false;
            this.cbxNoRecursive.CheckedChanged += new System.EventHandler(this.cbxNoRecursive_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.shortcutsToolStripMenuItem,
            this.presetToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exportToExcelFileToolStripMenuItem
            // 
            this.exportToExcelFileToolStripMenuItem.Image = global::Icarus.Properties.Resources.エクセル;
            this.exportToExcelFileToolStripMenuItem.Name = "exportToExcelFileToolStripMenuItem";
            resources.ApplyResources(this.exportToExcelFileToolStripMenuItem, "exportToExcelFileToolStripMenuItem");
            this.exportToExcelFileToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Icarus.Properties.Resources.非常口;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem,
            this.smallIconToolStripMenuItem,
            this.listToolStripMenuItem,
            this.tileToolStripMenuItem});
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Image = global::Icarus.Properties.Resources.large_icon;
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            resources.ApplyResources(this.largeIconToolStripMenuItem, "largeIconToolStripMenuItem");
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.largeIconToolStripMenuItem_Click);
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Image = global::Icarus.Properties.Resources.small_icon;
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            resources.ApplyResources(this.smallIconToolStripMenuItem, "smallIconToolStripMenuItem");
            this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.smallIconToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Image = global::Icarus.Properties.Resources.list;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            resources.ApplyResources(this.listToolStripMenuItem, "listToolStripMenuItem");
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Image = global::Icarus.Properties.Resources.tile;
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            resources.ApplyResources(this.tileToolStripMenuItem, "tileToolStripMenuItem");
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // shortcutsToolStripMenuItem
            // 
            this.shortcutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem,
            this.makingWoodBuildingPiecesByMyselfToolStripMenuItem});
            this.shortcutsToolStripMenuItem.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
            resources.ApplyResources(this.shortcutsToolStripMenuItem, "shortcutsToolStripMenuItem");
            // 
            // makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem
            // 
            this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem.Image = global::Icarus.Properties.Resources.ショートカット;
            this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem.Name = "makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem";
            resources.ApplyResources(this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem, "makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem");
            this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem.Click += new System.EventHandler(this.makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem_Click);
            // 
            // makingWoodBuildingPiecesByMyselfToolStripMenuItem
            // 
            this.makingWoodBuildingPiecesByMyselfToolStripMenuItem.Image = global::Icarus.Properties.Resources.ショートカット;
            this.makingWoodBuildingPiecesByMyselfToolStripMenuItem.Name = "makingWoodBuildingPiecesByMyselfToolStripMenuItem";
            resources.ApplyResources(this.makingWoodBuildingPiecesByMyselfToolStripMenuItem, "makingWoodBuildingPiecesByMyselfToolStripMenuItem");
            this.makingWoodBuildingPiecesByMyselfToolStripMenuItem.Click += new System.EventHandler(this.makingWoodBuildingPiecesByMyselfToolStripMenuItem_Click);
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem});
            this.presetToolStripMenuItem.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            resources.ApplyResources(this.presetToolStripMenuItem, "presetToolStripMenuItem");
            // 
            // registerToolStripMenuItem
            // 
            resources.ApplyResources(this.registerToolStripMenuItem, "registerToolStripMenuItem");
            this.registerToolStripMenuItem.Image = global::Icarus.Properties.Resources.スパナ;
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // pnlLower
            // 
            this.pnlLower.Controls.Add(this.flpnlRecipes);
            resources.ApplyResources(this.pnlLower, "pnlLower");
            this.pnlLower.Name = "pnlLower";
            // 
            // flpnlRecipes
            // 
            resources.ApplyResources(this.flpnlRecipes, "flpnlRecipes");
            this.flpnlRecipes.BackColor = System.Drawing.Color.LightYellow;
            this.flpnlRecipes.Name = "flpnlRecipes";
            // 
            // clbxAttrs
            // 
            this.clbxAttrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbxAttrs.CheckOnClick = true;
            resources.ApplyResources(this.clbxAttrs, "clbxAttrs");
            this.clbxAttrs.FormattingEnabled = true;
            this.clbxAttrs.Name = "clbxAttrs";
            this.clbxAttrs.Sorted = true;
            this.clbxAttrs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbxAttrs_ItemCheck);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.lvSouces);
            this.pnlMiddle.Controls.Add(this.clbxAttrs);
            resources.ApplyResources(this.pnlMiddle, "pnlMiddle");
            this.pnlMiddle.Name = "pnlMiddle";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.roTotal);
            resources.ApplyResources(this.pnlTotal, "pnlTotal");
            this.pnlTotal.Name = "pnlTotal";
            // 
            // roTotal
            // 
            resources.ApplyResources(this.roTotal, "roTotal");
            this.roTotal.ListViewStyle = System.Windows.Forms.View.LargeIcon;
            this.roTotal.Name = "roTotal";
            this.roTotal.ValueChanged = null;
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.Controls.Add(this.splitter2);
            this.pnlLeftSide.Controls.Add(this.pnlMiddle);
            this.pnlLeftSide.Controls.Add(this.pnlUpper);
            this.pnlLeftSide.Controls.Add(this.pnlLower);
            this.pnlLeftSide.Controls.Add(this.splitter1);
            this.pnlLeftSide.Controls.Add(this.pnlTotal);
            resources.ApplyResources(this.pnlLeftSide, "pnlLeftSide");
            this.pnlLeftSide.Name = "pnlLeftSide";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.DarkRed;
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // pnlRightSide
            // 
            this.pnlRightSide.Controls.Add(this.lvHavingBenches);
            this.pnlRightSide.Controls.Add(this.btnConbine);
            this.pnlRightSide.Controls.Add(this.btnHavingBenchesAllorNone);
            this.pnlRightSide.Controls.Add(this.lblHavingBenches);
            resources.ApplyResources(this.pnlRightSide, "pnlRightSide");
            this.pnlRightSide.Name = "pnlRightSide";
            // 
            // lvHavingBenches
            // 
            this.lvHavingBenches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvHavingBenches.CheckBoxes = true;
            resources.ApplyResources(this.lvHavingBenches, "lvHavingBenches");
            this.lvHavingBenches.HideSelection = false;
            this.lvHavingBenches.LargeImageList = this.ObjectImagesLarge;
            this.lvHavingBenches.Name = "lvHavingBenches";
            this.lvHavingBenches.SmallImageList = this.ObjectImagesSmall;
            this.lvHavingBenches.UseCompatibleStateImageBehavior = false;
            // 
            // btnConbine
            // 
            this.btnConbine.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btnConbine, "btnConbine");
            this.btnConbine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnConbine.Image = global::Icarus.Properties.Resources.返信矢印;
            this.btnConbine.Name = "btnConbine";
            this.btnConbine.UseVisualStyleBackColor = true;
            this.btnConbine.Click += new System.EventHandler(this.btnConbine_Click);
            // 
            // btnHavingBenchesAllorNone
            // 
            this.btnHavingBenchesAllorNone.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btnHavingBenchesAllorNone, "btnHavingBenchesAllorNone");
            this.btnHavingBenchesAllorNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnHavingBenchesAllorNone.Name = "btnHavingBenchesAllorNone";
            this.btnHavingBenchesAllorNone.UseVisualStyleBackColor = true;
            this.btnHavingBenchesAllorNone.Click += new System.EventHandler(this.btnHavingBenchesAllorNone_Click);
            // 
            // lblHavingBenches
            // 
            this.lblHavingBenches.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblHavingBenches, "lblHavingBenches");
            this.lblHavingBenches.ForeColor = System.Drawing.Color.White;
            this.lblHavingBenches.Name = "lblHavingBenches";
            // 
            // svfDlog
            // 
            resources.ApplyResources(this.svfDlog, "svfDlog");
            // 
            // WhatDoYouNeed
            // 
            this.AcceptButton = this.btnFilter;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLeftSide);
            this.Controls.Add(this.pnlRightSide);
            this.Controls.Add(this.menuStrip1);
            this.Name = "WhatDoYouNeed";
            this.SizeChanged += new System.EventHandler(this.WhatDoYouNeed_SizeChanged);
            this.pnlUpper.ResumeLayout(false);
            this.pnlUpper.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLower.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlLeftSide.ResumeLayout(false);
            this.pnlRightSide.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvSouces;
        private System.Windows.Forms.Panel pnlUpper;
        private System.Windows.Forms.ImageList ObjectImagesLarge;
        private System.Windows.Forms.ImageList ObjectImagesSmall;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Panel pnlLower;
        private System.Windows.Forms.CheckedListBox clbxAttrs;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.FlowLayoutPanel flpnlRecipes;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnlTotal;
        private RecipeTotal roTotal;
        private System.Windows.Forms.Panel pnlLeftSide;
        private System.Windows.Forms.Panel pnlRightSide;
        private System.Windows.Forms.Button btnHavingBenchesAllorNone;
        private System.Windows.Forms.ListView lvHavingBenches;
        private System.Windows.Forms.Label lblHavingBenches;
        private System.Windows.Forms.Button btnConbine;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem shortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makingWoodBuildingPiecesAtACarpentryBenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makingWoodBuildingPiecesByMyselfToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog svfDlog;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxNoRecursive;
    }
}

