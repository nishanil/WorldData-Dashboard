using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorldData.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private List<DataItem> data;

        public List<DataItem> Data
        {
            get { return data; }
            set { data = value; RaisePropertyChanged();}
        }

        private List<Item> itemsSource;

        public List<Item> ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; }
        }
        

        public HomePageViewModel()
        {
            
              Data = new List<DataItem>
              {
                  new DataItem { Label = "Europe", Value = 5 },
                  new DataItem { Label = "Africa", Value = 6 },
                  new DataItem { Label = "Oceania", Value = 3 },
                  new DataItem { Label = "South America", Value = 7 },
                  new DataItem { Label = "Asia", Value = 12 }

              };

              ItemsSource = new List<Item>
            {
                new Item{ Name = "India"},
                new Item{ Name = "China"},
                new Item{ Name = "America"},
                new Item{ Name = "Italy"},
                new Item{ Name = "Rome"},
                new Item{ Name = "United Kingdom"},
            };
        }
    }


    public class Item
    {
        public string Name { get; set; }


    }
}
