using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarRubro : System.Web.UI.Page
{
    BaseDatosDataContext bd;

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
                lblTitulo.Text = "Agregar Rubro";
                btnAccion.Text = "AGREGAR";
            }
            else
            {
                lblTitulo.Text = "Editar Rubro";
                btnAccion.Text = "GUARDAR";

                try
                {
                    var temp = (from rub in bd.Rubros
                                where rub.IdRubro == Convert.ToInt32(Request.QueryString["id"])
                                select rub).Single();

                    if (!IsPostBack)
                    {
                        txtCodigo.Text = temp.Codigo;
                        txtDenominacion.Text = temp.Denominacion;
                        ddlRubroSuperior.SelectedValue = temp.IdRubroSuperior.ToString();
                    }
                }
                catch (Exception) { }                
            }
        }
    }

    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Convert.ToInt32(Request.QueryString["id"]) == 0)
                {
                    Rubro temp = new Rubro();
                    temp.Codigo = txtCodigo.Text;
                    temp.Denominacion = txtDenominacion.Text;
                    temp.IdRubroSuperior = Convert.ToInt32(ddlRubroSuperior.SelectedValue);
                    bd.Rubros.InsertOnSubmit(temp);
                }
                else
                {
                    var temp = (from rub in bd.Rubros
                                where rub.IdRubro == Convert.ToInt32(Request.QueryString["id"])
                                select rub).Single();

                    temp.Codigo = txtCodigo.Text;
                    temp.Denominacion = txtDenominacion.Text;
                    temp.IdRubroSuperior = Convert.ToInt32(ddlRubroSuperior.SelectedValue);
                }
                bd.SubmitChanges();
                Response.Redirect("Rubros.aspx");
            }
            catch (Exception) { }            
        }
    }        
}