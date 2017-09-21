<%@ WebHandler Language="C#" Class="ReportePedido" %>

using System;
using System.Web;
using System.Linq;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReportePedido : IHttpHandler
{

    private BaseDatosDataContext bd = new BaseDatosDataContext();

    public void ProcessRequest(HttpContext context)
    {

        //Se guarda el id del pedido a ser reportado
        string idPedido = context.Request.QueryString["id"];

        //Se carga el pedido
        PedidoVenta pedido = (from ped in bd.PedidoVentas
                              where ped.IdPedidoVenta == Convert.ToInt32(idPedido)
                              select ped).FirstOrDefault();

        //Se carga el cliente
        Cliente cliente = (from cli in bd.Clientes
                           where cli.IdCliente == pedido.IdCliente
                           select cli).FirstOrDefault();

        //Se carga el domicilio
        Domicilio domicilio = (from dom in bd.Domicilios
                               where dom.IdDomicilio == cliente.IdDomicilio
                               select dom).FirstOrDefault();

        //Se cargan los detalles
        var detalles = from det in bd.PedidoVentaDetalles
                       where det.IdPedidoVenta == pedido.IdPedidoVenta
                       select det;

        //Se asigna el tipo de contenido
        context.Response.ContentType = "application/pdf";

        //Se asigna el tipo de descarga y nombre del archivo
        context.Response.AddHeader("Content-disposition", "inline; filename=Pedido" + pedido.NroPedido  + ".pdf");

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
            Font fuente9 = new Font(Font.FontFamily.HELVETICA, 9);
            Font fuente9Negrita = new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD);
            Font fuente11Negrita = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD);
            Font fuente14Negrita = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);

            //ENCABEZADO
            //Se crea una tabla de 2 columnas para el encabezado
            PdfPTable tablaEncabezado = new PdfPTable(2);
            tablaEncabezado.WidthPercentage = 100;

            //Logo de la empresa
            string imagepath = HttpContext.Current.Server.MapPath(".") + "/img/logo-utn.png";
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imagepath);
            PdfPCell cellLogo = new PdfPCell(imagen);
            cellLogo.FixedHeight = 85;
            cellLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            cellLogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            imagen.ScalePercent(45f);

            //Informacion de la empresa
            PdfPCell cellInfoEmpresa = new PdfPCell();
            cellInfoEmpresa.AddElement(new Phrase("                       Pedido", fuente14Negrita));
            cellInfoEmpresa.AddElement(new Phrase(" ", espaciador));
            cellInfoEmpresa.AddElement(new Phrase("Pedido N°: " + pedido.NroPedido, fuente9));
            DateTime fechaPedido = Convert.ToDateTime(pedido.FechaPedido);
            cellInfoEmpresa.AddElement(new Phrase("Fecha de pedido: " + fechaPedido.ToShortDateString(), fuente9));
            DateTime fechaEntrega = Convert.ToDateTime(pedido.FechaEstimadaEntrega);
            cellInfoEmpresa.AddElement(new Phrase("Fecha estimada de entrega: " + fechaEntrega.ToShortDateString(), fuente9));
            cellInfoEmpresa.PaddingLeft = 20;

            //Se agregan la celdas a la tabla
            tablaEncabezado.AddCell(cellLogo);
            tablaEncabezado.AddCell(cellInfoEmpresa);

            //Se agrega la tabla al documento
            documento.Add(tablaEncabezado);

            //CLIENTE
            //Se crea una tabla de una columna para los datos del cliente
            PdfPTable tablaCliente = new PdfPTable(1);
            tablaCliente.WidthPercentage = 100;

            PdfPCell cellInfoCliente = new PdfPCell();
            cellInfoCliente.FixedHeight = 80;
            cellInfoCliente.PaddingLeft = 20;
            cellInfoCliente.AddElement(new Phrase("Cliente: " + cliente.RazonSocial, fuente14Negrita));
            cellInfoCliente.AddElement(new Phrase("CUIT N°: " + cliente.Cuit, fuente9));
            cellInfoCliente.AddElement(new Phrase("Localidad: " + domicilio.Localidad, fuente9));
            cellInfoCliente.AddElement(new Phrase("Dirección: " + domicilio.Calle + " " + domicilio.Numero, fuente9));
            tablaCliente.AddCell(cellInfoCliente);

            documento.Add(tablaCliente);

            //TITULOS DETALLES
            PdfPTable tablaTitulosDetalles = new PdfPTable(6);
            tablaTitulosDetalles.WidthPercentage = 100;
            tablaTitulosDetalles.SetWidths(new float[] { 2, 5, 2, 2, 2, 2 });

            PdfPCell cellTituloCantidad = new PdfPCell(new Phrase("Cantidad", fuente9Negrita));
            PdfPCell cellTituloArticulo = new PdfPCell(new Phrase("Articulo", fuente9Negrita));
            PdfPCell cellTituloPrecio = new PdfPCell(new Phrase("Precio", fuente9Negrita));
            PdfPCell cellTituloSubtotal = new PdfPCell(new Phrase("Subtotal", fuente9Negrita));
            PdfPCell cellTituloDescuento = new PdfPCell(new Phrase("Descuento", fuente9Negrita));
            PdfPCell cellTituloTotal = new PdfPCell(new Phrase("Total", fuente9Negrita));

            cellTituloCantidad.FixedHeight = 22;

            cellTituloCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloCantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloArticulo.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloArticulo.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloPrecio.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloDescuento.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloDescuento.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTituloTotal.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

            tablaTitulosDetalles.AddCell(cellTituloCantidad);
            tablaTitulosDetalles.AddCell(cellTituloArticulo);
            tablaTitulosDetalles.AddCell(cellTituloPrecio);
            tablaTitulosDetalles.AddCell(cellTituloSubtotal);
            tablaTitulosDetalles.AddCell(cellTituloDescuento);
            tablaTitulosDetalles.AddCell(cellTituloTotal);

            documento.Add(tablaTitulosDetalles);

            //DETALLES
            foreach (var detalle in detalles)
            {
                PdfPTable tablaDetalle = new PdfPTable(6);
                tablaDetalle.WidthPercentage = 100;
                tablaDetalle.SetWidths(new float[] { 2, 5, 2, 2, 2, 2 });

                Articulo articulo = (from art in bd.Articulos
                                     where art.IdArticulo == detalle.IdArticulo
                                     select art).FirstOrDefault();

                PdfPCell cellCantidad = new PdfPCell(new Phrase(detalle.Cantidad.ToString(), fuente9));
                PdfPCell cellArticulo = new PdfPCell(new Phrase(articulo.Denominacion, fuente9));
                PdfPCell cellPrecio = new PdfPCell(new Phrase(String.Format("{0:C}", articulo.PrecioVenta), fuente9));
                PdfPCell cellSubtotal = new PdfPCell(new Phrase(String.Format("{0:C}", detalle.SubTotal), fuente9));
                PdfPCell cellDescuento = new PdfPCell(new Phrase(String.Format("{0:P2}", detalle.PorcentajeDescuento), fuente9));
                PdfPCell cellTotal = new PdfPCell(new Phrase(String.Format("{0:C}", detalle.Total), fuente9));

                cellCantidad.FixedHeight = 20;

                cellCantidad.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellArticulo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellArticulo.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPrecio.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPrecio.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellSubtotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellSubtotal.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellDescuento.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDescuento.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTotal.VerticalAlignment = Element.ALIGN_MIDDLE;

                tablaDetalle.AddCell(cellCantidad);
                tablaDetalle.AddCell(cellArticulo);
                tablaDetalle.AddCell(cellPrecio);
                tablaDetalle.AddCell(cellSubtotal);
                tablaDetalle.AddCell(cellDescuento);
                tablaDetalle.AddCell(cellTotal);

                documento.Add(tablaDetalle);
            }

            //VENDEDOR
            Vendedor tempVendedor = (from vend in bd.Vendedors
                                     where vend.IdVendedor == pedido.IdVendedor
                                     select vend).FirstOrDefault();

            Phrase vendedor1 = new Phrase("Vendedor: ", fuente9);
            Phrase vendedor2 = new Phrase(tempVendedor.Nombre + " " + tempVendedor.Apellido, fuente9Negrita);
            Paragraph vendedor = new Paragraph();
            vendedor.Add(vendedor1);
            vendedor.Add(vendedor2);
            vendedor.IndentationLeft = 5;

            documento.Add(vendedor);

            //TOTALES
            //Subtotal
            Phrase subtotal1 = new Phrase("Subtotal: ", fuente9);
            Phrase subtotal2 = new Phrase(String.Format("{0:C}", pedido.SubTotal), fuente11Negrita);
            Paragraph subtotal = new Paragraph();
            subtotal.Add(subtotal1);
            subtotal.Add(subtotal2);
            subtotal.Alignment = Element.ALIGN_RIGHT;
            subtotal.IndentationRight = 10;

            documento.Add(subtotal);

            //Gastos de envio
            Phrase gastosEnvio1 = new Phrase("Gastos de envio: ", fuente9);
            Phrase gastosEnvio2 = new Phrase(String.Format("{0:C}", pedido.GastosEnvio), fuente11Negrita);
            Paragraph gastosEnvio = new Paragraph();
            gastosEnvio.Add(gastosEnvio1);
            gastosEnvio.Add(gastosEnvio2);
            gastosEnvio.Alignment = Element.ALIGN_RIGHT;
            gastosEnvio.IndentationRight = 10;

            documento.Add(gastosEnvio);

            Paragraph espacioTotal = new Paragraph(" ", espaciador);
            documento.Add(espacioTotal);

            //Total
            Phrase total1 = new Phrase("Total: ", fuente11Negrita);
            Phrase total2 = new Phrase(String.Format("{0:C}", pedido.MontoTotal), fuente14Negrita);
            Paragraph total = new Paragraph();
            total.Add(total1);
            total.Add(total2);
            total.Alignment = Element.ALIGN_RIGHT;
            total.IndentationRight = 10;

            documento.Add(total);

            //Se cierra el documento
            documento.Close();

            context.Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        }
        context.Response.End();
    }

    //No tocar
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}