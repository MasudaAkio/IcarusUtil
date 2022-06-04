using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icarus
{
    public partial class InputPresetName : Form
    {
        public InputPresetName()
        {
            InitializeComponent();
        }

        public string PresetName => tbxPresetName.Text;

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbxPresetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (new[] { ',', ';' }.Contains(e.KeyChar));// コンマとセミコロンはSerializeしたときのデリミタなので使わせない
        }
    }
}
