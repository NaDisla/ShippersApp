using Newtonsoft.Json;
using ShippersApp.Models;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShippersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Obsolete]
    public partial class RegistroShippersPage : ContentPage
    {
        const string urlApi = "https://masterdetailapi.conveyor.cloud/shippers";
        string json;
        HttpClient client = new HttpClient();

        public RegistroShippersPage()
        {
            InitializeComponent();
        }

        private async void btnAddShipper_Clicked(object sender, EventArgs e)
        {
            Shippers shipper = new Shippers()
            {
                CompanyName = txtNombre.Text,
                Phone = txtPhone.Text
            };
            json = JsonConvert.SerializeObject(shipper);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync(urlApi, content);

            if (result.IsSuccessStatusCode)
                await DisplayAlert("Registro correcto", "Se ha registrado el transportista correctamente.", "OK");
            else
                await DisplayAlert("Registro incorrecto", "Ha ocurrido un error.", "OK");
        }
    }
}