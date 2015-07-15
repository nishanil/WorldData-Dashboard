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
            GetLifeExpectancy();

            ItemsSource = new List<Item>
            {
                new Item{ Name = "Birth and Death"},
                new Item{ Name = "Health and Disease"},
                new Item{ Name = "Education"},
            };


        }

        public void GetPopulation(string transformation=null, string frequency=null)
        {
            ShowOverlay = true;
            QuandlData.GetQuandlInfoDataAsync("yz1ovVBpJ6TC8viUCSLs", Country.AreaCode.ToLower(), "SP_POP_TOTL", transformation, collapse:frequency)
                .ContinueWith((data) =>
                {
                    PopulationData = data.Result;
                    ShowOverlay = false;
                });
        }

        public void GetLifeExpectancy(string transformation = null)
        {

            QuandlData.GetQuandlInfoDataAsync("yz1ovVBpJ6TC8viUCSLs", Country.AreaCode.ToLower(), "SP_DYN_LE00_IN", transformation)
                .ContinueWith((data) =>
                {
                    LifeExpenctancyData = data.Result;
                });
        }

        private QuandlInfoData _popdata;
        public QuandlInfoData PopulationData
        {
            get
            {
                return _popdata;
            }
            set
            {
                _popdata = value;
                RaisePropertyChanged();
            }
        }

        private QuandlInfoData _lifedata;
        public QuandlInfoData LifeExpenctancyData
        {
            get
            {
                return _lifedata;
            }
            set
            {
                _lifedata = value;
                RaisePropertyChanged();
            }
        }

        private List<Item> itemsSource;

        public List<Item> ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; }
        }

        private bool showOverlay;

        public bool ShowOverlay
        {
            get { return showOverlay; }
            set { showOverlay = value; RaisePropertyChanged(); }
        }

    }

   
}
