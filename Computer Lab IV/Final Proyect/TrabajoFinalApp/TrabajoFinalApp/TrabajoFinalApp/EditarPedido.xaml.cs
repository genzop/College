using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Controladores;
using TrabajoFinalApp.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoFinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPedido : ContentPage
    {
        protected List<Cliente> clientes;
        protected List<PedidoVentaDetalle> detalles;


        public EditarPedido(PedidoVenta pedido)
        {
            //Se inicializan las cosas
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Se verifica si se esta creando un pedido o si se esta modificando uno
            if(pedido == null)
            {
                lblTitulo.Text = "Agregar Pedido";
                cargarClientes();
            }
            else
            {
                lblTitulo.Text = "Editar Pedido";
                cargarDetalles();
            }            
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if(lblTitulo.Text == "Agregar Pedido")
            {
                PedidoVenta pedidoNuevo = new PedidoVenta();
                pedidoNuevo.EsEditable = true;
                
                pedidoNuevo.NroPedido = Convert.ToInt64(txtNumero.Text);
                pedidoNuevo.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;
                pedidoNuevo.Estado = pickerEstado.Items[pickerEstado.SelectedIndex];
                if(pedidoNuevo.Estado == "Entregado")
                {
                    pedidoNuevo.Entregado = true;
                }
                else
                {
                    pedidoNuevo.Entregado = false;
                }
                pedidoNuevo.FechaPedido = dateFechaPedido.Date;
                pedidoNuevo.FechaEstimadaEntrega = dateFechaEntrega.Date;
                pedidoNuevo.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);

                
                
            }

            

        }

        private async void listDetalles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

        }

        public void cargarDetalles()
        {
            List<PedidoVentaDetalleTabla> detalles = new List<PedidoVentaDetalleTabla>();

            PedidoVentaDetalleTabla pedido1 = new PedidoVentaDetalleTabla(2, "Lavandina", 20.0, 0, 40.0);
            PedidoVentaDetalleTabla pedido2 = new PedidoVentaDetalleTabla(3, "Jabon", 10, 0, 30.0);

            detalles.Add(pedido1);
            detalles.Add(pedido2);

            listDetalles.ItemsSource = detalles;
        }

        //Se cargan los clientes de la base de datos para ser utilizados en el picker
        public void cargarClientes()
        {            
            using( var cClientes = new ControladorCliente())
            {
                this.clientes = cClientes.ShowAll();        
            }

            foreach (Cliente cli in clientes)
            {
                pickerCliente.Items.Add(cli.RazonSocial);
            }
            
        }

        private void txtGastosEnvio_TextChanged(object sender, TextChangedEventArgs e)
        {
            double subTotal = Convert.ToDouble(lblSubTotal.Text);
            double gastosEnvio = 0;
            if (txtGastosEnvio.Text != "")
            {
                gastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
            }
            double total = subTotal + gastosEnvio;
            lblTotal.Text = total.ToString();            
        }

        private void btnEliminarDetalle_Clicked(object sender, EventArgs e)
        {

        }

        private void btnGuardarDetalle_Clicked(object sender, EventArgs e)
        {

        }

        private void imgAddDetalle_Tapped(object sender, EventArgs e)
        {            
            editarDetalle.IsVisible = true;
            lblTituloDetalle.Text = "Agregar Detalle";
            imgAddDetalle.IsVisible = false;     
        }

        private void imgCerrarDetalle_Tapped(object sender, EventArgs e)
        {
            editarDetalle.IsVisible = false;
            imgAddDetalle.IsVisible = true;
        }
    }
}
