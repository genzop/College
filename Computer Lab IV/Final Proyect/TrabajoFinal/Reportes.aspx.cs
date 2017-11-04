using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reportes : System.Web.UI.Page
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
            HyperLink reportes = (HyperLink)Master.FindControl("hlReportes");
            reportes.CssClass = "active";
            if (!IsPostBack)
            {
                cargarInformacion();
            }            
        }
    }

    private void cargarInformacion()
    {
        //Vendedores
        ddlPedidoVendedor.Items.Add(new ListItem("-", "-"));
        ddlArticuloVendedor.Items.Add(new ListItem("-", "-"));
        ddlClienteVendedor.Items.Add(new ListItem("-", "-"));
        var vendedores = from vend in bd.Vendedors
                         where vend.Administrador == false
                         select new
                         {
                             IdVendedor = vend.IdVendedor,
                             NombreCompleto = vend.Nombre + " " + vend.Apellido
                         };        
        foreach (var vend in vendedores)
        {
            ddlPedidoVendedor.Items.Add(new ListItem(vend.NombreCompleto, vend.IdVendedor.ToString()));
            ddlArticuloVendedor.Items.Add(new ListItem(vend.NombreCompleto, vend.IdVendedor.ToString()));
            ddlClienteVendedor.Items.Add(new ListItem(vend.NombreCompleto, vend.IdVendedor.ToString()));
        }

        //Clientes
        ddlPedidoCliente.Items.Add(new ListItem("-", "-"));
        ddlArticuloCliente.Items.Add(new ListItem("-", "-"));
        var clientes = from cli in bd.Clientes
                       orderby cli.RazonSocial
                       select new
                       {
                           IdCliente = cli.IdCliente,
                           RazonSocial = cli.RazonSocial
                       };
        foreach (var cli in clientes)
        {
            ddlPedidoCliente.Items.Add(new ListItem(cli.RazonSocial, cli.IdCliente.ToString()));
            ddlArticuloCliente.Items.Add(new ListItem(cli.RazonSocial, cli.IdCliente.ToString()));
        }

        //Pedidos Estado
        ddlPedidoEstado.Items.Add(new ListItem("-", "-"));
        ddlPedidoEstado.Items.Add(new ListItem("Pendiente", "Pendiente"));
        ddlPedidoEstado.Items.Add(new ListItem("Enviado", "Enviado"));
        ddlPedidoEstado.Items.Add(new ListItem("Entregado", "Entregado"));
        ddlPedidoEstado.Items.Add(new ListItem("Anulado", "Anulado"));

        //Pedidos Pagados
        ddlPedidoPagado.Items.Add(new ListItem("-", "-"));
        ddlPedidoPagado.Items.Add(new ListItem("Si", "true"));
        ddlPedidoPagado.Items.Add(new ListItem("No", "false"));

        //Paises
        ddlPedidoPais.Items.Add(new ListItem("-", "-"));
        ddlArticuloPais.Items.Add(new ListItem("-", "-"));
        ddlClientePais.Items.Add(new ListItem("-", "-"));
        var paises = from p in bd.Pais
                     orderby p.Denominacion
                     select new
                     {
                         IdPais = p.IdPais,
                         Denominacion = p.Denominacion
                     };
        foreach (var pais in paises)
        {
            ddlPedidoPais.Items.Add(new ListItem(pais.Denominacion, pais.IdPais.ToString()));
            ddlArticuloPais.Items.Add(new ListItem(pais.Denominacion, pais.IdPais.ToString()));
            ddlClientePais.Items.Add(new ListItem(pais.Denominacion, pais.IdPais.ToString()));
        }

        //Provincias
        ddlPedidoProvincia.Items.Add(new ListItem("-", "-"));
        ddlArticuloProvincia.Items.Add(new ListItem("-", "-"));
        ddlClienteProvincia.Items.Add(new ListItem("-", "-"));

        //Localidades
        ddlPedidoLocalidad.Items.Add(new ListItem("-", "-"));
        ddlArticuloLocalidad.Items.Add(new ListItem("-", "-"));
        ddlClienteLocalidad.Items.Add(new ListItem("-", "-"));

        //Rubros
        ddlArticuloRubro.Items.Add(new ListItem("-", "-"));
        var rubros = from rub in bd.Rubros
                     where rub.Denominacion != "-"
                     orderby rub.Denominacion
                     select new
                     {
                         IdRubro = rub.IdRubro,
                         Denominacion = rub.Denominacion
                     };
        foreach (var rubro in rubros)
        {
            ddlArticuloRubro.Items.Add(new ListItem(rubro.Denominacion, rubro.IdRubro.ToString()));
        }

        //Deudores
        ddlClienteDeudores.Items.Add(new ListItem("-", "-"));
        ddlClienteDeudores.Items.Add(new ListItem("Si", "true"));
        ddlClienteDeudores.Items.Add(new ListItem("No", "false"));
    }

    private void cargarProvincias(DropDownList ddlPaises, DropDownList ddlProvincias, DropDownList ddlLocalidades)
    {
        ddlProvincias.Items.Clear();
        ddlProvincias.Items.Add(new ListItem("-", "-"));
        ddlLocalidades.Items.Clear();
        ddlLocalidades.Items.Add(new ListItem("-", "-"));

        if (ddlPaises.SelectedValue != "-")
        {
            var tieneProvincias = (from prov in bd.Provincias
                                   where prov.IdPais == Convert.ToInt32(ddlPaises.SelectedValue)
                                   select prov).Any();
            if (tieneProvincias)
            {
                var provincias = from prov in bd.Provincias
                                 where prov.IdPais == Convert.ToInt32(ddlPaises.SelectedValue)
                                 orderby prov.Denominacion
                                 select new
                                 {
                                     IdProvincia = prov.IdProvincia,
                                     Denominacion = prov.Denominacion
                                 };
                foreach (var prov in provincias)
                {
                    ddlProvincias.Items.Add(new ListItem(prov.Denominacion, prov.IdProvincia.ToString()));
                }
            }
        }
    }

    protected void ddlPedidoPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincias(ddlPedidoPais, ddlPedidoProvincia, ddlPedidoLocalidad);
    }  

    protected void ddlArticuloPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincias(ddlArticuloPais, ddlArticuloProvincia, ddlArticuloLocalidad);
    }    

    protected void ddlClientePais_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarProvincias(ddlClientePais, ddlClienteProvincia, ddlClienteLocalidad);
    }

    private void cargarLocalidades(DropDownList ddlProvincias, DropDownList ddlLocalidades)
    {
        ddlLocalidades.Items.Clear();
        ddlLocalidades.Items.Add(new ListItem("-", "-"));

        if (ddlProvincias.SelectedValue != "-")
        {
            var tieneLocalidades = (from loc in bd.Localidads
                                    where loc.IdProvincia == Convert.ToInt32(ddlProvincias.SelectedValue)
                                    select loc).Any();
            if (tieneLocalidades)
            {
                var localidades = from loc in bd.Localidads
                                  where loc.IdProvincia == Convert.ToInt32(ddlProvincias.SelectedValue)
                                  orderby loc.Denominacion
                                  select new
                                  {
                                     IdLocalidad = loc.IdLocalidad,
                                     Denominacion = loc.Denominacion
                                  };
                foreach (var prov in localidades)
                {
                    ddlLocalidades.Items.Add(new ListItem(prov.Denominacion, prov.IdLocalidad.ToString()));
                }
            }
        }
    }

    protected void ddlPedidoProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarLocalidades(ddlPedidoProvincia, ddlPedidoLocalidad);
    }

    protected void ddlArticuloProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarLocalidades(ddlArticuloProvincia, ddlArticuloLocalidad);
    }
    
    protected void ddlClienteProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarLocalidades(ddlClienteProvincia, ddlClienteLocalidad);
    }   

    private List<int> calcularRubrosInferiores(int idRubro, List<int> resultado)
    {
        resultado.Add(idRubro);
        var rubrosInferiores = from rub in bd.Rubros
                               where rub.IdRubroSuperior == idRubro
                               select rub;
        if (rubrosInferiores.Count() != 0)
        {
            foreach (Rubro rub in rubrosInferiores)
            {
                calcularRubrosInferiores(rub.IdRubro, resultado);
            }
        }
        return resultado;
    }

    protected void btnReportePedidos_Click(object sender, EventArgs e)
    {
        //Verifica que haya Pedidos
        var hayPedidos = (from ped in bd.Pedidos
                          select ped).Any();

        //Si hay Pedidos los guarda en una variable
        if (hayPedidos)
        {
            var pedidos = (from ped in bd.Pedidos
                           select ped).ToList();
            //Filtro Vendedor
            if(pedidos.Count() != 0 && ddlPedidoVendedor.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if (pedido.IdVendedor == Convert.ToInt32(ddlPedidoVendedor.SelectedValue))
                    {
                        eliminar = false;
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Cliente
            if(pedidos.Count() != 0 && ddlPedidoCliente.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if (pedido.IdCliente == Convert.ToInt32(ddlPedidoCliente.SelectedValue))
                    {
                        eliminar = false;
                    }
                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }  

            //Filtro Fecha Inicio
            if(pedidos.Count() != 0 && txtPedidoFechaInicio.Text != "")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if (pedido.FechaPedido >= Convert.ToDateTime(txtPedidoFechaInicio.Text))
                    {
                        eliminar = false;
                    }
                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Fecha Fin
            if (pedidos.Count() != 0 && txtPedidoFechaFin.Text != "")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if (pedido.FechaPedido <= Convert.ToDateTime(txtPedidoFechaFin.Text))
                    {
                        eliminar = false;
                    }
                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Estado
            if(pedidos.Count() != 0 && ddlPedidoEstado.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if(pedido.Estado == ddlPedidoEstado.SelectedValue)
                    {
                        eliminar = false;
                    }
                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Pagado
            if (pedidos.Count() != 0 && ddlPedidoPagado.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    bool eliminar = true;
                    if (pedido.Pagado == Convert.ToBoolean(ddlPedidoPagado.Text))
                    {
                        eliminar = false;
                    }
                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Pais
            if (pedidos.Count() != 0 && ddlPedidoPais.SelectedValue != "-")
            {
                //Carga todas la Localidades de ese Pais
                List<int> idLocalidadesIncluidas = new List<int>();
                List<int> idProvincias = (from prov in bd.Provincias
                                          where prov.IdPais == Convert.ToInt32(ddlPedidoPais.SelectedValue)
                                          select prov.IdProvincia).ToList();
                foreach (int idProv in idProvincias)
                {
                    List<int> idLocalidades = (from loc in bd.Localidads
                                               where loc.IdProvincia == idProv
                                               select loc.IdLocalidad).ToList();

                    foreach (int idLoc in idLocalidades)
                    {
                        idLocalidadesIncluidas.Add(idLoc);
                    }
                }

                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    foreach (int idLoc in idLocalidadesIncluidas)
                    {
                        if (domicilio.IdLocalidad == idLoc)
                        {
                            eliminar = false;
                        }
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Provincia
            if (pedidos.Count() != 0 && ddlPedidoProvincia.SelectedValue != "-")
            {
                List<Cliente> clientesEliminados = new List<Cliente>();

                //Carga todas las localidades de esa provincia
                List<int> idLocalidadesIncluidas = (from loc in bd.Localidads
                                                    where loc.IdProvincia == Convert.ToInt32(ddlPedidoProvincia.SelectedValue)
                                                    select loc.IdLocalidad).ToList();

                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    foreach (int idLoc in idLocalidadesIncluidas)
                    {
                        if (domicilio.IdLocalidad == idLoc)
                        {
                            eliminar = false;
                        }
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Localidad
            if (pedidos.Count() != 0 && ddlPedidoLocalidad.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    if (domicilio.IdLocalidad == Convert.ToInt32(ddlPedidoLocalidad.SelectedValue))
                    {
                        eliminar = false;
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }                     

            if (pedidos.Count() != 0)
            {
                Session["Pedidos"] = pedidos.ToList();
                Session["PedidoVendedor"] = ddlPedidoVendedor.SelectedItem.Text;
                Session["PedidoCliente"] = ddlPedidoCliente.SelectedItem.Text;
                Session["PedidoFechaInicio"] = txtPedidoFechaInicio.Text;
                Session["PedidoFechaFin"] = txtPedidoFechaFin.Text;
                Session["PedidoEstado"] = ddlPedidoEstado.SelectedItem.Text;
                Session["PedidoPagado"] = ddlPedidoPagado.SelectedItem.Text;
                Session["PedidoPais"] = ddlPedidoPais.SelectedItem.Text;
                Session["PedidoProvincia"] = ddlPedidoProvincia.SelectedItem.Text;
                Session["PedidoLocalidad"] = ddlPedidoLocalidad.SelectedItem.Text;                
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "pedidosPDF", "window.open('ReportePedidos.ashx')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorFiltrosPedidos", "alert('No se encontro ningun pedido que cumpla con las caracteristicas seleccionadas')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorPedidos", "alert('No se encontro ningun pedido')", true);
        }
    }

    protected void btnReporteArticulos_Click(object sender, EventArgs e)
    {
        //Verifica que haya Pedidos
        var hayPedidos = (from ped in bd.Pedidos
                          select ped).Any();

        //Si hay Pedidos los guarda en una variable
        if (hayPedidos)
        {
            List<Pedido> pedidos = (from ped in bd.Pedidos
                                    select ped).ToList();
            //Filtro Vendedor
            if (pedidos.Count() != 0 && ddlArticuloVendedor.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    if (pedido.IdVendedor != Convert.ToInt32(ddlArticuloVendedor.SelectedValue))
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }                
            }

            //Filtro Cliente
            if (pedidos.Count() != 0 && ddlArticuloCliente.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    if (pedido.IdCliente != Convert.ToInt32(ddlArticuloCliente.SelectedValue))
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Fecha Inicio
            if (pedidos.Count() != 0 && txtArticuloFechaInicio.Text != "")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    if (pedido.FechaPedido <= Convert.ToDateTime(txtArticuloFechaInicio.Text))
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }                
            }

            //Filtro Fecha Fin
            if (pedidos.Count() != 0 && txtArticuloFechaFin.Text != "")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();
                foreach (Pedido pedido in pedidos)
                {
                    if (pedido.FechaPedido >= Convert.ToDateTime(txtArticuloFechaFin.Text))
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }
                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Pais
            if(pedidos.Count() != 0 && ddlArticuloPais.SelectedValue != "-")
            {
                //Carga todas la Localidades de ese Pais
                List<int> idLocalidadesIncluidas = new List<int>();
                List<int> idProvincias = (from prov in bd.Provincias
                                          where prov.IdPais == Convert.ToInt32(ddlArticuloPais.SelectedValue)
                                          select prov.IdProvincia).ToList();
                foreach (int idProv in idProvincias)
                {
                    List<int> idLocalidades = (from loc in bd.Localidads
                                               where loc.IdProvincia == idProv
                                               select loc.IdLocalidad).ToList();

                    foreach (int idLoc in idLocalidades)
                    {
                        idLocalidadesIncluidas.Add(idLoc);
                    }
                }

                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    foreach (int idLoc in idLocalidadesIncluidas)
                    {
                        if (domicilio.IdLocalidad == idLoc)
                        {
                            eliminar = false;
                        }
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Provincia
            if (pedidos.Count() != 0 && ddlArticuloProvincia.SelectedValue != "-")
            {
                List<Cliente> clientesEliminados = new List<Cliente>();

                //Carga todas las localidades de esa provincia
                List<int> idLocalidadesIncluidas = (from loc in bd.Localidads
                                                    where loc.IdProvincia == Convert.ToInt32(ddlArticuloProvincia.SelectedValue)
                                                    select loc.IdLocalidad).ToList();

                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    foreach (int idLoc in idLocalidadesIncluidas)
                    {
                        if (domicilio.IdLocalidad == idLoc)
                        {
                            eliminar = false;
                        }
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Filtro Localidad
            if (pedidos.Count() != 0 && ddlArticuloLocalidad.SelectedValue != "-")
            {
                List<Pedido> pedidosEliminados = new List<Pedido>();

                //Se recorren los Pedidos
                foreach (Pedido pedido in pedidos)
                {
                    Cliente cliente = (from cli in bd.Clientes
                                       where cli.IdCliente == pedido.IdCliente
                                       select cli).FirstOrDefault();
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cliente.IdDomicilio
                                           select dom).FirstOrDefault();
                    bool eliminar = true;
                    if (domicilio.IdLocalidad == Convert.ToInt32(ddlArticuloLocalidad.SelectedValue))
                    {
                        eliminar = false;
                    }

                    if (eliminar)
                    {
                        pedidosEliminados.Add(pedido);
                    }
                }

                foreach (Pedido pedido in pedidosEliminados)
                {
                    pedidos.Remove(pedido);
                }
            }

            //Guarda los Detalles de cada Pedido
            List<Detalle> detalles = new List<Detalle>();
            foreach (Pedido ped in pedidos)
            {
                var detallesPedido = from det in bd.Detalles
                                     where det.IdPedido == ped.IdPedido
                                     select det;
                foreach (Detalle det in detallesPedido)
                {
                    detalles.Add(det);
                }
            }

            //Filtro Rubro
            if (pedidos.Count() != 0 && ddlArticuloRubro.SelectedValue != "-")
            {
                List<int> resultado = new List<int>();
                resultado = calcularRubrosInferiores(Convert.ToInt32(ddlArticuloRubro.SelectedValue), resultado);

                List<Detalle> detallesEliminados = new List<Detalle>();

                foreach (Detalle det in detalles)
                {
                    Articulo articulo = (from art in bd.Articulos
                                         where art.IdArticulo == det.IdArticulo
                                         select art).FirstOrDefault();
                    bool eliminar = true;
                    foreach (int idRubro in resultado)
                    {
                        if (articulo.IdRubro == idRubro)
                        {
                            eliminar = false;
                        }
                    }
                    if (eliminar)
                    {
                        detallesEliminados.Add(det);
                    }
                }

                foreach (Detalle det in detallesEliminados)
                {
                    detalles.Remove(det);
                }
            }

            if(detalles.Count() != 0)
            {
                //Se crea un List de ArticuloCantidad que incluye el nombre del Articulo y la cantidad vendida
                List<ArticuloCantidad> articulosVendidos = new List<ArticuloCantidad>();

                //Calcular la cantidad de articulos
                foreach (Detalle det in detalles)
                {
                    Articulo articulo = (from art in bd.Articulos
                                         where art.IdArticulo == det.IdArticulo
                                         select art).FirstOrDefault();

                    Rubro rubro = (from rub in bd.Rubros
                                   where rub.IdRubro == articulo.IdRubro
                                   select rub).FirstOrDefault();

                    bool crearPareja = true;

                    //Revisa si ya hay una pareja con ese nombre
                    foreach (var pareja in articulosVendidos)
                    {
                        if (pareja.Denominacion == articulo.Denominacion)
                        {
                            crearPareja = false;
                            pareja.Cantidad += det.Cantidad;
                            pareja.Total += det.Total;
                        }
                    }

                    if (crearPareja)
                    {
                        articulosVendidos.Add(new ArticuloCantidad(articulo.Denominacion, det.Cantidad, articulo.PrecioVenta, rubro.Denominacion, det.Total));
                    }
                }

                //Envia la lista de articulos            
                Session["ArticulosVendidos"] = articulosVendidos;
                Session["ArticuloVendedor"] = ddlArticuloVendedor.SelectedItem.Text;
                Session["ArticuloCliente"] = ddlArticuloCliente.SelectedItem.Text;
                Session["ArticuloFechaInicio"] = txtArticuloFechaInicio.Text;
                Session["ArticuloFechaFin"] = txtArticuloFechaFin.Text;
                Session["ArticuloPais"] = ddlArticuloPais.SelectedItem.Text;
                Session["ArticuloProvincia"] = ddlArticuloProvincia.SelectedItem.Text;
                Session["ArticuloLocalidad"] = ddlArticuloLocalidad.SelectedItem.Text;
                Session["ArticuloRubro"] = ddlArticuloRubro.SelectedItem.Text;

                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "ArticulosPDF", "window.open('ReporteArticulos.ashx')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorFiltrosArticulos", "alert('No se encontro ningun articulo que cumpla con las caracteristicas seleccionadas')", true);
            }            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorArticulos", "alert('No se encontro ningun articulo')", true);
        }
    }

    protected void btnReporteClientes_Click(object sender, EventArgs e)
    {
        //Verifica que haya Clientes
        bool hayClientes = (from cli in bd.Clientes
                            select cli).Any();

        if (hayClientes)
        {
            List<Cliente> clientes = (from cli in bd.Clientes
                                      orderby cli.RazonSocial
                                      select cli).ToList();

            //Filtro Vendedor
            if(clientes.Count() != 0 && ddlClienteVendedor.SelectedValue != "-")
            {
                List<Pedido> pedidosVendedor = (from ped in bd.Pedidos
                                                where ped.IdVendedor == Convert.ToInt32(ddlClienteVendedor.SelectedValue)
                                                select ped).ToList();

                List<Cliente> clientesEliminados = new List<Cliente>();

                foreach (Cliente cliente in clientes)
                {
                    bool eliminar = true;
                    foreach (Pedido pedido in pedidosVendedor)
                    {
                        if (pedido.IdCliente == cliente.IdCliente)
                        {
                            eliminar = false;
                        }
                    }
                    if (eliminar)
                    {
                        clientesEliminados.Add(cliente);
                    }
                    
                }

                foreach (Cliente cliente in clientesEliminados)
                {
                    clientes.Remove(cliente);
                }
            }

            //Filtro Pais
            if(clientes.Count() != 0 && ddlClientePais.SelectedValue != "-")
            {
                //Carga todas la Localidades de ese Pais
                List<int> idLocalidadesIncluidas = new List<int>();
                List<int> idProvincias = (from prov in bd.Provincias
                                          where prov.IdPais == Convert.ToInt32(ddlClientePais.SelectedValue)
                                          select prov.IdProvincia).ToList();                
                foreach (int idProv in idProvincias)
                {
                    List<int> idLocalidades = (from loc in bd.Localidads
                                               where loc.IdProvincia == idProv
                                               select loc.IdLocalidad).ToList();
                    
                    foreach (int idLoc in idLocalidades)
                    {
                        idLocalidadesIncluidas.Add(idLoc);
                    }                                             
                }

                List<Cliente> clientesEliminados = new List<Cliente>();

                //Se recorren los Clientes
                foreach (Cliente cli in clientes)
                {
                    //Se carga su Domicilio
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cli.IdDomicilio
                                           select dom).FirstOrDefault();

                    bool eliminar = true;
                    foreach (int idLocalidad in idLocalidadesIncluidas)
                    {
                        if(domicilio.IdLocalidad == idLocalidad)
                        {
                            eliminar = false;
                        }  
                    }
                    if (eliminar)
                    {
                        clientesEliminados.Add(cli);
                    }                    
                }

                //Elimina los clientes
                foreach (Cliente cli in clientesEliminados)
                {
                    clientes.Remove(cli);
                }
            }

            //Filtro Provincia
            if (clientes.Count() != 0 && ddlClienteProvincia.SelectedValue != "-")
            {
                List<Cliente> clientesEliminados = new List<Cliente>();

                //Carga todas las localidades de esa provincia
                List<int> idLocalidadesIncluidas = (from loc in bd.Localidads
                                                    where loc.IdProvincia == Convert.ToInt32(ddlClienteProvincia.SelectedValue)
                                                    select loc.IdLocalidad).ToList();              

                //Se recorren los Clientes
                foreach (Cliente cli in clientes)
                {
                    //Se carga su Domicilio
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cli.IdDomicilio
                                           select dom).FirstOrDefault();

                    bool eliminar = true;
                    foreach (int idLocalidad in idLocalidadesIncluidas)
                    {
                        if (domicilio.IdLocalidad == idLocalidad)
                        {
                            eliminar = false;
                        }
                    }
                    if (eliminar)
                    {
                        clientesEliminados.Add(cli);
                    }
                }

                //Elimina los clientes
                foreach (Cliente cli in clientesEliminados)
                {
                    clientes.Remove(cli);
                }

            }

            //Filtro Localidad
            if (clientes.Count() != 0 && ddlClienteLocalidad.SelectedValue != "-")
            {
                List<Cliente> clientesEliminados = new List<Cliente>();

                foreach (Cliente cli in clientes)
                {
                    Domicilio domicilio = (from dom in bd.Domicilios
                                           where dom.IdDomicilio == cli.IdDomicilio
                                           select dom).FirstOrDefault();
                    if (domicilio.IdLocalidad != Convert.ToInt32(ddlClienteLocalidad.SelectedValue))
                    {
                        clientesEliminados.Add(cli);
                    }
                }

                //Elimina los clientes
                foreach (Cliente cli in clientesEliminados)
                {
                    clientes.Remove(cli);
                }
            }

            //Filtro Deudor
            if (clientes.Count() != 0 && ddlClienteDeudores.SelectedValue != "-")
            {
                List<Cliente> clientesEliminados = new List<Cliente>();

                foreach (Cliente cli in clientes)
                {
                    //Si se selecciono a los Clientes con saldo deudor
                    if (ddlClienteDeudores.SelectedValue == "true")
                    {
                        if (cli.Saldo == 0)
                        {
                            clientesEliminados.Add(cli);
                        }
                    }
                    else
                    {
                        if (cli.Saldo > 0)
                        {
                            clientesEliminados.Add(cli);
                        }
                    }
                }

                //Elimina los clientes
                foreach (Cliente cli in clientesEliminados)
                {
                    clientes.Remove(cli);
                }
            }

            //Enviar los ID's de los Clientes
            if (clientes.Count() != 0)
            {
                Session["Clientes"] = clientes.ToList();
                Session["ClienteVendedor"] = ddlClienteVendedor.SelectedItem.Text;
                Session["ClientePais"] = ddlClientePais.SelectedItem.Text;
                Session["ClienteProvincia"] = ddlClienteProvincia.SelectedItem.Text;
                Session["ClienteLocalidad"] = ddlClienteLocalidad.SelectedItem.Text;
                Session["ClienteDeudor"] = ddlClienteDeudores.SelectedItem.Text;
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "ClientesPDF", "window.open('ReporteClientes.ashx')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorFiltrosClientes", "alert('No se encontro ningun cliente que cumpla con las caracteristicas seleccionadas')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorClientes", "alert('No se encontro ningun cliente')", true);
        }        
    }
}