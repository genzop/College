using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Localidades : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            HyperLink localidades = (HyperLink)Master.FindControl("hlLocalidades");
            localidades.CssClass = "active";
        }
    }    

    //Pais
    protected void imgAddPais_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Agregar Pais";
        formulario.Visible = true;
        hdnID.Value = null;
        hdnTipo.Value = "Pais";
        txtDenominacion.Text = "";
    }

    protected void imgEditPais_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Editar Pais";
        formulario.Visible = true;     

        Pai pais = (from p in bd.Pais
                    where p.IdPais == Convert.ToInt32(ddlPaises.SelectedValue)
                    select p).FirstOrDefault();

        hdnID.Value = pais.IdPais.ToString();
        hdnTipo.Value = "Pais";
        txtDenominacion.Text = pais.Denominacion;
    }

    protected void imgDeletePais_Click(object sender, ImageClickEventArgs e)
    {
        //Verifica si no hay ninguna Provincia asociada con este Pais
        bool tieneProvincias = (from prov in bd.Provincias
                                where prov.IdPais == Convert.ToInt32(ddlPaises.SelectedValue)
                                select prov).Any();

        //Si no hay niguna, elimina el Pais
        if (!tieneProvincias)
        {            
            Pai pais = (from p in bd.Pais
                        where p.IdPais == Convert.ToInt32(ddlPaises.SelectedValue)
                        select p).FirstOrDefault();
            bd.Pais.DeleteOnSubmit(pais);
            bd.SubmitChanges();
            ddlPaises.DataBind();
        }
        //Sino muestra un mensaje alertando al usuario
        else
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorEliminarPais", "alert('ERROR: No se puede eliminar este pais ya que aún tiene provincias asociadas')", true);
        }        
    }
    

    //Provincia
    protected void imgAddProvincia_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Agregar Provincia";
        formulario.Visible = true;
        hdnID.Value = null;
        hdnTipo.Value = "Provincia";
        txtDenominacion.Text = "";        
        paisesFormulario.Visible = true;        
    }

    protected void imgEditProvincia_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Editar Provincia";
        formulario.Visible = true;        
        paisesFormulario.Visible = true;

        var provincia = (from prov in bd.Provincias
                         where prov.IdProvincia == Convert.ToInt32(ddlProvincias.SelectedValue)
                         select prov).FirstOrDefault();

        hdnID.Value = provincia.IdProvincia.ToString();
        hdnTipo.Value = "Provincia";
        txtDenominacion.Text = provincia.Denominacion;
        ddlPaisesFormulario.SelectedValue = provincia.IdPais.ToString();
    }

    protected void imgDeleteProvincia_Click(object sender, ImageClickEventArgs e)
    {
        //Verifica si no hay ninguna Localidad asociada con esta Provincia
        bool tieneLocalidades = (from loc in bd.Localidads
                                 where loc.IdProvincia == Convert.ToInt32(ddlProvincias.SelectedValue)
                                 select loc).Any();

        //Si no hay niguna, elimina la Provincia
        if (!tieneLocalidades)
        {
            Provincia provincia = (from prov in bd.Provincias
                                   where prov.IdProvincia == Convert.ToInt32(ddlProvincias.SelectedValue)
                                   select prov).FirstOrDefault();
            bd.Provincias.DeleteOnSubmit(provincia);
            bd.SubmitChanges();
            ddlProvincias.DataBind();
        }
        //Sino muestra un mensaje alertando al usuario
        else
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorEliminarProvincia", "alert('ERROR: No se puede eliminar esta pronvincia ya que aún tiene localidades asociadas')", true);
        }
    }


    //Localidad
    protected void imgAddLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Agregar Localidad";
        formulario.Visible = true;
        hdnID.Value = null;
        hdnTipo.Value = "Localidad";
        txtDenominacion.Text = "";
        paisesFormulario.Visible = true;
        provinciasFormulario.Visible = true;        
    }

    protected void imgEditLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        lblFormulario.Text = "Editar Localidad";
        formulario.Visible = true;
        paisesFormulario.Visible = true;
        provinciasFormulario.Visible = true;

        var localidad = (from loc in bd.Localidads
                         where loc.IdLocalidad == Convert.ToInt32(ddlLocalidades.SelectedValue)
                         select loc).FirstOrDefault();

        var provincia = (from prov in bd.Provincias
                         where prov.IdProvincia == Convert.ToInt32(localidad.IdProvincia)
                         select prov).FirstOrDefault();

        hdnID.Value = localidad.IdLocalidad.ToString();
        hdnTipo.Value = "Localidad";
        txtDenominacion.Text = localidad.Denominacion;
        ddlPaisesFormulario.SelectedValue = provincia.IdPais.ToString();
        ddlProvinciasFormulario.SelectedValue = localidad.IdProvincia.ToString();        
    }

    protected void imgDeleteLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        var localidad = (from loc in bd.Localidads
                         where loc.IdLocalidad == Convert.ToInt32(ddlLocalidades.SelectedValue)
                         select loc).FirstOrDefault();
        bd.Localidads.DeleteOnSubmit(localidad);
        bd.SubmitChanges();
        ddlLocalidades.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Agregar Pais
            if (lblFormulario.Text == "Agregar Pais")
            {
                Pai pais = new Pai()
                {
                    Denominacion = txtDenominacion.Text
                };
                bd.Pais.InsertOnSubmit(pais);
                bd.SubmitChanges();
                ddlPaises.DataBind();
            }
            //EditarPais
            else if (lblFormulario.Text == "Editar Pais")
            {
                Pai pais = (from p in bd.Pais
                            where p.IdPais == Convert.ToInt32(hdnID.Value)
                            select p).FirstOrDefault();
                pais.Denominacion = txtDenominacion.Text;
                bd.SubmitChanges();
                ddlPaises.DataBind();
            }
            //Agregar Provincia
            else if (lblFormulario.Text == "Agregar Provincia")
            {
                Provincia prov = new Provincia()
                {
                    Denominacion = txtDenominacion.Text,
                    IdPais = Convert.ToInt32(ddlPaisesFormulario.SelectedValue)
                };
                bd.Provincias.InsertOnSubmit(prov);
                bd.SubmitChanges();
                ddlProvincias.DataBind();
            }
            //Editar Provincia
            else if (lblFormulario.Text == "Editar Provincia")
            {
                Provincia prov = (from p in bd.Provincias
                                  where p.IdProvincia == Convert.ToInt32(hdnID.Value)
                                  select p).FirstOrDefault();
                prov.Denominacion = txtDenominacion.Text;
                prov.IdPais = Convert.ToInt32(ddlPaisesFormulario.SelectedValue);
                bd.SubmitChanges();
                ddlProvincias.DataBind();
            }
            //Agregar Localidad
            else if(lblFormulario.Text == "Agregar Localidad")
            {
                Localidad localidad = new Localidad()
                {
                    Denominacion = txtDenominacion.Text,
                    IdProvincia = Convert.ToInt32(ddlProvinciasFormulario.SelectedValue)
                };
                bd.Localidads.InsertOnSubmit(localidad);
                bd.SubmitChanges();
                ddlLocalidades.DataBind();
            }
            //Editar Localidad
            else if(lblFormulario.Text == "Editar Localidad")
            {
                Localidad localidad = (from loc in bd.Localidads
                                       where loc.IdLocalidad == Convert.ToInt32(hdnID.Value)
                                       select loc).FirstOrDefault();
                localidad.Denominacion = txtDenominacion.Text;
                localidad.IdProvincia = Convert.ToInt32(ddlProvinciasFormulario.SelectedValue);
                bd.SubmitChanges();
                ddlLocalidades.DataBind();
            }

            btnCancelar_Click(null, null);
        }        
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblFormulario.Text = "";
        hdnID.Value = null;
        hdnTipo.Value = null;
        txtDenominacion.Text = "";
        paisesFormulario.Visible = false;
        provinciasFormulario.Visible = false;
        formulario.Visible = false;
    }

    //Valida que no se repita la denominacion del Pais
    protected void csvDenominacionUnica_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Pais
        if(hdnTipo.Value == "Pais")
        {            
            //Si se quiere agregar un Pais
            if(lblFormulario.Text == "Agregar Pais")
            {
                //Verifica si hay un Pais con esa denominacion
                var pais = (from p in bd.Pais
                            where p.Denominacion == txtDenominacion.Text
                            select p).FirstOrDefault();

                if(pais == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            //Si se quiere editar un Pais
            else
            {
                //Verifica si hay otro Pais con esa denominacion
                var pais = (from p in bd.Pais
                            where p.Denominacion == txtDenominacion.Text && p.IdPais != Convert.ToInt32(hdnID.Value)
                            select p).FirstOrDefault();

                if (pais == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
        //Provincia
        else if (hdnTipo.Value == "Provincia")
        {
            //Si se quiere agregar una Provincia
            if (lblFormulario.Text == "Agregar Provincia")
            {
                //Verifica si hay otra Provincia en ese Pais con el mismo nombre
                var provincia = (from prov in bd.Provincias
                                 where prov.Denominacion == txtDenominacion.Text && prov.IdPais == Convert.ToInt32(ddlPaisesFormulario.SelectedValue)
                                 select prov).FirstOrDefault();

                if (provincia == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            //Si se quiere editar una Provincia
            else
            {
                //Verifica si hay otra Provincia en ese Pais con el mismo nombre
                var provincia = (from prov in bd.Provincias
                                 where prov.Denominacion == txtDenominacion.Text && prov.IdPais == Convert.ToInt32(ddlPaisesFormulario.SelectedValue) && prov.IdProvincia != Convert.ToInt32(hdnID.Value)
                                 select prov).FirstOrDefault();

                if (provincia == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
        //Localidad
        else if(hdnTipo.Value == "Localidad")
        {
            //Si se quiere agregar una Localidad
            if(lblFormulario.Text == "Agregar Localidad")
            {
                if(ddlProvinciasFormulario.SelectedValue == "")
                {
                    
                }
                else
                {
                    var localidad = (from loc in bd.Localidads
                                     where loc.Denominacion == txtDenominacion.Text && loc.IdProvincia == Convert.ToInt32(ddlProvinciasFormulario.SelectedValue)
                                     select loc).FirstOrDefault();
                    if (localidad == null)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }               
            }
            //Si se quiere editar una Localidad
            else
            {
                var localidad = (from loc in bd.Localidads
                                 where loc.Denominacion == txtDenominacion.Text && loc.IdProvincia == Convert.ToInt32(ddlProvinciasFormulario.SelectedValue) && loc.IdLocalidad != Convert.ToInt32(hdnID.Value) 
                                 select loc).FirstOrDefault();
                if (localidad == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
    }

    //Cuando se selecciona un Pais que aun no tiene ninguna Provincia, se limpia el DropDownList de Localidades
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

    //Valida que se haya seleccionado una Provincia
    protected void cvProvinciaVacia_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlProvinciasFormulario.SelectedValue == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}