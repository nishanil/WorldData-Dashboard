using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryInfoPage : ContentPage
    {
        public CountryInfoPage()
        {
            InitializeComponent();
            this.Title = "Country Info";

            BindingContext = new CountryInfoPageViewModel();
        }
    }
}
