using System;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryInfoPage : ContentPage
    {

        public CountryInfoPageViewModel ViewModel
        {
            get { return (BindingContext as CountryInfoPageViewModel) ; }
        }
        
        public CountryInfoPage()
        {
            InitializeComponent();
            ChartView.TransformationsChanged += ChartView_TransformationsChanged;
            
            // deselect row
            OthersListView.ItemTapped += (sender, args) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            OthersListView.ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem == null) return; 
                var detailsPage = new CountryDetailsPage
                {
                    BindingContext = new CountryDetailsPageViewModel {Data = ViewModel.LifeExpenctancyData}
                };
                Navigation.PushModalAsync(detailsPage, true);
            };
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
            ViewModel.GetPopulation(trans);
        }
    }
}
