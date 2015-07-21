using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using WorldData.Models;
using WorldData.Repository;

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

        private ObservableCollection<CountryItem> itemsSource;

        public ObservableCollection<CountryItem> ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; RaisePropertyChanged(); }
        }

        private string worldPopulation;

        public string WorldPopulation
        {
            get { return worldPopulation; }
            set { worldPopulation = value; RaisePropertyChanged(); }
        }

        private string lifeExpectancy;

        public string LifeExpectancy
        {
            get { return lifeExpectancy; }
            set { lifeExpectancy = value; RaisePropertyChanged(); }
        }

        public List<Country> Countries { get; set; }

        public HomePageViewModel()
        {
            var worldRepository = new WorldDataRepository();

            Data = new ObservableCollection<DataItem>();
            ItemsSource = new ObservableCollection<CountryItem>();

            worldRepository.GetCountries().ContinueWith(list =>
            {
                Countries = list.Result;
                var dataItems = new ObservableCollection<DataItem>();
                foreach (var item in Countries)
                {
                    var countryItem = new CountryItem
                    {
                        Name = item.Name,
                        Change = item.Chg1Y,
                        IsChangePositive = item.IsChangePositive
                    };
                    double val = 0.0;
                    double.TryParse(item.LifeExpectancy, out val);
                    countryItem.LifeExpectancy = val;
                    ItemsSource.Add(countryItem);

                }
                foreach (var region in worldRepository.CountriesByRegion)
                {
                    var dataItem = new DataItem {Label = region.Key, Level = region.Value.Sum(x => x.Level.ToDouble())};
                    dataItems.Add(dataItem);
                }
                WorldPopulation = dataItems.Sum(l => l.Level * 1000).ToString("#,##0,,,.B", CultureInfo.InvariantCulture);
                LifeExpectancy = ItemsSource.Average(x => x.LifeExpectancy).ToString("00.00", CultureInfo.InvariantCulture);
                Data = dataItems;
            });

        }
    }

    public class CountryItem
    {
        public string Name { get; set; }
        public string Change { get; set; }

        public double LifeExpectancy { get; set; }
        public bool IsChangePositive { get; set; }

    }
}
