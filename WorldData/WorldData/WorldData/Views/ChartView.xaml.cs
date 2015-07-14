using System;
using System.Linq;
using Infragistics.XF.Controls;
using Xamarin.Forms;

namespace WorldData
{
    public partial class ChartView : ContentView
    {

        public static readonly BindableProperty DataProperty =
                BindableProperty.Create<ChartView, PopulationData>(p => p.Data, null, propertyChanged: OnDataChanged);

        private static void OnDataChanged(BindableObject bindable, PopulationData oldvalue, PopulationData newvalue)
        {
            ((ChartView)bindable).OnDataChanged(oldvalue, newvalue);
        }

        public PopulationData Data
        {
            get { return (PopulationData)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public void OnDataChanged(PopulationData oldValue, PopulationData newValue)
        {
            PopulateChart(newValue);
        }


        public static readonly BindableProperty ShowOverlayProperty =
                BindableProperty.Create<ChartView, bool>(p => p.ShowOverlay, false, propertyChanged: OnShowOverlayChanged);

        private static void OnShowOverlayChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        {
            ((ChartView)bindable).OnShowOverlayChanged(oldvalue, newvalue);
        }

        public bool ShowOverlay
        {
            get { return (bool)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public void OnShowOverlayChanged(bool oldValue, bool newValue)
        {
            if (newValue)
            {
                overlay.Opacity = 0.5;
                downloadingData.Text = "Downloading..";
            }
            else
            {
                overlay.Opacity = 0;
                downloadingData.Text = string.Empty;

            }
        }


        private void PopulateChart(PopulationData newValue)
        {
            lineChart.Series[0].ItemsSource = newValue;
            var axis = lineChart.Axes.OfType<CategoryXAxis>().First();
            axis.ItemsSource = newValue;
        }

        public ChartView()
        {
            InitializeComponent();

            transformationsPicker.SelectedIndexChanged += (sender, args) =>
            {

                var selectedItem = transformationsPicker.Items[transformationsPicker.SelectedIndex];
                if (TransformationsChanged != null)
                    TransformationsChanged(this, selectedItem);
            };
        }

        public event EventHandler<string> TransformationsChanged;
    }
}
