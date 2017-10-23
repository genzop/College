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
            if (imgImportar.IsVisible)
            {
                string usuario = txtUsuario.Text;
                string contrasenia = txtContrasenia.Text;

                using (var cVendedor = new ControladorVendedor())
                {
                    Vendedor vendedor = cVendedor.FindByUser(usuario);

                    if (vendedor != null && !vendedor.Administrador)
                    {
                        if (vendedor.Contrasenia == contrasenia)
                        {
                            App.Current.MainPage = new Pedidos(vendedor.IdVendedor, txtDireccionWeb.Text);
                        }
                        else
                        {
                            DisplayAlert("Error", "La contraseña ingresada no es correcta", "Aceptar");
                            txtContrasenia.Text = "";
                            txtContrasenia.Focus();
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "El usuario ingresado no existe", "Aceptar");
                        txtUsuario.Text = "";
                        txtContrasenia.Text = "";
                        txtUsuario.Focus();
                    }
                }
            }
            else
            {
                DisplayAlert("Error", "Debe esperar que terminen de descargarse los datos para poder continuar.", "Aceptar");
            }
                                 
        }
        
        private async void imgImportar_Tapped(object sender, EventArgs e)
        {
            var confirmacion = await DisplayAlert("Confirmar importacion", "A continuacion se descargara la informacion necesaria del servidor ¿Desea continuar?", "Si", "Cancelar");

            if (confirmacion)
            {
                imgImportar.IsVisible = false;
                importarIndicator.IsVisible = true;
                comprobarConexion();
            }
        }

        private async Task comprobarConexion()
        {
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
                string url = string.Format("/Exportar.aspx?exportar=vendedores");
                var respuesta = clienteHttp.GetAsync(url);
                
                await importarVendedores();
                await importarUbicaciones();
                await importarClientes();
                await importarArticulos();
                await importarPedidos();
                
            }
            catch (Exception)
            {
                await DisplayAlert("Error de conexión", "No se pudo descargar la informacion del sitio web. Compruebe que su conexión a internet este funcionando correctamente.", "Aceptar");
                importarIndicator.IsVisible = false;
                imgImportar.IsVisible = true;
            }
        }

        private async Task importarVendedores()
        {
            //Se eliminan todos los vendedores
            using (var cVendedor = new ControladorVendedor())
            {
                cVendedor.DeleteAll();
            }

            //Se hace el request al servidor
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
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

        private async Task importarUbicaciones()
        {
            //Elimina todos los Paises
            using (var cPais = new ControladorPais())
            {
                cPais.DeleteAll();
            }

            //Elimina todos las Provincias
            using (var cProvincia = new ControladorProvincia())
            {
                cProvincia.DeleteAll();
            }

            //Elimina todas las Localidades
            using(var cLocalidad = new ControladorLocalidad())
            {
                cLocalidad.DeleteAll();
            }

            //Importa los Paises
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
            string url = string.Format("/Exportar.aspx?exportar=paises");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Pais> paises = JsonConvert.DeserializeObject<List<Pais>>(resultado);

            //Importa las Provincias
            url = string.Format("/Exportar.aspx?exportar=provincias");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Provincia> provincias = JsonConvert.DeserializeObject<List<Provincia>>(resultado);

            //Importa las Localidades
            url = string.Format("/Exportar.aspx?exportar=localidades");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Localidad> localidades = JsonConvert.DeserializeObject<List<Localidad>>(resultado);

            //Persiste los Paises
            using (var cPais = new ControladorPais())
            {
                foreach (Pais pais in paises)
                {
                    cPais.Insert(pais);
                }
            }

            //Persiste las Provincias
            using (var cProvincia = new ControladorProvincia())
            {
                foreach (Provincia prov in provincias)
                {
                    cProvincia.Insert(prov);
                }
            }

            //Persiste las Localidades
            using (var cLocalidad = new ControladorLocalidad())
            {
                foreach (Localidad loc in localidades)
                {
                    cLocalidad.Insert(loc);
                }
            }

        }

        private async Task importarClientes()
        {
            //Se eliminan todos los domicilios
            using (var cDomicilio = new ControladorDomicilio())
            {
                cDomicilio.DeleteAll();
            }

            //Se eliminan todos los clientes
            using (var cCliente = new ControladorCliente())
            {
                cCliente.DeleteAll();
            }

            //Se importan los clientes
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
            string url = string.Format("/Exportar.aspx?exportar=clientes");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultado);

            //Se importan todos domicilios
            url = string.Format("/Exportar.aspx?exportar=domicilios");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Domicilio> domicilios = JsonConvert.DeserializeObject<List<Domicilio>>(resultado);

            //Se persisten los domicilios
            using(var cDomicilios = new ControladorDomicilio())
            {
                foreach (Domicilio dom in domicilios)
                {
                    cDomicilios.Insert(dom);
                }
            }

            //Se persisten a la base de datos
            using (var cCliente = new ControladorCliente())
            {
                foreach (Cliente cli in clientes)
                {
                    cCliente.Insert(cli);
                }
            }
        }

        private async Task importarArticulos()
        {
            //Se eliminan todos los articulos
            using (var cArticulo = new ControladorArticulo())
            {
                cArticulo.DeleteAll();
            }

            //Se hace el request al servidor
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
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

        private async Task importarPedidos()
        {            
            //Se eliminan todos los detalles
            using (var cDetalle = new ControladorDetalle())
            {
                cDetalle.DeleteAll();
            }

            //Se eliminan todos los pedidos
            using (var cPedido = new ControladorPedido())
            {
                cPedido.DeleteAll();
            }            
            
            //Se importan todos los pedidos
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(txtDireccionWeb.Text);
            string url = string.Format("/Exportar.aspx?exportar=pedidos");
            var respuesta = await clienteHttp.GetAsync(url);
            var resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Pedido> pedidos = JsonConvert.DeserializeObject<List<Pedido>>(resultado);           
            
            //Se importan todos los detalles
            url = string.Format("/Exportar.aspx?exportar=detalles");
            respuesta = await clienteHttp.GetAsync(url);
            resultado = respuesta.Content.ReadAsStringAsync().Result;
            List<Detalle> detalles = JsonConvert.DeserializeObject<List<Detalle>>(resultado);
            
            //Por cada pedido
            foreach (Pedido pedido in pedidos)
            {
                int idPedidoSeleccionado = pedido.IdPedido;
                
                using (var cCliente = new ControladorCliente())
                {
                    var clienteCorrespondiente = cCliente.FindById(pedido.IdCliente);
                    pedido.Cliente = clienteCorrespondiente.RazonSocial;
                }

                //Se persiste el pedido
                using (var cPedidos = new ControladorPedido())
                {
                    cPedidos.Insert(pedido);
                }

                //Se buscan los detalles que correspondan a ese pedido
                foreach (Detalle detalle in detalles)
                {
                    if (detalle.IdPedido == idPedidoSeleccionado)
                    {
                        //Se actualiza el IdPedidoVenta en cada detalle
                        detalle.IdPedido = pedido.IdPedido;
                        detalle.Descuento = detalle.Descuento * 100;

                        using(var cArticulo = new ControladorArticulo())
                        {
                            var articuloCorrespondiente = cArticulo.FindById(detalle.IdArticulo);
                            detalle.Articulo = articuloCorrespondiente.Denominacion;
                            detalle.PrecioUnitario = articuloCorrespondiente.PrecioVenta;
                        }

                        //Se persiste el detalle
                        using(var cDetalle = new ControladorDetalle())
                        {
                            cDetalle.Insert(detalle);
                        }
                    }
                }                
            }

            importarIndicator.IsVisible = false;
            imgImportar.IsVisible = true;
            await DisplayAlert("Descarga exitosa", "Los datos se descargaron exitosamente", "Aceptar");            
        }

        private void imgConfig_Tapped(object sender, EventArgs e)
        {
            if (imgImportar.IsVisible)
            {
                frameDireccionWeb.IsVisible = !frameDireccionWeb.IsVisible;
            }
            else
            {
                DisplayAlert("Error", "Debe esperar que terminen de descargarse los datos para poder continuar.", "Aceptar");
            }            
        }
    }
}
