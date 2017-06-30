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

        //Se rellenan los campos del pedido
        hiddenID.Value = pedido.IdPedidoVenta.ToString();
        txtNumero.Text = pedido.NroPedido.ToString();
        ddlCliente.SelectedValue = pedido.IdCliente.ToString();
        ddlEstado.SelectedValue = pedido.Estado;
        DateTime fecha = (DateTime)pedido.FechaPedido;
        txtFecha.Text = fecha.ToString("yyyy-MM-dd");
        DateTime fechaEntrega = (DateTime)pedido.FechaEstimadaEntrega;
        txtFechaEntrega.Text = fechaEntrega.ToString("yyyy-MM-dd");
        txtSubTotal.Text = pedido.SubTotal.ToString();
        txtGastosEnvio.Text = pedido.GastosEnvio.ToString();
        txtMontoTotal.Text = pedido.MontoTotal.ToString();

        //Se carga el domicilio correspondiente
        var domicilio = (from dom in bd.Domicilios
                         where dom.IdDomicilio == pedido.IdDomicilio
                         select dom).Single();

        //Se rellenan los campos del domicilio
        txtCalle.Text = domicilio.Calle;
        txtNumeroCalle.Text = domicilio.Numero.ToString();
        DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");
        ddlLocalidad.SelectedValue = domicilio.Localidad;
        if(domicilio.Latitud != null)
        {
            txtLatitud.Text = domicilio.Latitud.ToString();
        }
        if(domicilio.Longitud != null)
        {
            txtLongitud.Text = domicilio.Longitud.ToString();
        }
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
                temp.Descuento = Convert.ToDouble(detalle.PorcentajeDescuento);
                temp.SubTotal = Convert.ToDouble(detalle.SubTotal);
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
    
    protected void btnAccion_Click(object sender, EventArgs e)
    {
        
    }
    
    //Se hace click en Agregar Detalle
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //Se muestra el formulario para detalles en blanco
        formularioDetalle.Visible = true;
        lblTituloDetalle.Text = "Agregar Detalle";
        hiddenFila.Value = "";
        txtCantidad.Text = "0";
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
        lblTituloDetalle.Text = "Editar Detalle";

        //Se carga el detalle seleccionado de la lista de detalles
        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        DetalleTemporal detalleSeleccionado = listaDetalles[fila];

        //Se cargan los datos del detalle seleccionado en el formulario
        hiddenFila.Value = fila.ToString();
        ddlArticulo.SelectedValue = detalleSeleccionado.IdArticulo.ToString();
        txtCantidad.Text = detalleSeleccionado.Cantidad.ToString();
        txtDescuento.Text = (detalleSeleccionado.Descuento * 100).ToString();
        txtSubTotalDetalle.Text = detalleSeleccionado.SubTotal.ToString();
    }


    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        //Se guarda el numero de la fila que se quiere editar
        ImageButton btn = (ImageButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int fila = row.RowIndex;

        List<DetalleTemporal> listaDetalles = (List<DetalleTemporal>)Session["Detalles"];
        listaDetalles.RemoveAt(fila);
        Session["Detalles"] = listaDetalles;
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
                temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                temp.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);                
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
                temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
                temp.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);
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
                subtotal += detalle.SubTotal;
            }
        }
        txtSubTotal.Text = subtotal.ToString();
        sumarGastosEnvio();
    }

    

    private void calcularSaldoCliente(int id)
    {
     
    }    
}