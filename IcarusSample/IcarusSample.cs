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
        private class ObjectItem : ListViewItem
        {
            public string key { get; private set; }
            public ObjectItem(IcarusLib.Object m, bool debug = false)
                : base(!debug ? m.name : $"{m.name}-{m.keyname}", m.keyname)
                => key = m.keyname;
        }

        private bool debug = false;

        public IcarusSample()
        {
            InitializeComponent();

            listView1.Items.AddRange(new Objects()
                .OrderBy(m => m.name)
                .Select(m => {
                    ObjectImagesLarge.Images.Add(m.keyname, m.image);
                    ObjectImagesSmall.Images.Add(m.keyname, m.image);
                    return new ObjectItem(m, debug);
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
                .Select(m => new ObjectItem(m, debug))
                .ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Filter(tbxFilter.Text);
        }
    }
}
