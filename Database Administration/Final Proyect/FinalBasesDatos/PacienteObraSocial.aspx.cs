using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PacienteObraSocial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        newObraSocial.Visible = false;
        newPlan.Visible = false;
        fechaInicio.Visible = false;
        fechaFin.Visible = false;
        btnCancelar.Visible = false;
        btnGuardar.Visible = false;

        ClinicaDataContext db = new ClinicaDataContext();

        lblTitulo.Text = "Obra Social del Paciente";

        var temp = (from pac in db.Pacientes
                    where pac.ID_Paciente == Convert.ToInt32(Request.QueryString["id"])
                    select pac).Single();

        if (!IsPostBack)
        {
            lblPaciente.Text = temp.Apellido + ", " + temp.Nombre;      
        }    
    }

    protected void btnNuevoPlan_Click(object sender, EventArgs e)
    {
        newObraSocial.Visible = true;
        newPlan.Visible = true;
        fechaInicio.Visible = true;
        fechaFin.Visible = true;
        btnCancelar.Visible = true;
        btnGuardar.Visible = true;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();

        var temp = (from pac in db.Pacientes
                    where pac.ID_Paciente == Convert.ToInt32(Request.QueryString["id"])
                    select pac).Single();

        var nuevoPlan = new PacientePlan();
        nuevoPlan.ID_Paciente = temp.ID_Paciente;
        nuevoPlan.Habilitado = true;
        nuevoPlan.ID_Plan = Convert.ToInt32(ddlPlan.SelectedValue);
        nuevoPlan.Estado = "Activo";
        nuevoPlan.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);        
        nuevoPlan.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
        db.PacientePlans.InsertOnSubmit(nuevoPlan);
        db.SubmitChanges();
        grdPlanPaciente.DataBind();  

        newObraSocial.Visible = false;
        newPlan.Visible = false;
        fechaInicio.Visible = false;
        fechaFin.Visible = false;
        btnCancelar.Visible = false;
        btnGuardar.Visible = false;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        newObraSocial.Visible = false;
        newPlan.Visible = false;
        fechaInicio.Visible = false;
        fechaFin.Visible = false;
        btnCancelar.Visible = false;
        btnGuardar.Visible = false;
    }
}