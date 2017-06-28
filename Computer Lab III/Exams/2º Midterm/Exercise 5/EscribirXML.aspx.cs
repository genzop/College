using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class EscribirXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void escribirXML(string ubicacion)
    {
        XDocument miXML = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("result",
                new XElement("permisos",
                    new XElement("permiso",
                        new XAttribute("tipo", "Comision Diaria"),
                        new XElement("id", "229"),
                        new XElement("sector", "Forestales"),
                        new XElement("consejo", "NO POSEE")
                    ),
                    new XElement("permiso",
                        new XAttribute("tipo", "Razones Particulares"),
                        new XElement("id", "381"),
                        new XElement("sector", "Alumbrado Público - Mantenimiento"),
                        new XElement("consejo", "NO POSEE")
                    )
                )   
            )
        );
        miXML.Save(ubicacion);
    }
}