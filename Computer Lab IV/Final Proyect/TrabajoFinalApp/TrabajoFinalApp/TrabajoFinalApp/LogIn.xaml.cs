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
        
        private async void imgImportar_Tapped(object sender, EventArgs e)
        {
            var confirmacion = await DisplayAlert("Confirmar importacion", "A continuacion se descargara la informacion necesaria del servidor ¿Desea continuar?", "Si", "Cancelar");

            if (confirmacion)
            {
                importarVendedores();
                importarClientes();
                importarArticulos();
                importarPedidos();                
            }            
        }

        private async void importarVendedores()
        {
            //Se eliminan todos los vendedores
            using (var cVendedor = new ControladorVendedor())
            {
                cVendedor.DeleteAll();
            }

            //Se hace el request al servidor
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://192.168.1.38:63942/");
            string url = string.Format("/Exportar.aspx?exportar=vendedores");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Vendedor> vendedores = JsonConvert.DeserializeObject<List<Vendedor>>(resultado);

            //Se persisten a la base de datos
            using (var cVendedor = new ControladorVendedor())
            {
                foreach (Vendedor vend in vendedores)
                {
                    cVendedor.Insert(vend);
                }
            }
        }

        private async void importarClientes()
        {
            //Se eliminan todos los clientes
            using (var cCliente = new ControladorCliente())
            {
                cCliente.DeleteAll();
            }

            //Se hace el request al servidor
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://192.168.1.38:63942/");
            string url = string.Format("/Exportar.aspx?exportar=clientes");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultado);

            //Se persisten a la base de datos
            using (var cCliente = new ControladorCliente())
            {
                foreach (Cliente cli in clientes)
                {
                    cCliente.Insert(cli);
                }
            }
        }

        private async void importarArticulos()
        {
            //Se eliminan todos los articulos
            using (var cArticulo = new ControladorArticulo())
            {
                cArticulo.DeleteAll();
            }

            //Se hace el request al servidor
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://192.168.1.38:63942/");
            string url = string.Format("/Exportar.aspx?exportar=articulos");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Articulo> articulos = JsonConvert.DeserializeObject<List<Articulo>>(resultado);

            //Se persisten a la base de datos
            using (var cArticulo = new ControladorArticulo())
            {
                foreach (Articulo art in articulos)
                {
                    cArticulo.Insert(art);
                }
            }
        }

        private async void importarPedidos()
        {
            
            //Se eliminan todos los detalles
            using (var cDetalle = new ControladorPedidoVentaDetalle())
            {
                cDetalle.DeleteAll();
            }

            //Se eliminan todos los pedidos
            using (var cPedido = new ControladorPedidoVenta())
            {
                cPedido.DeleteAll();
            }

            //Se eliminan todos los domicilios
            using (var cDomicilio = new ControladorDomicilio())
            {
                cDomicilio.DeleteAll();
            }
            
            //Se importan todos los pedidos
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://192.168.1.38:63942/");
            string url = string.Format("/Exportar.aspx?exportar=pedidos");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<PedidoVenta> pedidos = JsonConvert.DeserializeObject<List<PedidoVenta>>(resultado);
                        
            //Se importan todos domicilios
            url = string.Format("/Exportar.aspx?exportar=domicilios");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Domicilio> domicilios = JsonConvert.DeserializeObject<List<Domicilio>>(resultado);
            
            //Se importan todos los detalles
            url = string.Format("/Exportar.aspx?exportar=detalles");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<PedidoVentaDetalle> detalles = JsonConvert.DeserializeObject<List<PedidoVentaDetalle>>(resultado);
            

            //Por cada pedido
            foreach (PedidoVenta pedido in pedidos)
            {
                int idPedidoSeleccionado = pedido.IdPedidoVenta;

                //Se guarda el domicilio correspondiente
                Domicilio domCorrespondiente = new Domicilio();
                foreach (Domicilio dom in domicilios)
                {
                    if(dom.IdDomicilio == pedido.IdDomicilio)
                    {
                        domCorrespondiente = dom;
                    }
                }

                //Se persiste el domicilio
                using (var cDomicilio = new ControladorDomicilio())
                {
                    cDomicilio.Insert(domCorrespondiente);
                }

                //Se actualiza el IdDomicilio en el pedido
                pedido.IdDomicilio = domCorrespondiente.IdDomicilio;

                using (var cCliente = new ControladorCliente())
                {
                    var clienteCorrespondiente = cCliente.FindById(pedido.IdCliente);
                    pedido.Cliente = clienteCorrespondiente.RazonSocial;
                }

                //Se persiste el pedido
                using (var cPedidos = new ControladorPedidoVenta())
                {
                    cPedidos.Insert(pedido);
                }

                //Se buscan los detalles que correspondan a ese pedido
                foreach (PedidoVentaDetalle detalle in detalles)
                {
                    if (detalle.IdPedidoVenta == idPedidoSeleccionado)
                    {
                        //Se actualiza el IdPedidoVenta en cada detalle
                        detalle.IdPedidoVenta = pedido.IdPedidoVenta;
                        detalle.PorcentajeDescuento = detalle.PorcentajeDescuento * 100;

                        using(var cArticulo = new ControladorArticulo())
                        {
                            var articuloCorrespondiente = cArticulo.FindById(detalle.IdArticulo);
                            detalle.Articulo = articuloCorrespondiente.Denominacion;
                            detalle.PrecioUnitario = articuloCorrespondiente.PrecioVenta;
                        }

                        //Se persiste el detalle
                        using(var cDetalle = new ControladorPedidoVentaDetalle())
                        {
                            cDetalle.Insert(detalle);
                        }
                    }
                }

                await DisplayAlert("Descarga exitosa", "Los datos se descargaron exitosamente", "Aceptar");
            }       
        }
    }
}
