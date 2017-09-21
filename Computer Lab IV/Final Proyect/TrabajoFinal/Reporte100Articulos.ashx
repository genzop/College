<%@ WebHandler Language="C#" Class="Reporte100Articulos" %>

using System;
using System.Web;

public class Reporte100Articulos : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}