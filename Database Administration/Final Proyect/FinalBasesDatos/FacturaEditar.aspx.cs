using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacturaEditar : System.Web.UI.Page
{
    protected ClinicaDataContext db;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.db = new ClinicaDataContext();

        //Si se desea agregar una nueva factura, se setean los totales en 0
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar factura";
            tdDetalles.Visible = false; 

            if (!IsPostBack)
            {                                
                txtSubTotal.Text = "0";
                txtIva.Text = "0";
                txtDescuento.Text = "0";
                txtTotal.Text = "0";
            }
        }
        //Sino se cargan los datos de la factura selecionada y sus respectivos detalles
        else
        {
            lblTitulo.Text = "Editar factura";
            //Se cargan los datos de la factura seleccionada
            var temp = (from fac in db.Facturas
                        where fac.ID_Factura == Convert.ToInt32(Request.QueryString["id"]) && fac.Habilitado == true
                        select fac).Single();

            if (!IsPostBack)
            {
                //Se cargan los datos en los campos
                ddlPaciente.SelectedValue = temp.ID_Paciente.ToString();
                ddlTipo.SelectedValue = temp.Tipo.ToString();
                DateTime fecha = (DateTime)temp.Fecha;
                txtFecha.Text = fecha.ToString("yyyy-MM-dd");
                ddlEstado.SelectedValue = temp.Estado;
                txtSubTotal.Text = temp.SubTotal.ToString();
                txtIva.Text = temp.Iva.ToString();
                calcularDescuento(Convert.ToInt32(temp.ID_Paciente));
                txtTotal.Text = temp.Total.ToString();
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Si se esta agregando una factura
            if(Request.QueryString["id"] == null)
            {
                Factura temp = new Factura();
                temp.Habilitado = true;
                temp.ID_Paciente = Convert.ToInt32(ddlPaciente.SelectedValue);
                temp.Tipo = Convert.ToChar(ddlTipo.SelectedValue);
                temp.Fecha = Convert.ToDateTime(txtFecha.Text);
                temp.Estado = ddlEstado.SelectedValue;
                temp.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                temp.Iva = Convert.ToDouble(txtIva.Text);
                temp.Total = Convert.ToDouble(txtTotal.Text);
                db.Facturas.InsertOnSubmit(temp);
                db.SubmitChanges();
                Response.Redirect("FacturaEditar.aspx?id=" + temp.ID_Factura);
            }
            else
            {
                var temp = (from fact in db.Facturas
                            where fact.ID_Factura == Convert.ToInt32(Request.QueryString["id"]) && fact.Habilitado == true
                            select fact).Single();

                temp.ID_Paciente = Convert.ToInt32(ddlPaciente.SelectedValue);
                temp.Tipo = Convert.ToChar(ddlTipo.SelectedValue);
                temp.Fecha = Convert.ToDateTime(txtFecha.Text);
                temp.Estado = ddlEstado.SelectedValue;
                temp.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                temp.Iva = Convert.ToDouble(txtIva.Text);
                temp.Total = Convert.ToDouble(txtTotal.Text);
                db.SubmitChanges();
                Response.Redirect("Facturacion.aspx");
            }
        }
    }
    
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        formDetalle.Visible = true;
        lblTituloDetalle.Text = "Agregar Detalle";
        txtIdDetalle.Value = "0";
        txtCantidad.Text = "0";
        txtSubTotalDetalle.Text = "0";
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        formDetalle.Visible = true;
        lblTituloDetalle.Text = "Editar Detalle";

        var temp = (from det in db.FacturaDetalles
                    where det.ID_FacturaDetalle == Convert.ToInt32(e.CommandArgument)
                    select det).Single();

        txtIdDetalle.Value = temp.ID_FacturaDetalle.ToString();
        ddlServicio.SelectedValue = temp.ID_Servicio.ToString();
        txtCantidad.Text = temp.Cantidad.ToString();
        txtSubTotalDetalle.Text = temp.SubTotal.ToString();
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        var temp = (from det in db.FacturaDetalles
                    where det.ID_FacturaDetalle == Convert.ToInt32(e.CommandArgument)
                    select det).Single();

        temp.Habilitado = false;
        db.SubmitChanges();
        grdDetalles.DataBind();
    }

    protected void actualizarSubTotalDetalle(object sender, EventArgs e)
    {
        int idServicio = Convert.ToInt32(ddlServicio.SelectedValue);
        var servicioSeleccionado = (from serv in db.Servicios
                                    where serv.ID_Servicio == idServicio
                                    select serv).Single();

        int cantidad = Convert.ToInt32(txtCantidad.Text);
        double subTotal = Convert.ToDouble(servicioSeleccionado.Precio) * cantidad;
        txtSubTotalDetalle.Text = subTotal.ToString();
    }

    protected void btnCancelarDetalle_Click(object sender, EventArgs e)
    {
        formDetalle.Visible = false;
    }

    protected void btnGuardarDetalle_Click(object sender, EventArgs e)
    {
        if (txtIdDetalle.Value == "0")
        {
            FacturaDetalle detalleNuevo = new FacturaDetalle();
            detalleNuevo.Habilitado = true;
            detalleNuevo.ID_Factura = Convert.ToInt32(Request.QueryString["id"]);
            detalleNuevo.ID_Servicio = Convert.ToInt32(ddlServicio.SelectedValue);
            detalleNuevo.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalleNuevo.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);
            db.FacturaDetalles.InsertOnSubmit(detalleNuevo);
        }
        else
        {
            var detalle = (from det in db.FacturaDetalles
                           where det.ID_FacturaDetalle == Convert.ToInt32(txtIdDetalle.Value)
                           select det).Single();
            detalle.ID_Servicio = Convert.ToInt32(ddlServicio.SelectedValue);
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.SubTotal = Convert.ToDouble(txtSubTotalDetalle.Text);
        }
        db.SubmitChanges();
        grdDetalles.DataBind();
        formDetalle.Visible = false;

        actualizarSubTotal();
    }

    protected void actualizarSubTotal()
    {
        int idFactura = Convert.ToInt32(Request.QueryString["id"]);
        double subTotal = 0;
        double iva = 0;
        double descuento = Convert.ToDouble(txtDescuento.Text) / 100;

        bool tieneDetalles = (from det in db.FacturaDetalles
                              where det.ID_Factura == idFactura && det.Habilitado == true
                              select det).Any();

        if (tieneDetalles)
        {
            var detalles = from det in db.FacturaDetalles
                           where det.ID_Factura == idFactura && det.Habilitado == true
                           select det;

            foreach (var detalle in detalles)
            {
                subTotal += Convert.ToDouble(detalle.SubTotal);
            }
        }       

        if (txtIva.Text != "")
        {
            iva = Convert.ToDouble(txtIva.Text) / 100;
        }

        double total = subTotal + (subTotal * iva);
        if(descuento != 0)
        {
            total = total - (total * descuento);
        }
            
        txtSubTotal.Text = subTotal.ToString();
        txtTotal.Text = total.ToString();
    }

    protected void actualizarTotal(object sender, EventArgs e)
    {
        actualizarSubTotal();
    }

    protected void ddlPaciente_SelectedIndexChanged(object sender, EventArgs e)
    {
        calcularDescuento(Convert.ToInt32(ddlPaciente.SelectedValue));
        actualizarSubTotal();
    }

    protected void calcularDescuento(int idPaciente)
    {
        txtDescuento.Text = "0";

        var paciente = (from pac in db.Pacientes
                        where pac.ID_Paciente == idPaciente
                        select pac).Single();

        var tieneObraSocial = (from pacPlan in db.PacientePlans
                               where pacPlan.ID_Paciente == paciente.ID_Paciente
                               select pacPlan).Any();

        if (tieneObraSocial)
        {
            PacientePlan planMasReciente = (from pacPlan in db.PacientePlans
                                            where pacPlan.ID_Paciente == paciente.ID_Paciente
                                            orderby pacPlan.FechaFin descending
                                            select pacPlan).First();

            DateTime hoy = DateTime.Today;

            if (DateTime.Compare(hoy, Convert.ToDateTime(planMasReciente.FechaInicio)) >= 0 && DateTime.Compare(hoy, Convert.ToDateTime(planMasReciente.FechaFin)) <= 0)
            {
                var plan = (from p in db.Plans
                            where p.ID_Plan == planMasReciente.ID_Plan
                            select p).Single();

                txtDescuento.Text = (plan.Descuento * 100).ToString();
            }
        }
    }
}