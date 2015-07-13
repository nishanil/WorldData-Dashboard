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
    public partial class HomePage : ContentPage
    {
        protected XFPieChart chartView;
        public HomePage()
        {
            InitializeComponent();
            

            BindingContext = new HomePageViewModel();
            chartView = (pieChart as XFPieChart);
            chartView.SliceClick += chartView_SliceClick;

        }

        void chartView_SliceClick(object sender, SliceClickEventArgs e)
        {
            e.IsExploded = !e.IsExploded;
        }
    }
}
