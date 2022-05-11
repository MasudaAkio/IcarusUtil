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

namespace IcarusTest
{
    public partial class IcarusSample : Form
    {
        public IcarusSample()
        {
            InitializeComponent();

            listView1.Items.AddRange(new Materials().Select(m => {
                ObjectImagesLarge.Images.Add(m.keyname, m.image);
                ObjectImagesSmall.Images.Add(m.keyname, m.image);
                var item = new ListViewItem(m.name, m.keyname);
                return item;

            }).ToArray());
            
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.LargeIcon;

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.SmallIcon;

        // private void detailsToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Details;

        private void listToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.List;

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) => listView1.View = View.Tile;
    }
}
