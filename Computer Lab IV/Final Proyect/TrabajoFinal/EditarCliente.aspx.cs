using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarCliente : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();
    Cliente tempCliente = null;
    Domicilio tempDomicilio = null;
    Localidad tempLocalidad = null;
    Provincia tempProvincia = null;
    bool datosCargados = false;

    //Si se recibe un id de parametro, se cargan los datos del cliente seleccionado, sino se muestra el formulario vacio
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            //Actualiza el mapa de JavaScript en el UpdatePanel
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "InitMap", "initMap()", true);
                        
            if (Convert.ToInt32(Request.QueryString["id"]) == 0)
            {
                lblTitulo.Text = "Agregar Cliente";
                txtSaldo.Text = "$ 0,0";
                if (!IsPostBack)
                {
                    txtLatitud.Text = "0";
                    txtLongitud.Text = "0";
                }                         
            }
            else
            {
                lblTitulo.Text = "Editar Cliente";

                try
                {
                    tempCliente = (from cliente in bd.Clientes
                                    where cliente.IdCliente == Convert.ToInt32(Request.QueryString["id"])
                                    select cliente).FirstOrDefault();

                    tempDomicilio = (from dom in bd.Domicilios
                                     where dom.IdDomicilio == tempCliente.IdDomicilio
                                     select dom).FirstOrDefault();

                    tempLocalidad = (from loc in bd.Localidads
                                     where loc.IdLocalidad == tempDomicilio.IdLocalidad
                                     select loc).FirstOrDefault();

                    tempProvincia = (from prov in bd.Provincias
                                     where prov.IdProvincia == tempLocalidad.IdProvincia
                                     select prov).FirstOrDefault();

                    if (!IsPostBack)
                    {
                        txtRazonSocial.Text = tempCliente.RazonSocial;
                        txtCuit.Text = tempCliente.Cuit;
                        txtSaldo.Text = String.Format("{0:C}", tempCliente.Saldo);
                        txtCalle.Text = tempDomicilio.Calle;
                        txtNumero.Text = tempDomicilio.Numero.ToString();
                        if (tempDomicilio.Latitud == null)
                        {
                            txtLatitud.Text = "0";
                        }
                        else
                        {
                            txtLatitud.Text = tempDomicilio.Latitud.ToString();
                        }   
                        
                        if(tempDomicilio.Longitud == null)
                        {
                            txtLongitud.Text = "0";
                        }
                        else
                        {
                            txtLongitud.Text = tempDomicilio.Longitud.ToString();
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
                //Si se esta agregando un Cliente
                if (Convert.ToInt32(Request.QueryString["id"]) == 0)
                {
                    //Guarda el Domicilio
                    tempDomicilio = new Domicilio();
                    tempDomicilio.Calle = txtCalle.Text;
                    tempDomicilio.Numero = Convert.ToInt32(txtNumero.Text);
                    tempDomicilio.IdLocalidad = Convert.ToInt32(ddlLocalidades.SelectedValue);
                    if (txtLatitud.Text != "")
                    {
                        tempDomicilio.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    else
                    {
                        tempDomicilio.Latitud = 0;
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDomicilio.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    else
                    {
                        tempDomicilio.Longitud = 0;
                    }
                    bd.Domicilios.InsertOnSubmit(tempDomicilio);
                    bd.SubmitChanges();

                    //Guarda al Cliente
                    tempCliente = new Cliente();
                    tempCliente.RazonSocial = txtRazonSocial.Text;
                    tempCliente.Cuit = txtCuit.Text;
                    tempCliente.Saldo = 0.0;
                    tempCliente.IdDomicilio = tempDomicilio.IdDomicilio;
                    bd.Clientes.InsertOnSubmit(tempCliente);
                    bd.SubmitChanges();
                    Response.Redirect("Clientes.aspx");
                }
                else
                {
                    tempCliente.RazonSocial = txtRazonSocial.Text;
                    tempCliente.Cuit = txtCuit.Text;
                    tempDomicilio.Calle = txtCalle.Text;
                    tempDomicilio.Numero = Convert.ToInt32(txtNumero.Text);
                    tempDomicilio.IdLocalidad = Convert.ToInt32(ddlLocalidades.SelectedValue);
                    if (txtLatitud.Text != "")
                    {
                        tempDomicilio.Latitud = Convert.ToDouble(txtLatitud.Text);
                    }
                    else
                    {
                        tempDomicilio.Latitud = 0;
                    }
                    if (txtLongitud.Text != "")
                    {
                        tempDomicilio.Longitud = Convert.ToDouble(txtLongitud.Text);
                    }
                    else
                    {
                        tempDomicilio.Longitud = 0;
                    }
                    bd.SubmitChanges();
                    Response.Redirect("Clientes.aspx");
                }
            }
            catch (Exception) { }            
        }       
    }    

    //Valida que la Razon Social ingresada no este en uso
    protected void cvRazonSocialUnica_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Si se esta agregando un Cliente
        if (Request.QueryString["id"] == null)  
        {
            var cliente = (from cli in bd.Clientes
                           where cli.RazonSocial == txtRazonSocial.Text
                           select cli).FirstOrDefault();
            if(cliente == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        //Si se esta editando un Cliente
        else
        {
            var cliente = (from cli in bd.Clientes
                           where cli.RazonSocial == txtRazonSocial.Text && cli.IdCliente != Convert.ToInt32(Request.QueryString["id"])
                           select cli).FirstOrDefault();
            if (cliente == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }

    //Valida que el Cuit ingresado no este en uso
    protected void cvCuitUnico_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Si se esta agregando un Cliente
        if (Request.QueryString["id"] == null)
        {
            var cliente = (from cli in bd.Clientes
                           where cli.Cuit == txtCuit.Text
                           select cli).FirstOrDefault();
            if (cliente == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        //Si se esta editando un Cliente
        else
        {
            var cliente = (from cli in bd.Clientes
                           where cli.Cuit == txtCuit.Text && cli.IdCliente != Convert.ToInt32(Request.QueryString["id"])
                           select cli).FirstOrDefault();
            if (cliente == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }

    //Valida que el usuario haya seleccionado un pais
    protected void cvPaisVacio_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlPaises.SelectedValue == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    //Valida que el usuario haya seleccionado una provincia
    protected void cvProvinciaVacia_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlProvincias.SelectedValue == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    //Valida que el usuario haya seleccionado una localidad
    protected void cvLocalidadVacia_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlLocalidades.SelectedValue == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }   

    protected void ddlProvincias_DataBound(object sender, EventArgs e)
    {
        if (ddlProvincias.Items.Count == 0)
        {
            ddlLocalidades.Items.Clear();
        }
        else
        {
            ddlLocalidades.DataBind();
        }
    }

    protected void ddlLocalidades_DataBound(object sender, EventArgs e)
    {
        if(Request.QueryString["id"] != null && !datosCargados)
        {
            if (!IsPostBack)
            {
                ddlPaises.SelectedValue = tempProvincia.IdPais.ToString();
                ddlProvincias.SelectedValue = tempLocalidad.IdProvincia.ToString();
                ddlLocalidades.SelectedValue = tempLocalidad.IdLocalidad.ToString();
                datosCargados = true;
            }            
        }
    }
}