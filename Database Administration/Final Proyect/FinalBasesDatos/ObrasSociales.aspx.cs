using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ObrasSociales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resaltarNavbar();
    }

    private void resaltarNavbar()
    {
        HyperLink obraSocial = (HyperLink)Master.FindControl("hlObraSocial");
        obraSocial.CssClass = "active";
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ObraSocialEditar.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("ObraSocialEditar.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();
        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        var temp = (from ob in db.ObraSocials
                    where ob.ID_ObraSocial == idSeleccionado
                    select ob).Single();

        db.ObraSocials.DeleteOnSubmit(temp);
        db.SubmitChanges();
        grdObraSocial.DataBind();
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT * FROM ObraSocial WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        SqlDataSource1.SelectCommand = query;
        grdObraSocial.DataBind();
    }
}