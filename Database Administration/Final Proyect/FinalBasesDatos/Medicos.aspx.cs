using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Medicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resaltarNavBar();       
    }

    private void resaltarNavBar()
    {
        HyperLink medicos = (HyperLink)Master.FindControl("hlMedicos");
        medicos.CssClass = "active";    
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MedicoEditar.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MedicoEditar.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();
        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        var temp = (from med in db.Medicos
                    where med.ID_Medico == idSeleccionado
                    select med).Single();

        temp.Habilitado = false;
        db.SubmitChanges();
        grdMedicos.DataBind();
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT * FROM Medico WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        SqlDataSource1.SelectCommand = query;
        grdMedicos.DataBind();
    }
}