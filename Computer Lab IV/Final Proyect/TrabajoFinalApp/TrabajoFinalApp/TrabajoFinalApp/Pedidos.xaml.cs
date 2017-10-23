using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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

        protected ObservableCollection<Pedido> listaPedidos;        
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
            if (imgExportar.IsVisible)
            {
                listPedidos.BeginRefresh();

                if (string.IsNullOrEmpty(e.NewTextValue))
                {
                    cargarPedidos();
                }
                else
                {
                    //Se cargan los pedidos correspondientes a ese vendedor
                    using (var pedControlador = new ControladorPedido())
                    {
                        this.listaPedidos = new ObservableCollection<Pedido>(pedControlador.FindByVendedorAndRazonSocial(this.IdVendedor, e.NewTextValue));
                    }

                    listPedidos.ItemsSource = listaPedidos;
                }

                listPedidos.EndRefresh();
            }
            else
            {
                DisplayAlert("Error", "Debe esperar que terminen de enviarse los datos para poder continuar.", "Aceptar");
            }            
        }
             
        private async void listPedidos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (imgExportar.IsVisible)
            {
                //No se muestra el item seleccionado
                ((ListView)sender).SelectedItem = null;

                //Se redirecciona a la pagina Editar Pedido con el pedido seleccionado
                await Navigation.PushModalAsync(new EditarPedido((Pedido)e.Item, this.IdVendedor));
            }
            else
            {
                await DisplayAlert("Error", "Debe esperar que terminen de enviarse los datos para poder continuar.", "Aceptar");
            }                      
        }       

        private async void imgExportar_Tapped(object sender, EventArgs e)
        {
            var confirmacion = await DisplayAlert("Confirmar exportacion", "A continuacion se exportaran todos los pedidos que hayan sido creados ¿Desea continuar?", "Si", "Cancelar");

            if (confirmacion)
            {
                imgExportar.IsVisible = false;
                exportarIndicator.IsVisible = true;
                
                await exportarPedidos();
            }
        }

        private async void imgInsertar_Tapped(object sender, EventArgs e)
        {
            if (imgExportar.IsVisible)
            {
                await Navigation.PushModalAsync(new EditarPedido(null, this.IdVendedor));
            }
            else
            {
                await DisplayAlert("Error", "Debe esperar que terminen de enviarse los datos para poder continuar.", "Aceptar");
            }            
        }

        private void cargarPedidos()
        {
            //Se cargan los pedidos correspondientes a ese vendedor
            using (var pedControlador = new ControladorPedido())
            {
                this.listaPedidos = new ObservableCollection<Pedido>(pedControlador.FindByVendedor(this.IdVendedor));
            }

            listPedidos.ItemsSource = listaPedidos;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            cargarPedidos();
        }
        

        private async Task exportarPedidos()
        {
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri(Direccion);
                string url = string.Format("/Exportar.aspx?exportar=vendedores");
                var respuesta = await clienteHttp.GetAsync(url);

                //Cargar todos los pedidos editables de este vendedor  
                List<Pedido> pedidosExportar;
                bool operacionExitosa = true;

                using (var cPedidos = new ControladorPedido())
                {
                    pedidosExportar = cPedidos.FindForExport(this.IdVendedor);
                }

                //Por cada pedido encontrado
                foreach (Pedido pedExportar in pedidosExportar)
                {
                    //Se cambia el atributo "editable" en todos los pedidos que fueron exportados
                    pedExportar.Editable = false;
                    using (var pControlador = new ControladorPedido())
                    {
                        pControlador.Update(pedExportar);
                    }

                    //Se guardan sus detalles
                    List<Detalle> detExportar;
                    using (var cDetalle = new ControladorDetalle())
                    {
                        detExportar = cDetalle.FindByPedido(pedExportar.IdPedido);
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
                    clienteHttp = new HttpClient();
                    clienteHttp.BaseAddress = new Uri(this.Direccion);
                    url = string.Format("/Importar.aspx");
                    respuesta = clienteHttp.PostAsync(url, contenido).Result;

                    if (!respuesta.IsSuccessStatusCode)
                    {
                        operacionExitosa = false;
                    }
                }

                //Si fue exitosa la operacion se muestra un mensaje
                if (operacionExitosa)
                {
                    exportarIndicator.IsVisible = false;
                    imgExportar.IsVisible = true;
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
            catch (Exception)
            {
                await DisplayAlert("Error de conexión", "No se pudo descargar la informacion del sitio web. Compruebe que su conexión a internet este funcionando correctamente.", "Aceptar");
            }            
        }
    }
}
