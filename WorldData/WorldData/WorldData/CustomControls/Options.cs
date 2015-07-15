using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorldData
{
    public class Options : View
    {
        public event EventHandler SelectedIndexChanged;
        public IList<string> Items { get; private set; }

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create("SelectedIndex", typeof(int), typeof(Options), -1, BindingMode.TwoWay,
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var selectedIndexChangedInstance = ((Options)bindable).SelectedIndexChanged;
            if (selectedIndexChangedInstance != null)
                selectedIndexChangedInstance(bindable, EventArgs.Empty);
        });

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public Options()
        {
            // todo: make it observable
            Items = new List<string>();
        }
    }
}
