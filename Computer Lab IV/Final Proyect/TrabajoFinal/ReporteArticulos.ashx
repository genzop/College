<%@ WebHandler Language="C#" Class="ReporteArticulos" %>

using System;
using System.Web;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReporteArticulos : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        List<KeyValuePair<string, int>> articulosVendidos = calcularUnidadesVendidas();

        //Se ordenan las parejas por su valor de forma descendente 
        articulosVendidos = (from pareja in articulosVendidos
                             orderby pareja.Value descending
                             select pareja).ToList();


        //Se asigna el tipo de contenido
        context.Response.ContentType = "application/pdf";

        //Se asigna el tipo de descarga y nombre del archivo
        context.Response.AddHeader("Content-disposition", "inline; filename=ArticulosVendidos.pdf");

        //Se crea un stream de memoria para almacenar el documento
        using (MemoryStream m = new MemoryStream())
        {
            //Se crea el documento
            Document documento = new Document();
            PdfWriter.GetInstance(documento, m);

            //Se abre el documento para escribirlo
            documento.Open();

            Font fuente9 = new Font(Font.FontFamily.HELVETICA, 11);
            Font fuente9Negrita = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD);
            Font fuente14Negrita = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);

            //Logo
            string imagepath = HttpContext.Current.Server.MapPath(".") + "/img/logo-utn.png";
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagepath);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(50);
            documento.Add(logo);

            //Titulo
            Paragraph titulo = new Paragraph("Cantidad de articulos vendidos", fuente14Negrita);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 30f;
            documento.Add(titulo);

            int contador = 1;

            foreach (var articulo in articulosVendidos)
            {
                Phrase numero = new Phrase(contador + " - ", fuente9);
                Phrase nombre = new Phrase(articulo.Key + ": ", fuente9);
                Phrase cantidad = new Phrase(articulo.Value + " unidades", fuente9Negrita);
                Paragraph linea = new Paragraph();
                    linea.Alignment = Element.ALIGN_CENTER;
                linea.Add(numero);
                linea.Add(nombre);
                linea.Add(cantidad);

                documento.Add(linea);

                contador++;
            }

            //Se cierra el documento
            documento.Close();

            context.Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        }
        context.Response.End();




    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private List<KeyValuePair<string, int>> calcularUnidadesVendidas()
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        //Se cargan todos los articulos
        var tempArticulos = from art in bd.Articulos
                            orderby art.Denominacion ascending
                            select art;

        //Se crea un arraylist de clavevalor con el nombre del articulo y la cantidad vendida
        var articulosVendidos = new List<KeyValuePair<string, int>>();

        //Por cada articulo  se buscan todos los detalles que esten relacionados
        foreach (Articulo art in tempArticulos)
        {
            //Se buscan los detalles correspondientes a este articulo
            var tempDetalles = from det in bd.PedidoVentaDetalles
                               where det.IdArticulo == art.IdArticulo
                               select det;

            int cantidadVendida = 0;

            //Su suma la cantidad vendida en cada detalle
            foreach (PedidoVentaDetalle det in tempDetalles)
            {
                cantidadVendida += Convert.ToInt32(det.Cantidad);
            }

            //Se agrega a la lista de articulos
            articulosVendidos.Add(new KeyValuePair<string, int>(art.Denominacion, cantidadVendida));
        }

        return articulosVendidos;
    }
}