using System.Windows.Forms;
using System.Drawing;

using IcarusLib;

namespace Icarus
{
    public class ObjectItem : ListViewItem
    {
        public IcrObject.Recipe[] Recipes { get; set; }
        private decimal _volume = 0m;
        public decimal Volume
        {
            get => _volume;
            set { _volume = value;  Text = MakeTextWithVolume(basetext, value); }
        }

        private decimal basevolume { get; set; }

        private string basetext { get; set; }

        private static string MakeTextWithVolume(string basetext, decimal volume)
        {
            var ceiling = decimal.Ceiling(volume);
            return basetext + $"{(ceiling > 1 ? $" x {ceiling}" : "")}"; 
        }

        // public ObjectItem() { }
        public ObjectItem(IcarusLib.IcrObject obj, decimal volume = 0m, bool debug = false)
            : base($"{obj.Name}{(debug ? $"-{obj.Key}" : "")}", obj.Key)
        {
            Name = obj.Key;
            basetext = Text;
            Volume = volume;
            basevolume = volume;
            Recipes = obj.Recipes;
            ToolTipText = obj.SelectedRecipe.ToString();
            if (obj.Recipes.Length > 1) Font = new Font(Font, FontStyle.Underline);
        }

        public decimal Multiply(decimal times) => Volume = basevolume * times;

        override public object Clone()
        {
            var c = (ObjectItem)base.Clone();
            c.Name = Name;
            c.basetext = basetext;
            c.Volume = Volume;
            c.Recipes = Recipes;
            return c;
        }

        public ObjectItem Copy() => (ObjectItem)Clone();
    }
}
