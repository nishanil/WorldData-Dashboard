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


            ItemsSource = new List<Item>
            {
                new Item{ Name = "Birth and Death"},
                new Item{ Name = "Health and Disease"},
                new Item{ Name = "Education"},
            };


        }

        public void GetPopulation( string transformation=null)
        {
            ShowOverlay = true;
            QuandlData.GetPopulationDataAsync("yz1ovVBpJ6TC8viUCSLs", Country.AreaCode.ToLower(), "SP_POP_TOTL", transformation)
                .ContinueWith((data) =>
                {
                    Data = data.Result;
                    ShowOverlay = false;
                });
        }

        private PopulationData _data;
        public PopulationData Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
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
