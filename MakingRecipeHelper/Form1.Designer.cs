
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
            this.tbxInputArea = new System.Windows.Forms.TextBox();
            this.tbxEdited = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbxBenches = new System.Windows.Forms.ListBox();
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
            this.tbxInputArea.Location = new System.Drawing.Point(0, 0);
            this.tbxInputArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxInputArea.Multiline = true;
            this.tbxInputArea.Name = "tbxInputArea";
            this.tbxInputArea.Size = new System.Drawing.Size(526, 419);
            this.tbxInputArea.TabIndex = 0;
            this.tbxInputArea.TextChanged += new System.EventHandler(this.tbxInputArea_TextChanged);
            // 
            // tbxEdited
            // 
            this.tbxEdited.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbxEdited.Location = new System.Drawing.Point(0, 419);
            this.tbxEdited.Margin = new System.Windows.Forms.Padding(6);
            this.tbxEdited.Name = "tbxEdited";
            this.tbxEdited.Size = new System.Drawing.Size(526, 22);
            this.tbxEdited.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxInputArea);
            this.panel1.Controls.Add(this.tbxEdited);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(178, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 441);
            this.panel1.TabIndex = 2;
            // 
            // lbxBenches
            // 
            this.lbxBenches.BackColor = System.Drawing.Color.Silver;
            this.lbxBenches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxBenches.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxBenches.FormattingEnabled = true;
            this.lbxBenches.ItemHeight = 14;
            this.lbxBenches.Location = new System.Drawing.Point(0, 0);
            this.lbxBenches.Name = "lbxBenches";
            this.lbxBenches.Size = new System.Drawing.Size(178, 441);
            this.lbxBenches.TabIndex = 3;
            this.lbxBenches.SelectedIndexChanged += new System.EventHandler(this.lbxBenches_SelectedIndexChanged);
            // 
            // MakingRecipeHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbxBenches);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MakingRecipeHelper";
            this.Text = "MakingRecipeHelper";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInputArea;
        private System.Windows.Forms.TextBox tbxEdited;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbxBenches;
    }
}

