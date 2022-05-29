
namespace Icarus
{
    partial class ResultOne
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultOne));
            this.picObject = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.nupdnValue = new System.Windows.Forms.NumericUpDown();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlRecipe = new System.Windows.Forms.Panel();
            this.lvStuffs = new System.Windows.Forms.ListView();
            this.lvBenches = new System.Windows.Forms.ListView();
            this.ImagesLarge = new System.Windows.Forms.ImageList(this.components);
            this.ImagesSmall = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnValue)).BeginInit();
            this.pnlTarget.SuspendLayout();
            this.pnlRecipe.SuspendLayout();
            this.SuspendLayout();
            // 
            // picObject
            // 
            this.picObject.BackColor = System.Drawing.SystemColors.Control;
            this.picObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picObject, "picObject");
            this.picObject.Name = "picObject";
            this.picObject.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // nupdnValue
            // 
            resources.ApplyResources(this.nupdnValue, "nupdnValue");
            this.nupdnValue.Name = "nupdnValue";
            this.nupdnValue.ValueChanged += new System.EventHandler(this.nupdnValue_ValueChanged);
            // 
            // pnlTarget
            // 
            this.pnlTarget.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlTarget.Controls.Add(this.picObject);
            this.pnlTarget.Controls.Add(this.btnRemove);
            this.pnlTarget.Controls.Add(this.lblName);
            this.pnlTarget.Controls.Add(this.nupdnValue);
            this.pnlTarget.Controls.Add(this.lblTotal);
            resources.ApplyResources(this.pnlTarget, "pnlTarget");
            this.pnlTarget.Name = "pnlTarget";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotal.ForeColor = System.Drawing.Color.Moccasin;
            this.lblTotal.Name = "lblTotal";
            // 
            // pnlRecipe
            // 
            this.pnlRecipe.Controls.Add(this.lvStuffs);
            this.pnlRecipe.Controls.Add(this.lvBenches);
            resources.ApplyResources(this.pnlRecipe, "pnlRecipe");
            this.pnlRecipe.Name = "pnlRecipe";
            // 
            // lvStuffs
            // 
            resources.ApplyResources(this.lvStuffs, "lvStuffs");
            this.lvStuffs.HideSelection = false;
            this.lvStuffs.Name = "lvStuffs";
            this.lvStuffs.UseCompatibleStateImageBehavior = false;
            this.lvStuffs.View = System.Windows.Forms.View.SmallIcon;
            // 
            // lvBenches
            // 
            resources.ApplyResources(this.lvBenches, "lvBenches");
            this.lvBenches.HideSelection = false;
            this.lvBenches.Name = "lvBenches";
            this.lvBenches.ShowItemToolTips = true;
            this.lvBenches.UseCompatibleStateImageBehavior = false;
            this.lvBenches.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ImagesLarge
            // 
            this.ImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ImagesLarge, "ImagesLarge");
            this.ImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImagesSmall
            // 
            this.ImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ImagesSmall, "ImagesSmall");
            this.ImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ResultOne
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRecipe);
            this.Controls.Add(this.pnlTarget);
            this.Name = "ResultOne";
            ((System.ComponentModel.ISupportInitialize)(this.picObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnValue)).EndInit();
            this.pnlTarget.ResumeLayout(false);
            this.pnlRecipe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picObject;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown nupdnValue;
        private System.Windows.Forms.Panel pnlTarget;
        private System.Windows.Forms.Panel pnlRecipe;
        private System.Windows.Forms.ListView lvStuffs;
        private System.Windows.Forms.ListView lvBenches;
        private System.Windows.Forms.ImageList ImagesLarge;
        private System.Windows.Forms.ImageList ImagesSmall;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
