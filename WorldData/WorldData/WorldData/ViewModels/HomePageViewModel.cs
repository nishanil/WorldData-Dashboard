using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorldData.Repository;
using Xamarin.Forms;

namespace WorldData.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ObservableCollection<DataItem> data;

        public ObservableCollection<DataItem> Data
        {
            get { return data; }
            set { data = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Item> itemsSource;

        public ObservableCollection<Item> ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; RaisePropertyChanged(); }
        }


        public HomePageViewModel()
        {
            var worldRepository = new WorldDataRepository();

            Data = new ObservableCollection<DataItem>();
            ItemsSource = new ObservableCollection<Item>();

            worldRepository.GetCountries().ContinueWith((list) =>
            {
                var countries = list.Result;
                var data = new ObservableCollection<DataItem>();
                foreach (var item in countries)
                {
                    ItemsSource.Add(new Item { Name = item.Name, Change = item.Chg1Y, IsChangePositive = item.IsChangePositive});
                }
                foreach (var region in worldRepository.CountriesByRegion)
                {
                    var dataItem = new DataItem();
                    dataItem.Label = region.Key;
                    dataItem.Level = region.Value.Sum(x => x.Level.ToDouble());
                    data.Add(dataItem);
                }
                Data = data;
            });

        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Change { get; set; }

        public bool IsChangePositive { get; set; }

    }
}
