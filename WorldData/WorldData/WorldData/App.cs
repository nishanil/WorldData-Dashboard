using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldData.Views;
using Xamarin.Forms;

namespace WorldData
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var navPage = new NavigationPage(new CountryInfoPage());
            navPage.BarTextColor = Theme.PrimaryColor;
            MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
