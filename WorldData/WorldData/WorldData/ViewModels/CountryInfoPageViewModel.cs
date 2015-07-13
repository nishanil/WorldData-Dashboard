using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldData.ViewModels
{
    public class CountryInfoPageViewModel : ViewModelBase
    {

        public CountryInfoPageViewModel()
        {
            OverlayOpacity = 0.5;
            QuandlData.GetFinancialData("https://www.quandl.com/api/v1/datasets/WIKI/AAPL.json", "yz1ovVBpJ6TC8viUCSLs")
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

        private FinancialData _data;
        public FinancialData Data
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
