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

using IcarusLib.Properties;

namespace IcarusTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resources.IronOre;

            var rs = Resources.ResourceManager.GetResourceSet(Resources.Culture??CultureInfo.CurrentCulture, true, true);
            listView1.Items.AddRange(rs.Cast<DictionaryEntry>().Select(r => new ListViewItem(r.Key + "|" + r.Value)).ToArray());


        }

    }
}
