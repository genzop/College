using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Exportar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Consumir http://localhost:63942/Exportar.aspx?exportar=domicilios

        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        string respuesta = "";

        switch (Request.QueryString["exportar"])
        {
            case "vendedores":
                respuesta = exportarVendedores();
                break;

            case "clientes":
                respuesta = exportarClientes();
                break;

            case "articulos":
                respuesta = exportarArticulos();
                break;

            case "pedidos":
                respuesta = exportarPedidos();
                break;

            case "detalles":
                respuesta = exportarDetalles();
                break;

            case "domicilios":
                respuesta = exportarDomicilios();
                break;
        }

        Response.Write(respuesta);
        Response.End();
    }

    protected string exportarVendedores()
    {
        string sql = "SELECT * FROM Vendedor";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);
        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }

    protected string exportarClientes()
    {
        string sql = "SELECT * FROM Cliente";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }

    protected string exportarArticulos()
    {
        string sql = "SELECT * FROM Articulo";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }

    protected string exportarPedidos()
    {
        string sql = "SELECT * FROM PedidoVenta";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }

    protected string exportarDetalles()
    {
        string sql = "SELECT * FROM PedidoVentaDetalle";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }

    protected string exportarDomicilios()
    {
        string sql = "SELECT * FROM Domicilio";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds.Tables[0], Newtonsoft.Json.Formatting.Indented);
    }
}