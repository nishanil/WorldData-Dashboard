using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryDetailsPage : ContentPage
    {

        public CountryDetailsPageViewModel ViewModel
        {
            get { return (BindingContext as CountryDetailsPageViewModel); }
        }

        public CountryDetailsPage()
        {
            InitializeComponent();
            ChartView.TransformationsChanged += ChartView_TransformationsChanged;
            ChartView.FrequencyChanged += ChartView_FrequencyChanged;

        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        void ChartView_FrequencyChanged(object sender, string e)
        {
            var freq = "none";
            switch (e)
            {
                case "Daily":
                    freq = "daily";
                    break;
                case "Weekly":
                    freq = "weekly";
                    break;
                case "Monthly":
                    freq = "monthly";
                    break;
                case "Quarterly":
                    freq = "quarterly";
                    break;
                case "Annual":
                    freq = "annual";
                    break;
            }
            ViewModel.GetData(frequency: freq);
        }

        void ChartView_TransformationsChanged(object sender, string e)
        {
            // More info: https://www.quandl.com/help/api 
            var trans = "none";
            switch (e)
            {
                case "Change":
                    trans = "diff";
                    break;
                case "% Change":
                    trans = "rdiff";
                    break;
                case "Cumulative":
                    trans = "cumul";
                    break;
            }
            ViewModel.GetData(transformation: trans);
        }

    }
}
