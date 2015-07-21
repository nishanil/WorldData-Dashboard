using System;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryInfoPage : ContentPage
    {
        public CountryInfoPageViewModel ViewModel
        {
            get { return (BindingContext as CountryInfoPageViewModel); }
        }

        public CountryInfoPage()
        {
            InitializeComponent();
            ChartView.TransformationsChanged += ChartView_TransformationsChanged;
            ChartView.FrequencyChanged += ChartView_FrequencyChanged;

            // deselect row
            OthersListView.ItemTapped += (sender, args) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
            OthersListView.ItemSelected += (sender, args) =>
            {
                var selectedItem = args.SelectedItem as OthersListViewItem;
                if (selectedItem == null) return;

                Navigation.PushModalAsync(new CountryDetailsPage { BindingContext = new CountryDetailsPageViewModel(ViewModel.Country, selectedItem.Name) }, true);
            };
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
            ViewModel.GetPopulation(frequency: freq);
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
            ViewModel.GetPopulation(transformation: trans);
        }
    }
}
