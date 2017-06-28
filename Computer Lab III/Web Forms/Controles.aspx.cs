using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void botonClick(object sender, EventArgs e)
    {       
        cajaTextoIngresada.InnerText = "Caja de Texto: " + cajaTexto.Value;
        
        comboIngresado.InnerText = "Combo: " + combo.Value;

        imagenIngresada.InnerHtml = "Imagen: " + "<img src=" + imagen.Src + " style=\"height:50px; vertical-align:middle\"/>";

        if (checkboxSi.Checked && checkboxNo.Checked)
        {
            checkboxIngresado.InnerText = "Checkbox: Si & No";
        }
        else if (checkboxSi.Checked)
        {
            checkboxIngresado.InnerText = "Checkbox: Si";
        }
        else if (checkboxNo.Checked)
        {
            checkboxIngresado.InnerText = "Checkbox: No";
        }      
        else
        {
            checkboxIngresado.InnerText = "Checkbox: ";
        }

        hipervinculoIngresado.InnerHtml = "Hipervinculo: " + "<a href=" + hipervinculo.HRef + ">" + hipervinculo.InnerText + "</a>";

        if (radio1.Checked)
        {
            radioButtonIngresado.InnerText = "Radio Button: " + radio1.Value;
        }
        else if (radio2.Checked)
        {
            radioButtonIngresado.InnerText = "Radio Button: " + radio2.Value;
        }
        else if (radio3.Checked)
        {
            radioButtonIngresado.InnerText = "Radio Button: " + radio3.Value;
        }
        else
        {
            radioButtonIngresado.InnerText = "Radio Button: ";
        }

        campoOcultoIngresado.InnerText = "Campo oculto: " + hidden.Value;
    }
}