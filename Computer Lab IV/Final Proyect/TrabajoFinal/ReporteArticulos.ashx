<%@ WebHandler Language="C#" Class="ReporteArticulos" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReporteArticulos : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //Carga la informacion
        List<ArticuloCantidad> articulosVendidos = (List<ArticuloCantidad>)context.Session["ArticulosVendidos"];
        //Ordena los articulos en base a la cantidad vendida de mayor a menor
        articulosVendidos.Sort((x, y) => y.Cantidad.CompareTo(x.Cantidad));

        context.Session["ArticulosVendidos"] = null;
        string txtVendedor = "-";
        string txtCliente = "-";
        string txtFechaInicio = "-";
        string txtFechaFin = "-";
        string txtPais = "-";
        string txtProvincia = "-";
        string txtLocalidad = "-";
        string txtRubro = "-";

        if (context.Session["ArticuloVendedor"].ToString() != "-")
        {
            txtVendedor = context.Session["ArticuloVendedor"].ToString();
            context.Session["ArticuloVendedor"] = null;
        }

        if (context.Session["ArticuloCliente"].ToString() != "-")
        {
            txtCliente = context.Session["ArticuloCliente"].ToString();
            context.Session["ArticuloCliente"] = null;
        }

        if (context.Session["ArticuloFechaInicio"].ToString() != "")
        {
            txtFechaInicio = context.Session["ArticuloFechaInicio"].ToString();
            context.Session["ArticuloFechaInicio"] = null;
        }

        if (context.Session["ArticuloFechaFin"].ToString() != "")
        {
            txtFechaFin = context.Session["ArticuloFechaFin"].ToString();
            context.Session["ArticuloFechaFin"] = null;
        }

        if (context.Session["ArticuloPais"].ToString() != "-")
        {
            txtPais = context.Session["ArticuloPais"].ToString();
            context.Session["ArticuloPais"] = null;
        }

        if (context.Session["ArticuloProvincia"].ToString() != "-")
        {
            txtProvincia = context.Session["ArticuloProvincia"].ToString();
            context.Session["ArticuloProvincia"] = null;
        }

        if (context.Session["ArticuloLocalidad"].ToString() != "-")
        {
            txtLocalidad = context.Session["ArticuloLocalidad"].ToString();
            context.Session["ArticuloLocalidad"] = null;
        }

        if (context.Session["ArticuloRubro"].ToString() != "-")
        {
            txtRubro = context.Session["ArticuloRubro"].ToString();
            context.Session["ArticuloRubro"] = null;
        }

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

            //Se abre el documento
            documento.Open();

            //FUENTES
            Font espaciador = new Font(Font.FontFamily.HELVETICA, 5);
            Font fuente8 = new Font(Font.FontFamily.HELVETICA, 8);
            Font fuente8Negrita = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD);
            Font fuente9 = new Font(Font.FontFamily.HELVETICA, 9);
            Font fuente9Negrita = new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD);
            Font fuente11Negrita = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD);
            Font fuente14Negrita = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);
            Font fuenteTitulo = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);

            //ENCABEZADO
            //Se crea una tabla de 2 columnas para el encabezado
            PdfPTable tablaEncabezado = new PdfPTable(2);
            tablaEncabezado.WidthPercentage = 100;

            //Logo de la empresa
            string imagepath = HttpContext.Current.Server.MapPath(".") + "/img/logo-utn.png";
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imagepath);
            PdfPCell cellLogo = new PdfPCell(imagen);
            cellLogo.FixedHeight = 85;
            cellLogo.HorizontalAlignment = Element.ALIGN_LEFT;
            cellLogo.BorderWidth = 0;
            imagen.ScalePercent(45f);

            //Fecha y Hora            
            Paragraph fecha = new Paragraph();
            fecha.Add(new Phrase("                                                                    Fecha: ", fuente9));
            fecha.Add(new Phrase(DateTime.Now.ToShortDateString(), fuente11Negrita));

            Paragraph hora = new Paragraph();
            hora.Add(new Phrase("                                                                                 Hora: ", fuente9));
            hora.Add(new Phrase(DateTime.Now.ToString("HH:mm"), fuente11Negrita));

            PdfPCell cellFechaHora = new PdfPCell();
            cellFechaHora.BorderWidth = 0;
            cellFechaHora.AddElement(fecha);
            cellFechaHora.AddElement(hora);

            //Se agregan la celdas a la tabla
            tablaEncabezado.AddCell(cellLogo);
            tablaEncabezado.AddCell(cellFechaHora);

            //Se agrega la tabla al documento
            documento.Add(tablaEncabezado);

            //Titulo
            Paragraph titulo = new Paragraph("Artículos Vendidos", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 30;
            documento.Add(titulo);

            //Tabla Filtros Vendedor y Cliente
            PdfPTable tablaFiltrosPersonas = new PdfPTable(2);
            tablaFiltrosPersonas.WidthPercentage = 100;
            tablaFiltrosPersonas.SetWidths(new float[] { 1, 2 });

            Paragraph filtroVendedor = new Paragraph();
            filtroVendedor.Add(new Phrase("Vendedor: ", fuente9Negrita));
            filtroVendedor.Add(new Phrase(txtVendedor, fuente9));
            PdfPCell cellFiltroVendedor = new PdfPCell(filtroVendedor);
            cellFiltroVendedor.BorderWidth = 0;

            Paragraph filtroCliente = new Paragraph();
            filtroCliente.Add(new Phrase("Cliente: ", fuente9Negrita));
            filtroCliente.Add(new Phrase(txtCliente, fuente9));
            PdfPCell cellFiltroCliente = new PdfPCell(filtroCliente);
            cellFiltroCliente.BorderWidth = 0;

            tablaFiltrosPersonas.AddCell(cellFiltroVendedor);
            tablaFiltrosPersonas.AddCell(cellFiltroCliente);

            documento.Add(tablaFiltrosPersonas);

            //Tabla Filtros Fechas y Pagado                
            PdfPTable tablaFiltrosFechas = new PdfPTable(3);
            tablaFiltrosFechas.WidthPercentage = 100;

            Paragraph filtroFechaInicio = new Paragraph();
            filtroFechaInicio.Add(new Phrase("A partir de: ", fuente9Negrita));
            filtroFechaInicio.Add(new Phrase(txtFechaInicio, fuente9));
            PdfPCell cellFiltroFechaInicio = new PdfPCell(filtroFechaInicio);
            cellFiltroFechaInicio.BorderWidth = 0;

            Paragraph filtroFechaFin = new Paragraph();
            filtroFechaFin.Add(new Phrase("Hasta: ", fuente9Negrita));
            filtroFechaFin.Add(new Phrase(txtFechaFin, fuente9));
            PdfPCell cellFiltroFechaFin = new PdfPCell(filtroFechaFin);
            cellFiltroFechaFin.BorderWidth = 0;

            Paragraph filtroRubro = new Paragraph();
            filtroRubro.Add(new Phrase("Rubro: ", fuente9Negrita));
            filtroRubro.Add(new Phrase(txtRubro, fuente9));
            PdfPCell cellFiltroRubro = new PdfPCell(filtroRubro);
            cellFiltroRubro.BorderWidth = 0;

            tablaFiltrosFechas.AddCell(cellFiltroFechaInicio);
            tablaFiltrosFechas.AddCell(cellFiltroFechaFin);
            tablaFiltrosFechas.AddCell(cellFiltroRubro);

            documento.Add(tablaFiltrosFechas);

            //Tabla Filtros Ubicacion
            PdfPTable tablaFiltrosUbicacion = new PdfPTable(3);
            tablaFiltrosUbicacion.WidthPercentage = 100;
            tablaFiltrosUbicacion.SpacingAfter = 20;

            Paragraph filtroPais = new Paragraph();
            filtroPais.Add(new Phrase("Pais: ", fuente9Negrita));
            filtroPais.Add(new Phrase(txtPais, fuente9));
            PdfPCell cellFiltroPais = new PdfPCell(filtroPais);
            cellFiltroPais.BorderWidth = 0;

            Paragraph filtroProvincia = new Paragraph();
            filtroProvincia.Add(new Phrase("Provincia: ", fuente9Negrita));
            filtroProvincia.Add(new Phrase(txtProvincia, fuente9));
            PdfPCell cellFiltroProvincia = new PdfPCell(filtroProvincia);
            cellFiltroProvincia.BorderWidth = 0;

            Paragraph filtroLocalidad = new Paragraph();
            filtroLocalidad.Add(new Phrase("Localidad: ", fuente9Negrita));
            filtroLocalidad.Add(new Phrase(txtLocalidad, fuente9));
            PdfPCell cellFiltroLocalidad = new PdfPCell(filtroLocalidad);
            cellFiltroLocalidad.BorderWidth = 0;

            tablaFiltrosUbicacion.AddCell(cellFiltroPais);
            tablaFiltrosUbicacion.AddCell(cellFiltroProvincia);
            tablaFiltrosUbicacion.AddCell(cellFiltroLocalidad);

            documento.Add(tablaFiltrosUbicacion);

            //Tabla Titulos
            PdfPTable tablaTitulos = new PdfPTable(6);
            tablaTitulos.WidthPercentage = 100;
            tablaTitulos.SetWidths(new float[] { 8, 4, 3, 3, 4, 4});

            PdfPCell cellTituloArticulo = new PdfPCell(new Phrase("Articulo", fuente8Negrita));
            PdfPCell cellTituloRubro = new PdfPCell(new Phrase("Rubro", fuente8Negrita));
            PdfPCell cellTituloCantidad = new PdfPCell(new Phrase("Cantidad", fuente8Negrita));
            PdfPCell cellTituloPrecio = new PdfPCell(new Phrase("Precio unitario", fuente8Negrita));
            PdfPCell cellTituloSubtotal = new PdfPCell(new Phrase("Subtotal", fuente8Negrita));
            PdfPCell cellTituloTotal = new PdfPCell(new Phrase("Total                (Desc. incluido)", fuente8Negrita));

            cellTituloArticulo.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloArticulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloRubro.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloRubro.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloCantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloPrecio.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

            tablaTitulos.AddCell(cellTituloArticulo);
            tablaTitulos.AddCell(cellTituloRubro);
            tablaTitulos.AddCell(cellTituloCantidad);
            tablaTitulos.AddCell(cellTituloPrecio);
            tablaTitulos.AddCell(cellTituloSubtotal);
            tablaTitulos.AddCell(cellTituloTotal);

            documento.Add(tablaTitulos);

            double total = 0;

            foreach (ArticuloCantidad articulo in articulosVendidos)
            {
                PdfPTable tablaArticulo = new PdfPTable(6);
                tablaArticulo.WidthPercentage = 100;
                tablaArticulo.SetWidths(new float[] { 8, 4, 3, 3, 4, 4,});

                PdfPCell cellArticulo = new PdfPCell(new Phrase("  " + articulo.Denominacion, fuente8));
                cellArticulo.PaddingTop = 5;
                cellArticulo.PaddingBottom = 5;
                PdfPCell cellRubro = new PdfPCell(new Phrase(articulo.Rubro, fuente8));
                PdfPCell cellCantidad = new PdfPCell(new Phrase(articulo.Cantidad.ToString(), fuente8));
                PdfPCell cellPrecio = new PdfPCell(new Phrase(String.Format("{0:C}", articulo.Precio), fuente8));
                PdfPCell cellSubtotal = new PdfPCell(new Phrase(String.Format("{0:C}", articulo.Cantidad * articulo.Precio), fuente8));
                PdfPCell cellTotal = new PdfPCell(new Phrase(String.Format("{0:C}", articulo.Total), fuente8));

                cellArticulo.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellRubro.HorizontalAlignment = Element.ALIGN_CENTER;
                cellRubro.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPrecio.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

                tablaArticulo.AddCell(cellArticulo);
                tablaArticulo.AddCell(cellRubro);
                tablaArticulo.AddCell(cellCantidad);
                tablaArticulo.AddCell(cellPrecio);
                tablaArticulo.AddCell(cellSubtotal);
                tablaArticulo.AddCell(cellTotal);

                documento.Add(tablaArticulo);

                total += articulo.Total;
            }

            //Total
            Phrase phraseTotal1 = new Phrase("Total: ", fuente9Negrita);
            Phrase phraseTotal2 = new Phrase(String.Format("{0:C}", total), fuente11Negrita);
            Paragraph paragraphTotal = new Paragraph();
            paragraphTotal.Add(phraseTotal1);
            paragraphTotal.Add(phraseTotal2);
            paragraphTotal.Alignment = Element.ALIGN_RIGHT;
            paragraphTotal.IndentationRight = 10;
            paragraphTotal.SpacingBefore = 5;

            documento.Add(paragraphTotal);

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
}