using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServicioEditar : System.Web.UI.Page
{
    ClinicaDataContext db = new ClinicaDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar Servicio";
            tdEditar.Visible = false;
        }
        else
        {
            lblTitulo.Text = "Editar Servicio";

            

            var temp = (from serv in db.Servicios
                        where serv.ID_Servicio == Convert.ToInt32(Request.QueryString["id"])
                        select serv).Single();
            if (!IsPostBack)
            {
                txtDenominacion.Text = temp.Denominacion;
                txtPrecio.Text = temp.Precio.ToString().Replace(',', '.');
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {        
        if (Request.QueryString["id"] == null)
        {
            Servicio temp = new Servicio();
            temp.Habilitado = true;
            temp.Denominacion = txtDenominacion.Text;
            temp.Precio = Convert.ToDouble(txtPrecio.Text);
            db.Servicios.InsertOnSubmit(temp);
            db.SubmitChanges();
            Response.Redirect("ServicioEditar.aspx?id=" + temp.ID_Servicio);          
        }
        else
        {
            var temp = (from serv in db.Servicios
                        where serv.ID_Servicio == Convert.ToInt32(Request.QueryString["id"])
                        select serv).Single();
            temp.Denominacion = txtDenominacion.Text;
            temp.Precio = Convert.ToDouble(txtPrecio.Text.Replace('.', ','));
            db.SubmitChanges();
            Response.Redirect("Servicios.aspx");
        }        
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        formMedicos.Visible = true;
    }

    protected void btnCancelarMed_Click(object sender, EventArgs e)
    {
        formMedicos.Visible = false;    
    }

    protected void btnGuardarMed_Click(object sender, EventArgs e)
    {
        MedicoServicio temp = new MedicoServicio();
        temp.Habilitado = true;
        temp.ID_Medico = Convert.ToInt32(ddlMedicos.SelectedValue);
        temp.ID_Servicio = Convert.ToInt32(Request.QueryString["id"]);
        db.MedicoServicios.InsertOnSubmit(temp);
        db.SubmitChanges();
        grdMedicos.DataBind();

        formMedicos.Visible = false;
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        var temp = (from medserv in db.MedicoServicios
                    where medserv.ID_MedicoServicio == Convert.ToInt32(e.CommandArgument)
                    select medserv).Single();

        temp.Habilitado = false;
        db.SubmitChanges();
        grdMedicos.DataBind();
    }
}