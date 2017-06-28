using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facturacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink facturacion = (HyperLink)Master.FindControl("hlFacturacion");
        facturacion.CssClass = "active";
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    { 
        //Se redirecciona a la pagina para agregar una factura
        Response.Redirect("FacturaEditar.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        //Se redirecciona a la pagina para editar una factura
        Response.Redirect("FacturaEditar.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();
                
        int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

        //Se guarda la factura seleccionada
        var temp = (from fact in db.Facturas
                    where fact.ID_Factura == idSeleccionado
                    select fact).Single();

        //Se da una baja logica
        temp.Habilitado = false;
        db.SubmitChanges();
        grdFacturas.DataBind();
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {        
        string query = "SELECT Factura.ID_Factura, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Factura.Tipo, Factura.Fecha, Factura.Estado, Factura.Total FROM Factura INNER JOIN Paciente ON Factura.ID_Paciente = Paciente.ID_Paciente WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%' AND Factura.Habilitado = 'true'";
        SqlDataSource1.SelectCommand = query;
        grdFacturas.DataBind();
    }
     
}