using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MedicoEditar : System.Web.UI.Page
{
    ClinicaDataContext db = new ClinicaDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar Medico";
            tdEspecialidades.Visible = false;
        }
        else
        {
            lblTitulo.Text = "Editar Medico";

            ClinicaDataContext db = new ClinicaDataContext();

            var temp = (from med in db.Medicos
                        where med.ID_Medico == Convert.ToInt32(Request.QueryString["id"])
                        select med).Single();

            if (!IsPostBack)
            {
                txtNombre.Text = temp.Nombre;
                txtApellido.Text = temp.Apellido;
                txtMatricula.Text = temp.Matricula;
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Medico temp = new Medico();
            temp.Habilitado = true;
            temp.Nombre = txtNombre.Text;
            temp.Apellido = txtApellido.Text;
            temp.Matricula = txtMatricula.Text;
            db.Medicos.InsertOnSubmit(temp);
            db.SubmitChanges();
            Response.Redirect("MedicoEditar.aspx?id=" + temp.ID_Medico);            
        }
        else
        {
            var temp = (from med in db.Medicos
                        where med.ID_Medico == Convert.ToInt32(Request.QueryString["id"])
                        select med).Single();

            temp.Nombre = txtNombre.Text;
            temp.Apellido = txtApellido.Text;
            temp.Matricula = txtMatricula.Text;
            db.SubmitChanges();
            Response.Redirect("Medicos.aspx");
        }
        
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        formEspecialidad.Visible = true;
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        var temp = (from medesp in db.MedicoEspecialidads
                    where medesp.ID_MedicoEspecialidad == Convert.ToInt32(e.CommandArgument)
                    select medesp).Single();

        temp.Habilitado = false;
        db.SubmitChanges();
        grdEspecialidades.DataBind();
    }


    protected void btnCancelarEsp_Click(object sender, EventArgs e)
    {
        formEspecialidad.Visible = false;
    }

    protected void btnGuardarEsp_Click(object sender, EventArgs e)
    {
        MedicoEspecialidad temp = new MedicoEspecialidad();
        temp.Habilitado = true;
        temp.ID_Medico = Convert.ToInt32(Request.QueryString["id"]);
        temp.ID_Especialidad = Convert.ToInt32(ddlEspecialidades.SelectedValue);
        db.MedicoEspecialidads.InsertOnSubmit(temp);
        db.SubmitChanges();
        grdEspecialidades.DataBind();

        formEspecialidad.Visible = false;
    }
}