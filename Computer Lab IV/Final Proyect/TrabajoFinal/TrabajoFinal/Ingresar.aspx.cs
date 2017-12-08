using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ingresar : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();
        
    protected void Page_Load(object sender, EventArgs e)
    {           
        //Si hay una sesion iniciada, se cierra
        if (Session["IdVendedor"] != null)
        {
            Session["IdVendedor"] = null;
        }        
    }

    //Valida que el usuario ingresado exista en la base de datos
    protected void cvUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            var temp = from vend in bd.Vendedors
                       where vend.Usuario == txtUsuario.Text
                       select vend;
            if (temp.Any())
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        catch (Exception) { }
    }

    //Valida que la contraseña ingresada sea la correcta
    protected void cvContrasenia_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            var temp = from vend in bd.Vendedors
                       where vend.Usuario == txtUsuario.Text
                       select vend;

            foreach (var vend in temp)
            {
                if (vend.Contrasenia == txtContrasenia.Text)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
        catch (Exception) { }
    }

    //Si las validaciones fueron correctas, se loguea al usuario y se redirecciona a la pagina de pedidos
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {               
            if (Page.IsValid)
            {
                var temp = (from vend in bd.Vendedors
                            where vend.Usuario == txtUsuario.Text
                            select vend).Single();

                Session.Timeout = 600;
                Session["IdVendedor"] = temp.IdVendedor;
                Response.Redirect("Pedidos.aspx");
            }
        }
        catch (Exception) { }        
    }   
}