using ShippersApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShippersApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ShippersPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
