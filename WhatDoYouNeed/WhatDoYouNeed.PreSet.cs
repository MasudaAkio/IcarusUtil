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
using System.Deployment.Application;

using IcarusLib;
using IcarusLib.Properties;

namespace Icarus
{
    public partial class WhatDoYouNeed
    {
        private class PresetStuff
        {
            public string Key { get; set; }
            public decimal Volume { get; set; }
        }

        private class PresetOne
        {
            public string Name { get; set; }
            public PresetStuff[] Stuffs { get; set; }

            public override string ToString()
            {
                return $"{Name},{String.Join(",", Stuffs.Select(s => $"{s.Key}:{s.Volume}"))};";
            }

            public void FromString(string x)
            {
                if (x != null)
                {
                    x.Trim(';');
                    var eles = x.Split(',');
                    Name = eles[0];
                    Stuffs = eles.Skip(1).Select(ele =>
                    {
                        var k_v = ele.Split(':');
                        return new PresetStuff() { Key = k_v[0], Volume = decimal.Parse(k_v[1]) };
                    }).ToArray();
                }
            }

            public PresetOne() { }

            public PresetOne(string x) : base() => this.FromString(x);
        }

        private PresetOne ConstructPresetOne(string name)
        {
            return new PresetOne()
            {
                Name = name,
                Stuffs = flpnlRecipes.Controls
                     .OfType<ResultOne>()
                     .Select(ro => new PresetStuff() { Key = ro.Target.Key, Volume = ro.Volume }).ToArray()
            };
        }

        private void ExpandPresetOne(PresetOne po)
        {
            foreach (var st in po.Stuffs)
            {
                int vol = (int)st.Volume;
                for (int i = 0; i < vol; i++) Add2RecipeView(st.Key);
            }
            CalcTotal();
        }
        public void PresetMenuItem_Click(object sender, EventArgs e)
        {
            var mi = (ToolStripMenuItem)sender;
            // MessageBox.Show(((ToolStripMenuItem)sender).Text);
            ExpandPresetOne(PresetMany.Default[mi.Text]);
        }

        private void EditPresets(Action<PresetMany> doit)
        {
            var presets = PresetMany.Default;
            doit(presets);
            presets.Save();
            presets.Set2Menu(presetToolStripMenuItem, PresetMenuItem_Click, PresetMenuItem_MouseUp);
        }
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flpnlRecipes.Controls.Count > 0)
            {
                var input = new InputPresetName();
                input.Opacity = 0.9;
                input.StartPosition = FormStartPosition.CenterParent;
                var result = input.ShowDialog(this);
                if (result == DialogResult.OK && !string.IsNullOrEmpty(input.PresetName))
                    EditPresets(presets => presets.Add(ConstructPresetOne(input.PresetName)));
            }
        }

        private void PresetMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var mi = (ToolStripMenuItem)sender;
                var msg = string.Format(Messages.RemovePresetPromptMessage, mi.Text);
                PrepareCenteringMessageBoxOnTheForm(this);
                var ret = MessageBox.Show(msg, "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ret == DialogResult.OK)
                    EditPresets(presets => presets.Remove(presets[mi.Text]));
            }
        }

        private class PresetMany
        {
            private Dictionary<string, PresetOne> Presets { get; set; }

            public override string ToString() => String.Join("", Presets.Select(p => p.Value.ToString()).ToArray());

            private PresetMany(string src)
            {
                Presets = string.IsNullOrEmpty(src) ?
                    new Dictionary<string, PresetOne>() :
                    src
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(ele => new PresetOne(ele))
                    .ToDictionary(po => po.Name, po => po);
            }

            public void Add(PresetOne po) => Presets[po.Name] = po;
            public void Remove(PresetOne po) => Presets.Remove(po.Name);
            public PresetOne this[string name] => Presets[name];
            public static PresetMany Default { get; private set; }
            static PresetMany()
            {
                var presets_str = (string)Properties.Settings.Default["Presets"];
                Default = new PresetMany(presets_str);
            }

            public void Save()
            {
                Properties.Settings.Default["Presets"] = Default.ToString();
                Properties.Settings.Default.Save();
            }

            public void Set2Menu(ToolStripMenuItem mi, EventHandler on_click, MouseEventHandler on_mouse_btn_up)
            {
                var items = mi.DropDownItems;
                foreach (var it in items.OfType<ToolStripItem>().Skip(1).ToArray()) items.Remove(it);
                mi.DropDownItems.Add(new ToolStripSeparator());
                foreach (var ps in Presets)
                {
                    var child = new ToolStripMenuItem(ps.Key, Properties.Resources.スパナ, on_click);
                    child.MouseUp += on_mouse_btn_up;
                    mi.DropDownItems.Add(child);
                }
            }
        }

    }
}
