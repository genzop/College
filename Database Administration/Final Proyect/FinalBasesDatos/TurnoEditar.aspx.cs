using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TurnoEditar : System.Web.UI.Page
{
    ClinicaDataContext db = new ClinicaDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar Turno";
        }
        else
        {
            lblTitulo.Text = "Editar Turno";

            ClinicaDataContext db = new ClinicaDataContext();

            var temp = (from tur in db.Turnos
                        where tur.ID_Turno == Convert.ToInt32(Request.QueryString["id"])
                        select tur).Single();

            if (!IsPostBack)
            {
                //Se cargan los datos en los campos
                DateTime fecha = (DateTime)temp.FechaHora;
                txtFechaHora.Text = fecha.ToString(" yyyy-MM-dd HH:mm:ss");
                ddlEstado.SelectedValue = temp.Estado;
                ddlPaciente.SelectedValue = temp.ID_Paciente.ToString();
                ddlMedico.SelectedValue = temp.ID_Medico.ToString();
            }
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Request.QueryString["id"] == null)
            {
                Turno temp = new Turno();
                
                temp.FechaHora = Convert.ToDateTime(txtFechaHora.Text);
                temp.Estado = ddlEstado.SelectedValue;
                temp.ID_Paciente = Convert.ToInt32(ddlPaciente.SelectedValue);
                temp.ID_Medico = Convert.ToInt32(ddlMedico.SelectedValue);
                db.Turnos.InsertOnSubmit(temp);
                db.SubmitChanges();
                Response.Redirect("TurnoEditar.aspx?id=" + temp.ID_Turno);
            }
            else
            {
                var temp = (from tur in db.Turnos
                            where tur.ID_Turno == Convert.ToInt32(Request.QueryString["id"])
                            select tur).Single();

                temp.FechaHora = Convert.ToDateTime(txtFechaHora.Text);
                temp.Estado = ddlEstado.SelectedValue;
                temp.ID_Paciente = Convert.ToInt32(ddlPaciente.SelectedValue);
                temp.ID_Medico = Convert.ToInt32(ddlMedico.SelectedValue);
                db.SubmitChanges();
                Response.Redirect("Turnos.aspx");
            }

        }
    }
}