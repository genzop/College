using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PacienteEditar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Agregar Paciente";
        }
        else
        {
            lblTitulo.Text = "Editar Paciente";

            ClinicaDataContext db = new ClinicaDataContext();
            var temp = (from pac in db.Pacientes
                        where pac.ID_Paciente== Convert.ToInt32(Request.QueryString["id"])
                        select pac).Single();

            if (!IsPostBack)
            {
                txtNombre.Text = temp.Nombre;
                txtApellido.Text = temp.Apellido;
                txtDNI.Text = temp.Dni.ToString();
                txtSexo.Text = temp.Sexo.ToString();
                DateTime fecha = (DateTime)temp.FechaNacimiento;
                txtFecha.Text = fecha.ToString("yyyy-MM-dd");
                txtEstadoCivil.Text = temp.EstadoCivil.ToString();
                txtDomicilio.Text = temp.Domicilio;
                txtLocalidad.Text = temp.Localidad;
                txtTelefono.Text = temp.Telefono;
                txtOcupacion.Text = temp.Ocupacion;
                txtEmail.Text = temp.Email;                
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();

        if (Request.QueryString["id"] == null)
        {
            HistoriaClinica hist = new HistoriaClinica();
            db.HistoriaClinicas.InsertOnSubmit(hist);
            hist.Alergias = "";
            hist.AntecedentesFamiliares = "";
            hist.Enfermedades = "";
            hist.GrupoSanguineo = "";
            db.SubmitChanges();
            Paciente temp = new Paciente();            
            temp.Nombre = txtNombre.Text;
            temp.Apellido = txtApellido.Text;
            temp.Sexo = Char.Parse(txtSexo.Text);
            temp.Dni = Int32.Parse(txtDNI.Text);
            temp.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            temp.EstadoCivil = Char.Parse(txtEstadoCivil.Text);
            temp.Domicilio = txtDomicilio.Text;
            temp.Localidad = txtLocalidad.Text;
            temp.Telefono = txtTelefono.Text;
            temp.Ocupacion = txtOcupacion.Text;
            temp.Email = txtEmail.Text;           
            db.Pacientes.InsertOnSubmit(temp);            
            temp.ID_HistoriaClinica = hist.ID_HistoriaClinica;
            db.SubmitChanges();
        }
        else
        {
            var temp = (from pac in db.Pacientes
                        where pac.ID_Paciente == Convert.ToInt32(Request.QueryString["id"])
                        select pac).Single();

            temp.Nombre = txtNombre.Text;
            temp.Apellido = txtApellido.Text;
            temp.Dni = Int32.Parse(txtDNI.Text);
            temp.Sexo = Char.Parse(txtSexo.Text);
            temp.EstadoCivil = Char.Parse(txtEstadoCivil.Text);
            temp.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            temp.Domicilio = txtDomicilio.Text;
            temp.Localidad = txtLocalidad.Text;
            temp.Telefono = txtTelefono.Text;
            temp.Email = txtEmail.Text;
            temp.Ocupacion = txtOcupacion.Text;
            db.SubmitChanges();
        }

        Response.Redirect("Pacientes.aspx");
    }
}