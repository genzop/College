using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ObraSocialEditar : System.Web.UI.Page
{
    ClinicaDataContext db = new ClinicaDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar Obra Social";
            tdPlanes.Visible = false;
        }
        else
        {
            lblTitulo.Text = "Editar Obra Social";
                        
            var temp = (from ob in db.ObraSocials
                        where ob.ID_ObraSocial == Convert.ToInt32(Request.QueryString["id"])
                        select ob).Single();

            if (!IsPostBack)
            {
                txtNombre.Text = temp.Nombre;
                txtDireccion.Text = temp.Direccion;
                ddlLocalidad.SelectedValue = temp.Localidad;
                txtTelefono.Text = temp.Telefono;
            }
        }

        formPlan.Visible = false;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            ObraSocial temp = new ObraSocial();
            temp.Habilitado = true;
            temp.Nombre = txtNombre.Text;
            temp.Direccion = txtDireccion.Text;
            temp.Localidad = ddlLocalidad.SelectedValue;
            temp.Telefono = txtTelefono.Text;
            db.ObraSocials.InsertOnSubmit(temp);
            db.SubmitChanges();
            Response.Redirect("ObraSocialEditar.aspx?id=" + temp.ID_ObraSocial);
        }
        else
        {
            var temp = (from ob in db.ObraSocials
                        where ob.ID_ObraSocial == Convert.ToInt32(Request.QueryString["id"])
                        select ob).Single();

            temp.Nombre = txtNombre.Text;
            temp.Direccion = txtDireccion.Text;
            temp.Localidad = ddlLocalidad.SelectedValue;
            temp.Telefono = txtTelefono.Text;
            db.SubmitChanges();
            Response.Redirect("ObrasSociales.aspx");
        }
        
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Write("<script language='javascript'>alert('Antes de poder agregar un plan a la Obra Social, debe guardar sus correspondientes datos.')</script>");
        }
        else
        {
            formPlan.Visible = true;
            txtIDPlan.Value = "";
            txtDenominacion.Text = "";
            txtDescuento.Text = "";
        }        
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        string idSeleccionado = e.CommandArgument.ToString();
            
        Plan temp = (from plan in db.Plans
                     where plan.ID_Plan == Convert.ToInt32(idSeleccionado)
                     select plan).Single();

        formPlan.Visible = true;

        txtIDPlan.Value = idSeleccionado;
        txtDenominacion.Text = temp.Denominacion;
        txtDescuento.Text = (Convert.ToDouble(temp.Descuento) * 100).ToString();

    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        var temp = (from plan in db.Plans
                    where plan.ID_Plan == idSeleccionado
                    select plan).Single();
        temp.Habilitado = false;        
        db.SubmitChanges();
        grdPlan.DataBind();
    }

    protected void btnGuardarPlan_Click(object sender, EventArgs e)
    {
        if (txtIDPlan.Value == "")
        {
            Plan temp = new Plan();
            temp.Habilitado = true;
            temp.Denominacion = txtDenominacion.Text;
            temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
            temp.ID_ObraSocial = Convert.ToInt32(Request.QueryString["id"]);

            db.Plans.InsertOnSubmit(temp);
        } 
        else
        {
            var temp = (from plan in db.Plans
                        where plan.ID_Plan == Convert.ToInt32(txtIDPlan.Value)
                        select plan).Single();

            temp.Denominacion = txtDenominacion.Text;
            temp.Descuento = Convert.ToDouble(txtDescuento.Text) / 100;
        }

        db.SubmitChanges();
        grdPlan.DataBind();
        formPlan.Visible = false;
    }

    protected void btnCancelarPlan_Click(object sender, EventArgs e)
    {
        formPlan.Visible = false;
    }    
}