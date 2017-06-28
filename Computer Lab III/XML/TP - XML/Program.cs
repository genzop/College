using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP___XML
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorXML gestorXML = new GestorXML();
            gestorXML.CrearDocumentoXML(@"C:\Users\Enzo\Desktop\miXML.xml");
            gestorXML.CrearDocumentoXMLTextWriter(@"C:\Users\Enzo\Desktop\miXMLTextWriter.xml");
            gestorXML.LeerDocumentoXML(@"C:\Users\Enzo\Desktop\miXML.xml");
            gestorXML.LeerDocumentoXMLTextReader(@"C:\Users\Enzo\Desktop\miXMLTextWriter.xml");
        }   
    }
}
