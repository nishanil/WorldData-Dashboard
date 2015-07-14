using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.XF.Controls;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class HomePage : ContentPage
    {
        protected XFPieChart chartView;
        private HomePageViewModel vm;
        public HomePage()
        {
            InitializeComponent();
            

            BindingContext = vm =  new HomePageViewModel();
            chartView = (pieChart as XFPieChart);
            chartView.SliceClick += chartView_SliceClick;

            searchBar.TextChanged += searchBar_TextChanged;

            CountryListView.ItemTapped += (sender, args) =>
            {
                ((ListView) sender).SelectedItem = null;
            };

            CountryListView.ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem == null) return; 
                var selectedItem = vm.Countries.First(x => x.Name == (args.SelectedItem as Item).Name);
                var countryInfoPage = new CountryInfoPage {BindingContext = new CountryInfoPageViewModel(selectedItem)};
                Navigation.PushAsync(countryInfoPage, true);
            };
        }

        void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PerformSearch(searchBar.Text);
        }

        private void PerformSearch(string searchtext)
        {
            CountryListView.BeginRefresh();

            CountryListView.ItemsSource = string.IsNullOrEmpty(searchtext) ? vm.ItemsSource : vm.ItemsSource.Where(x => x.Name.ToLower().Contains(searchtext.ToLower()));
            CountryListView.EndRefresh();
        }

        void chartView_SliceClick(object sender, SliceClickEventArgs e)
        {
            e.IsExploded = !e.IsExploded;
        }
    }
}
