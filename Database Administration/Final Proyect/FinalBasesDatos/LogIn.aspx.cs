using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    ClinicaDataContext clinica = new ClinicaDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Se vacia la sesion
        Session["TipoUsuario"] = null;

        //Si se registro un nuevo usuario
        if (Request.QueryString["user"] != null)
        {            
            if (!IsPostBack)
            {
                Response.Write("<script language='javascript'>alert('El usuario fue creado exitosamente')</script>");
                txtUsuario.Text = Request.QueryString["user"].ToString();
            }
            
        }
    }

    protected void cstvUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Se valida que el usuario ingresado exista en la base de datos y este habilitado
        bool existeUsuario = (from user in clinica.Usuarios
                              where user.Nombre == txtUsuario.Text && user.Habilitado == true
                              select user).Any();
        if (existeUsuario)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void cstvContrasenia_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Si el usuario es valido
        if (cstvUsuario.IsValid)
        {
            //Se valida que la contraseña sea correcta
            var usuario = (from user in clinica.Usuarios
                           where user.Nombre == txtUsuario.Text
                           select user).Single();
            if (usuario.Contrasenia == txtContrasenia.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }                  
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var usuario = (from user in clinica.Usuarios
                           where user.Nombre == txtUsuario.Text
                           select user).Single();

            var tipoUsuario = (from tipo in clinica.TipoUsuarios
                               where tipo.ID_TipoUsuario == usuario.ID_TipoUsuario
                               select tipo).Single();

            Session["TipoUsuario"] = tipoUsuario.Denominacion;
            Response.Redirect("Turnos.aspx");            
        }
    }
}