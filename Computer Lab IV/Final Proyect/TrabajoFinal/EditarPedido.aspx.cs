using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarPedido : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bd = new BaseDatosDataContext();

        //Si se termina la sesion del usuario, se redirecciona a la pagina de login
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            //Si se esta insertando un pedido, se muestra un formulario vacio
            if(Request.QueryString["id"] == null)
            {
                imgbtnAdd.Visible = false;
                lblDetalles.Visible = false;
                if (!IsPostBack)
                {
                    lblTitulo.Text = "Agregar Pedido";
                    btnAccion.Text = "AGREGAR";
                    txtSubTotal.Text = "0";
                    txtMontoTotal.Text = "0";
                }
            }
            //Sino se muestra el formulario con sus respectivos datos
            else
            {
                if (!IsPostBack)
                {
                    //Se cambia el texto de los titulos y de los botones
                    lblTitulo.Text = "Editar Pedido";
                    btnAccion.Text = "GUARDAR";
                    lblTituloDetalle.Text = "Editar Detalle";
                    btnAccionDetalle.Text = "GUARDAR";

                    try
                    {
                        PedidoVenta tempPedido = (from ped in bd.PedidoVentas
                                                  where ped.IdPedidoVenta == Convert.ToInt32(Request.QueryString["id"])
                                                  select ped).Single();
                        Domicilio tempDom = (from dom in bd.Domicilios
                                             where dom.IdDomicilio == tempPedido.IdDomicilio
                                             select dom).Single();

                        //Se ponen los valores correspondientes al registro que se quiere editar
                        hiddenID.Value = tempPedido.IdPedidoVenta.ToString();
                        txtNumero.Text = tempPedido.NroPedido.ToString();
                        ddlCliente.SelectedValue = tempPedido.IdCliente.ToString();
                        ddlEstado.SelectedValue = tempPedido.Estado.ToString();
                        DateTime fecha = (DateTime)tempPedido.FechaPedido;
                        txtFecha.Text = fecha.ToString("yyyy-MM-dd");
                        DateTime fechaEntrega = (DateTime)tempPedido.FechaEstimadaEntrega;
                        txtFechaEntrega.Text = fechaEntrega.ToString("yyyy-MM-dd");
                        txtSubTotal.Text = tempPedido.SubTotal.ToString();
                        txtGastosEnvio.Text = tempPedido.GastosEnvio.ToString();
                        txtMontoTotal.Text = tempPedido.MontoTotal.ToString();
                        txtCalle.Text = tempDom.Calle;
                        txtNumeroCalle.Text = tempDom.Numero.ToString();
                        DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");
                        ddlLocalidad.SelectedValue = tempDom.Localidad;
                        if (tempDom.Latitud != null)
                        {
                            txtLatitud.Text = tempDom.Latitud.ToString();
                        }
                        if (tempDom.Longitud != null)
                        {
                            txtLongitud.Text = tempDom.Longitud.ToString();
                        }
                    }
                    catch (Exception) { }                   
                }
            }            
        }        
    }

    //Si no se paso ningun id como parametro, se agrega un nuevo pedido, sino se modifica uno ya existente
    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Request.QueryString["id"] == null)
                {
                    PedidoVenta tempPedido = new PedidoVenta();
                    tempPedido.IdVendedor = Convert.ToInt32(Session["IdVendedor"]);
                    tempPedido.NroPedido = Convert.ToInt64(txtNumero.Text);
                    tempPedido.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
                    tempPedido.Estado = ddlEstado.SelectedValue;
                    if (ddlEstado.SelectedValue == "Entregado")
                    {
                        tempPedido.Entregado = true;
                    }
                    else
                    {
                        tempPedido.Entregado = false;
                    }
                    tempPedido.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                    tempPedido.FechaEstimadaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                    tempPedido.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                    tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                    tempPedido.MontoTotal = tempPedido.SubTotal + tempPedido.GastosEnvio;
                    tempPedido.Editable = false;

                    Domicilio tempDom = new Domicilio();
                    tempDom.Calle = txtCalle.Text;
                    tempDom.Numero = Convert.ToInt32(txtNumeroCalle.Text);
                    DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");
                    tempDom.Localidad = ddlLocalidad.SelectedValue;
                    if (txtLatitud.Text != "")
                    {
                        tempDom.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDom.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    bd.Domicilios.InsertOnSubmit(tempDom);
                    bd.SubmitChanges();
                    tempPedido.IdDomicilio = tempDom.IdDomicilio;
                    bd.PedidoVentas.InsertOnSubmit(tempPedido);
                    bd.SubmitChanges();
                    calcularSaldoCliente(Convert.ToInt32(ddlCliente.SelectedValue));

                    Response.Redirect("EditarPedido.aspx?id=" + tempPedido.IdPedidoVenta);
                }
                else
                {
                    PedidoVenta tempPedido = (from ped in bd.PedidoVentas
                                              where ped.IdPedidoVenta == Convert.ToInt32(Request.QueryString["id"])
                                              select ped).Single();
                    Domicilio tempDom = (from dom in bd.Domicilios
                                         where dom.IdDomicilio == tempPedido.IdDomicilio
                                         select dom).Single();

                    //Se guardan los datos del pedido
                    tempPedido.NroPedido = Convert.ToInt64(txtNumero.Text);
                    tempPedido.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
                    tempPedido.Estado = ddlEstado.SelectedValue;
                    if (ddlEstado.SelectedValue == "Entregado")
                    {
                        tempPedido.Entregado = true;
                    }
                    else
                    {
                        tempPedido.Entregado = false;
                    }
                    tempPedido.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                    tempPedido.FechaEstimadaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                    tempPedido.GastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                    tempPedido.MontoTotal = Convert.ToDouble(txtMontoTotal.Text);
                    tempPedido.Editable = false;
                    tempDom.Calle = txtCalle.Text;
                    tempDom.Numero = Convert.ToInt32(txtNumeroCalle.Text);
                    DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");
                    tempDom.Localidad = ddlLocalidad.SelectedValue;
                    if (txtLatitud.Text != "")
                    {
                        tempDom.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDom.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    bd.SubmitChanges();
                    //Cambia el subtotal del pedido
                    calcularTotales(Convert.ToInt32(Request.QueryString["id"]));

                    //Cambia el saldo del cliente
                    calcularSaldoCliente(Convert.ToInt32(tempPedido.IdCliente));
                    Response.Redirect("Pedidos.aspx");
                }
            }
            catch (Exception) { }            
        }
    }

    //Se muestra el formulario detalle con los campos en blanco
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        lblTituloDetalle.Text = "Agregar Detalle";
        btnAccionDetalle.Text = "AGREGAR";
        formularioDetalle.Visible = true;
        vaciarFormularioDetalle();        
    }

    //Se cargan los datos del detalle seleccionado en el formulario detalle
    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        lblTituloDetalle.Text = "Editar Detalle";
        btnAccionDetalle.Text = "GUARDAR";
        formularioDetalle.Visible = true;

        try
        {
            hiddenID.Value = e.CommandArgument.ToString();

            PedidoVentaDetalle temp = (from detalle in bd.PedidoVentaDetalles
                                       where detalle.IdPedidoVentaDetalle == Convert.ToInt32(hiddenID.Value)
                                       select detalle).Single();

            ddlArticulo.SelectedValue = temp.IdArticulo.ToString();
            txtCantidad.Text = temp.Cantidad.ToString();
            txtDescuento.Text = (temp.PorcentajeDescuento * 100).ToString();
            txtSubTotalDetalle.Text = temp.SubTotal.ToString();
        }
        catch (Exception) { }        
    }

    //Se elimina el detalle seleccionado
    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            PedidoVentaDetalle temp = (from detalle in bd.PedidoVentaDetalles
                                       where detalle.IdPedidoVentaDetalle == Convert.ToInt32(e.CommandArgument)
                                       select detalle).Single();
            bd.PedidoVentaDetalles.DeleteOnSubmit(temp);
            bd.SubmitChanges();
            calcularTotales(Convert.ToInt32(Request.QueryString["id"]));
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception) { }
    }

    //Se vacia el formulario detalle y se oculta
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        vaciarFormularioDetalle();
        formularioDetalle.Visible = false;
    }

    //Si el hiddenID esta vacio, se agrega un detalle con los detalles ingresados, sino se modifica uno ya existente
    protected void btnAccionDetalle_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (hiddenID.Value == "")
                {
                    //Se crea un nuevo detalle y se lo inserta en la base de datos
                    PedidoVentaDetalle tempDetalle = new PedidoVentaDetalle();
                    tempDetalle.IdPedidoVenta = Convert.ToInt32(Request.QueryString["id"]);
                    tempDetalle.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);
                    tempDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    double descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                    tempDetalle.PorcentajeDescuento = descuento;
                    tempDetalle.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);
                    bd.PedidoVentaDetalles.InsertOnSubmit(tempDetalle);

                }
                else
                {
                    //Se edita el detalle en la base de datos
                    PedidoVentaDetalle tempDetalle = (from detalle in bd.PedidoVentaDetalles
                                                      where detalle.IdPedidoVentaDetalle == Convert.ToInt32(hiddenID.Value)
                                                      select detalle).Single();

                    tempDetalle.IdArticulo = Convert.ToInt32(ddlArticulo.SelectedValue);
                    tempDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                    double descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                    tempDetalle.PorcentajeDescuento = descuento;
                    tempDetalle.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);
                }

                //Se ejecutan los cambios y se oculta el formulario
                bd.SubmitChanges();
                grdDetalles.DataBind();
                vaciarFormularioDetalle();
                formularioDetalle.Visible = false;

                //Cambia el subtotal del pedido
                calcularTotales(Convert.ToInt32(Request.QueryString["id"]));

                //Cambia el saldo del cliente
                var temp = (from ped in bd.PedidoVentas
                            where ped.IdPedidoVenta == Convert.ToInt32(Request.QueryString["id"])
                            select ped).Single();

                calcularSaldoCliente(Convert.ToInt32(temp.IdCliente));
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception) { }                        
        }        
    }

    //Se vacian los campos del formulario detalle
    private void vaciarFormularioDetalle()
    {
        hiddenID.Value = "";
        txtCantidad.Text = "0";
        txtDescuento.Text = "0";
        txtSubTotalDetalle.Text = "0";
    }

    //Se calcula el subtotal del detalle cuando alguno de los campos del formulario detalle cambia
    protected void cambiaSubTotalDetalle(object sender, EventArgs e)
    {
        try
        {
            Articulo tempArt = (from art in bd.Articulos
                                where art.IdArticulo == Convert.ToInt32(ddlArticulo.SelectedValue)
                                select art).Single();
            double precioVenta = (Convert.ToDouble(tempArt.PrecioVenta));

            txtSubTotalDetalle.Text = "0";
            if (txtCantidad.Text != "")
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                txtSubTotalDetalle.Text = (precioVenta * cantidad).ToString();

                if (txtDescuento.Text != "")
                {
                    double descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                    if (descuento != 0)
                    {
                        txtSubTotalDetalle.Text = (((precioVenta * cantidad) * (100 - (descuento * 100))) / 100).ToString();
                    }
                }
            }
        }
        catch (Exception) { }        
    }

    //Cuando cambia el valor del campo Gastos de Envio, se calcula el monto total
    protected void cambiaTotal(object sender, EventArgs e)
    {
        try
        {
            double subTotal = Convert.ToDouble(txtSubTotal.Text);
            double total = subTotal;
            if (txtGastosEnvio.Text != "")
            {
                double gastosEnvio = Convert.ToDouble(txtGastosEnvio.Text);
                total = subTotal + gastosEnvio;
            }
            txtMontoTotal.Text = total.ToString();
        }
        catch (Exception) { }
    }



    //Se calculan el subtotal y el monto total
    private void calcularTotales(int id)
    {
        try
        {
            double subtotal = 0;
            bool hayDetalles = (from det in bd.PedidoVentaDetalles
                                where det.IdPedidoVenta == id
                                select det).Any();
            if (hayDetalles)
            {
                var detalles = from det in bd.PedidoVentaDetalles
                               where det.IdPedidoVenta == id
                               select det;

                foreach (var detalle in detalles)
                {
                    subtotal += Convert.ToDouble(detalle.SubTotal);
                }
            }
            var pedido = (from ped in bd.PedidoVentas
                          where ped.IdPedidoVenta == id
                          select ped).Single();
            pedido.SubTotal = subtotal;
            pedido.MontoTotal = subtotal;

            if (txtGastosEnvio.Text != "")
            {
                pedido.MontoTotal = subtotal + Convert.ToDouble(txtGastosEnvio.Text);
            }

            bd.SubmitChanges();
            txtSubTotal.Text = subtotal.ToString();
        }
        catch (Exception) { }        
    }

    //Se calcula el saldo del cliente
    private void calcularSaldoCliente(int id)
    {
        try
        {
            double saldo = 0;
            bool hayPedidos = (from ped in bd.PedidoVentas
                               where ped.IdCliente == id
                               select ped).Any();

            if (hayPedidos)
            {
                var pedidos = from ped in bd.PedidoVentas
                              where ped.IdCliente == id
                              select ped;

                foreach (var pedido in pedidos)
                {
                    saldo -= Convert.ToDouble(pedido.MontoTotal);
                }
            }

            Cliente cliente = (from cli in bd.Clientes
                               where cli.IdCliente == id
                               select cli).Single();

            cliente.Saldo = saldo;
            bd.SubmitChanges();
        }
        catch (Exception) { }        
    }    
}