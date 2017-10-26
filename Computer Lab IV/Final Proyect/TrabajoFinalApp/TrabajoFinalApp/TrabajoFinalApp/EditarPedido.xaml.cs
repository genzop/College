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
                
        protected Pedido tempPedido;
        protected Domicilio tempDomicilio;
        protected Detalle tempDetalle;

        protected ObservableCollection<Detalle> detalles;
        protected List<Detalle> detallesEliminados;

        protected int IdVendedor { get; set; }        

        //Constructor
        public EditarPedido(Pedido pedido, int idVendedor)
        {
            //Inicializa la pantalla
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Guarda el ID del Vendedor
            this.IdVendedor = idVendedor;

            //Cargan los Clientes para el picker
            cargarClientes();

            //Cargan los Articulos para el picker
            cargarArticulos();

            pickerCliente.IsVisible = true;
            pickerEstado.IsVisible = true;
            dateFechaPedido.IsVisible = true;
            dateFechaEntrega.IsVisible = true;
            txtGastosEnvio.IsVisible = true;
            imgAddDetalle.IsVisible = true;
            btnGuardar.IsVisible = true;
            btnGuardarDetalle.IsVisible = true;
            
            lblCliente.IsVisible = false;
            lblEstado.IsVisible = false;
            lblFecha.IsVisible = false;
            lblFechaEntrega.IsVisible = false;
            lblGastosEnvio.IsVisible = false;

            //Verifica si se esta creando un Pedido o si se esta odificando uno
            if (pedido == null)
            {
                lblTitulo.Text = "Agregar Pedido";
                this.tempPedido = new Pedido();
                tempPedido.Editable = true;
                this.tempDomicilio = new Domicilio();
                int idPedido;
                using (var cPedido = new ControladorPedido())
                {
                    idPedido = cPedido.LastID() + 1;                    
                }
                lblNumero.Text = idPedido.ToString();                
                btnEliminar.Text = "Cancelar";
                this.detalles = new ObservableCollection<Detalle>();
                listDetalles.ItemsSource = this.detalles;
                this.detallesEliminados = new List<Detalle>();
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
                this.detallesEliminados = new List<Detalle>();                                
            }            
        }

        //Se cargan los articulos de la base de datos
        private void cargarArticulos()
        {
            using(var cArticulos = new ControladorArticulo())
            {
                this.articulos = cArticulos.ShowAll();
            }

            foreach (Articulo art in this.articulos)
            {
                pickerArticulo.Items.Add(art.Denominacion);
            }
        }
                
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
                    using(var detControlador = new ControladorDetalle())
                    {
                        var detallesAEliminar = detControlador.FindByPedido(this.tempPedido.IdPedido);

                        foreach (Detalle det in detallesAEliminar)
                        {
                            detControlador.Delete(det);
                        }
                    }

                    //Se elimina el pedido en si
                    using (var pedControlador = new ControladorPedido())
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
                    tempPedido.IdPedido = Convert.ToInt32(lblNumero.Text);
                    tempPedido.Editable = true;
                    tempPedido.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;

                    using (var cliControlador = new ControladorCliente())
                    {
                        var clienteSeleccionado = cliControlador.FindById(tempPedido.IdCliente);
                        tempPedido.Cliente = clienteSeleccionado.RazonSocial;
                    }

                    tempPedido.IdVendedor = this.IdVendedor;
                    tempPedido.Estado = pickerEstado.Items[pickerEstado.SelectedIndex];
                    tempPedido.FechaPedido = dateFechaPedido.Date;
                    tempPedido.FechaEntrega = dateFechaEntrega.Date;
                    tempPedido.Subtotal = Convert.ToDouble(lblSubTotal.Text);
                    tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                    tempPedido.Total = Convert.ToDouble(lblTotal.Text);
                    tempPedido.Pagado = switchPagado.IsToggled;

                    //Se persiste el pedido a la base de datos
                    using (var pedControlador = new ControladorPedido())
                    {
                        pedControlador.Insert(tempPedido);
                    }
                }
                else
                {
                    tempPedido.IdCliente = clientes[pickerCliente.SelectedIndex].IdCliente;
                    using (var cliControlador = new ControladorCliente())
                    {
                        var clienteSeleccionado = cliControlador.FindById(tempPedido.IdCliente);
                        tempPedido.Cliente = clienteSeleccionado.RazonSocial;
                    }

                    tempPedido.Estado = pickerEstado.Items[pickerEstado.SelectedIndex];
                    tempPedido.FechaPedido = dateFechaPedido.Date;
                    tempPedido.FechaEntrega = dateFechaEntrega.Date;
                    tempPedido.Subtotal = Convert.ToDouble(lblSubTotal.Text);
                    tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                    tempPedido.Total = Convert.ToDouble(lblTotal.Text);
                    tempPedido.Pagado = switchPagado.IsToggled;

                    //Se persiste el pedido a la base de datos
                    using (var pedControlador = new ControladorPedido())
                    {
                        pedControlador.Update(tempPedido);
                    }

                }

                //Persistir detalles
                foreach (Detalle det in detalles)
                {
                    if (det.IdDetalle == 0)
                    {
                        det.IdPedido = tempPedido.IdPedido;
                        using (var detControlador = new ControladorDetalle())
                        {
                            detControlador.Insert(det);
                        }
                    }
                    else
                    {
                        using (var detControlador = new ControladorDetalle())
                        {
                            detControlador.Update(det);
                        }
                    }
                }

                //Eliminar detalles eliminados
                foreach (Detalle det in detallesEliminados)
                {
                    using (var detControlador = new ControladorDetalle())
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
            this.tempDetalle = (Detalle)e.Item;

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
            lblSubTotalDetalle.Text = this.tempDetalle.Subtotal.ToString();
            txtDescuento.Text = this.tempDetalle.Descuento.ToString();
            lblTotalDetalle.Text = this.tempDetalle.Total.ToString();

            if (this.tempPedido.Editable || lblTitulo.Text == "Agregar Pedido")
            {
                btnEliminarDetalle.Text = "Eliminar";                
                pickerArticulo.IsEnabled = true;
                txtCantidad.IsEnabled = true;
                txtDescuento.IsEnabled = true;
                
            }
            else
            {
                btnEliminarDetalle.Text = "Cancelar";
                btnEliminarDetalle.BackgroundColor = Color.FromHex("#3AAFA9");
                pickerArticulo.IsEnabled = false;
                txtCantidad.IsEnabled = false;
                txtDescuento.IsEnabled = false;
            }
        }

        public void cargarDetalles()
        {
           using(var detControlador = new ControladorDetalle())
            {
                this.detalles = new ObservableCollection<Detalle>(detControlador.FindByPedido(this.tempPedido.IdPedido));
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

        //Cuando cambian los gastos de envio, se actualizan los Totales 
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

            this.tempDetalle = new Detalle();
        }

        //Se rellenan todos los campos con los datos del pedido seleccionado
        private void rellenarCampos()
        {
            if(this.tempPedido.Editable)
            {
                //Pedido
                lblNumero.Text = tempPedido.IdPedido.ToString();
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
                dateFechaEntrega.Date = this.tempPedido.FechaEntrega;
                txtGastosEnvio.Text = this.tempPedido.GastosEnvio.ToString();
                switchPagado.IsToggled = this.tempPedido.Pagado;
            }
            else
            {                
                pickerCliente.IsVisible = false;
                pickerEstado.IsVisible = false;
                dateFechaPedido.IsVisible = false;
                dateFechaEntrega.IsVisible = false;
                txtGastosEnvio.IsVisible = false;
                imgAddDetalle.IsVisible = false;
                btnGuardar.IsVisible = false;
                btnGuardarDetalle.IsVisible = false;

                lblCliente.IsVisible = true;
                lblEstado.IsVisible = true;
                lblFecha.IsVisible = true;
                lblFechaEntrega.IsVisible = true;
                lblGastosEnvio.IsVisible = true;

                lblNumero.Text = tempPedido.IdPedido.ToString();
                foreach (Cliente cli in clientes)
                {
                    if (cli.IdCliente == this.tempPedido.IdCliente)
                    {
                        lblCliente.Text = cli.RazonSocial;
                    }
                }                
                lblEstado.Text = this.tempPedido.Estado;                
                lblFecha.Text = this.tempPedido.FechaPedido.ToString("dd/MM/yyyy");
                lblFechaEntrega.Text = this.tempPedido.FechaEntrega.ToString("dd/MM/yyyy");
                lblGastosEnvio.Text = this.tempPedido.GastosEnvio.ToString();
                switchPagado.IsToggled = this.tempPedido.Pagado;

                btnEliminar.BackgroundColor = Color.FromHex("#3AAFA9");
                btnEliminar.Text = "Cancelar";
            }           
            
            //Domicilio
            lblCalle.Text = tempDomicilio.Calle + " " + tempDomicilio.Numero.ToString();
            using (var cLocalidad = new ControladorLocalidad())
            {
                Localidad localidad = cLocalidad.FindById(tempDomicilio.IdLocalidad);
                lblLocalidad.Text = localidad.Denominacion;

                using (var cProvincia = new ControladorProvincia())
                {
                    Provincia provincia = cProvincia.FindById(localidad.IdProvincia);
                    lblProvincia.Text = provincia.Denominacion;

                    using(var cPais = new ControladorPais())
                    {
                        Pais pais = cPais.FindById(provincia.IdPais);
                        lblPais.Text = pais.Denominacion;
                    }
                }
            }

            //Totales
            lblSubTotal.Text = this.tempPedido.Subtotal.ToString();
            lblTotal.Text = this.tempPedido.Total.ToString();

                   
        }

        //Calcula el subtotal del detalles
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
                    tempDetalle.Subtotal = Convert.ToDouble(lblSubTotalDetalle.Text);
                    tempDetalle.Descuento = Convert.ToDouble(txtDescuento.Text);
                    tempDetalle.Total = Convert.ToDouble(lblTotalDetalle.Text);

                    this.detalles.Add(tempDetalle);

                }
                else
                {
                    //Se guarda la posicion del pedido en la lista
                    int posicion = this.detalles.IndexOf(this.tempDetalle);

                    tempDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    tempDetalle.Subtotal = Convert.ToDouble(lblSubTotalDetalle.Text);
                    tempDetalle.Descuento = Convert.ToDouble(txtDescuento.Text);
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

                if (this.pickerCliente.IsVisible)
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

                    if (this.tempDetalle.IdDetalle == 0)
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
        
        //Calcula el Subtotal y el Total del Pedido
        private void calcularTotales()
        {
            double subTotal = 0;
            double gastosEnvio = 0;
            double total = 0;

            foreach (Detalle det in detalles)
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

        //Validaciones
        private bool validarCamposObligatorios()
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

        //Cuando se selecciona otro Cliente, se actualiza el Domicilio
        private void pickerCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var cCliente = new ControladorCliente())
            {
                Cliente tempCli = cCliente.FindByRazonSocial(pickerCliente.Items[pickerCliente.SelectedIndex]);

                using (var cDomicilio = new ControladorDomicilio())
                {
                    Domicilio tempDom = cDomicilio.FindById(tempCli.IdDomicilio);
                    lblCalle.Text = tempDom.Calle + " " + tempDom.Numero;

                    using (var cLocalidad = new ControladorLocalidad())
                    {
                        Localidad localidad = cLocalidad.FindById(tempDom.IdLocalidad);
                        lblLocalidad.Text = localidad.Denominacion;

                        using (var cProvincia = new ControladorProvincia())
                        {
                            Provincia provincia = cProvincia.FindById(localidad.IdProvincia);
                            lblProvincia.Text = provincia.Denominacion;

                            using (var cPais = new ControladorPais())
                            {
                                Pais pais = cPais.FindById(provincia.IdPais);
                                lblPais.Text = pais.Denominacion;
                            }
                        }
                    }
                }
            }           
        }
    }
}

