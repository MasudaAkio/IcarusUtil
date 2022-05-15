﻿
namespace IcarusSample
{
    partial class IcarusSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IcarusSample));
            this.lvSouces = new System.Windows.Forms.ListView();
            this.ObjectImagesLarge = new System.Windows.Forms.ImageList(this.components);
            this.ObjectImagesSmall = new System.Windows.Forms.ImageList(this.components);
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLower = new System.Windows.Forms.Panel();
            this.lvTarget = new System.Windows.Forms.ListView();
            this.lvRecipe = new System.Windows.Forms.ListView();
            this.pnlUpper.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlLower.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSouces
            // 
            this.lvSouces.BackColor = System.Drawing.Color.MistyRose;
            this.lvSouces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSouces.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvSouces.GridLines = true;
            this.lvSouces.HideSelection = false;
            this.lvSouces.LargeImageList = this.ObjectImagesLarge;
            this.lvSouces.Location = new System.Drawing.Point(182, 24);
            this.lvSouces.Margin = new System.Windows.Forms.Padding(2);
            this.lvSouces.Name = "lvSouces";
            this.lvSouces.Size = new System.Drawing.Size(1082, 557);
            this.lvSouces.SmallImageList = this.ObjectImagesSmall;
            this.lvSouces.TabIndex = 1;
            this.lvSouces.UseCompatibleStateImageBehavior = false;
            this.lvSouces.View = System.Windows.Forms.View.List;
            this.lvSouces.SelectedIndexChanged += new System.EventHandler(this.lvSouces_SelectedIndexChanged);
            // 
            // ObjectImagesLarge
            // 
            this.ObjectImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ObjectImagesLarge.ImageSize = new System.Drawing.Size(48, 48);
            this.ObjectImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ObjectImagesSmall
            // 
            this.ObjectImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ObjectImagesSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ObjectImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlUpper
            // 
            this.pnlUpper.BackColor = System.Drawing.Color.DarkGray;
            this.pnlUpper.Controls.Add(this.btnFilter);
            this.pnlUpper.Controls.Add(this.tbxFilter);
            this.pnlUpper.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUpper.Location = new System.Drawing.Point(0, 24);
            this.pnlUpper.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUpper.Name = "pnlUpper";
            this.pnlUpper.Size = new System.Drawing.Size(182, 557);
            this.pnlUpper.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightYellow;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(125, 12);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(48, 24);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxFilter
            // 
            this.tbxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilter.Location = new System.Drawing.Point(8, 11);
            this.tbxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(113, 25);
            this.tbxFilter.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem,
            this.smallIconToolStripMenuItem,
            this.listToolStripMenuItem,
            this.tileToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItem1.Text = "表示";
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.largeIconToolStripMenuItem.Text = "アイコン(大)";
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.largeIconToolStripMenuItem_Click);
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.smallIconToolStripMenuItem.Text = "アイコン(小)";
            this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.smallIconToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.listToolStripMenuItem.Text = "リスト";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.tileToolStripMenuItem.Text = "タイル";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // pnlLower
            // 
            this.pnlLower.Controls.Add(this.lvRecipe);
            this.pnlLower.Controls.Add(this.lvTarget);
            this.pnlLower.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLower.Location = new System.Drawing.Point(0, 581);
            this.pnlLower.Name = "pnlLower";
            this.pnlLower.Size = new System.Drawing.Size(1264, 100);
            this.pnlLower.TabIndex = 4;
            // 
            // lvTarget
            // 
            this.lvTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvTarget.HideSelection = false;
            this.lvTarget.LargeImageList = this.ObjectImagesLarge;
            this.lvTarget.Location = new System.Drawing.Point(0, 0);
            this.lvTarget.Name = "lvTarget";
            this.lvTarget.Size = new System.Drawing.Size(182, 100);
            this.lvTarget.SmallImageList = this.ObjectImagesSmall;
            this.lvTarget.TabIndex = 5;
            this.lvTarget.UseCompatibleStateImageBehavior = false;
            // 
            // lvRecipe
            // 
            this.lvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecipe.HideSelection = false;
            this.lvRecipe.LargeImageList = this.ObjectImagesLarge;
            this.lvRecipe.Location = new System.Drawing.Point(182, 0);
            this.lvRecipe.Name = "lvRecipe";
            this.lvRecipe.Size = new System.Drawing.Size(1082, 100);
            this.lvRecipe.SmallImageList = this.ObjectImagesSmall;
            this.lvRecipe.TabIndex = 6;
            this.lvRecipe.UseCompatibleStateImageBehavior = false;
            // 
            // IcarusSample
            // 
            this.AcceptButton = this.btnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lvSouces);
            this.Controls.Add(this.pnlUpper);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlLower);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IcarusSample";
            this.Text = "IcarusSample";
            this.pnlUpper.ResumeLayout(false);
            this.pnlUpper.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLower.ResumeLayout(false);
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
        private System.Windows.Forms.ListView lvTarget;
        private System.Windows.Forms.ListView lvRecipe;
    }
}

