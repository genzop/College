using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarRubro : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Validar que el usuario este logeado
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            //Si se va a editar un Rubro
            if (Request.QueryString["id"] != null)
            {
                lblTitulo.Text = "Editar Rubro";                

                try
                {
                    var rubro = (from rub in bd.Rubros
                                 where rub.IdRubro == Convert.ToInt32(Request.QueryString["id"])
                                 select rub).Single();

                    //Rellena el formulario con los datos
                    if (!IsPostBack)
                    {
                        txtCodigo.Text = rubro.IdRubro.ToString();
                        txtDenominacion.Text = rubro.Denominacion;                        
                        ddlRubroSuperior.SelectedValue = rubro.IdRubroSuperior.ToString();
                    }
                }
                catch (Exception) { }                
            }
            //Si se va a crear un Rubro
            else
            {
                //Cargar el ID que deberia tener en la base de datos
                var ultimoID = (from num in bd.GetIdentityRubro()
                                select num.Column1).FirstOrDefault();

                //Se muestra el proximo ID
                txtCodigo.Text = (Convert.ToInt32(ultimoID) + 1).ToString();                
            }
        }
    }

    //Valida que el Rubro superior no tenga asignado como Rubro superior a este rubro
    protected void cvRubroSuperior_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Carga el Rubro superior selecionado
        int idSeleccionado = Convert.ToInt32(ddlRubroSuperior.SelectedValue);

        Rubro rubroSeleccionado = (from rub in bd.Rubros
                                   where rub.IdRubro == idSeleccionado
                                   select rub).FirstOrDefault();

        //Compara que el Rubro seleccionado como superior no tenga a este Rubro como Rubro superior NI que se este asignando asi mismo como Rubro superior
        if (rubroSeleccionado.IdRubroSuperior == Convert.ToInt32(txtCodigo.Text) || rubroSeleccionado.IdRubro == Convert.ToInt32(txtCodigo.Text))
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnAccion_Click(object sender, EventArgs e)
    {
        //Si se cumplen todas las validaciones
        if (Page.IsValid)
        {
            try
            {
                //Si se esta creando un Rubro
                if (Request.QueryString["id"] == null)
                {
                    Rubro temp = new Rubro();
                    temp.Denominacion = txtDenominacion.Text;
                    temp.IdRubroSuperior = Convert.ToInt32(ddlRubroSuperior.SelectedValue);
                    bd.Rubros.InsertOnSubmit(temp);
                }
                else
                {
                    Rubro temp = (from rub in bd.Rubros
                                  where rub.IdRubro == Convert.ToInt32(Request.QueryString["id"])
                                  select rub).FirstOrDefault();                    
                    temp.Denominacion = txtDenominacion.Text;
                    temp.IdRubroSuperior = Convert.ToInt32(ddlRubroSuperior.SelectedValue);
                }

                bd.SubmitChanges();
                Response.Redirect("Rubros.aspx");
            }
            catch (Exception) { }            
        }
    }

    protected void cvRubroUnico_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Request.QueryString["id"] == null)
        {
            var rubro = (from rub in bd.Rubros
                         where rub.Denominacion == txtDenominacion.Text
                         select rub).FirstOrDefault();

            if(rubro == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            var rubro = (from rub in bd.Rubros
                         where rub.Denominacion == txtDenominacion.Text && rub.IdRubro != Convert.ToInt32(txtCodigo.Text)
                         select rub).FirstOrDefault();

            if (rubro == null)
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