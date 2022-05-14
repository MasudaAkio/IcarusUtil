using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// InputArea に以下のような文字列を書き込む(通常はクリップボードから貼り付ける)と
// Recipes.resx 用のレシピ式に整形してクリップボードに格納する。

//    Glassworking Bench
//    Amount	Resource
//    12	 Iron Ingot
//    18	 Glass
//    4	 Epoxy
//
// 整形後 => GlassworkingBench(IronIngot:12,Glass: 18,Epoxy: 4)
//
// また、作成ベンチを含まない以下のような文字列の場合は、
// 左のリストから選択したものを追加する。
//
//    12  Iron Ingot
//    4  Steel Screw
//    4  Epoxy
//
// 整形後 => HerbalismBench(IronIngot:12,SteelScrew: 4,Epoxy: 4)
// (ベンチリストの"Herbalism Bench"を選択した場合)

namespace MakingRecipeHelper
{
    public partial class MakingRecipeHelper : Form
    {
        private string[] Benches = new string[] {
            "Character Crafting",
            "Anvil Bench",
            "Carpentry Bench",
            "Cement Mixer",
            "Chemistry Bench",
            "Crafting Bench",
            "Electric Carpentry Bench",
            "Electric Masonry Bench",
            "Fabricator",
            "Glassworking Bench",
            "Herbalism Bench",
            "Machining Bench",
            "Masonry Bench",
            "Material Processor",
            "Mortar and Pestle",
            "Skinning Bench",
            "Textiles Bench",
            "Trophy Bench",
            "Biofuel Stove",
            "Campfire",
            "Cooking Station",
            "Drying Rack",
            "Firepit",
            "Fireplace",
            "Kitchen Bench",
            "MXC Campfire",
            "Potbelly Stove",
            "Wood Composter",
            "Stone Furnace",
            "Concrete Furnace",
            "Electric Furnace",
            "MXC Furnace",
        };

        public MakingRecipeHelper()
        {
            InitializeComponent();
            lbxBenches.Items.AddRange(Benches);
        }

        private void tbxInputArea_TextChanged(object sender, EventArgs e)
        {
            string remove_spc(string s) => s?.Replace(" ", "");

            IEnumerable<string> pull_bench(string s) => Benches.Where(b => s.Contains(b));

            var src = tbxInputArea.Lines;
            var benches = new List<string>();
            var staffs = new List<string>();
            var staff_regex = new Regex(@"^\s*(\d+)\s+(.+)$", RegexOptions.Compiled);

            foreach (var ln in src.Select(s => s.Trim()))
            {

                benches.AddRange(pull_bench(ln));
                {
                    var m = staff_regex.Match(ln);
                    if (m.Success)
                        staffs.Add($"{remove_spc(m.Groups[2].Value)}:{m.Groups[1]}");
                }
            }
            if (staffs.Count > 0)
            {
                if (benches.Count == 0) benches.Add(lbxBenches.SelectedItem?.ToString() ?? "");
                var args = $"({string.Join(",", staffs.ToArray())})";
                tbxEdited.Text = string.Join("|", benches
                                                    .Distinct()
                                                    .Select(bn => $"{remove_spc(bn)}{args}"));
                this.BeginInvoke(new MethodInvoker(() => Clipboard.SetDataObject(tbxEdited.Text, true, 25, 100)));
            }
        }

        private void lbxBenches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxEdited.Text))
                tbxInputArea_TextChanged(tbxInputArea, new EventArgs());
        }

        private void tbxEdited_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbxEdited, tbxEdited.Text);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            tbxInputArea.Clear();
            tbxInputArea.Text = Clipboard.GetText();
        }
    }
}
