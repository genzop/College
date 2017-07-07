using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Controladores;
using TrabajoFinalApp.Modelo;
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
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;

            using (var cVendedor = new ControladorVendedor())
            {
                var vendedor = cVendedor.FindByUser(usuario);
                //Si el usuario existe
                if(vendedor != null)
                {
                    if(vendedor.Contrasenia == contrasenia)
                    {
                        App.Current.MainPage = new Pedidos(vendedor.IdVendedor);
                    }
                    else
                    {
                        DisplayAlert("Error", "La contraseña ingresada no es correcta", "Aceptar");
                        txtContrasenia.Text = "";
                        txtContrasenia.Focus();
                    }
                }else
                {
                    DisplayAlert("Error", "El usuario ingresado no existe", "Aceptar");
                    txtUsuario.Text = "";
                    txtContrasenia.Text = "";
                    txtUsuario.Focus();
                }                
            }                       
        }
        
        private void imgImportar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Error Critico", "Esta parte todavia no hace nada", "Aceptar");
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
