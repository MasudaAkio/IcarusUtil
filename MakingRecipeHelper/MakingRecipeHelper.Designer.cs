
namespace MakingRecipeHelper
{
    partial class MakingRecipeHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakingRecipeHelper));
            this.tbxInputArea = new System.Windows.Forms.TextBox();
            this.tbxEdited = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbxBenches = new System.Windows.Forms.ListBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxInputArea
            // 
            this.tbxInputArea.AcceptsReturn = true;
            this.tbxInputArea.AllowDrop = true;
            this.tbxInputArea.BackColor = System.Drawing.Color.DimGray;
            this.tbxInputArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxInputArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxInputArea.ForeColor = System.Drawing.Color.Bisque;
            this.tbxInputArea.HideSelection = false;
            this.tbxInputArea.Location = new System.Drawing.Point(178, 0);
            this.tbxInputArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxInputArea.Multiline = true;
            this.tbxInputArea.Name = "tbxInputArea";
            this.tbxInputArea.Size = new System.Drawing.Size(286, 306);
            this.tbxInputArea.TabIndex = 0;
            this.tbxInputArea.TextChanged += new System.EventHandler(this.tbxInputArea_TextChanged);
            // 
            // tbxEdited
            // 
            this.tbxEdited.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbxEdited.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEdited.Location = new System.Drawing.Point(0, 338);
            this.tbxEdited.Margin = new System.Windows.Forms.Padding(6);
            this.tbxEdited.Name = "tbxEdited";
            this.tbxEdited.ReadOnly = true;
            this.tbxEdited.Size = new System.Drawing.Size(464, 23);
            this.tbxEdited.TabIndex = 1;
            this.tbxEdited.TabStop = false;
            this.tbxEdited.MouseHover += new System.EventHandler(this.tbxEdited_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxInputArea);
            this.panel1.Controls.Add(this.lbxBenches);
            this.panel1.Controls.Add(this.btnPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 338);
            this.panel1.TabIndex = 2;
            // 
            // lbxBenches
            // 
            this.lbxBenches.BackColor = System.Drawing.Color.Silver;
            this.lbxBenches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxBenches.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxBenches.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxBenches.FormattingEnabled = true;
            this.lbxBenches.Location = new System.Drawing.Point(0, 0);
            this.lbxBenches.Name = "lbxBenches";
            this.lbxBenches.Size = new System.Drawing.Size(178, 306);
            this.lbxBenches.Sorted = true;
            this.lbxBenches.TabIndex = 3;
            this.lbxBenches.SelectedIndexChanged += new System.EventHandler(this.lbxBenches_SelectedIndexChanged);
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.Orange;
            this.btnPaste.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPaste.FlatAppearance.BorderSize = 0;
            this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaste.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.ForeColor = System.Drawing.Color.Maroon;
            this.btnPaste.Location = new System.Drawing.Point(0, 306);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(464, 32);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // MakingRecipeHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxEdited);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MakingRecipeHelper";
            this.Text = "MakingRecipeHelper";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInputArea;
        private System.Windows.Forms.TextBox tbxEdited;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbxBenches;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPaste;
    }
}

