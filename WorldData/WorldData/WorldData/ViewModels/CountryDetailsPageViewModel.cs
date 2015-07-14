using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldData.ViewModels
{
    public class CountryDetailsPageViewModel : ViewModelBase
    {
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
    }
}
