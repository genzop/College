using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BarraNavegacion : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["TipoUsuario"].ToString() == "Medico")
        {
            hlFacturacion.Visible = false;
            hlServicios.Visible = false;
            hlMedicos.Visible = false;
            hlObraSocial.Visible = false;
        }
    }
}
