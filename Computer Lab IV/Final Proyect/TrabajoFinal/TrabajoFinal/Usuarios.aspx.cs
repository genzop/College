using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios : System.Web.UI.Page
{
    private BaseDatosDataContext bd = new BaseDatosDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = (from vend in bd.Vendedors
                       where vend.IdVendedor == Convert.ToInt32(Session["IdVendedor"])
                       select vend).FirstOrDefault();

        if (!usuario.Administrador)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            HyperLink usuarios = (HyperLink)Master.FindControl("hlUsuarios");
            usuarios.CssClass = "active";
        }        
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
    
    protected void imgFind_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBuscar.Text == "admin")
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorBuscarAdmin", "alert('ERROR: No se puede modificar la informacion del administrador')", true);
        }
        else
        {
            Vendedor tempVend = (from vend in bd.Vendedors
                                 where vend.Usuario == txtBuscar.Text
                                 select vend).FirstOrDefault();
            if (tempVend != null)
            {
                formUsuario.Visible = true;
                hdnID.Value = tempVend.IdVendedor.ToString();
                txtNombre.Text = tempVend.Nombre;
                txtApellido.Text = tempVend.Apellido;
                txtUsuario.Text = tempVend.Usuario;
                txtContrasenia.Text = tempVend.Contrasenia;
                txtConfirmarContrasenia.Text = tempVend.Contrasenia;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorBuscarUsuario", "alert('ERROR: El usuario buscado no existe')", true);
            }
        }
    }

    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        formUsuario.Visible = true;
        hdnID.Value = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtUsuario.Text = "";
        txtContrasenia.Text = "";
        txtConfirmarContrasenia.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        formUsuario.Visible = false;
    }
    
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (hdnID.Value == "")
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
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    Vendedor temp = (from vend in bd.Vendedors
                                     where vend.IdVendedor == Convert.ToInt32(hdnID.Value)
                                     select vend).FirstOrDefault();

                    temp.Nombre = txtNombre.Text;
                    temp.Apellido = txtApellido.Text;
                    temp.Usuario = txtUsuario.Text;
                    temp.Contrasenia = txtContrasenia.Text;

                    bd.SubmitChanges();
                }
                catch (Exception) { }
            }
            formUsuario.Visible = false;
        }
    }

    //Valida que el nombre de usuario no este en uso
    protected void cvUsuarioUnico_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Si se esta creando un Vendedor
        if (hdnID.Value == "")
        {
            //Revisa si ya existe un Vendedor con ese nombre de usuario
            var usuario = (from vend in bd.Vendedors
                           where vend.Usuario == txtUsuario.Text
                           select vend).FirstOrDefault();

            if (usuario == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        //Si se esta editando un Vendedor
        else{
            //Revisa si otro Vendedor esta utilizando ese nombre de usuario
            var usuario = (from vend in bd.Vendedors
                           where vend.Usuario == txtUsuario.Text && vend.IdVendedor != Convert.ToInt32(hdnID.Value)
                           select vend).FirstOrDefault();

            if (usuario == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}