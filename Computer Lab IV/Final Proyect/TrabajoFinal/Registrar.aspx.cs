using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registrar : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bd = new BaseDatosDataContext();
    }

    //Se valida que el nombre de usuario ingresado no este en uso
    protected void cvUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            var temp = from vend in bd.Vendedors
                       where vend.Usuario == txtUsuario.Text
                       select vend;

            if (temp.Any())
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        catch (Exception) { }        
    }

    //Si la pagina es valida, se registra un nuevo usuario en la base de datos
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Vendedor temp = new Vendedor();
                temp.Nombre = txtNombre.Text;
                temp.Apellido = txtApellido.Text;
                temp.Usuario = txtUsuario.Text;
                temp.Contrasenia = txtContrasenia.Text;

                bd.Vendedors.InsertOnSubmit(temp);
                bd.SubmitChanges();

                Response.Redirect("Ingresar.aspx?user=" + temp.Usuario);
            }
            catch (Exception) { }     
        }       
    }   
}