using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Servicios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resaltarNavBar();        
    }

    private void resaltarNavBar()
    {
        HyperLink servicios = (HyperLink)Master.FindControl("hlServicios");
        servicios.CssClass = "active";
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ServicioEditar.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("ServicioEditar.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();

        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        var temp = (from serv in db.Servicios
                    where serv.ID_Servicio == idSeleccionado
                    select serv).Single();
        temp.Habilitado = false;
        db.SubmitChanges();
        grdServicios.DataBind();
    }



    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT * FROM Servicio WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        SqlDataSource1.SelectCommand = query;
        grdServicios.DataBind();
    }
}