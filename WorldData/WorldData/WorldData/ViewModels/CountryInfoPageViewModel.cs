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
            OverlayOpacity = 0.5;
            
            Country = selectedCountry;

            QuandlData.GetPopulationDataAsync("yz1ovVBpJ6TC8viUCSLs", selectedCountry.AreaCode.ToLower(), "SP_POP_TOTL")
                .ContinueWith((data) =>
            {
                StatusText = "";
                Data = data.Result;
                OverlayOpacity = 0;

                
            });


            ItemsSource = new List<Item>
            {
                new Item{ Name = "Birth and Death"},
                new Item{ Name = "Health and Disease"},
                new Item{ Name = "Education"},
            };


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

        private string _statusText = "Downloading...";
        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                _statusText = value;
                RaisePropertyChanged();
            }
        }


        private List<Item> itemsSource;

        public List<Item> ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; }
        }

        private double overlayOpacity;

        public double OverlayOpacity
        {
            get { return overlayOpacity; }
            set { overlayOpacity = value; RaisePropertyChanged(); }
        }
        
        

    }

   
}
