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

        protected PedidoVenta tempPedido;
        protected Domicilio tempDomicilio;

        protected int IdVendedor { get; set; }
        
        public EditarPedido(PedidoVenta pedido, int idVendedor)
        {
            //Se inicializan las cosas
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.IdVendedor = idVendedor;

            //Se verifica si se esta creando un pedido o si se esta modificando uno
            if(pedido == null)
            {
                lblTitulo.Text = "Agregar Pedido";
                cargarClientes();
                this.tempPedido = new PedidoVenta();
                this.tempDomicilio = new Domicilio();
                btnEliminar.Text = "Cancelar";         
            }
            else
            {
                lblTitulo.Text = "Editar Pedido";
                cargarClientes();
                this.tempPedido = pedido;
                using(var domControlador = new ControladorDomicilio())
                {
                    this.tempDomicilio = domControlador.FindById(this.tempPedido.IdDomicilio);
                }
                rellenarCampos();
            }            
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if(btnEliminar.Text == "Eliminar")
            {
                var respuesta = await DisplayAlert("Confirmar eliminacion del pedido", "¿Está seguro que desea eliminar este pedido con sus respectivos detalles?", "Si", "Cancelar");

                if (respuesta)
                {
                    using (var domControlador = new ControladorDomicilio())
                    {
                        domControlador.Delete(this.tempDomicilio);
                    }
                    using (var pedControlador = new ControladorPedidoVenta())
                    {
                        pedControlador.Delete(this.tempPedido);
                    }

                    await Navigation.PopModalAsync();
                }
            }
            else
            {
                var respuesta = await DisplayAlert("Confirmar cancelacion del pedido", "¿Está seguro que desea cancelar la creacion de ste pedido?", "Si", "Cancelar");
                if (respuesta)
                {
                    await Navigation.PopModalAsync();
                }
            }            
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if(lblTitulo.Text == "Agregar Pedido")
            {
                //Se crea un domicilio nuevo y se guardan los datos ingresados                
                tempDomicilio.Calle = txtCalle.Text;
                tempDomicilio.Numero = Convert.ToInt32(txtCalleNumero.Text);
                tempDomicilio.Localidad = pickerLocalidad.Items[pickerLocalidad.SelectedIndex];
                if(txtLatitud.Text != null)
                {
                    tempDomicilio.Latitud = Convert.ToDouble(txtLatitud.Text);
                }
                if(txtLongitud.Text != null)
                {
                    tempDomicilio.Longitud = Convert.ToDouble(txtLongitud.Text);
                }

                //Se persiste a la base de datos
                using(var domControlador = new ControladorDomicilio())
                {
                    domControlador.Insert(tempDomicilio);
                }

                //Se crea un pedido nuevo y se guardan los datos ingresados
                tempPedido.EsEditable = true;
                tempPedido.NroPedido = Convert.ToInt64(txtNumero.Text);
                tempPedido.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;

                using(var cliControlador = new ControladorCliente())
                {
                    var clienteSeleccionado = cliControlador.FindById(tempPedido.IdCliente);
                    tempPedido.Cliente = clienteSeleccionado.RazonSocial;
                }

                tempPedido.IdVendedor = this.IdVendedor;
                tempPedido.IdDomicilio = tempDomicilio.IdDomicilio;
                tempPedido.Estado = pickerEstado.Items[pickerEstado.SelectedIndex];
                if(tempPedido.Estado == "Entregado")
                {
                    tempPedido.Entregado = true;
                }
                else
                {
                    tempPedido.Entregado = false;
                }
                tempPedido.FechaPedido = dateFechaPedido.Date;
                tempPedido.FechaEstimadaEntrega = dateFechaEntrega.Date;
                tempPedido.SubTotal = Convert.ToDouble(lblSubTotal.Text);
                tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                tempPedido.MontoTotal = Convert.ToDouble(lblTotal.Text);                
                
                //Se persiste el pedido a la base de datos
                using(var pedControlador = new ControladorPedidoVenta())
                {
                    pedControlador.Insert(tempPedido);
                }
            }
            else
            {
                //Se actualizan un domicilio y se guardan los datos ingresados                
                tempDomicilio.Calle = txtCalle.Text;
                tempDomicilio.Numero = Convert.ToInt32(txtCalleNumero.Text);
                tempDomicilio.Localidad = pickerLocalidad.Items[pickerLocalidad.SelectedIndex];
                if (txtLatitud.Text != null)
                {
                    tempDomicilio.Latitud = Convert.ToDouble(txtLatitud.Text);
                }
                if (txtLongitud.Text != null)
                {
                    tempDomicilio.Longitud = Convert.ToDouble(txtLongitud.Text);
                }

                using (var domControlador = new ControladorDomicilio())
                {
                    domControlador.Update(tempDomicilio);
                }



                tempPedido.NroPedido = Convert.ToInt64(txtNumero.Text);
                tempPedido.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;

                using (var cliControlador = new ControladorCliente())
                {
                    var clienteSeleccionado = cliControlador.FindById(tempPedido.IdCliente);
                    tempPedido.Cliente = clienteSeleccionado.RazonSocial;
                }
                
                tempPedido.Estado = pickerEstado.Items[pickerEstado.SelectedIndex];
                if (tempPedido.Estado == "Entregado")
                {
                    tempPedido.Entregado = true;
                }
                else
                {
                    tempPedido.Entregado = false;
                }
                tempPedido.FechaPedido = dateFechaPedido.Date;
                tempPedido.FechaEstimadaEntrega = dateFechaEntrega.Date;
                tempPedido.SubTotal = Convert.ToDouble(lblSubTotal.Text);
                tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                tempPedido.MontoTotal = Convert.ToDouble(lblTotal.Text);

                //Se persiste el pedido a la base de datos
                using (var pedControlador = new ControladorPedidoVenta())
                {
                    pedControlador.Update(tempPedido);
                }

            }

            Navigation.PopModalAsync();      

        }

        private async void listDetalles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

        }

        public void cargarDetalles()
        {
           
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

        //Cuando cambian los gastos de envio, se actualizan los totales 
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

        //Se muestra el formulario para editar un detalle
        private void imgAddDetalle_Tapped(object sender, EventArgs e)
        {            
            editarDetalle.IsVisible = true;
            lblTituloDetalle.Text = "Agregar Detalle";
            imgAddDetalle.IsVisible = false;     
        }

        //Se esconde el formulario para editar un detalle
        private void imgCerrarDetalle_Tapped(object sender, EventArgs e)
        {
            editarDetalle.IsVisible = false;
            imgAddDetalle.IsVisible = true;
        }

        //Se rellenan todos los campos con los datos del pedido seleccionado
        private void rellenarCampos()
        {
            txtNumero.Text = this.tempPedido.NroPedido.ToString();
            for (int i = 0; i < clientes.Count(); i++)
            {
                if(this.tempPedido.IdCliente == clientes[i].IdCliente)
                {
                    pickerCliente.SelectedIndex = i;
                }
            }
            switch (this.tempPedido.Estado)
            {
                case "Pendiente":
                    pickerEstado.SelectedIndex = 0;
                    break;
                case "Enviado":
                    pickerEstado.SelectedIndex = 1;
                    break;
                case "Entregado":
                    pickerEstado.SelectedIndex = 2;
                    break;
                case "Anulado":
                    pickerEstado.SelectedIndex = 3;
                    break;
            }

            dateFechaPedido.Date = this.tempPedido.FechaPedido;
            dateFechaEntrega.Date = this.tempPedido.FechaEstimadaEntrega;
            txtGastosEnvio.Text = this.tempPedido.GastosEnvio.ToString();
            
            txtCalle.Text = tempDomicilio.Calle;
            txtCalleNumero.Text = tempDomicilio.Numero.ToString();
            switch (tempDomicilio.Localidad)
            {
                case "Guaymallen":
                    pickerLocalidad.SelectedIndex = 0;
                    break;
                case "Capital":
                    pickerLocalidad.SelectedIndex = 1;
                    break;
            }
            if(tempDomicilio.Latitud != 0)
            {
                txtLatitud.Text = tempDomicilio.Latitud.ToString();
            }
            if(tempDomicilio.Longitud != 0)
            {
                txtLongitud.Text = tempDomicilio.Longitud.ToString();
            }
            lblSubTotal.Text = this.tempPedido.SubTotal.ToString();
            lblTotal.Text = this.tempPedido.MontoTotal.ToString();                   
        }
    }
}

