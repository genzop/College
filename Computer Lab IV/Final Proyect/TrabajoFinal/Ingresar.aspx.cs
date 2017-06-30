using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ingresar : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    //Si llega a haber una sesion iniciada, se vacia
    protected void Page_Load(object sender, EventArgs e)
    {   
        bd = new BaseDatosDataContext();

        if (Session["IdVendedor"] != null)
        {
            Session["IdVendedor"] = null;
        }

        if(Request.QueryString["user"] != null)
        {
            txtUsuario.Text = Request.QueryString["user"].ToString();
        }
    }

    //Se valida que el usuario ingresado exista en la base de datos
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

    //Se valida que la contraseña ingresada sea la correcta
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

    //Si la pagina es valida se inicia sesion con la cuenta ingresada y se redirecciona a la pagina de pedidos
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