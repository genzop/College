using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registrar : System.Web.UI.Page
{
    ClinicaDataContext clinica = new ClinicaDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }



    protected void cvUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Se valida que no exista un usuario con ese nombre
        var existe = (from user in clinica.Usuarios
                      where user.Nombre == txtUsuario.Text
                      select user).Any();
        if (existe)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                //Se crea un nuevo usuario
                Usuario newUser = new Usuario();
                newUser.ID_TipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                newUser.Nombre = txtUsuario.Text;
                newUser.Contrasenia = txtContrasenia.Text;
                newUser.Habilitado = true;

                //Se lo agrega a la base de datos
                clinica.Usuarios.InsertOnSubmit(newUser);
                clinica.SubmitChanges();

                //Si el usuario es un medico
                if(newUser.ID_TipoUsuario == 3)
                {
                    //Se guarda el id del medico seleccionado
                    int idMedico = Convert.ToInt32(ddlMedicos.SelectedValue);

                    //Se le vincula el usuario creado
                    var medico = (from med in clinica.Medicos
                                  where med.ID_Medico == idMedico
                                  select med).Single();
                    medico.ID_Usuario = newUser.ID_Usuario;    
                    clinica.SubmitChanges();
                }

                //Se redirecciona a la pagina de login
                Response.Redirect("LogIn.aspx?user=" + newUser.Nombre);
            }
            catch (Exception) { }            
        }
    }

    
    protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Si se desea registrar un usuario de tipo medico, se muestra el dropdownlist para elegir que medico
        if(ddlTipoUsuario.SelectedValue == "3")
        {
            campoMedico.Visible = true;
        }
        else
        {
            campoMedico.Visible = false;
        }
    }
}