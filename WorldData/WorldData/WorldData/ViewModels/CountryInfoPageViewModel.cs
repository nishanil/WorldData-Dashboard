using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldData.Models;

namespace WorldData.ViewModels
{
    public class CountryInfoPageViewModel : ViewModelBase
    {
        private Country country;

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }
        

        public CountryInfoPageViewModel(Country selectedCountry)
        {
            
            Country = selectedCountry;
            GetPopulation();
            ItemsSource = new List<OthersListViewItem>
            {
                new OthersListViewItem{ Name = "Birth and Death"},
                new OthersListViewItem{ Name = "Health and Disease"},
                new OthersListViewItem{ Name = "Education"},
                new OthersListViewItem{ Name = "Economic Activity"},

            };
        }


        private QuandlInfoData popdata;
        public QuandlInfoData PopulationData
        {
            get
            {
                return popdata;
            }
            set
            {
                popdata = value;
                RaisePropertyChanged();
            }
        }

        public void GetPopulation(string transformation=null, string frequency=null)
        {
            ShowOverlay = true;
            QuandlData.GetData(country.AreaCode.ToLower(),"SP_POP_TOTL", transformation, frequency).ContinueWith((data) =>
            {
                PopulationData = data.Result;
                ShowOverlay = false;
            });
        }


        public List<OthersListViewItem> ItemsSource { get; set; }

        private bool showOverlay;

        public bool ShowOverlay
        {
            get { return showOverlay; }
            set { showOverlay = value; RaisePropertyChanged(); }
        }

    }

    public class OthersListViewItem
    {
        public string Name { get; set; }
    }
}
