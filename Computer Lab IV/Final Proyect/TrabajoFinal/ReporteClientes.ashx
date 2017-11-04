<%@ WebHandler Language="C#" Class="ReporteClientes" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReporteClientes : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        //Carga la informacion
        List<Cliente> clientes = (List<Cliente>)context.Session["Clientes"];
        clientes.Sort((x, y) => x.RazonSocial.CompareTo(y.RazonSocial));
        context.Session["Clientes"] = null;
        string txtVendedor = "-";
        string txtPais = "-";
        string txtProvincia = "-";
        string txtLocalidad = "-";
        string txtDeudor = "-";

        if (context.Session["ClienteVendedor"].ToString() != "-")
        {
            txtVendedor = context.Session["ClienteVendedor"].ToString();
            context.Session["ClienteVendedor"] = null;
        }

        if (context.Session["ClientePais"].ToString() != "-")
        {
            txtPais = context.Session["ClientePais"].ToString();
            context.Session["ClientePais"] = null;
        }

        if (context.Session["ClienteProvincia"].ToString() != "-")
        {
            txtProvincia = context.Session["ClienteProvincia"].ToString();
            context.Session["ClienteProvincia"] = null;
        }

        if (context.Session["ClienteLocalidad"].ToString() != "-")
        {
            txtLocalidad = context.Session["ClienteLocalidad"].ToString();
            context.Session["ClienteLocalidad"] = null;
        }

        if (context.Session["ClienteDeudor"].ToString() != "-")
        {
            txtDeudor = context.Session["ClienteDeudor"].ToString();
            context.Session["ClienteDeudor"] = null;
        }

        //Se asigna el tipo de contenido
        context.Response.ContentType = "application/pdf";

        //Se asigna el tipo de descarga y nombre del archivo
        context.Response.AddHeader("Content-disposition", "inline; filename=Clientes.pdf");

        //Se crea un stream de memoria para almacenar el documento
        using (MemoryStream m = new MemoryStream())
        {
            //Se crea el documento
            Document documento = new Document();
            PdfWriter.GetInstance(documento, m);

            //Se abre el documento para escribirlo
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
            Paragraph titulo = new Paragraph("Información de los Clientes", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 30;
            documento.Add(titulo);

            //Tabla Filtros Vendedor y Deudor
            PdfPTable tablaFiltrosPersonas = new PdfPTable(2);
            tablaFiltrosPersonas.WidthPercentage = 100;
            tablaFiltrosPersonas.SetWidths(new float[] { 1, 2 });

            Paragraph filtroVendedor = new Paragraph();
            filtroVendedor.Add(new Phrase("Vendedor: ", fuente9Negrita));
            filtroVendedor.Add(new Phrase(txtVendedor, fuente9));
            PdfPCell cellFiltroVendedor = new PdfPCell(filtroVendedor);
            cellFiltroVendedor.BorderWidth = 0;

            Paragraph filtroDeudor = new Paragraph();
            filtroDeudor.Add(new Phrase("Deudores: ", fuente9Negrita));
            filtroDeudor.Add(new Phrase(txtDeudor, fuente9));
            PdfPCell cellFiltroDeudor = new PdfPCell(filtroDeudor);
            cellFiltroDeudor.BorderWidth = 0;

            tablaFiltrosPersonas.AddCell(cellFiltroVendedor);
            tablaFiltrosPersonas.AddCell(cellFiltroDeudor);

            documento.Add(tablaFiltrosPersonas);

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
            PdfPTable tablaTitulos = new PdfPTable(7);
            tablaTitulos.WidthPercentage = 100;
            tablaTitulos.SetWidths(new float[] { 8, 4, 6, 3, 4, 4, 4 });

            PdfPCell cellTituloRazonSocial = new PdfPCell(new Phrase("Razon Social", fuente8Negrita));
            PdfPCell cellTituloCuit = new PdfPCell(new Phrase("Cuit", fuente8Negrita));
            PdfPCell cellTituloDomicilio = new PdfPCell(new Phrase("Domicilio", fuente8Negrita));
            PdfPCell cellTituloLocalidad = new PdfPCell(new Phrase("Localidad", fuente8Negrita));
            PdfPCell cellTituloProvincia = new PdfPCell(new Phrase("Provincia", fuente8Negrita));
            PdfPCell cellTituloPais = new PdfPCell(new Phrase("Pais", fuente8Negrita));
            PdfPCell cellTituloSaldo = new PdfPCell(new Phrase("Saldo", fuente8Negrita));

            cellTituloRazonSocial.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloRazonSocial.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloRazonSocial.PaddingTop = 7;
            cellTituloRazonSocial.PaddingBottom = 7;
            cellTituloCuit.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloCuit.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloDomicilio.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloDomicilio.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloLocalidad.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloLocalidad.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloProvincia.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloProvincia.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloPais.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloPais.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloSaldo.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloSaldo.VerticalAlignment = Element.ALIGN_MIDDLE;

            tablaTitulos.AddCell(cellTituloRazonSocial);
            tablaTitulos.AddCell(cellTituloCuit);
            tablaTitulos.AddCell(cellTituloDomicilio);
            tablaTitulos.AddCell(cellTituloLocalidad);
            tablaTitulos.AddCell(cellTituloProvincia);
            tablaTitulos.AddCell(cellTituloPais);
            tablaTitulos.AddCell(cellTituloSaldo);

            documento.Add(tablaTitulos);

            foreach (Cliente cli in clientes)
            {

                Domicilio domicilio = (from dom in bd.Domicilios
                                       where dom.IdDomicilio == cli.IdDomicilio
                                       select dom).FirstOrDefault();
                Localidad localidad = (from loc in bd.Localidads
                                       where loc.IdLocalidad == domicilio.IdLocalidad
                                       select loc).FirstOrDefault();
                Provincia provincia = (from prov in bd.Provincias
                                       where prov.IdProvincia == localidad.IdProvincia
                                       select prov).FirstOrDefault();
                Pai pais = (from p in bd.Pais
                            where p.IdPais == provincia.IdPais
                            select p).FirstOrDefault();


                PdfPTable tablaCliente = new PdfPTable(7);
                tablaCliente.WidthPercentage = 100;
                tablaCliente.SetWidths(new float[] { 8, 4, 6, 3, 4, 4, 4 });

                PdfPCell cellRazonSocial = new PdfPCell(new Phrase(cli.RazonSocial, fuente8));
                cellRazonSocial.PaddingTop = 7;
                cellRazonSocial.PaddingBottom = 7;
                PdfPCell cellCuit = new PdfPCell(new Phrase(cli.Cuit, fuente8));
                PdfPCell cellDomicilio = new PdfPCell(new Phrase(domicilio.Calle + " " + domicilio.Numero, fuente8));
                PdfPCell cellLocalidad = new PdfPCell(new Phrase(localidad.Denominacion, fuente8));
                PdfPCell cellProvincia = new PdfPCell(new Phrase(provincia.Denominacion, fuente8));
                PdfPCell cellPais = new PdfPCell(new Phrase(pais.Denominacion, fuente8));
                PdfPCell cellSaldo = new PdfPCell(new Phrase(String.Format("{0:C}", cli.Saldo), fuente8));

                cellRazonSocial.HorizontalAlignment = Element.ALIGN_CENTER;
                cellRazonSocial.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellCuit.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCuit.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellDomicilio.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDomicilio.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellLocalidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cellLocalidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellProvincia.HorizontalAlignment = Element.ALIGN_CENTER;
                cellProvincia.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPais.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPais.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellSaldo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellSaldo.VerticalAlignment = Element.ALIGN_MIDDLE;

                tablaCliente.AddCell(cellRazonSocial);
                tablaCliente.AddCell(cellCuit);
                tablaCliente.AddCell(cellDomicilio);
                tablaCliente.AddCell(cellLocalidad);
                tablaCliente.AddCell(cellProvincia);
                tablaCliente.AddCell(cellPais);
                tablaCliente.AddCell(cellSaldo);

                documento.Add(tablaCliente);
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
}