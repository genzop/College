using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rubros : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            HyperLink rubros = (HyperLink)Master.FindControl("hlRubros");
            rubros.CssClass = "active";

            var usuario = (from vend in bd.Vendedors
                           where vend.IdVendedor == Convert.ToInt32(Session["IdVendedor"])
                           select vend).FirstOrDefault();

            if(!usuario.Administrador)
            {
                grdRubros.Columns[3].Visible = false;
                grdRubros.Columns[4].Visible = false;
                imgAdd.Visible = false;
            }
        }
    }

    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EditarRubro.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarRubro.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

            //Se verifica si el rubro tiene Articulos asociados
            bool tieneArticulos = (from art in bd.Articulos
                                   where art.IdRubro == idSeleccionado
                                   select art).Any();

            //Se verifica si el rubro tiene otros Rubros asociados
            bool tieneSubRubros = (from rub in bd.Rubros
                                   where rub.IdRubroSuperior == idSeleccionado
                                   select rub).Any();

            if (tieneArticulos || tieneSubRubros)
            {                
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorEliminarRubro", "alert('ERROR: El rubro no puede ser eliminado ya que hay otros rubros y/o articulos asociados a el')", true);                
            }
            else
            {
                var temp = (from rub in bd.Rubros
                            where rub.IdRubro == idSeleccionado
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
            query = "SELECT hijo.IdRubro, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion = '-'";
        }
        else
        {
            query = "SELECT hijo.IdRubro, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion = '-' AND " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        }
        SqlDataSource1.SelectCommand = query;
        grdRubros.DataBind();
    }    
}