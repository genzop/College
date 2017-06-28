using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarCliente : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    //Si se recibe un id de parametro, se cargan los datos del cliente seleccionado, sino se muestra el formulario vacio
    protected void Page_Load(object sender, EventArgs e)
    {
        bd = new BaseDatosDataContext();

        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            if (Convert.ToInt32(Request.QueryString["id"]) == 0)
            {
                lblTitulo.Text = "Agregar Cliente";
                txtSaldo.Text = "$ 0,0";
                btnAccion.Text = "AGREGAR";
            }
            else
            {
                lblTitulo.Text = "Editar Cliente";
                btnAccion.Text = "GUARDAR";

                try
                {
                    Cliente temp = (from cliente in bd.Clientes
                                    where cliente.IdCliente == Convert.ToInt32(Request.QueryString["id"])
                                    select cliente).Single();
                    Domicilio tempDom = (from dom in bd.Domicilios
                                         where dom.IdDomicilio == temp.IdDomicilio
                                         select dom).Single();
                    if (!IsPostBack)
                    {
                        txtRazonSocial.Text = temp.RazonSocial;
                        txtCuit.Text = temp.Cuit;
                        txtSaldo.Text = temp.Saldo.ToString();
                        txtCalle.Text = tempDom.Calle;
                        txtNumero.Text = tempDom.Numero.ToString();
                        DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");
                        ddlLocalidad.SelectedValue = tempDom.Localidad;
                        if (tempDom.Latitud != null)
                        {
                            txtLatitud.Text = tempDom.Latitud.ToString();
                        }
                        if (tempDom.Longitud != null)
                        {
                            txtLongitud.Text = tempDom.Longitud.ToString();
                        }
                    }
                }
                catch (Exception) { }
            }
        }        
    }

    //Se crea un nuevo cliente o se modifica uno ya existente
    protected void btnAccion_Click(object sender, EventArgs e)
    {        
        if (Page.IsValid)
        {
            try
            {
                DropDownList ddlLocalidad = (DropDownList)ddlLocalidades.FindControl("ddlLocalidad");

                if (Convert.ToInt32(Request.QueryString["id"]) == 0)
                {
                    Domicilio tempDom = new Domicilio();
                    tempDom.Calle = txtCalle.Text;
                    tempDom.Numero = Convert.ToInt32(txtNumero.Text);
                    tempDom.Localidad = ddlLocalidad.SelectedValue;
                    if (txtLatitud.Text != "")
                    {
                        tempDom.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDom.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    bd.Domicilios.InsertOnSubmit(tempDom);
                    bd.SubmitChanges();

                    Cliente tempCliente = new Cliente();
                    tempCliente.RazonSocial = txtRazonSocial.Text;
                    tempCliente.Cuit = txtCuit.Text;
                    tempCliente.Saldo = 0.0;
                    tempCliente.IdDomicilio = tempDom.IdDomicilio;
                    bd.Clientes.InsertOnSubmit(tempCliente);
                    bd.SubmitChanges();
                    Response.Redirect("Clientes.aspx");
                }
                else
                {
                    Cliente tempCliente = (from cliente in bd.Clientes
                                           where cliente.IdCliente == Convert.ToInt32(Request.QueryString["id"])
                                           select cliente).Single();
                    Domicilio tempDom = (from dom in bd.Domicilios
                                         where dom.IdDomicilio == tempCliente.IdDomicilio
                                         select dom).Single();

                    tempCliente.RazonSocial = txtRazonSocial.Text;
                    tempCliente.Cuit = txtCuit.Text;
                    tempDom.Calle = txtCalle.Text;
                    tempDom.Numero = Convert.ToInt32(txtNumero.Text);

                    tempDom.Localidad = ddlLocalidad.SelectedValue;
                    if (txtLatitud.Text != "")
                    {
                        tempDom.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDom.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    bd.SubmitChanges();
                    Response.Redirect("Clientes.aspx");
                }
            }
            catch (Exception) { }            
        }       
    }
}