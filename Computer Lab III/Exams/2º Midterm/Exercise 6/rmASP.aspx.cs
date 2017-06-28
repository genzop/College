using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ParcialLab4PanettieriGino : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void boton_Click(object sender, EventArgs e)
    {
        apellidoIngresado.Text = "Apellido: " + apellido.Text;
        nombreIngresado.Text = "Nombre: " + nombre.Text;        
        
    }
}