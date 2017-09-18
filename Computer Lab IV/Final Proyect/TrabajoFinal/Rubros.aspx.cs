using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rubros : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bd = new BaseDatosDataContext();

        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            HyperLink rubros = (HyperLink)Master.FindControl("hlRubros");
            rubros.CssClass = "active";

            if(Convert.ToInt32(Session["IdVendedor"]) != 20)
            {
                grdRubros.Columns[3].Visible = false;
                grdRubros.Columns[4].Visible = false;
                imgAdd.Visible = false;
            }
        }
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarRubro.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string idSeleccionado = e.CommandArgument.ToString();

            bool tieneArticulos = (from art in bd.Articulos
                                   where art.IdRubro == Convert.ToInt32(idSeleccionado)
                                   select art).Any();

            bool tieneSubRubros = (from rub in bd.Rubros
                                   where rub.IdRubroSuperior == Convert.ToInt32(idSeleccionado)
                                   select rub).Any();

            if (tieneArticulos || tieneSubRubros)
            {
                Response.Write("<script language=\"JavaScript\">alert(\"El rubro no puede ser eliminado ya que hay articulos o subrubros asociados con el\")</script>");
            }
            else
            {
                var temp = (from rub in bd.Rubros
                            where rub.IdRubro == Convert.ToInt32(idSeleccionado)
                            select rub).Single();

                bd.Rubros.DeleteOnSubmit(temp);
                bd.SubmitChanges();
                grdRubros.DataBind();
            }
        }
        catch (Exception) { }           
    }

    protected void imgFind_Click(object sender, ImageClickEventArgs e)
    {
        string query = "";

        if (txtBuscar.Text == "")
        {
            query = "SELECT hijo.IdRubro, hijo.Codigo, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion = '-'";
        }
        else
        {
            query = "SELECT hijo.IdRubro, hijo.Codigo, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion = '-' AND " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        }

        SqlDataSource1.SelectCommand = query;
        grdRubros.DataBind();
    }

    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EditarRubro.aspx");
    }
}