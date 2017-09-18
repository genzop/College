using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarPedido : System.Web.UI.Page
{
    private BaseDatosDataContext bd = new BaseDatosDataContext();    

    //Cuando se carga la pagina
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdVendedor"] == null)
        {            
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            //Si es el administrador, se muestra el campo elegir vendedor
            if(Convert.ToInt32(Session["IdVendedor"]) == 20)
            {
                campoVendedor.Visible = true;
            }            

            //Si no se paso un id como parametro
            if (Request.QueryString["id"] == null)
            {
                lblTitulo.Text = "Agregar Pedido";                
                if (!IsPostBack)
                {
                    List<DetalleTemporal> listaDetalles = new List<DetalleTemporal>();
                    Session["Detalles"] = listaDetalles;
                    txtSubTotal.Text = "0";
                    txtGastosEnvio.Text = "0";
                    txtMontoTotal.Text = "0";

                    //Se carga la direccion del cliente
                    Cliente tempCli = (from cli in bd.Clientes
                                       select cli).FirstOrDefault();

                    Domicilio tempDom = (from dom in bd.Domicilios
                                         where dom.IdDomicilio == tempCli.IdDomicilio
                                         select dom).Single();

                    //Mostrar los datos por pantalla
                    txtCalle.Text = tempDom.Calle;
                    txtNumeroCalle.Text = tempDom.Numero.ToString();
                    txtLocalidad.Text = tempDom.Localidad;
                    txtLatitud.Text = tempDom.Latitud.ToString();
                    txtLongitud.Text = tempDom.Longitud.ToString();


                }
            }
            //Si se paso un id como parametro
            else
            {
                lblTitulo.Text = "Editar Pedido";
                if (!IsPostBack)
                {
                    cargarPedido(Convert.ToInt32(Request.QueryString["id"]));
                    cargarDetalles(Convert.ToInt32(Request.QueryString["id"]));                    
                    rellenarTabla();
                    crearListaEliminados();
                }                
            }  
        }        
    }
        

    //Se rellena el formulario con los datos del pedido seleccionado
    private void cargarPedido(int id)
    {
        //Se carga el pedido
        var pedido = (from ped in bd.PedidoVentas
                      where ped.IdPedidoVenta == id
                      select ped).Single();

        //Se carga el cliente 
        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == pedido.IdCliente
                       select cli).Single();

        //Se carga el domicilio del cliente 
        var domicilio = (from dom in bd.Domicilios
                         where dom.IdDomicilio == cliente.IdDomicilio
                         select dom).Single();

        //Se rellenan los campos del pedido
        hiddenID.Value = pedido.IdPedidoVenta.ToString();
        txtNumero.Text = pedido.NroPedido.ToString();
        ddlCliente.SelectedValue = pedido.IdCliente.ToString();
        ddlEstado.SelectedValue = pedido.Estado;
        DateTime fecha = (DateTime)pedido.FechaPedido;
        txtFecha.Text = fecha.ToString("yyyy-MM-dd");
        DateTime fechaEntrega = (DateTime)pedido.FechaEstimadaEntrega;
        txtFechaEntrega.Text = fechaEntrega.ToString("yyyy-MM-dd");        
        txtCalle.Text = domicilio.Calle;
        txtNumeroCalle.Text = domicilio.Numero.ToString();
        txtLocalidad.Text = domicilio.Localidad;
        txtLatitud.Text = domicilio.Latitud.ToString();
        txtLongitud.Text = domicilio.Longitud.ToString();
        if(Convert.ToInt32(Session["IdVendedor"]) == 20)
        {
            ddlVendedor.SelectedValue = pedido.IdVendedor.ToString();
        }
        txtSubTotal.Text = pedido.SubTotal.ToString();
        txtGastosEnvio.Text = pedido.GastosEnvio.ToString();
        txtMontoTotal.Text = pedido.MontoTotal.ToString();
        cboxPagado.Checked = Convert.ToBoolean(pedido.Pagado);

        //Se guarda el id del cliente anterior en caso de que este cambie y haya que actualizar su saldo
        Session["ClienteAnterior"] = pedido.IdCliente;
                 
    }

    private void cargarDetalles(int id)
    {
        //Si ya esta ocupada la sesion de detalles, se vacia
        if(Session["Detalles"] != null)
        {
            Session["Detalles"] = null;
        }

        //Se crea una lista de detalles
        List<DetalleTemporal> listaDetalles = new List<DetalleTemporal>();

        //Se verifica si el pedido tiene detalles
        bool tieneDetalles = (from det in bd.PedidoVentaDetalles
                              where det.IdPedidoVenta == id
                              select det).Any();

        //Si tiene detalles
        if (tieneDetalles)
        {
            //Se cargan los detalles
            var detalles = from det in bd.PedidoVentaDetalles
                           where det.IdPedidoVenta == id
                           select det;
            
            //Por cada detalle en detalles
            foreach (var detalle in detalles)
            {
                //Se carga el articulo correspondiente a ese detalle
                var tempArt = (from art in bd.Articulos
                               where art.IdArticulo == detalle.IdArticulo
                               select art).Single();

                //Se crea un DetalleTemporal con sus respectivos datos
                DetalleTemporal temp = new DetalleTemporal();
                temp.IdPedidoVentaDetalle = detalle.IdPedidoVentaDetalle;
                temp.Articulo = tempArt.Denominacion;
                temp.PrecioUnitario = Convert.ToDouble(tempArt.PrecioVenta);
                temp.Cantidad = Convert.ToInt32(detalle.Cantidad);
                temp.SubTotal = Convert.ToDouble(detalle.SubTotal);
                temp.Descuento = Convert.ToDouble(detalle.PorcentajeDescuento);
                temp.Total = Convert.ToDouble(detalle.Total);
                temp.IdPedidoVenta = Convert.ToInt32(detalle.IdPedidoVenta);
                temp.IdArticulo = Convert.ToInt32(detalle.IdArticulo);

                //Se agrega el DetalleTemporal a la listaDetalles
                listaDetalles.Add(temp);
            }
        }

        //Se guarda la listaDetalles en una sesion
        Session["Detalles"] = listaDetalles;
    }

    private void rellenarTabla()
    {
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        grdDetalles.DataSource = listaDetalles;
        grdDetalles.DataBind();
    }
    
    //Se hace click en el boton Guardar
    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Si se esta creando un nuevo pedido
            if (Request.QueryString["id"] == null)
            {
                crearPedido();
            }
            //Si se esta editando un pedido ya existente
            else
            {
                editarPedido(Convert.ToInt32(Request.QueryString["id"]));
            }

            Response.Redirect("Pedidos.aspx");
        }        
    }
    
    //Se hace click en Agregar Detalle
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //Se muestra el formulario para detalles en blanco
        formularioDetalle.Visible = true;        
        hiddenFila.Value = "";

        Articulo tempArt = (from art in bd.Articulos
                            select art).FirstOrDefault();

        ddlArticulo.SelectedValue = tempArt.IdArticulo.ToString();

        //Se muestran los valores
        txtPrecioUnitario.Text = tempArt.PrecioVenta.ToString();
        txtCantidad.Text = "0";
        txtSubTotalSinDescuento.Text = "0";
        txtDescuento.Text = "0";
        txtSubTotalDetalle.Text = "0";        
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {        
        //Se guarda el numero de la fila que se quiere editar
        ImageButton btn = (ImageButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int fila = row.RowIndex;

        //Se muestra el formulario de detalle
        formularioDetalle.Visible = true;        

        //Se carga el detalle seleccionado de la lista de detalles
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        DetalleTemporal detalleSeleccionado = listaDetalles[fila];

        //Se cargan los datos del detalle seleccionado en el formulario
        hiddenFila.Value = fila.ToString();
        ddlArticulo.SelectedValue = detalleSeleccionado.IdArticulo.ToString();
        txtPrecioUnitario.Text = detalleSeleccionado.PrecioUnitario.ToString();
        txtCantidad.Text = detalleSeleccionado.Cantidad.ToString();
        txtSubTotalSinDescuento.Text = (detalleSeleccionado.PrecioUnitario * detalleSeleccionado.Cantidad).ToString();
        txtDescuento.Text = (detalleSeleccionado.Descuento * 100).ToString();
        txtSubTotalDetalle.Text = detalleSeleccionado.Total.ToString();
    }


    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        //Se guarda el numero de la fila que se quiere editar
        ImageButton btn = (ImageButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int fila = row.RowIndex;

        //Se carga la lista de detalles
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];

        //Se guarda en una variable el detalle a eliminar
        DetalleTemporal detalleSeleccionado = listaDetalles[fila];

        //Si el detalle seleccionado, no ha sido persistido
        if(detalleSeleccionado.IdPedidoVentaDetalle == 0)
        {
            //Se lo elimina del list de detalles
            listaDetalles.RemoveAt(fila);
            Session["Detalles"] = listaDetalles;
        }
        //Si ya habia sido persistido
        else
        {
            //Se carga la lista de detalles eliminados
            List<DetalleTemporal> listaEliminados = (List<DetalleTemporal>)Session["Eliminados"];

            //Se agrega el detalle persistido a eliminar
            listaEliminados.Add(detalleSeleccionado);

            //Se lo elimina de la lista de detalles
            listaDetalles.RemoveAt(fila);

            //Se guardan los cambios en las listas
            Session["Detalles"] = listaDetalles;
            Session["Eliminados"] = listaEliminados;
        }
                
        rellenarTabla();
        calcularTotales();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //Se esconde el formulario de detalles
        formularioDetalle.Visible = false;
    }
    
    protected void btnAccionDetalle_Click(object sender, EventArgs e)
    {
        //Si es valida la pagina
        if (Page.IsValid)
        {
            //Se cargan los datos del articulo seleccionado
            var articulo = (from art in bd.Articulos
                            where art.IdArticulo == Convert.ToInt32(ddlArticulo.SelectedValue)
                            select art).Single();

            //Si se esta agregando un detalle
            if (hiddenFila.Value == "")
            {
                DetalleTemporal temp = new DetalleTemporal();
                temp.IdPedidoVenta = Convert.ToInt32(Request.QueryString["id"]);
                temp.IdPedidoVentaDetalle = 0;
                temp.Articulo = articulo.Denominacion;
                temp.PrecioUnitario = Convert.ToDouble(articulo.PrecioVenta);
                temp.Cantidad = Convert.ToInt32(txtCantidad.Text);
                temp.SubTotal = Convert.ToDouble(txtSubTotalSinDescuento.Text);
                temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                temp.Total = Convert.ToDouble(txtSubTotalDetalle.Text);                
                temp.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);

                List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
                listaDetalles.Add(temp);
                Session["Detalles"] = listaDetalles;
            }
            //Si se esta editando un detalle
            else
            {         
                List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
                DetalleTemporal temp = listaDetalles[Convert.ToInt32(hiddenFila.Value)];
                temp.Articulo = articulo.Denominacion;
                temp.PrecioUnitario = Convert.ToDouble(articulo.PrecioVenta);
                temp.Cantidad = Convert.ToInt32(txtCantidad.Text);
                temp.SubTotal = Convert.ToDouble(txtSubTotalSinDescuento.Text);
                temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                temp.Total = Convert.ToDouble(txtSubTotalDetalle.Text);
                temp.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);

                listaDetalles[Convert.ToInt32(hiddenFila.Value)] = temp;
                Session["Detalles"] = listaDetalles;
            }
            rellenarTabla();
            formularioDetalle.Visible = false;
            calcularTotales();
        }
    }

    //Cuando cambia alguno de los valores del formulario de detalles, se recalcula el subtotal de ese detalle
    protected void cambiaSubTotalDetalle(object sender, EventArgs e)
    {
        int idArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);
        var articulo = (from art in bd.Articulos
                        where art.IdArticulo == idArticulo
                        select art).Single();

        double precioVenta = Convert.ToDouble(articulo.PrecioVenta);
        txtPrecioUnitario.Text = precioVenta.ToString();

        int cantidad = 0;
        double descuento = 0;

        if(txtCantidad.Text != "")
        {
            cantidad = Convert.ToInt32(txtCantidad.Text);
        } 

        if(txtDescuento.Text != "")
        {
            descuento = Convert.ToDouble(txtDescuento.Text);
        }

        double subTotal = cantidad * precioVenta;
        txtSubTotalSinDescuento.Text = subTotal.ToString();
        subTotal = subTotal - subTotal * (descuento / 100);
        txtSubTotalDetalle.Text = subTotal.ToString();
    }


    protected void cambiarGastosEnvio(object sender, EventArgs e)
    {
        sumarGastosEnvio();
    }

    private void sumarGastosEnvio()
    {
        double subtotal = Convert.ToDouble(txtSubTotal.Text);

        //Se suman los gastos de envio
        double gastosEnvio = 0;
        if (txtGastosEnvio.Text != "")
        {
            gastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
        }

        //Se calcula el total del pedido
        double total = subtotal + gastosEnvio;
        txtMontoTotal.Text = total.ToString();
    }

    private void calcularTotales()
    {
        double subtotal = 0;      

        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];

        //Si hay detalles, se suman sus subtotales para obtener el subtotal del pedido
        if(listaDetalles.Count > 0)
        {
            foreach (DetalleTemporal detalle in listaDetalles)
            {
                subtotal += detalle.Total;
            }
        }
        txtSubTotal.Text = subtotal.ToString();
        sumarGastosEnvio();
    }    

    private void calcularSaldoCliente(int idCliente)
    {
        double subtotalCliente = 0;

        //Se verifica si ese cliente tiene pedidos a su nombre
        bool tienePedidos = (from ped in bd.PedidoVentas
                             where ped.IdCliente == idCliente
                             select ped).Any();

        //Si tiene pedidos 
        if (tienePedidos)
        {
            //Se cargan los pedidos
            var pedidos = from ped in bd.PedidoVentas
                          where ped.IdCliente == idCliente
                          select ped;
                        
            foreach (var pedido in pedidos)
            {
                //Si el pedido no esta pagado
                if (!Convert.ToBoolean(pedido.Pagado))
                {
                    //Se suma el monto total de cada pedido
                    subtotalCliente += Convert.ToDouble(pedido.MontoTotal);
                }
            }
        }

        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == idCliente
                       select cli).Single();

        cliente.Saldo = 0 + subtotalCliente;
        bd.SubmitChanges();
    }    

    private void crearListaEliminados()
    {
        List<DetalleTemporal> listaEliminados = new List<DetalleTemporal>();
        Session["Eliminados"] = listaEliminados;
    }

    //Se guarda un pedido nuevo en la base de datos
    private void crearPedido()
    {
        //Se guardan los datos del pedido
        PedidoVenta nuevoPedido = new PedidoVenta();
        nuevoPedido.Editable = false;
        if(Convert.ToInt32(Session["IdVendedor"]) != 20)
        {
            nuevoPedido.IdVendedor = Convert.ToInt32(Session["IdVendedor"]);
        }
        else
        {
            nuevoPedido.IdVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);
        }
        nuevoPedido.NroPedido = Convert.ToInt32(txtNumero.Text);
        nuevoPedido.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);        
        nuevoPedido.Estado = ddlEstado.SelectedValue;
        if (ddlEstado.SelectedValue == "Entregado")
        {
            nuevoPedido.Entregado = true;
        }
        else
        {
            nuevoPedido.Entregado = false;
        }        
        nuevoPedido.FechaPedido = Convert.ToDateTime(txtFecha.Text);
        nuevoPedido.FechaEstimadaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
        nuevoPedido.SubTotal = Convert.ToDouble(txtSubTotal.Text);
        nuevoPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
        nuevoPedido.MontoTotal = Convert.ToDouble(txtMontoTotal.Text);
        nuevoPedido.Pagado = cboxPagado.Checked;   
        bd.PedidoVentas.InsertOnSubmit(nuevoPedido);
        bd.SubmitChanges();

        guardarDetalles(nuevoPedido.IdPedidoVenta);

        calcularSaldoCliente(Convert.ToInt32(nuevoPedido.IdCliente));                       
    }

    //Se edita un pedido ya existente en la base de datos
    private void editarPedido(int id)
    {
        var pedidoEditar = (from ped in bd.PedidoVentas
                             where ped.IdPedidoVenta == id
                             select ped).Single();

        

        pedidoEditar.NroPedido = Convert.ToInt32(txtNumero.Text);
        pedidoEditar.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
        pedidoEditar.Estado = ddlEstado.SelectedValue;
        if (ddlEstado.SelectedValue == "Entregado")
        {
            pedidoEditar.Entregado = true;
        }
        else
        {
            pedidoEditar.Entregado = false;
        }
        pedidoEditar.FechaPedido = Convert.ToDateTime(txtFecha.Text);
        pedidoEditar.FechaEstimadaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
        if(Convert.ToInt32(Session["IdVendedor"]) == 20)
        {
            pedidoEditar.IdVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);
        }
        pedidoEditar.SubTotal = Convert.ToDouble(txtSubTotal.Text);
        pedidoEditar.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
        pedidoEditar.MontoTotal = Convert.ToDouble(txtMontoTotal.Text);
        pedidoEditar.Pagado = cboxPagado.Checked;

        bd.SubmitChanges();

        guardarDetalles(pedidoEditar.IdPedidoVenta);
        eliminarDetalles();

        calcularSaldoCliente(Convert.ToInt32(Session["ClienteAnterior"]));
        calcularSaldoCliente(Convert.ToInt32(pedidoEditar.IdCliente));

    }

    //Se persisten todos los detalles asociados con un pedido
    private void guardarDetalles(int idPedido)
    {
        //Se cargan todos los detalles de este pedido
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];

        foreach (DetalleTemporal detalle in listaDetalles)
        {
            //Si el detalle aun no ha sido persistido
            if (detalle.IdPedidoVentaDetalle == 0)
            {
                //Se crea un nuevo detalle
                PedidoVentaDetalle detalleNuevo = new PedidoVentaDetalle();
                detalleNuevo.IdPedidoVenta = idPedido;
                detalleNuevo.Cantidad = detalle.Cantidad;
                detalleNuevo.SubTotal = detalle.SubTotal;
                detalleNuevo.PorcentajeDescuento = detalle.Descuento;
                detalleNuevo.Total = detalle.Total;
                detalleNuevo.IdArticulo = detalle.IdArticulo;

                //Se lo inserta en la base de datos
                bd.PedidoVentaDetalles.InsertOnSubmit(detalleNuevo);
                bd.SubmitChanges();
            }
            //Si el detalle ya ha sido persistido
            else
            {
                //Se carga el detalle seleccionado
                var detalleEditado = (from det in bd.PedidoVentaDetalles
                                      where det.IdPedidoVentaDetalle == detalle.IdPedidoVentaDetalle
                                      select det).Single();

                //Se cambian los datos
                detalleEditado.Cantidad = detalle.Cantidad;
                detalleEditado.SubTotal = detalle.SubTotal;
                detalleEditado.PorcentajeDescuento = detalle.Descuento;
                detalleEditado.Total = detalle.Total;
                detalleEditado.IdArticulo = detalle.IdArticulo;

                //Se aplican los cambios a la base de datos
                bd.SubmitChanges();
            }
        }
    }

    private void eliminarDetalles()
    {
        List<DetalleTemporal> listaElminados = (List<DetalleTemporal>)Session["Eliminados"];

        foreach (DetalleTemporal detalle in listaElminados)
        {
            var temp = (from det in bd.PedidoVentaDetalles
                        where det.IdPedidoVentaDetalle == detalle.IdPedidoVentaDetalle
                        select det).Single();

            bd.PedidoVentaDetalles.DeleteOnSubmit(temp);            
        }
        bd.SubmitChanges();
    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Cargar el cliente
        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == Convert.ToInt32(ddlCliente.SelectedValue)
                       select cli).Single();

        //Cargar domilicio del cliente        
        var domicilio = (from dom in bd.Domicilios
                         where dom.IdDomicilio == cliente.IdDomicilio
                         select dom).Single();

        //Mostrar los datos por pantalla
        txtCalle.Text = domicilio.Calle;
        txtNumeroCalle.Text = domicilio.Numero.ToString();
        txtLocalidad.Text = domicilio.Localidad;
        txtLatitud.Text = domicilio.Latitud.ToString();
        txtLongitud.Text = domicilio.Longitud.ToString();            
    }
}