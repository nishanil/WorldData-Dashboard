using System;
using System.Globalization;
using Newtonsoft.Json.Schema;

namespace WorldData.Models
{
    public class Country : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private string areaCode;

        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; RaisePropertyChanged(); }
        }

        private string regionName;

        public string RegionName
        {
            get { return regionName; }
            set { regionName = value; RaisePropertyChanged(); }
        }

        private string level;

        public string Level
        {
            get { return level; }
            set { level = value; RaisePropertyChanged(); }
        }

      
        private int units;

        public int Units
        {
            get { return units; }
            set { units = value; RaisePropertyChanged(); }
        }

        private string asOf;

        public string AsOf
        {
            get { return asOf; }
            set { asOf = value; RaisePropertyChanged(); }
        }

        private string chg1y;

        public string Chg1Y
        {
            get { return chg1y; }
            set { chg1y = value; RaisePropertyChanged(); }
        }



        public bool IsChangePositive
        {
            get { return !(Chg1Y.StartsWith("-", StringComparison.OrdinalIgnoreCase)); }
        }

        private string year5;

        public string Year5
        {
            get { return year5; }
            set { year5 = value; RaisePropertyChanged(); }
        }

        private string year10;

        public string Year10
        {
            get { return year10; }
            set { year10 = value; RaisePropertyChanged(); }
        }

        private string year25;

        public string Year25
        {
            get { return year25; }
            set { year25 = value; RaisePropertyChanged(); }
        }

        private string lifeExpectancy;

        public string LifeExpectancy
        {
            get { return lifeExpectancy; }
            set { lifeExpectancy = value; RaisePropertyChanged(); }
        }

        private string healthExpenditure;

        public string HealthExpenditure
        {
            get { return healthExpenditure; }
            set { healthExpenditure = value; RaisePropertyChanged(); }
        }

        private string adultLiteracyRate;

        public string AdultLiteracyRate
        {
            get { return adultLiteracyRate; }
            set { adultLiteracyRate = value; RaisePropertyChanged(); }
        }
        
        
    }
}
