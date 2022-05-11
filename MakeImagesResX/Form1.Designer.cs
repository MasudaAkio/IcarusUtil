
namespace MakeImagesResX
{
    partial class MakeImagesResX
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPathPrefix = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path Prefix";
            // 
            // tbxPathPrefix
            // 
            this.tbxPathPrefix.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbxPathPrefix.Location = new System.Drawing.Point(121, 32);
            this.tbxPathPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxPathPrefix.Name = "tbxPathPrefix";
            this.tbxPathPrefix.Size = new System.Drawing.Size(447, 27);
            this.tbxPathPrefix.TabIndex = 1;
            this.tbxPathPrefix.Text = "..\\..\\..\\IcarusLib";
            // 
            // btnGo
            // 
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.btnGo.Location = new System.Drawing.Point(528, 101);
            this.btnGo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 38);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // MakeImagesResX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 153);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.tbxPathPrefix);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MakeImagesResX";
            this.Text = "MakeImagesResX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPathPrefix;
        private System.Windows.Forms.Button btnGo;
    }
}

