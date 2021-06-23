using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using ShippersApp.Models;
using Newtonsoft.Json;

namespace ShippersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShippersPage : ContentPage
    {
        const string urlApi = "https://masterdetailapi.conveyor.cloud/shippers";
        string json;
        HttpClient client = new HttpClient();

        public ShippersPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetShippers();
        }
        async void GetShippers()
        {
            json = await client.GetStringAsync(urlApi);
            List<Shippers> getShippers = JsonConvert.DeserializeObject<List<Shippers>>(json);
            ShippersList.ItemsSource = getShippers;
        }

        [Obsolete]
        private async void btnAddShipperPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroShippersPage());
        }
    }
}