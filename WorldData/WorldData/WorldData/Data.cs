using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;

namespace WorldData
{
    public class DataItem : ObservableObject
    {
        private string label;

        public string Label
        {
            get { return label; }
            set { label = value; RaisePropertyChanged(); }
        }

        private double value;

        public double Value
        {
            get { return value; }
            set { value = value; RaisePropertyChanged(); }
        }

        private double level;

        public double Level
        {
            get { return level; }
            set { level = value; }
        }
        

    }

}
