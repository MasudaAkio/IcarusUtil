using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IcarusLib;

namespace Icarus
{

    abstract public partial class ResultOne : UserControl
    {

        protected bool Recursive { get; set; }
        public ResultOne(bool recursive = true)
        {
            InitializeComponent();
            Recursive = recursive;
        }
        public void SetImageLists(ImageList large, ImageList small)
        {
            lvBenches.LargeImageList = large;
            lvBenches.SmallImageList = small;
            lvStuffs.LargeImageList = large;
            lvStuffs.SmallImageList = small;
        }

        protected void SetRecipe(IcrObject.Recipe? rcp = null)
        {
            ObjectItem CreateItem(string key, decimal vol = 0m) => new ObjectItem(new IcrObject(key), vol, false); // IcrObjectは軽量なのでバンバン作っても影響は小さい
            lvBenches.Items.Clear();
            lvStuffs.Items.Clear();
            if (rcp != null)
            {
                var rcp_str = rcp.ToString();
                toolTip1.SetToolTip(picObject, rcp_str);
                toolTip1.SetToolTip(lblName, rcp_str);
                var aggre = rcp.FinalRequirements(Recursive);
                foreach (var i in aggre.aggregated)
                    lvStuffs.Items.Add(CreateItem(i.Item.Key, /* decimal.Ceiling(i.Volume) */ i.Volume));
                lvBenches.Items.AddRange(aggre.benches.Select(k => new ObjectItem(new IcrObject(k))).ToArray());
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public (ObjectItem[] benches, ObjectItem[] stuffs) Recipe
        {
            get
            => (benches: lvBenches.Items.OfType<ObjectItem>().ToArray(),
                stuffs: lvStuffs.Items.OfType<ObjectItem>().ToArray());
            set
            {
                lvBenches.Items?.Clear();
                lvBenches.Items?.AddRange(value.benches);
                lvStuffs.Items?.Clear();
                lvStuffs.Items?.AddRange(value.stuffs);
            }
        }

        private View _view;

        public View ListViewStyle
        {
            get => _view;
            set
            {
                _view = value;
                lvBenches.View = value;
                lvStuffs.View = value;
            }
        }

        public decimal Volume => nupdnValue.Value;
        public void ReCalc(IcrObject _obj)
        {
            if (_obj.Recipes.Length > 0) SetRecipe(_obj.Recipes[_obj.RecipeIndex]);
        }

        public delegate void RemoveEventHandler(object sender, EventArgs e);
        public event RemoveEventHandler? Remove;
        protected virtual void RaiseRemoveEvent() => Remove?.Invoke(this, new EventArgs());

        private void btnRemove_Click(object sender, EventArgs e) => RaiseRemoveEvent();

        public Action? ValueChanged { get; set; }
        public decimal Increment(decimal deff = 1.0m)
        {
            nupdnValue.Value += deff;
            return nupdnValue.Value;
        }

        private void nupdnValue_ValueChanged(object sender, EventArgs e)
        {
            var current = nupdnValue.Value;
            if (current == 0.0m) btnRemove.PerformClick();
            else
            {
                foreach (var it in lvStuffs.Items.OfType<ObjectItem>())
                    it.Multiply(current);
            }
            ValueChanged?.Invoke();

        }

        protected void PrepareForRecipeTotal()
        {
            foreach (var ctr in pnlTarget.Controls.OfType<Control>())
                if (ctr.Name != "lblTotal" && ctr.Name != "btnRemove") ctr.Visible = false;
            btnRemove.Text = "Remove All";
            btnRemove.BackColor = Color.White;
            lblTotal.Visible = true;
        }

    }

    public class EachRecipe : ResultOne
    {
        public IcrObject Target { get; private set; }
                //if (_obj != null)
                //{
                //    lblName.Text = _obj.Name;
                //    nupdnValue.Value = 1;
                //    picObject.Image = new Bitmap(_obj.Image, picObject.Size);
                //    if (_obj.Recipes.Length > 0) SetRecipe(_obj.Recipes[_obj.RecipeIndex]);
                //}
                //else
                //{
                //    lblName.Text = "";
                //    nupdnValue.Value = 0;
                //    picObject.Image = null;
                //}
        public EachRecipe(IcrObject iobj, ImageList large, ImageList small, bool recursive = true) : base(recursive)
        {
            Target = iobj;
            lblName.Text = Target.Name;
            nupdnValue.Value = 1;
            picObject.Image = new Bitmap(Target.Image, picObject.Size);
            if (Target.Recipes.Length > 0) SetRecipe(Target.Recipes[Target.RecipeIndex]);
            SetImageLists(large, small);
        }

        public void ReCalc() => ReCalc(Target);
        public void ReCalc(bool recursive) { Recursive = recursive; ReCalc(); }
        // private Label lblTotal = new Label() { Text = "TOTAL", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
    }

    public class RecipeTotal : ResultOne
    {
        public RecipeTotal()
        {
            PrepareForRecipeTotal();
        }
    }
}

