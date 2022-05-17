
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
            this.picObject = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.nupdnValue = new System.Windows.Forms.NumericUpDown();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.pnlRecipe = new System.Windows.Forms.Panel();
            this.lvStuffs = new System.Windows.Forms.ListView();
            this.lvBenches = new System.Windows.Forms.ListView();
            this.ImagesLarge = new System.Windows.Forms.ImageList(this.components);
            this.ImagesSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
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
            this.picObject.Location = new System.Drawing.Point(3, 3);
            this.picObject.Margin = new System.Windows.Forms.Padding(0);
            this.picObject.Name = "picObject";
            this.picObject.Size = new System.Drawing.Size(42, 43);
            this.picObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picObject.TabIndex = 0;
            this.picObject.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Location = new System.Drawing.Point(45, 4);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 19);
            this.lblName.TabIndex = 1;
            // 
            // nupdnValue
            // 
            this.nupdnValue.Location = new System.Drawing.Point(44, 23);
            this.nupdnValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nupdnValue.Name = "nupdnValue";
            this.nupdnValue.Size = new System.Drawing.Size(96, 23);
            this.nupdnValue.TabIndex = 2;
            this.nupdnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupdnValue.ValueChanged += new System.EventHandler(this.nupdnValue_ValueChanged);
            // 
            // pnlTarget
            // 
            this.pnlTarget.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlTarget.Controls.Add(this.btnRemove);
            this.pnlTarget.Controls.Add(this.picObject);
            this.pnlTarget.Controls.Add(this.lblName);
            this.pnlTarget.Controls.Add(this.nupdnValue);
            this.pnlTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTarget.Location = new System.Drawing.Point(0, 0);
            this.pnlTarget.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTarget.MinimumSize = new System.Drawing.Size(143, 42);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTarget.Size = new System.Drawing.Size(143, 70);
            this.pnlTarget.TabIndex = 3;
            // 
            // pnlRecipe
            // 
            this.pnlRecipe.Controls.Add(this.lvStuffs);
            this.pnlRecipe.Controls.Add(this.lvBenches);
            this.pnlRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecipe.Location = new System.Drawing.Point(143, 0);
            this.pnlRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRecipe.Name = "pnlRecipe";
            this.pnlRecipe.Size = new System.Drawing.Size(489, 70);
            this.pnlRecipe.TabIndex = 3;
            // 
            // lvStuffs
            // 
            this.lvStuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStuffs.HideSelection = false;
            this.lvStuffs.Location = new System.Drawing.Point(119, 0);
            this.lvStuffs.Name = "lvStuffs";
            this.lvStuffs.Size = new System.Drawing.Size(370, 70);
            this.lvStuffs.TabIndex = 1;
            this.lvStuffs.UseCompatibleStateImageBehavior = false;
            this.lvStuffs.View = System.Windows.Forms.View.SmallIcon;
            // 
            // lvBenches
            // 
            this.lvBenches.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvBenches.HideSelection = false;
            this.lvBenches.Location = new System.Drawing.Point(0, 0);
            this.lvBenches.Name = "lvBenches";
            this.lvBenches.Size = new System.Drawing.Size(119, 70);
            this.lvBenches.TabIndex = 0;
            this.lvBenches.UseCompatibleStateImageBehavior = false;
            this.lvBenches.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ImagesLarge
            // 
            this.ImagesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImagesLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.ImagesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImagesSmall
            // 
            this.ImagesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImagesSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ImagesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Meiryo UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRemove.Location = new System.Drawing.Point(3, 46);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(138, 19);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ResultOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRecipe);
            this.Controls.Add(this.pnlTarget);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResultOne";
            this.Size = new System.Drawing.Size(632, 70);
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
    }
}
