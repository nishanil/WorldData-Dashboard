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

            // binding context set by calling page
            // BindingContext = new CountryInfoPageViewModel();

            ChartView.TransformationsChanged += ChartView_TransformationsChanged;
        }

        void ChartView_TransformationsChanged(object sender, string e)
        {
            //     <x:String>No Transform</x:String>
            //  <x:String>Change</x:String>
            //  <x:String>% Change</x:String>
            //  <x:String>Cumulative</x:String>
            // transformation=none|diff|rdiff|cumul|normalize
            // https://www.quandl.com/help/api 
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
