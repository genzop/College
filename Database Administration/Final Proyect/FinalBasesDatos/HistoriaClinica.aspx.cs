using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HistoriaClinica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Historia Clinica";
        }
        else
        {
            lblTitulo.Text = "Historia Clínica";

            ClinicaDataContext db = new ClinicaDataContext();
            var temp = (from med in db.Pacientes
                        where med.ID_Paciente == Convert.ToInt32(Request.QueryString["id"])
                        select med).Single();

            if (!IsPostBack)
            {
                string grupoSanguineo = (temp.HistoriaClinica.GrupoSanguineo).ToString().TrimEnd();
                txtGrupoSanguineo.SelectedValue = grupoSanguineo;
                txtAlergias.Text = temp.HistoriaClinica.Alergias;
                txtAntecedentes.Text = temp.HistoriaClinica.AntecedentesFamiliares;
                txtEnfermedades.Text = temp.HistoriaClinica.Enfermedades;
            }
        }
    }         

   protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();

        if(Request.QueryString["id"] == null)
        {
            Paciente temp = new Paciente();
            temp.HistoriaClinica.GrupoSanguineo = txtGrupoSanguineo.SelectedValue;
            temp.HistoriaClinica.Alergias = txtAlergias.Text;
            temp.HistoriaClinica.AntecedentesFamiliares = txtAntecedentes.Text;            
            temp.HistoriaClinica.Enfermedades = txtEnfermedades.Text;
            db.Pacientes.InsertOnSubmit(temp);
            db.SubmitChanges();
        }
        else
        {
            var temp = (from med in db.Pacientes
                        where med.ID_Paciente== Convert.ToInt32(Request.QueryString["id"])
                        select med).Single();

            temp.HistoriaClinica.GrupoSanguineo = txtGrupoSanguineo.SelectedValue;
            temp.HistoriaClinica.Alergias = txtAlergias.Text;
            temp.HistoriaClinica.AntecedentesFamiliares = txtAntecedentes.Text;
            temp.HistoriaClinica.Enfermedades = txtEnfermedades.Text;
            db.SubmitChanges();
        }

        Response.Redirect("Pacientes.aspx");
    }

    protected void btnNuevaConsulta_Command(object sender, CommandEventArgs e)
    {               
        Response.Redirect("DetalleHistoriaClinica.aspx?historia=" + Request.QueryString["historia"]);
    }

    protected void btnVerConsulta_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("DetalleHistoriaClinica.aspx?id=" + e.CommandArgument);
    }

}