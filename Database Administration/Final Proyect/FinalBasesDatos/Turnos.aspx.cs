using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Turnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resaltarNavBar();
    }

    private void resaltarNavBar()
    {
        HyperLink turnos = (HyperLink)Master.FindControl("hlTurnos");
        turnos.CssClass = "active";
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        /*SELECT Turno.ID_Turno, Turno.FechaHora, Turno.Estado, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Medico.Nombre + ' ' + Medico.Apellido AS Medico FROM Turno INNER JOIN Paciente ON Turno.ID_Paciente = Paciente.ID_Paciente INNER JOIN Medico ON Turno.ID_Medico = Medico.ID_Medico*/
        /*string query = "SELECT Factura.ID_Factura, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Factura.Tipo, Factura.Fecha, Factura.Estado, Factura.Total FROM Factura INNER JOIN Paciente ON Factura.ID_Paciente = Paciente.ID_Paciente WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%' AND Factura.Habilitado = 'true'";*/
        string query = "SELECT Turno.ID_Turno, Turno.FechaHora, Turno.Estado, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Medico.Nombre + ' ' + Medico.Apellido AS Medico FROM Turno INNER JOIN Paciente ON Turno.ID_Paciente = Paciente.ID_Paciente INNER JOIN Medico ON Turno.ID_Medico = Medico.ID_Medico WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        SqlDataSource1.SelectCommand = query;
        grdTurnos.DataBind();
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["TipoUsuario"].ToString() == "Medico")
        {
            Response.Write("<script language='javascript'>alert('No se tiene los permisos necesarios para ejecutar esa accion')</script>");
        }
        else
        {
            //Redirecciona para agregar un nuevo turno
            Response.Redirect("TurnoEditar.aspx");
        }        
    }
    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        //Redirecciona para editar un turno con id de la fila seleccionada
        if (Session["TipoUsuario"].ToString() == "Medico")
        {
            Response.Write("<script language='javascript'>alert('No se tiene los permisos necesarios para ejecutar esa accion')</script>");
        }
        else
        {
            Response.Redirect("TurnoEditar.aspx?id=" + e.CommandArgument);
        }        
    }
    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        if (Session["TipoUsuario"].ToString() == "Medico")
        {
            Response.Write("<script language='javascript'>alert('No se tiene los permisos necesarios para ejecutar esa accion')</script>");
        }
        else
        {
            ClinicaDataContext db = new ClinicaDataContext();
            int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString());

            var temp = (from tur in db.Turnos
                        where tur.ID_Turno == idSeleccionado
                        select tur).Single();
            db.Turnos.DeleteOnSubmit(temp);
            db.SubmitChanges();
            grdTurnos.DataBind();
        }        
    }
}
 