using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class LeerXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        leerXML(@"D:\Puesto 2.2\Escritorio\sectores.xml");
    }

    public void leerXML(string ubicacion)
    {
        XmlDocument docXML = new XmlDocument();
        docXML.Load(ubicacion);

        XmlNodeList sectores = docXML.GetElementsByTagName("sectores");
        XmlNodeList totalPages = ((XmlElement)sectores[0]).GetElementsByTagName("totalPages");
        XmlNodeList listaSector = ((XmlElement)sectores[0]).GetElementsByTagName("sector");

        Console.WriteLine("Total pages: " + totalPages[0].InnerText);

        foreach (XmlElement nodo in listaSector)
        {
            XmlNodeList id = nodo.GetElementsByTagName("id");
            XmlNodeList denominacion = nodo.GetElementsByTagName("denominacion");
            XmlNodeList ubi = nodo.GetElementsByTagName("ubicacion");
            XmlNodeList fechaBaja = nodo.GetElementsByTagName("fechaBaja");

            div.InnerText = "ID: " + id[0].InnerText + 
                            "<br> Denominacion: " + denominacion[0].InnerText +
                            "<br> Ubicacion: " + ubi[0].InnerText +
                            "<br> Localidad: " + ((XmlElement)ubi[0]).GetAttribute("localidad") +
                            "<br> Fecha Baja: " + fechaBaja[0].InnerText + "<br>";
        }
    }
}