<%@ WebHandler Language="C#" Class="ReportePedidos" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReportePedidos : IHttpHandler, IRequiresSessionState
{

    private BaseDatosDataContext bd = new BaseDatosDataContext();

    public void ProcessRequest (HttpContext context) {

        //Carga toda la informacion
        List<Pedido> pedidos = (List<Pedido>)context.Session["Pedidos"];
        pedidos.Sort((x, y) => x.IdPedido.CompareTo(y.IdPedido));
        context.Session["Pedidos"] = null;
        string txtVendedor = "-";
        string txtCliente = "-";
        string txtFechaInicio = "-";
        string txtFechaFin = "-";
        string txtEstado = "-";
        string txtPagado = "-";
        string txtPais = "-";
        string txtProvincia = "-";
        string txtLocalidad = "-";


        if (context.Session["PedidoVendedor"].ToString() != "-")
        {
            txtVendedor = context.Session["PedidoVendedor"].ToString();
            context.Session["PedidoVendedor"] = null;
        }

        if (context.Session["PedidoCliente"].ToString() != "-")
        {
            txtCliente = context.Session["PedidoCliente"].ToString();
            context.Session["PedidoCliente"] = null;
        }

        if (context.Session["PedidoFechaInicio"].ToString() != "")
        {
            txtFechaInicio = context.Session["PedidoFechaInicio"].ToString();
            context.Session["PedidoFechaInicio"] = null;
        }

        if (context.Session["PedidoFechaFin"].ToString() != "")
        {
            txtFechaFin = context.Session["PedidoFechaFin"].ToString();
            context.Session["PedidoFechaFin"] = null;
        }

        if(context.Session["PedidoEstado"].ToString() != "-")
        {
            txtEstado = context.Session["PedidoEstado"].ToString();
            context.Session["PedidoEstado"] = null;
        }

        if (context.Session["PedidoPagado"].ToString() != "-")
        {
            txtPagado = context.Session["PedidoPagado"].ToString();
            context.Session["PedidoPagado"] = null;
        }

        if (context.Session["PedidoPais"].ToString() != "-")
        {
            txtPais = context.Session["PedidoPais"].ToString();
            context.Session["PedidoPais"] = null;
        }

        if (context.Session["PedidoProvincia"].ToString() != "-")
        {
            txtProvincia = context.Session["PedidoProvincia"].ToString();
            context.Session["PedidoProvincia"] = null;
        }

        if (context.Session["PedidoLocalidad"].ToString() != "-")
        {
            txtLocalidad = context.Session["PedidoLocalidad"].ToString();
            context.Session["PedidoLocalidad"] = null;
        }


        //Se asigna el tipo de contenido
        context.Response.ContentType = "application/pdf";

        //Se asigna el tipo de descarga y nombre del archivo
        context.Response.AddHeader("Content-disposition", "inline; filename=Pedidos.pdf");

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
            Paragraph titulo = new Paragraph("Listado de Pedidos", fuenteTitulo);
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

            //Tabla Filtros Ubicacion
            PdfPTable tablaFiltrosUbicacion = new PdfPTable(4);
            tablaFiltrosUbicacion.WidthPercentage = 100;            

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

            PdfPCell cellEspacio = new PdfPCell();
            cellEspacio.BorderWidth = 0;
                               
            tablaFiltrosUbicacion.AddCell(cellFiltroPais);
            tablaFiltrosUbicacion.AddCell(cellFiltroProvincia);
            tablaFiltrosUbicacion.AddCell(cellFiltroLocalidad);
            tablaFiltrosUbicacion.AddCell(cellEspacio);

            documento.Add(tablaFiltrosUbicacion);

            //Tabla Filtros Estados y Fechas           
            PdfPTable tablaFiltrosEstadosFechas = new PdfPTable(4);
            tablaFiltrosEstadosFechas.WidthPercentage = 100;
            tablaFiltrosEstadosFechas.SpacingAfter = 20;

            Paragraph filtroEstado = new Paragraph();
            filtroEstado.Add(new Phrase("Estado: ", fuente9Negrita));
            filtroEstado.Add(new Phrase(txtEstado, fuente9));
            PdfPCell cellFiltroEstado = new PdfPCell(filtroEstado);
            cellFiltroEstado.BorderWidth = 0;

            Paragraph filtroPagado = new Paragraph();
            filtroPagado.Add(new Phrase("Pagado: ", fuente9Negrita));
            filtroPagado.Add(new Phrase(txtPagado, fuente9));
            PdfPCell cellFiltroPagado = new PdfPCell(filtroPagado);
            cellFiltroPagado.BorderWidth = 0;

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

            tablaFiltrosEstadosFechas.AddCell(cellFiltroEstado);
            tablaFiltrosEstadosFechas.AddCell(cellFiltroPagado);
            tablaFiltrosEstadosFechas.AddCell(cellFiltroFechaInicio);
            tablaFiltrosEstadosFechas.AddCell(cellFiltroFechaFin);

            documento.Add(tablaFiltrosEstadosFechas);

            //Tabla Titulos
            PdfPTable tablaTitulos = new PdfPTable(8);
            tablaTitulos.WidthPercentage = 100;
            tablaTitulos.SetWidths(new float[] { 3, 6, 4, 4, 3, 4, 4, 4 });

            PdfPCell cellTituloNumero = new PdfPCell(new Phrase("Numero", fuente8Negrita));
            PdfPCell cellTituloCliente = new PdfPCell(new Phrase("Cliente", fuente8Negrita));
            PdfPCell cellTituloEstado = new PdfPCell(new Phrase("Estado", fuente8Negrita));
            PdfPCell cellTituloFecha = new PdfPCell(new Phrase("Fecha", fuente8Negrita));
            PdfPCell cellTituloPagado = new PdfPCell(new Phrase("Pagado", fuente8Negrita));
            PdfPCell cellTituloSubtotal = new PdfPCell(new Phrase("Subtotal", fuente8Negrita));
            PdfPCell cellTituloGastosEnvio = new PdfPCell(new Phrase("Gastos de Envio", fuente8Negrita));
            PdfPCell cellTituloTotal = new PdfPCell(new Phrase("Total", fuente8Negrita));

            cellTituloNumero.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloNumero.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloCliente.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloCliente.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloEstado.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloEstado.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloFecha.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloFecha.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloPagado.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloPagado.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloGastosEnvio.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloGastosEnvio.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

            tablaTitulos.AddCell(cellTituloNumero);
            tablaTitulos.AddCell(cellTituloCliente);
            tablaTitulos.AddCell(cellTituloEstado);
            tablaTitulos.AddCell(cellTituloFecha);
            tablaTitulos.AddCell(cellTituloPagado);
            tablaTitulos.AddCell(cellTituloSubtotal);
            tablaTitulos.AddCell(cellTituloGastosEnvio);
            tablaTitulos.AddCell(cellTituloTotal);

            documento.Add(tablaTitulos);

            double total = 0;

            foreach (Pedido ped in pedidos)
            {
                Cliente cliente = (from cli in bd.Clientes
                                   where cli.IdCliente == ped.IdCliente
                                   select cli).FirstOrDefault();

                PdfPTable tablaPedido = new PdfPTable(8);
                tablaPedido.WidthPercentage = 100;
                tablaPedido.SetWidths(new float[] { 3, 6, 4, 4, 3, 4, 4, 4 });

                PdfPCell cellNumero = new PdfPCell(new Phrase(ped.IdPedido.ToString(), fuente8));
                PdfPCell cellCliente = new PdfPCell(new Phrase(cliente.RazonSocial, fuente8));
                PdfPCell cellEstado = new PdfPCell(new Phrase(ped.Estado, fuente8));
                PdfPCell cellFecha = new PdfPCell(new Phrase(ped.FechaPedido.ToShortDateString(), fuente8));
                PdfPCell cellPagado;
                if (ped.Pagado)
                {
                    cellPagado = new PdfPCell(new Phrase("X", fuente8Negrita));
                }else
                {
                    cellPagado = new PdfPCell(new Phrase(" ", fuente8));
                }
                PdfPCell cellSubtotal = new PdfPCell(new Phrase(String.Format("{0:C}", ped.SubTotal), fuente8));
                PdfPCell cellGastosEnvio = new PdfPCell(new Phrase(String.Format("{0:C}", ped.GastosEnvio), fuente8));
                PdfPCell cellTotal = new PdfPCell(new Phrase(String.Format("{0:C}", ped.Total), fuente8));


                cellNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                cellNumero.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellCliente.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCliente.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellEstado.HorizontalAlignment = Element.ALIGN_CENTER;
                cellEstado.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellFecha.HorizontalAlignment = Element.ALIGN_CENTER;
                cellFecha.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPagado.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPagado.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellGastosEnvio.HorizontalAlignment = Element.ALIGN_CENTER;
                cellGastosEnvio.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

                tablaPedido.AddCell(cellNumero);
                tablaPedido.AddCell(cellCliente);
                tablaPedido.AddCell(cellEstado);
                tablaPedido.AddCell(cellFecha);
                tablaPedido.AddCell(cellPagado);
                tablaPedido.AddCell(cellSubtotal);
                tablaPedido.AddCell(cellGastosEnvio);
                tablaPedido.AddCell(cellTotal);

                documento.Add(tablaPedido);

                total += ped.Total;
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

    public bool IsReusable {
        get {
            return false;
        }
    }

}