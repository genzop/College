using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetalleHistoriaClinica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            lblTitulo.Text = "Nueva Consulta";
        }
        else
        {
            lblTitulo.Text = "Ver Consulta";
            ClinicaDataContext db = new ClinicaDataContext();
            var consulta = (from pac in db.ConsultaHistoriaClinicas
                        where pac.ID_ConsultaHistoriaClinica == Convert.ToInt32(Request.QueryString["id"])
                        select pac).Single();

            if (!IsPostBack)
            {                
                txtAltura.Text = consulta.Altura.ToString();
                txtPeso.Text = consulta.Peso.ToString();
                txtSintomas.Text = consulta.Sintomas;
                txtDiagnostico.Text = consulta.DiagnosticoPresunto;
                txtPedidos.Text = consulta.PedidoEstudio;
                txtDerivaciones.Text = consulta.Derivaciones;
                txtTratamiento.Text = consulta.Tratamiento;
                txtReceta.Text = consulta.Receta;
                DateTime fecha = (DateTime)consulta.ProximoControl;
                txtControl.Text = fecha.ToString("yyyy-MM-dd");
                if (consulta.Alta == 1)
                {
                    cbAlta.Checked = true;
                }
                else
                {
                    cbAlta.Checked = false;
                }
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ClinicaDataContext db = new ClinicaDataContext();

        if (Request.QueryString["id"] == null)
        {        
            ConsultaHistoriaClinica temp = new ConsultaHistoriaClinica();

            temp.ID_HistoriaClinica = Convert.ToInt32(Request.QueryString["historia"]);
            temp.Altura = Decimal.Parse(txtAltura.Text);
            temp.Peso = Decimal.Parse(txtPeso.Text);
            temp.Sintomas = txtSintomas.Text;
            temp.DiagnosticoPresunto = txtDiagnostico.Text;
            temp.PedidoEstudio = txtPedidos.Text;
            temp.Derivaciones = txtDerivaciones.Text;
            temp.Tratamiento = txtTratamiento.Text;
            temp.Receta = txtReceta.Text;
            temp.ProximoControl = Convert.ToDateTime(txtControl.Text);
            if (cbAlta.Checked == true)
            {
                temp.Alta = 1;
            }
            else
            {
                temp.Alta = 0;
            }            
            db.ConsultaHistoriaClinicas.InsertOnSubmit(temp);
            db.SubmitChanges();

            var paciente = (from pac in db.Pacientes
                            where pac.ID_HistoriaClinica == temp.ID_HistoriaClinica
                            select pac).Single();

            Response.Redirect("HistoriaClinica.aspx?id=" + paciente.ID_Paciente + "&historia=" + paciente.ID_HistoriaClinica);

        }
        else
        {
            var consulta = (from med in db.ConsultaHistoriaClinicas
                            where med.ID_ConsultaHistoriaClinica == Convert.ToInt32(Request.QueryString["id"])
                            select med).Single();
            
            consulta.Altura = Decimal.Parse(txtAltura.Text);
            consulta.Peso = Decimal.Parse(txtPeso.Text);
            consulta.Sintomas = txtSintomas.Text;
            consulta.DiagnosticoPresunto = txtDiagnostico.Text;
            consulta.PedidoEstudio = txtPedidos.Text;
            consulta.Derivaciones = txtDerivaciones.Text;
            consulta.Tratamiento = txtTratamiento.Text;
            consulta.Receta = txtReceta.Text;
            consulta.ProximoControl = Convert.ToDateTime(txtControl.Text);
            if (cbAlta.Checked == true)
            {
                consulta.Alta = 1;
            }
            else
            {
                consulta.Alta = 0;
            }            
            db.SubmitChanges();

            var paciente = (from pac in db.Pacientes
                            where pac.ID_HistoriaClinica == consulta.ID_HistoriaClinica
                            select pac).Single();

            Response.Redirect("HistoriaClinica.aspx?id=" + paciente.ID_Paciente + "&historia=" + paciente.ID_HistoriaClinica);
        }               
    }
}