using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for Exportar
/// </summary>
[WebService(Namespace = "FinalLaboratorioIV")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Exportar : System.Web.Services.WebService
{

    public Exportar()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    [WebMethod]
    public string getVendedores()
    {
        string sql = "SELECT * FROM Vendedor";
        SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["TrabajoFinalConnectionString"].ToString());
        DataSet ds = new DataSet();
        da.Fill(ds);

        return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
    }



}
