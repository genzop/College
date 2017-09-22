<%@ WebHandler Language="C#" Class="ReporteClientes" %>

using System;
using System.Web;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReporteClientes : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        //Se guarda el id del vendedor
        string idVendedor = context.Request.QueryString["id"];

        //Se cargan los pedidos
        List<PedidoVenta> pedidos = cargarPedidos(Convert.ToInt32(idVendedor));

        //Se cargan los clientes
        List<Cliente> clientes = cargarClientes(pedidos);

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

            Font fuente11 = new Font(Font.FontFamily.HELVETICA, 11);
            Font fuente11Negrita = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD);
            Font fuente14Negrita = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);

            //Logo
            string imagepath = HttpContext.Current.Server.MapPath(".") + "/img/logo-utn.png";
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagepath);
            logo.Alignment = Element.ALIGN_CENTER;
            logo.ScalePercent(50);
            documento.Add(logo);

            //Titulo
            Paragraph titulo = new Paragraph("Listado de clientes", fuente14Negrita);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 30f;
            documento.Add(titulo);

            foreach (Cliente cli in clientes)
            {
                Domicilio domicilio = (from dom in bd.Domicilios
                                       where dom.IdDomicilio == cli.IdDomicilio
                                       select dom).FirstOrDefault();

                Paragraph denominacion = new Paragraph(cli.RazonSocial, fuente11Negrita);
                denominacion.SpacingBefore = 20f;
                Paragraph cuit = new Paragraph("CUIT N°: " + cli.Cuit, fuente11);
                Paragraph localidad = new Paragraph("Localidad: " + domicilio.Localidad, fuente11);
                Paragraph direccion = new Paragraph("Dirección: " + domicilio.Calle + " " + domicilio.Numero, fuente11);
                Paragraph saldo = new Paragraph("Saldo: $ " + cli.Saldo, fuente11);
                Paragraph barraSeparadora = new Paragraph("___________________________________________________________________", fuente14Negrita);

                documento.Add(denominacion);
                documento.Add(cuit);
                documento.Add(localidad);
                documento.Add(direccion);
                documento.Add(saldo);
                documento.Add(barraSeparadora);
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

    private List<PedidoVenta> cargarPedidos(int idVendedor)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        //Si es el administrador se cargan todos los pedidos
        if (idVendedor == 20)
        {
            var pedidos = (from ped in bd.PedidoVentas
                           select ped).ToList();
            return pedidos;
        }
        //Sino se cargan los del vendedor correspondiente
        else
        {
            var pedidos = (from ped in bd.PedidoVentas
                           where ped.IdVendedor == Convert.ToInt32(idVendedor)
                           select ped).ToList();
            return pedidos;
        }
    }

    private List<Cliente> cargarClientes(List<PedidoVenta> pedidos)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();
        List<Cliente> listaClientes = new List<Cliente>();

        //Por cada pedido
        foreach (PedidoVenta pedido in pedidos)
        {
            bool esta = false;

            //Por cada cliente en la lista
            foreach (Cliente cli in listaClientes)
            {
                //Se verifica si ya registrado
                if (cli.IdCliente == pedido.IdCliente)
                {
                    esta = true;
                }
            }

            //Sino esta registrado se agrega a la lista
            if (!esta)
            {
                Cliente tempCliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();

                listaClientes.Add(tempCliente);
            }
        }
        return listaClientes;
    }
}