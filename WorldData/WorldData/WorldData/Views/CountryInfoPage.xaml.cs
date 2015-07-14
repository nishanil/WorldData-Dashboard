using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.XF.Controls;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class CountryInfoPage : ContentPage
    {
        public CountryInfoPage()
        {
            InitializeComponent();
         
            // binding context set by calling page
           // BindingContext = new CountryInfoPageViewModel();

         
        }
    }
}
