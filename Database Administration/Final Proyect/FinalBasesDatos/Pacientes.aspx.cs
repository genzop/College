using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resaltarNavBar();
    }

    private void resaltarNavBar()
    {
        HyperLink Pacientes = (HyperLink)Master.FindControl("hlPacientes");
        Pacientes.CssClass = "active";
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PacienteEditar.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("PacienteEditar.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();
        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        var temp = (from pac in db.Pacientes
                    where pac.ID_Paciente == idSeleccionado
                    select pac).Single();

        db.Pacientes.DeleteOnSubmit(temp);
        db.SubmitChanges();
        grdPacientes.DataBind();
    }

    protected void historiaClinica_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();
        var paciente = (from pac in db.Pacientes
                        where pac.ID_Paciente == Convert.ToInt32(e.CommandArgument)
                        select pac).Single();

        Response.Redirect("HistoriaClinica.aspx?id=" + paciente.ID_Paciente + "&historia=" + paciente.ID_HistoriaClinica);
    }
    protected void obraSocial_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("PacienteObraSocial.aspx?id=" + e.CommandArgument);
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT * FROM paciente WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        SqlDataSource1.SelectCommand = query;
        grdPacientes.DataBind();
    }
}