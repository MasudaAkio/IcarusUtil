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

using IcarusLib;
using IcarusLib.Properties;

namespace IcarusSample
{
    public partial class IcarusSample : Form
    {
        ListViewItem CreateItem(IcarusLib.Object m) => new ListViewItem(/* $"{m.name}-{m.keyname}" */ m.name, m.keyname);
        ListViewItem CreateItem2(IcarusLib.Object m) => new ListViewItem($"{m.name}-{m.keyname}" /* m.name */, m.keyname);
        public IcarusSample()
        {
            InitializeComponent();

            listView1.Items.AddRange(new Objects()
                .OrderBy(m => m.name)
                .Select(m => {
                    ObjectImagesLarge.Images.Add(m.keyname, m.image);
                    ObjectImagesSmall.Images.Add(m.keyname, m.image);
                    return CreateItem(m);
                })
                .ToArray());
            
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.LargeIcon;

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.SmallIcon;

        // private void detailsToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Details;

        private void listToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.List;

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Tile;

        void Filter(string s)
        {
            var all = string.IsNullOrEmpty(s);
            listView1.Items.AddRange(new Objects()
                .Where(m => all || m.name.Contains(s))
                .OrderBy(m => m.name)
                .Select(m => CreateItem(m))
                .ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Filter(tbxFilter.Text);
        }
    }
}
