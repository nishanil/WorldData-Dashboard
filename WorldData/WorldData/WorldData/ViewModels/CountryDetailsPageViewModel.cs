using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldData.Models;

namespace WorldData.ViewModels
{
    public class CountryDetailsPageViewModel : ViewModelBase
    {
        private Country country;
        public Country Country
        {
            get { return country; }
            set { country = value; RaisePropertyChanged(); }
        }

        private bool showOverlay;

        public bool ShowOverlay
        {
            get { return showOverlay; }
            set { showOverlay = value; RaisePropertyChanged(); }
        }

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        private string chartTitle;

        public string ChartTitle
        {
            get { return chartTitle; }
            set { chartTitle = value; RaisePropertyChanged(); }
        }
        
        public CountryDetailsPageViewModel(Country selectedCountry, string selectedItem)
        {
            country = selectedCountry;
            SelectedItem = selectedItem;
            GetData();
        }

        public void GetData(string transformation = null, string frequency = null)
        {
            switch (SelectedItem)
            {
                case "Birth and Death":
                    GetLifeExpectancy(transformation, frequency);
                    break;
                case "Health and Disease":
                    GetHealthExpenditure(transformation, frequency);
                    break;
                case "Education":
                    GetAdultLiteracyRate(transformation, frequency);
                    break;
                case "Economic Activity":
                    GetGdpPerCapita(transformation, frequency);
                    break;
            }
        }

        private QuandlInfoData data;
        public QuandlInfoData Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                RaisePropertyChanged();
            }
        }

        public void GetLifeExpectancy(string transformation = null, string frequency = null)
        {
            ShowOverlay = true;
            QuandlData.GetData(country.AreaCode.ToLower(), "SP_DYN_LE00_IN", transformation, frequency).ContinueWith((data) =>
            {
                Data = data.Result;
                ChartTitle = Data.DataName;
                ShowOverlay = false;
            });
        }

        public void GetHealthExpenditure(string transformation = null, string frequency = null)
        {
            ShowOverlay = true;
            QuandlData.GetData(country.AreaCode.ToLower(), "SH_XPD_PCAP_PP_KD", transformation, frequency).ContinueWith((data) =>
            {
                Data = data.Result;
                ChartTitle = Data.DataName;
                ShowOverlay = false;
            });
        }

        public void GetAdultLiteracyRate(string transformation = null, string frequency = null)
        {
            ShowOverlay = true;
            QuandlData.GetData(country.AreaCode.ToLower(), "SE_ADT_LITR_ZS", transformation, frequency).ContinueWith((data) =>
            {
                Data = data.Result;
                ChartTitle = Data.DataName;
                ShowOverlay = false;
            });
        }

        public void GetGdpPerCapita(string transformation = null, string frequency = null)
        {
            ShowOverlay = true;
            QuandlData.GetData(country.AreaCode.ToLower(), "NY_GDP_PCAP_PP_CD", transformation, frequency).ContinueWith((data) =>
            {
                Data = data.Result;
                ChartTitle = Data.DataName;
                ShowOverlay = false;
            });
        }
       
    }
}
