using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoFinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


        }

        private void btnLogIn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Pedidos();
            
        }
















        private async void probarConexion()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://192.168.1.38:63942/");
            string url = string.Format("/Exportar.asmx/getVendedores");
            var respuesta = await cliente.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;

        }
    }
}
