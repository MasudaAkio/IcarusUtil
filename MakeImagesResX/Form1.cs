using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace MakeImagesResX
{
    public partial class MakeImagesResX : Form
    {
        public MakeImagesResX()
        {
            InitializeComponent();

            // btnGo.FlatStyle = FlatStyle.Flat;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPathPrefix.Text)) tbxPathPrefix.Text =  @"..\..\..\IcarusLib";
            var prefix = tbxPathPrefix.Text;

            var wrtr = new ResXResourceWriter(Path.Combine(prefix, @"Properties\Images.resx"));

            var noimage = new Bitmap(Path.Combine(prefix, @"Resources\NoImage.png"));
            foreach (var k in IcarusLib.Object.Keys.Concat(new string[] { "NoImage" }))
            {
                var png = new FileInfo(Path.Combine(prefix, $@"Resources\{k}.png"));
                if (png.Exists) wrtr.AddResource(k, new Bitmap(png.ToString()));
                else wrtr.AddResource(k, noimage);
            }
            wrtr.Close();
        }
    }
}
