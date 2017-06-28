using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Navegacion : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        var temp = (from vend in bd.Vendedors
                    where vend.IdVendedor == Int32.Parse(Session["IdVendedor"].ToString())
                    select vend).Single();

        lblNombre.Text = temp.Nombre + " " + temp.Apellido;
    }
}
