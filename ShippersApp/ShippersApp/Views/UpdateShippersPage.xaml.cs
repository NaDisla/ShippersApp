using Newtonsoft.Json;
using ShippersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShippersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateShippersPage : ContentPage
    {
        string _id, _companyName, _phone;
        string urlApi = "https://masterdetailapi.conveyor.cloud/shippers";
        string json;
        HttpClient client = new HttpClient();

        public UpdateShippersPage(int id, string companyName, string phone)
        {
            InitializeComponent();
            _id = id.ToString();
            _companyName = companyName;
            _phone = phone;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtShipperID.Text = _id;
            txtCompanyName.Text = _companyName;
            txtPhone.Text = _phone;
        }

        private async void btnUpdateInfo_Clicked(object sender, EventArgs e)
        {
            Shippers shipper = new Shippers()
            {
                ShipperID = int.Parse(txtShipperID.Text),
                CompanyName = txtCompanyName.Text,
                Phone = txtPhone.Text
            };
            json = JsonConvert.SerializeObject(shipper);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            urlApi += $"/{txtShipperID.Text}";
            var result = await client.PutAsync(urlApi, content);

            if (result.IsSuccessStatusCode)
                await DisplayAlert("Update correcto", "Se ha actualizado el transportista correctamente.", "OK");
            else
                await DisplayAlert("Update incorrecto", "Ha ocurrido un error.", "OK");
        }
    }
}