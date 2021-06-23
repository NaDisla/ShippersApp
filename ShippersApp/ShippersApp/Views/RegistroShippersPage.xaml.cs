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
            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPhone.Text))
                await DisplayAlert("Campos vacíos", "Por favor complete los campos.", "OK");

            Shippers shipper = new Shippers()
            {
                CompanyName = txtNombre.Text,
                Phone = txtPhone.Text
            };
            try
            {
                json = JsonConvert.SerializeObject(shipper);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(urlApi, content);

                if (result.IsSuccessStatusCode)
                    await DisplayAlert("Registro satisfactorio", "Se ha registrado el transportista correctamente.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Registro erróneo", $"Ha ocurrido un error en la inserción de los datos: {ex.Message}", "OK");
            }
            
        }
    }
}