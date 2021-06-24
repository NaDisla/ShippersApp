using Newtonsoft.Json;
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
    public partial class DeleteShipperPage : ContentPage
    {
        string urlApi = "https://masterdetailapi.conveyor.cloud/shippers";
        HttpClient client = new HttpClient();

        public DeleteShipperPage()
        {
            InitializeComponent();
        }

        private async void btnDeleteShipper_Clicked(object sender, EventArgs e)
        {
            urlApi += $"/{txtShipperID.Text}";
            var result = await client.DeleteAsync(urlApi);

            if (result.IsSuccessStatusCode)
                await DisplayAlert("Eliminación correcta", "Se ha eliminado el transportista correctamente.", "OK");
            else
                await DisplayAlert("Eliminación incorrecta", "Ha ocurrido un error.", "OK");
        }
    }
}