using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarPedido : System.Web.UI.Page
{
    private BaseDatosDataContext bd = new BaseDatosDataContext();
    Vendedor usuario = null;   
        
    protected void Page_Load(object sender, EventArgs e)
    {
        //Si no hay un usuario logueado se lo redirecciona a la pagina de LogIn
        if (Session["IdVendedor"] == null)
        {            
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            //Actualiza el mapa de JavaScript en el UpdatePanel
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "InitMap", "initMap()", true);

            //Guarda al usuario en una variable global
            usuario = (from vend in bd.Vendedors
                       where vend.IdVendedor == Convert.ToInt32(Session["IdVendedor"])
                       select vend).FirstOrDefault();                 

            //Si es el administrador, se muestra el campo elegir vendedor
            if (usuario.Administrador)
            {
                campoVendedor.Visible = true;
            }            

            //Si se quiere agregar un Pedido
            if (Request.QueryString["id"] == null)
            {
                lblTitulo.Text = "Agregar Pedido";                
                if (!IsPostBack)
                {
                    List<DetalleTemporal> listaDetalles = new List<DetalleTemporal>();
                    Session["Detalles"] = listaDetalles;

                    //Carga el ID que deberia tener en la base de datos
                    var ultimoID = (from num in bd.GetIdentityPedido()
                                    select num.Column1).FirstOrDefault();
                    txtNumero.Text = (Convert.ToInt32(ultimoID) + 1).ToString();

                    //Se carga la direccion del cliente
                    rellenarDomicilio(0);

                    //Resetea los Totales a 0
                    txtSubTotal.Text = String.Format("{0:C}", 0);
                    txtGastosEnvio.Text = String.Format("{0:C}", 0);
                    txtMontoTotal.Text = String.Format("{0:C}", 0);
                }
            }
            //Si se quiere editar un Pedido
            else
            {
                lblTitulo.Text = "Editar Pedido";
                if (!IsPostBack)
                {
                    cargarPedido(Convert.ToInt32(Request.QueryString["id"]));
                    cargarDetalles(Convert.ToInt32(Request.QueryString["id"]));                    
                    rellenarTablaDetalles();
                    List<DetalleTemporal> listaEliminados = new List<DetalleTemporal>();
                    Session["Eliminados"] = listaEliminados;
                }                
            }  
        }        
    }
        
    //Rellena el formulario con los datos del Pedido
    private void cargarPedido(int idPedido)
    {
        //Se carga el pedido
        var pedido = (from ped in bd.Pedidos
                      where ped.IdPedido == idPedido
                      select ped).Single();
                
        //Rellena los campos del pedido
        txtNumero.Text = pedido.IdPedido.ToString();        
        ddlCliente.SelectedValue = pedido.IdCliente.ToString();
        ddlEstado.SelectedValue = pedido.Estado;
        DateTime fecha = (DateTime)pedido.FechaPedido;
        txtFecha.Text = fecha.ToString("yyyy-MM-dd");
        DateTime fechaEntrega = (DateTime)pedido.FechaEntrega;
        txtFechaEntrega.Text = fechaEntrega.ToString("yyyy-MM-dd");
        txtSubTotal.Text = String.Format("{0:C}", pedido.SubTotal);
        txtGastosEnvio.Text = String.Format("{0:C}", pedido.GastosEnvio);
        txtMontoTotal.Text = String.Format("{0:C}", pedido.Total);
        cboxPagado.Checked = Convert.ToBoolean(pedido.Pagado);

        //Rellena los campos del domicilio
        rellenarDomicilio(pedido.IdCliente);

        //Si es el Administrador, muestra el DropDownList de Vendedores
        if(usuario.Administrador)
        {
            ddlVendedor.SelectedValue = pedido.IdVendedor.ToString();
        }

        //Guarda el ID del Cliente anterior en caso de que este cambie y tenga que actualizar su saldo
        Session["ClienteAnterior"] = pedido.IdCliente;
                 
    }

    private void cargarDetalles(int idPedido)
    {
        //Vacia la sesion de Detalles
        if(Session["Detalles"] != null)
        {
            Session["Detalles"] = null;
        }

        //Crea una lista de Detalles
        List<DetalleTemporal> listaDetalles = new List<DetalleTemporal>();

        //Verifica si el Pedido tiene Detalles
        bool tieneDetalles = (from det in bd.Detalles
                              where det.IdPedido == idPedido
                              select det).Any();
        
        if (tieneDetalles)
        {
            //Cargan los Detalles
            var detalles = from det in bd.Detalles
                           where det.IdPedido == idPedido
                           select det;
                       
            foreach (var detalle in detalles)
            {
                //Carga el articulo correspondiente a ese detalle
                var tempArt = (from art in bd.Articulos
                               where art.IdArticulo == detalle.IdArticulo
                               select art).Single();

                //Crea un DetalleTemporal con sus respectivos datos
                DetalleTemporal temp = new DetalleTemporal();
                temp.IdDetalle = detalle.IdDetalle;                
                temp.Cantidad = Convert.ToInt32(detalle.Cantidad);
                temp.SubTotal = Convert.ToDouble(detalle.SubTotal);
                temp.Descuento = Convert.ToDouble(detalle.Descuento);
                temp.Total = Convert.ToDouble(detalle.Total);
                temp.IdPedido = Convert.ToInt32(detalle.IdPedido);
                temp.IdArticulo = Convert.ToInt32(detalle.IdArticulo);
                temp.Articulo = tempArt.Denominacion;
                temp.PrecioUnitario = Convert.ToDouble(tempArt.PrecioVenta);

                //Agrega el DetalleTemporal a la listaDetalles
                listaDetalles.Add(temp);
            }
        }

        //Guarda la listaDetalles en una sesion
        Session["Detalles"] = listaDetalles;
    }

    private void rellenarTablaDetalles()
    {
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        grdDetalles.DataSource = listaDetalles;
        grdDetalles.DataBind();
    }
        
    //Boton Guardar
    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Si se quiere guardar un nuevo Pedido
            if (Request.QueryString["id"] == null)
            {
                crearPedido();
            }
            //Si se quiere editar un Pedido 
            else
            {
                editarPedido(Convert.ToInt32(Request.QueryString["id"]));
            }

            Response.Redirect("Pedidos.aspx");
        }        
    }
    
    //Boton Agregar Detalle
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //Muestra el formulario
        formularioDetalle.Visible = true;        
        hiddenFila.Value = "";
        Articulo tempArt = (from art in bd.Articulos
                            orderby art.Denominacion
                            select art).FirstOrDefault();
        ddlArticulo.SelectedValue = tempArt.IdArticulo.ToString();        
        txtPrecioUnitario.Text = String.Format("{0:C}", tempArt.PrecioVenta);
        txtCantidad.Text = "0";
        txtSubTotalSinDescuento.Text = String.Format("{0:C}", 0);
        txtDescuento.Text = String.Format("{0:P}", 0);
        txtSubTotalDetalle.Text = String.Format("{0:C}", 0);        
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
        txtPrecioUnitario.Text = String.Format("{0:C}", detalleSeleccionado.PrecioUnitario);
        txtCantidad.Text = detalleSeleccionado.Cantidad.ToString();
        txtSubTotalSinDescuento.Text = String.Format("{0:C}", (detalleSeleccionado.PrecioUnitario * detalleSeleccionado.Cantidad));
        txtDescuento.Text = String.Format("{0:P}", detalleSeleccionado.Descuento);
        txtSubTotalDetalle.Text = String.Format("{0:C}", detalleSeleccionado.Total);
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
        if(detalleSeleccionado.IdDetalle == 0)
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
                
        rellenarTablaDetalles();
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
                temp.IdPedido = Convert.ToInt32(Request.QueryString["id"]);                
                temp.Cantidad = Convert.ToInt32(txtCantidad.Text);
                temp.SubTotal = Convert.ToDouble(txtSubTotalSinDescuento.Text.Replace("$", "").Replace(".", ""));
                temp.Descuento = Convert.ToDouble(txtDescuento.Text.Replace(" %" , "")) / 100;
                temp.Total = Convert.ToDouble(txtSubTotalDetalle.Text.Replace("$", "").Replace(".", ""));                
                temp.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);
                temp.IdDetalle = 0;
                temp.Articulo = articulo.Denominacion;
                temp.PrecioUnitario = Convert.ToDouble(articulo.PrecioVenta);

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
                temp.SubTotal = Convert.ToDouble(txtSubTotalSinDescuento.Text.Replace("$", "").Replace(".", ""));
                temp.Descuento = Convert.ToDouble(txtDescuento.Text.Replace(" %", "")) / 100;
                temp.Total = Convert.ToDouble(txtSubTotalDetalle.Text.Replace("$", "").Replace(".", ""));
                temp.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);

                listaDetalles[Convert.ToInt32(hiddenFila.Value)] = temp;
                Session["Detalles"] = listaDetalles;
            }
            rellenarTablaDetalles();
            formularioDetalle.Visible = false;
            calcularTotales();
        }
    }

    //Cuando cambia alguno de los valores del formulario de detalles, se recalcula el subtotal de ese detalle
    protected void cambiaSubTotalDetalle(object sender, EventArgs e)
    {
        //
        int idArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);
        var articulo = (from art in bd.Articulos
                        where art.IdArticulo == idArticulo
                        select art).Single();

        double precioVenta = Convert.ToDouble(articulo.PrecioVenta);
        txtPrecioUnitario.Text = String.Format("{0:C}", precioVenta);

        int cantidad = 0;
        if(txtCantidad.Text != "")
        {
            cantidad = Convert.ToInt32(txtCantidad.Text);
        }

        double descuento = 0;
        if(txtDescuento.Text != "")
        {
            descuento = Convert.ToDouble(txtDescuento.Text.Replace(" %", ""));
        }
                
        double subTotal = cantidad * precioVenta;
        txtSubTotalSinDescuento.Text = String.Format("{0:C}", subTotal);
        subTotal = subTotal - subTotal * (descuento / 100);
        txtSubTotalDetalle.Text = String.Format("{0:C}", subTotal);
    }


    protected void cambiarGastosEnvio(object sender, EventArgs e)
    {
        sumarGastosEnvio();
    }

    private void sumarGastosEnvio()
    {
        double subtotal = Convert.ToDouble(txtSubTotal.Text.Replace("$", ""));
        double gastosEnvio = 0;

        //Se suman los gastos de envio            
        if(txtGastosEnvio.Text != "" && txtGastosEnvio.Text.Contains("$") && txtGastosEnvio.Text.Contains(","))
        {
            gastosEnvio = Convert.ToDouble(txtGastosEnvio.Text.Replace("$", ""));
        }   

        //Se calcula el total del pedido
        double total = subtotal + gastosEnvio;
        txtMontoTotal.Text = String.Format("{0:C}", total);
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
        txtSubTotal.Text = String.Format("{0:C}", subtotal);
        sumarGastosEnvio();
    }    

    private void calcularSaldoCliente(int idCliente)
    {
        double subtotalCliente = 0;

        //Se verifica si ese cliente tiene pedidos a su nombre
        bool tienePedidos = (from ped in bd.Pedidos
                             where ped.IdCliente == idCliente
                             select ped).Any();

        //Si tiene pedidos 
        if (tienePedidos)
        {
            //Se cargan los pedidos
            var pedidos = from ped in bd.Pedidos
                          where ped.IdCliente == idCliente
                          select ped;
                        
            foreach (var pedido in pedidos)
            {
                //Si el pedido no esta pagado
                if (!Convert.ToBoolean(pedido.Pagado))
                {
                    //Se suma el monto total de cada pedido
                    subtotalCliente += Convert.ToDouble(pedido.Total);
                }
            }
        }

        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == idCliente
                       select cli).Single();

        cliente.Saldo = 0 + subtotalCliente;
        bd.SubmitChanges();
    }    
    
    //Se guarda un pedido nuevo en la base de datos
    private void crearPedido()
    {
        //Se guardan los datos del pedido
        Pedido nuevoPedido = new Pedido();
        nuevoPedido.Editable = false;
        nuevoPedido.Estado = ddlEstado.SelectedValue;
        nuevoPedido.Pagado = cboxPagado.Checked;
        nuevoPedido.FechaPedido = Convert.ToDateTime(txtFecha.Text);
        nuevoPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
        nuevoPedido.SubTotal = Convert.ToDouble(txtSubTotal.Text.Replace("$", ""));
        nuevoPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text.Replace("$", ""));
        nuevoPedido.Total = Convert.ToDouble(txtMontoTotal.Text.Replace("$", ""));        
        nuevoPedido.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
        if (!usuario.Administrador)
        {
            nuevoPedido.IdVendedor = Convert.ToInt32(Session["IdVendedor"]);
        }
        else
        {
            nuevoPedido.IdVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);
        }
        bd.Pedidos.InsertOnSubmit(nuevoPedido);
        bd.SubmitChanges();

        //Persiste los detalles
        guardarDetalles(nuevoPedido.IdPedido);

        //Calcula el saldo del Cliente
        calcularSaldoCliente(Convert.ToInt32(nuevoPedido.IdCliente));                       
    }

    //Se edita un pedido ya existente en la base de datos
    private void editarPedido(int id)
    {
        var pedidoEditar = (from ped in bd.Pedidos
                             where ped.IdPedido == id
                             select ped).Single();

        pedidoEditar.Estado = ddlEstado.SelectedValue;
        pedidoEditar.Pagado = cboxPagado.Checked;
        pedidoEditar.FechaPedido = Convert.ToDateTime(txtFecha.Text);
        pedidoEditar.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);        
        pedidoEditar.SubTotal = Convert.ToDouble(txtSubTotal.Text.Replace("$", ""));
        pedidoEditar.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text.Replace("$", ""));
        pedidoEditar.Total = Convert.ToDouble(txtMontoTotal.Text.Replace("$", ""));        
        pedidoEditar.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
        if (usuario.Administrador)
        {
            pedidoEditar.IdVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);
        }

        bd.SubmitChanges();

        guardarDetalles(pedidoEditar.IdPedido);
        eliminarDetalles();

        calcularSaldoCliente(Convert.ToInt32(Session["ClienteAnterior"]));
        Session["ClienteAnterior"] = null;
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
            if (detalle.IdDetalle == 0)
            {
                //Se crea un nuevo detalle
                Detalle detalleNuevo = new Detalle();
                detalleNuevo.IdPedido = idPedido;
                detalleNuevo.Cantidad = detalle.Cantidad;
                detalleNuevo.SubTotal = detalle.SubTotal;
                detalleNuevo.Descuento = detalle.Descuento;
                detalleNuevo.Total = detalle.Total;
                detalleNuevo.IdArticulo = detalle.IdArticulo;

                //Se lo inserta en la base de datos
                bd.Detalles.InsertOnSubmit(detalleNuevo);
                bd.SubmitChanges();
            }
            //Si el detalle ya ha sido persistido
            else
            {
                //Se carga el detalle seleccionado
                var detalleEditado = (from det in bd.Detalles
                                      where det.IdDetalle == detalle.IdDetalle
                                      select det).Single();

                //Se cambian los datos
                detalleEditado.Cantidad = detalle.Cantidad;
                detalleEditado.SubTotal = detalle.SubTotal;
                detalleEditado.Descuento = detalle.Descuento;
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
            var temp = (from det in bd.Detalles
                        where det.IdDetalle == detalle.IdDetalle
                        select det).Single();

            bd.Detalles.DeleteOnSubmit(temp);            
        }
        bd.SubmitChanges();
    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        rellenarDomicilio(Convert.ToInt32(ddlCliente.SelectedValue));        
    }    
    
    //Rellena los campos del domicilio
    private void rellenarDomicilio(int idCliente)
    {
        var cliente = new Cliente();
        
        if (idCliente == 0)
        {
            cliente = (from cli in bd.Clientes
                       orderby cli.RazonSocial ascending
                       select cli).FirstOrDefault();
        }
        else
        {
            cliente = (from cli in bd.Clientes
                       where cli.IdCliente == idCliente
                       select cli).FirstOrDefault();
        }        

        var domicilio = (from dom in bd.Domicilios
                         where dom.IdDomicilio == cliente.IdDomicilio
                         select dom).FirstOrDefault();

        var localidad = (from loc in bd.Localidads
                         where loc.IdLocalidad == domicilio.IdLocalidad
                         select loc).FirstOrDefault();

        var provincia = (from prov in bd.Provincias
                         where prov.IdProvincia == localidad.IdProvincia
                         select prov).FirstOrDefault();

        var pais = (from p in bd.Pais
                    where p.IdPais == provincia.IdPais
                    select p).FirstOrDefault();

        txtCalle.Text = domicilio.Calle;
        txtNumeroCalle.Text = domicilio.Numero.ToString();
        txtPais.Text = pais.Denominacion;
        txtProvincia.Text = provincia.Denominacion;
        txtLocalidad.Text = localidad.Denominacion;
        txtLatitud.Value = domicilio.Latitud.ToString();
        txtLongitud.Value = domicilio.Longitud.ToString();
    }

    protected void cstvDescuento_ServerValidate(object source, ServerValidateEventArgs args)
    {
        double descuento = Convert.ToDouble(txtDescuento.Text.Replace(" %", ""));
        if (descuento < 0 || descuento > 100)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cstvMinimoDetalles_ServerValidate(object source, ServerValidateEventArgs args)
    {
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        if (listaDetalles.Count == 0)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cstvVendedor_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (usuario.Administrador)
        {
            if(ddlVendedor.SelectedValue == "1")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnCancelarPedido_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pedidos.aspx");
    }
}