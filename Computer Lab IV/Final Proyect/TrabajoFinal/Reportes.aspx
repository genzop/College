<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Reportes</title>
    <style type="text/css">
        .auto-style1 {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <div style="text-align: center; padding: 40px 0px 20px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Reportes" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>

    <form runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Pedidos -->
                <div>
                    <div style="width: 900px; margin: 0 auto">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 5%">
                                    <asp:Label ID="lblPedidos" runat="server" Text="Pedidos" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="23px " />
                                </td>
                                <td style="width: 95%">
                                    <hr style="display: block; height: 1px; border: 0; border-top: 3px solid #ccc; margin: 1em 0; padding: 0; margin-left:10px" />
                                </td>
                            </tr>
                        </table>                
                    </div>            
                <div style="width: 900px; margin: 0 auto">
                <table style="width: 100%">
                    <tr>
                        <!-- Vendedor -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white">Vendedor</p>
                                <asp:DropDownList ID="ddlPedidoVendedor" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                                
                            </div>
                        </td>
                        <!-- Cliente -->
                        <td style="vertical-align: top" class="auto-style1">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Cliente</p>                                
                                <asp:DropDownList ID="ddlPedidoCliente" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Fecha Inicio -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Fecha Inicio</p>
                                <asp:TextBox ID="txtPedidoFechaInicio" runat="server" TextMode="Date" />
                            </div>
                        </td>
                        <!-- Fecha Fin -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Fecha Fin</p>
                                <asp:TextBox ID="txtPedidoFechaFin" runat="server" TextMode="Date" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <!-- Pais -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Pais</p>
                                <asp:DropDownList ID="ddlPedidoPais" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlPedidoPais_SelectedIndexChanged"/>                                
                            </div>
                        </td>
                        <!-- Provincia -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Provincia</p>
                                <asp:DropDownList ID="ddlPedidoProvincia" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlPedidoProvincia_SelectedIndexChanged" />                                
                            </div>
                        </td>
                        <!-- Localidad -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Localidad</p>
                                <asp:DropDownList ID="ddlPedidoLocalidad" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Pagado -->
                        <td>
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Pagado</p>
                                <asp:DropDownList ID="ddlPedidoPagado" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>                        
                    </tr>
                </table><br />  
                <asp:button id="btnReportePedidos" runat="server" text="Generar Reporte" OnClick="btnReportePedidos_Click" cssclass="botonImportante" Width="200" Height="50" style="float: right; margin-right: 15px"/>
            </div>
        </div>
        
        <!-- Articulos -->
        <div style="margin-top:100px">
            <div style="width: 900px; margin: 0 auto">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 5%">
                            <asp:Label ID="lblArticulo" runat="server" Text="Articulos" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="23px " />
                        </td>
                        <td style="width: 95%">
                            <hr style="display: block; height: 1px; border: 0; border-top: 3px solid #ccc; margin: 1em 0; padding: 0; margin-left:10px" />
                        </td>
                    </tr>
                </table>                
            </div>
            
            <div style="width: 900px; margin: 0 auto">
                <table style="width: 100%">
                    <tr>
                        <!-- Vendedor-->  
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white">Vendedor</p>
                                <asp:DropDownList ID="ddlArticuloVendedor" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Cliente -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Cliente</p>
                                <asp:DropDownList ID="ddlArticuloCliente" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Fecha Inicio -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Fecha Inicio</p>
                                <asp:TextBox ID="txtArticuloFechaInicio" runat="server" TextMode="Date" />
                            </div>
                        </td>
                        <!-- Fecha Fin -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Fecha Fin</p>
                                <asp:TextBox ID="txtArticuloFechaFin" runat="server" TextMode="Date" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <!-- Pais -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white">Pais</p>
                                <asp:DropDownList ID="ddlArticuloPais" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlArticuloPais_SelectedIndexChanged" />                                
                            </div>
                        </td>
                        <!-- Provincia -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Provincia</p>
                                <asp:DropDownList ID="ddlArticuloProvincia" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlArticuloProvincia_SelectedIndexChanged" />                                
                            </div>
                        </td>
                        <!-- Localidad -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Localidad</p>
                                <asp:DropDownList ID="ddlArticuloLocalidad" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Rubro -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Rubro</p>
                                <asp:DropDownList ID="ddlArticuloRubro" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                    </tr>
                </table><br />
                <asp:button id="btnReporteArticulos" runat="server" text="Generar Reporte" OnClick="btnReporteArticulos_Click" cssclass="botonImportante" Width="200" Height="50" style="float: right; margin-right: 15px"/>
            </div>
        </div>

        <!-- Clientes -->
        <div style="margin-top:100px; margin-bottom: 100px">
            <div style="width: 900px; margin: 0 auto">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 5%">
                            <asp:Label ID="lblClientes" runat="server" Text="Clientes" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="23px " />
                        </td>
                        <td style="width: 95%">
                            <hr style="display: block; height: 1px; border: 0; border-top: 3px solid #ccc; margin: 1em 0; padding: 0; margin-left:10px" />
                        </td>
                    </tr>
                </table>                
            </div>
            
            <div style="width: 900px; margin: 0 auto">
                <table style="width: 100%">
                    <tr>
                        <!-- Vendedor -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white">Vendedor</p>
                                <asp:DropDownList ID="ddlClienteVendedor" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                        <!-- Pais -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Pais</p>
                                <asp:DropDownList ID="ddlClientePais" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlClientePais_SelectedIndexChanged"/>                                
                            </div>
                        </td>
                        <!-- Provincia -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Provincia</p>
                                <asp:DropDownList ID="ddlClienteProvincia" runat="server" CssClass="drownDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlClienteProvincia_SelectedIndexChanged" />                                
                            </div>
                        </td>
                        <!-- Localidad -->
                        <td style="width: 25%; vertical-align: top">
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Localidad</p>
                                <asp:DropDownList ID="ddlClienteLocalidad" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold; color: white"">Deudor</p>
                                <asp:DropDownList ID="ddlClienteDeudores" runat="server" CssClass="drownDownList" AutoPostBack="True" />                                
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:button id="btnReporteClientes" runat="server" text="Generar Reporte" OnClick="btnReporteClientes_Click" cssclass="botonImportante" Width="200" Height="50" style="float: right; margin-right: 15px"/>
            </div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        
    </form>
</asp:Content>

