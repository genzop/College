using Newtonsoft.Json;
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
    public partial class Pedidos : ContentPage
    {

        protected List<PedidoVenta> listaPedidos;        
        private int IdVendedor { get; set; }

        public Pedidos(int idVendedor)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Se guarda el id del vendedor que se le logueo
            this.IdVendedor = idVendedor;
            cargarPedidos();                                  
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
             
        private async void listPedidos_ItemTapped(object sender, ItemTappedEventArgs e)
        {                    
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

            //Se redirecciona a la pagina Editar Pedido con el pedido seleccionado
            await Navigation.PushModalAsync(new EditarPedido((PedidoVenta)e.Item, this.IdVendedor));            
        }       

        private void imgExportar_Tapped(object sender, EventArgs e)
        {
            //Cargar todos los pedidos editables de este vendedor  
            List<PedidoVenta> pedidosExportar;                     
            using(var cPedidos = new ControladorPedidoVenta())
            {
                pedidosExportar = cPedidos.FindForExport(this.IdVendedor);
            }

            //Por cada pedido encontrado
            foreach (PedidoVenta pedExportar in pedidosExportar)
            {
                //Se guarda el domicilio
                Domicilio domExportar;
                using (var cDomicilio = new ControladorDomicilio())
                {
                    domExportar = cDomicilio.FindById(pedExportar.IdDomicilio);
                }

                //Se guardan sus detalles
                List<PedidoVentaDetalle> detExportar;
                using (var cDetalle = new ControladorPedidoVentaDetalle())
                {
                    detExportar = cDetalle.FindByPedidoVenta(pedExportar.IdPedidoVenta);
                }

                //Se pasan a formato JSON
                var pedidoJson = JsonConvert.SerializeObject(pedExportar, Newtonsoft.Json.Formatting.Indented);
                var domicilioJson = JsonConvert.SerializeObject(domExportar, Newtonsoft.Json.Formatting.Indented);
                var detallesJson = JsonConvert.SerializeObject(detExportar, Newtonsoft.Json.Formatting.Indented);

                //Se crea una lista de parejas
                var parejas = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("pedido", pedidoJson),
                    new KeyValuePair<string, string>("domicilio", domicilioJson),
                    new KeyValuePair<string, string>("detalles", detallesJson)
                };

                //Se le da formato de formulario
                var contenido = new FormUrlEncodedContent(parejas);

                //Se envia el pedido, su domicilio y sus detalles correspondientes al servidor
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://192.168.1.38:63942/");
                string url = string.Format("/Importar.aspx");
                var respuesta = clienteHttp.PostAsync(url, contenido).Result;

                //Si fue exitosa la operacion se muestra un mensaje
                if (respuesta.IsSuccessStatusCode)
                {
                    DisplayAlert("Exportacion exitosa", "Los datos fueron enviados al servidor exitosamente", "Aceptar");
                }
            }
        }

        private async void imgInsertar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditarPedido(null, this.IdVendedor));
        }

        private void cargarPedidos()
        {
            //Se cargan los pedidos correspondientes a ese vendedor
            using (var pedControlador = new ControladorPedidoVenta())
            {
                this.listaPedidos = pedControlador.FindByVendedor(this.IdVendedor);
            }

            listPedidos.ItemsSource = listaPedidos;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            cargarPedidos();
        }
    }
}
