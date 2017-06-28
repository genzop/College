using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Componentes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void boton_Click(object sender, EventArgs e)
    {
        cajaTextoIngresada.Text = "Caja de Texto: " + cajaTexto.Text;
        comboIngresado.Text = "Combo: " + combo.Text;
        imagenIngresada.Text = "Imagen: " + imagen.ImageUrl;
        if (checkBoxList.Items[0].Selected && checkBoxList.Items[1].Selected)
        {
            checkBoxIngresado.Text = "CheckBox: SI y NO"; 
        }
        else
        {
            checkBoxIngresado.Text = "CheckBox: " + checkBoxList.Text;
        }
        hiperviculoIngresado.Text = "Hipervinculo: " + hipervinculo.NavigateUrl;
        radioButtonIngresado.Text = "Radio Button: " + radioButton.Text;
        campoOcultoIngresado.Text = "Campo Oculto: " + campoOculto.Value;
    }
}