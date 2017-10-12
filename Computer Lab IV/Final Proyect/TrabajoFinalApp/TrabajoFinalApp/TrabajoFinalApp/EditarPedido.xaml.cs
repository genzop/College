using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //Propiedades
        protected List<Cliente> clientes;
        protected List<Articulo> articulos;         
                
        protected PedidoVenta tempPedido;
        protected Domicilio tempDomicilio;
        protected PedidoVentaDetalle tempDetalle;

        protected ObservableCollection<PedidoVentaDetalle> detalles;
        protected List<PedidoVentaDetalle> detallesEliminados;

        protected int IdVendedor { get; set; }
        

        //Constructor
        public EditarPedido(PedidoVenta pedido, int idVendedor)
        {
            //Se inicializan las cosas
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Se guarda el id del vendedor
            this.IdVendedor = idVendedor;

            //Se cargan los clientes para el picker
            cargarClientes();

            //Se cargan los articulos para el picker
            cargarArticulos();

            txtNumero.IsVisible = true;
            pickerCliente.IsVisible = true;
            pickerEstado.IsVisible = true;
            dateFechaPedido.IsVisible = true;
            dateFechaEntrega.IsVisible = true;
            txtGastosEnvio.IsVisible = true;
            imgAddDetalle.IsVisible = true;
            btnGuardar.IsVisible = true;
            btnGuardarDetalle.IsVisible = true;

            lblNumero.IsVisible = false;
            lblCliente.IsVisible = false;
            lblEstado.IsVisible = false;
            lblFecha.IsVisible = false;
            lblFechaEntrega.IsVisible = false;
            lblGastosEnvio.IsVisible = false;

            //Se verifica si se esta creando un pedido o si se esta modificando uno
            if (pedido == null)
            {
                lblTitulo.Text = "Agregar Pedido";
                
                this.tempPedido = new PedidoVenta();
                this.tempDomicilio = new Domicilio();
                btnEliminar.Text = "Cancelar";
                this.detalles = new ObservableCollection<PedidoVentaDetalle>();
                listDetalles.ItemsSource = this.detalles;
                this.detallesEliminados = new List<PedidoVentaDetalle>();
                switchPagado.IsToggled = false;             
            }
            else
            {
                lblTitulo.Text = "Editar Pedido";
                this.tempPedido = pedido;
                
                using(var cliControlador = new ControladorCliente())
                {
                    Cliente tempCliente = cliControlador.FindById(this.tempPedido.IdCliente);

                    using (var domControlador = new ControladorDomicilio())
                    {
                        this.tempDomicilio = domControlador.FindById(tempCliente.IdDomicilio);
                    }
                }
                
                rellenarCampos();
                cargarDetalles();
                this.detallesEliminados = new List<PedidoVentaDetalle>();                                
            }            
        }

        //Se cargan los articulos de la base de datos
        private void cargarArticulos()
        {
            using(var artControlador = new ControladorArticulo())
            {
                this.articulos = artControlador.ShowAll();
            }

            foreach (Articulo art in this.articulos)
            {
                pickerArticulo.Items.Add(art.Denominacion);
            }
        }

        //Cuando se presiona eliminar pedido
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            //Si se esta eliminando un pedido ya persistido
            if(btnEliminar.Text == "Eliminar")
            {
                //Se confirma la eliminacion del pedido
                var respuesta = await DisplayAlert("Confirmar eliminacion del pedido", "¿Está seguro que desea eliminar este pedido con sus respectivos detalles?", "Si", "Cancelar");

                if (respuesta)
                {
                    //Se eliminan todos los detalles de ese pedido
                    using(var detControlador = new ControladorPedidoVentaDetalle())
                    {
                        var detallesAEliminar = detControlador.FindByPedidoVenta(this.tempPedido.IdPedidoVenta);

                        foreach (PedidoVentaDetalle det in detallesAEliminar)
                        {
                            detControlador.Delete(det);
                        }
                    }

                    //Se elimina el pedido en si
                    using (var pedControlador = new ControladorPedidoVenta())
                    {
                        pedControlador.Delete(this.tempPedido);
                    }

                    await Navigation.PopModalAsync();
                }
            }
            else
            {
                //Se confirma que se quiera cancelar la creacion del pedido
                if (this.tempPedido.Editable)
                {
                    var respuesta = await DisplayAlert("Confirmar cancelacion del pedido", "¿Está seguro que desea cancelar la creacion de ste pedido?", "Si", "Cancelar");
                    if (respuesta)
                    {
                        await Navigation.PopModalAsync();
                    }
                }
                else
                {
                    await Navigation.PopModalAsync();
                }
                
            }            
        }

        //Cuando se presiona el boton guardar pedido
        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            bool puedoGuardar = validarCamposObligatorios();

            if (puedoGuardar)
            {
                if (lblTitulo.Text == "Agregar Pedido")
                {
                    //Se crea un pedido nuevo y se guardan los datos ingresados
                    tempPedido.Editable = true;
                    tempPedido.NroPedido = Convert.ToInt64(txtNumero.Text);
                    tempPedido.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;

                    using (var cliControlador = new ControladorCliente())
                    {
                        var clienteSeleccionado = cliControlador.FindById(tempPedido.IdCliente);
                        tempPedido.Cliente = clienteSeleccionado.RazonSocial;
                    }

                    tempPedido.IdVendedor = this.IdVendedor;
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
                    tempPedido.Pagado = switchPagado.IsToggled;

                    //Se persiste el pedido a la base de datos
                    using (var pedControlador = new ControladorPedidoVenta())
                    {
                        pedControlador.Insert(tempPedido);
                    }
                }
                else
                {
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
                    tempPedido.Pagado = switchPagado.IsToggled;

                    //Se persiste el pedido a la base de datos
                    using (var pedControlador = new ControladorPedidoVenta())
                    {
                        pedControlador.Update(tempPedido);
                    }

                }

                //Persistir detalles
                foreach (PedidoVentaDetalle det in detalles)
                {
                    if (det.IdPedidoVentaDetalle == 0)
                    {
                        det.IdPedidoVenta = tempPedido.IdPedidoVenta;
                        using (var detControlador = new ControladorPedidoVentaDetalle())
                        {
                            detControlador.Insert(det);
                        }
                    }
                    else
                    {
                        using (var detControlador = new ControladorPedidoVentaDetalle())
                        {
                            detControlador.Update(det);
                        }
                    }
                }

                //Eliminar detalles eliminados
                foreach (PedidoVentaDetalle det in detallesEliminados)
                {
                    using (var detControlador = new ControladorPedidoVentaDetalle())
                    {
                        detControlador.Delete(det);
                    }
                }

                Navigation.PopModalAsync();
            }
        }

        //Cuando se selecciona uno de los detalles en la lista
        private void listDetalles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

            //Se guarda el detalle seleccionado en una variable
            this.tempDetalle = (PedidoVentaDetalle)e.Item;

            //Se muestra el formulario para editar un detalle
            tablaDetalles.IsVisible = false;
            editarDetalle.IsVisible = true;
            imgAddDetalle.IsVisible = false;
            lblTituloDetalle.Text = "Editar Detalle";

            //Se cargan los valores correspondientes
            for (int i = 0; i < articulos.Count; i++)
            {
                if(articulos[i].IdArticulo == this.tempDetalle.IdArticulo)
                {
                    pickerArticulo.SelectedIndex = i;
                }
            }

            txtCantidad.Text = this.tempDetalle.Cantidad.ToString();
            lblSubTotalDetalle.Text = this.tempDetalle.SubTotal.ToString();
            txtDescuento.Text = this.tempDetalle.PorcentajeDescuento.ToString();
            lblTotalDetalle.Text = this.tempDetalle.Total.ToString();

            if (this.tempPedido.Editable)
            {
                btnEliminarDetalle.Text = "Eliminar";
                pickerArticulo.IsEnabled = true;
                txtCantidad.IsEnabled = true;
                txtDescuento.IsEnabled = true;
            }
            else
            {
                btnEliminarDetalle.Text = "Cancelar";
                pickerArticulo.IsEnabled = false;
                txtCantidad.IsEnabled = false;
                txtDescuento.IsEnabled = false;
            }
        }

        public void cargarDetalles()
        {
           using(var detControlador = new ControladorPedidoVentaDetalle())
            {
                this.detalles = new ObservableCollection<PedidoVentaDetalle>(detControlador.FindByPedidoVenta(this.tempPedido.IdPedidoVenta));
                listDetalles.ItemsSource = this.detalles;
            }
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

        //Se muestra el formulario para editar un detalle
        private void imgAddDetalle_Tapped(object sender, EventArgs e)
        {
            tablaDetalles.IsVisible = false;
            editarDetalle.IsVisible = true;
            lblTituloDetalle.Text = "Agregar Detalle";
            imgAddDetalle.IsVisible = false;
            
            txtCantidad.Text = "0";
            txtDescuento.Text = "0";
            lblSubTotalDetalle.Text = "0";

            btnEliminarDetalle.Text = "Cancelar";

            this.tempDetalle = new PedidoVentaDetalle();
        }

        //Se rellenan todos los campos con los datos del pedido seleccionado
        private void rellenarCampos()
        {
            if(this.tempPedido.Editable)
            {
                //Pedido
                txtNumero.Text = this.tempPedido.NroPedido.ToString();
                for (int i = 0; i < clientes.Count(); i++)
                {
                    if (this.tempPedido.IdCliente == clientes[i].IdCliente)
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
                switchPagado.IsToggled = this.tempPedido.Pagado;
            }
            else
            {
                txtNumero.IsVisible = false;
                pickerCliente.IsVisible = false;
                pickerEstado.IsVisible = false;
                dateFechaPedido.IsVisible = false;
                dateFechaEntrega.IsVisible = false;
                txtGastosEnvio.IsVisible = false;
                imgAddDetalle.IsVisible = false;
                btnGuardar.IsVisible = false;
                btnGuardarDetalle.IsVisible = false;

                lblNumero.IsVisible = true;
                lblCliente.IsVisible = true;
                lblEstado.IsVisible = true;
                lblFecha.IsVisible = true;
                lblFechaEntrega.IsVisible = true;
                lblGastosEnvio.IsVisible = true;                

                lblNumero.Text = this.tempPedido.NroPedido.ToString();
                foreach (Cliente cli in clientes)
                {
                    if (cli.IdCliente == this.tempPedido.IdCliente)
                    {
                        lblCliente.Text = cli.RazonSocial;
                    }
                }                
                lblEstado.Text = this.tempPedido.Estado;                
                lblFecha.Text = this.tempPedido.FechaPedido.ToString("dd/MM/yyyy");
                lblFechaEntrega.Text = this.tempPedido.FechaEstimadaEntrega.ToString("dd/MM/yyyy");
                lblGastosEnvio.Text = this.tempPedido.GastosEnvio.ToString();
                switchPagado.IsToggled = this.tempPedido.Pagado;                
            }           
            
            //Domicilio
            lblCalle.Text = tempDomicilio.Calle + " " + tempDomicilio.Numero.ToString();            
            lblLocalidad.Text = tempDomicilio.Localidad;       
            lblLatitud.Text = tempDomicilio.Latitud.ToString();
            lblLongitud.Text = tempDomicilio.Longitud.ToString();

            //Totales
            lblSubTotal.Text = this.tempPedido.SubTotal.ToString();
            lblTotal.Text = this.tempPedido.MontoTotal.ToString();

            btnEliminar.BackgroundColor = Color.FromHex("#3AAFA9");
            btnEliminar.Text = "Cancelar";

            btnEliminarDetalle.BackgroundColor = Color.FromHex("#3AAFA9");           
        }

        //Se calcula el subtotal del detalles
        private void calcularSubTotalDetalle()
        {
            double precio = Convert.ToDouble(lblPrecioUnitario.Text);
            int cantidad = 0;
            double descuento = 0;

            if(txtCantidad.Text != "")
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
            }
            if(txtDescuento.Text != "")
            {
                descuento = (Convert.ToDouble(txtDescuento.Text)) / 100;
            }            

            double subTotal = precio * cantidad;
            lblSubTotalDetalle.Text = subTotal.ToString();
            double total = Convert.ToDouble(lblSubTotalDetalle.Text) * (1 - descuento);
            lblTotalDetalle.Text = total.ToString();

        }

        //Cambia el valor del picker de articulo
        private void pickerArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularSubTotalDetalle();

            Articulo artSeleccionado = this.articulos[pickerArticulo.SelectedIndex];
            lblPrecioUnitario.Text = artSeleccionado.PrecioVenta.ToString();
        }

        //Cambia el valor de la cantidad
        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            calcularSubTotalDetalle();
        }

        //Cambia el valor del descuento
        private void txtDescuento_TextChanged(object sender, TextChangedEventArgs e)
        {
            calcularSubTotalDetalle();
        }

        //Se presiona guardar detalle
        private void btnGuardarDetalle_Clicked(object sender, EventArgs e)
        {
            if(pickerArticulo.SelectedIndex != -1)
            {
                var articulo = articulos[pickerArticulo.SelectedIndex];

                if (lblTituloDetalle.Text == "Agregar Detalle")
                {
                    tempDetalle.IdArticulo = articulo.IdArticulo;
                    tempDetalle.Articulo = articulo.Denominacion;
                    tempDetalle.PrecioUnitario = articulo.PrecioVenta;
                    tempDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    tempDetalle.SubTotal = Convert.ToDouble(lblSubTotalDetalle.Text);
                    tempDetalle.PorcentajeDescuento = Convert.ToDouble(txtDescuento.Text);
                    tempDetalle.Total = Convert.ToDouble(lblTotalDetalle.Text);

                    this.detalles.Add(tempDetalle);

                }
                else
                {
                    //Se guarda la posicion del pedido en la lista
                    int posicion = this.detalles.IndexOf(this.tempDetalle);

                    tempDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    tempDetalle.SubTotal = Convert.ToDouble(lblSubTotalDetalle.Text);
                    tempDetalle.PorcentajeDescuento = Convert.ToDouble(txtDescuento.Text);
                    tempDetalle.IdArticulo = articulo.IdArticulo;
                    tempDetalle.Articulo = articulo.Denominacion;
                    tempDetalle.PrecioUnitario = articulo.PrecioVenta;
                    tempDetalle.Total = Convert.ToDouble(lblTotalDetalle.Text);

                    detalles[posicion] = tempDetalle;

                    this.tempDetalle = null;
                }

                editarDetalle.IsVisible = false;
                imgAddDetalle.IsVisible = true;
                tablaDetalles.IsVisible = true;
                calcularTotales();
            }
            else
            {
                DisplayAlert("Error", "No se selecciono ningun articulo", "Aceptar");
            }            
        }

        //Se presiona eliminar detalle
        private async void btnEliminarDetalle_Clicked(object sender, EventArgs e)
        {            
            if(btnEliminarDetalle.Text == "Cancelar")
            {
                editarDetalle.IsVisible = false;
                
                tablaDetalles.IsVisible = true;

                if (this.txtNumero.IsVisible)
                {
                    imgAddDetalle.IsVisible = true;
                }
                else
                {
                    imgAddDetalle.IsVisible = false;
                }
            }
            else
            {
                var respuesta = await DisplayAlert("Confirmar eliminacion del detalle", "¿Está seguro que desea eliminar este detalle?", "Si", "Cancelar");
                if (respuesta)
                {
                    //Se guarda la posicion del pedido en la lista
                    int posicion = this.detalles.IndexOf(this.tempDetalle);

                    if (this.tempDetalle.IdPedidoVentaDetalle == 0)
                    {
                        detalles.RemoveAt(posicion);
                    }
                    else
                    {
                        this.detallesEliminados.Add(detalles[posicion]);
                        this.detalles.RemoveAt(posicion);
                    }

                    editarDetalle.IsVisible = false;
                    imgAddDetalle.IsVisible = true;
                    tablaDetalles.IsVisible = true;
                }                              
            }
            calcularTotales();
        }               
        
        private void calcularTotales()
        {
            double subTotal = 0;
            double gastosEnvio = 0;
            double total = 0;

            foreach (PedidoVentaDetalle det in detalles)
            {
                subTotal += det.Total;
            }

            lblSubTotal.Text = subTotal.ToString();

            if(txtGastosEnvio.Text != "" || lblGastosEnvio.Text != "")
            {
                gastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
            }

            total = subTotal + gastosEnvio;

            lblTotal.Text = total.ToString();
        } 

        private bool validarCamposObligatorios()
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                if (pickerCliente.SelectedIndex != -1)
                {
                    if (pickerEstado.SelectedIndex != -1)
                    {
                        if (!string.IsNullOrEmpty(txtGastosEnvio.Text))
                        {
                            return true;
                        }
                        else
                        {
                            DisplayAlert("Error", "Debe ingresar los gastos de envio", "Aceptar");
                            txtGastosEnvio.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Debe seleccionar un estado", "Aceptar");
                        return false;
                    }
                }
                else
                {
                    DisplayAlert("Error", "Debe seleccionar un cliente", "Aceptar");
                    return false;
                }
            }
            else
            {
                DisplayAlert("Error", "Debe ingresar un numero", "Aceptar");
                txtNumero.Focus();
                return false;
            }
        }

        private void pickerCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var cliControlador = new ControladorCliente())
            {
                Cliente tempCli = cliControlador.FindByRazonSocial(pickerCliente.Items[pickerCliente.SelectedIndex]);

                using (var domControlador = new ControladorDomicilio())
                {
                    Domicilio tempDom = domControlador.FindById(tempCli.IdDomicilio);
                    lblCalle.Text = tempDom.Calle + " " + tempDom.Numero;
                    lblLocalidad.Text = tempDom.Localidad;
                    lblLatitud.Text = tempDom.Latitud.ToString();
                    lblLongitud.Text = tempDom.Longitud.ToString();
                }
            }           
        }
    }
}

