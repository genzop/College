using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected ObservableCollection<PedidoVenta> listaPedidos;        
        private int IdVendedor { get; set; }
        private string Direccion { get; set; }

        public Pedidos(int idVendedor, string direccion)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Se guarda el id del vendedor que se le logueo
            this.IdVendedor = idVendedor;
            this.Direccion = direccion;
            cargarPedidos();                                  
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listPedidos.BeginRefresh();

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                cargarPedidos();
            }
            else
            {
                //Se cargan los pedidos correspondientes a ese vendedor
                using (var pedControlador = new ControladorPedidoVenta())
                {
                    this.listaPedidos = new ObservableCollection<PedidoVenta>(pedControlador.FindByVendedorAndRazonSocial(this.IdVendedor, e.NewTextValue));
                }

                listPedidos.ItemsSource = listaPedidos;
            }

            listPedidos.EndRefresh();
        }
             
        private async void listPedidos_ItemTapped(object sender, ItemTappedEventArgs e)
        {                    
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

            //Se redirecciona a la pagina Editar Pedido con el pedido seleccionado
            await Navigation.PushModalAsync(new EditarPedido((PedidoVenta)e.Item, this.IdVendedor));            
        }       

        private async void imgExportar_Tapped(object sender, EventArgs e)
        {
            var confirmacion = await DisplayAlert("Confirmar exportacion", "A continuacion se exportaran todos los pedidos que hayan sido creados ¿Desea continuar?", "Si", "Cancelar");

            if (confirmacion)
            {
                //Cargar todos los pedidos editables de este vendedor  
                List<PedidoVenta> pedidosExportar;
                bool operacionExitosa = true;

                using (var cPedidos = new ControladorPedidoVenta())
                {
                    pedidosExportar = cPedidos.FindForExport(this.IdVendedor);
                }

                //Por cada pedido encontrado
                foreach (PedidoVenta pedExportar in pedidosExportar)
                {
                    //Se cambia el atributo "editable" en todos los pedidos que fueron exportados
                    pedExportar.Editable = false;                    
                    using (var pControlador = new ControladorPedidoVenta())
                    {
                        pControlador.Update(pedExportar);
                    }                    

                    //Se guardan sus detalles
                    List<PedidoVentaDetalle> detExportar;
                    using (var cDetalle = new ControladorPedidoVentaDetalle())
                    {
                        detExportar = cDetalle.FindByPedidoVenta(pedExportar.IdPedidoVenta);
                    }

                    //Se pasan a formato JSON
                    var pedidoJson = JsonConvert.SerializeObject(pedExportar, Newtonsoft.Json.Formatting.Indented);                    
                    var detallesJson = JsonConvert.SerializeObject(detExportar, Newtonsoft.Json.Formatting.Indented);

                    //Se crea una lista de parejas
                    var parejas = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("pedido", pedidoJson),
                        new KeyValuePair<string, string>("detalles", detallesJson)
                    };

                    //Se le da formato de formulario
                    var contenido = new FormUrlEncodedContent(parejas);

                    //Se envia el pedido y sus detalles correspondientes al servidor
                    HttpClient clienteHttp = new HttpClient();
                    clienteHttp.BaseAddress = new Uri(this.Direccion);
                    string url = string.Format("/Importar.aspx");
                    var respuesta = clienteHttp.PostAsync(url, contenido).Result;
                                        
                    if (!respuesta.IsSuccessStatusCode)
                    {
                        operacionExitosa = false;                        
                    }
                }
                
                //Si fue exitosa la operacion se muestra un mensaje
                if (operacionExitosa)
                {
                    if (pedidosExportar.Count > 0)
                    {
                        await DisplayAlert("Exportacion exitosa", "Los pedidos se exportaron exitosamente", "Aceptar");
                        App.Current.MainPage = new Pedidos(this.IdVendedor, this.Direccion);
                    }
                    else
                    {
                        await DisplayAlert("Exportacion fallida", "No hay ningun pedido para exportar", "Aceptar");
                    }                    
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
                this.listaPedidos = new ObservableCollection<PedidoVenta>(pedControlador.FindByVendedor(this.IdVendedor));
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
