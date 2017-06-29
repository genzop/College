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
            }
            //Si se paso un id como parametro
            else
            {
                lblTitulo.Text = "Editar Pedido";
                if (!IsPostBack)
                {
                    cargarPedido(Int32.Parse(Request.QueryString["id"]));
                    
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

    }
    
    protected void btnAccion_Click(object sender, EventArgs e)
    {
        
    }
    
    //Se hace click en Agregar Detalle
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        formularioDetalle.Visible = true;
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        
    }


    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
       
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnAccionDetalle_Click(object sender, EventArgs e)
    {
    }

    private void vaciarFormularioDetalle()
    {
   
    }


    protected void cambiaSubTotalDetalle(object sender, EventArgs e)
    {
        
    }


    protected void cambiaTotal(object sender, EventArgs e)
    {
    
    }
    
    private void calcularTotales(int id)
    {
       
    }


    private void calcularSaldoCliente(int id)
    {
     
    }    
}