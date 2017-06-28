<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarCliente.aspx.cs" Inherits="EditarCliente" %>
<%@ Register Src="~/ddlLocalidades.ascx" TagPrefix="uc" TagName="ddlLocalidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Editar Cliente</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <table style="margin: 0 auto">
        <tr>
            <td><br /><br />
                <div class="create-form" style="width: 400px; padding: 30px">

                    <!-- Formulario Cliente -->
                    <form runat="server">
                        <div style="margin: 10px 0">
                            <asp:Label ID="lblTitulo" runat="server" Text="Titulo Temporal" Font-Names="Arial" Font-Bold="true" Font-Size="25px" /><br />
                            <br />
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Razon Social</p>
                            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="inputCentrado" />
                            <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ValidationExpression="^(\s|.){1,100}$" ErrorMessage="* La razon social puede contener hasta un máximo de 100 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">CUIT</p>
                            <asp:TextBox ID="txtCuit" runat="server" CssClass="inputCentrado"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCuit" runat="server" ControlToValidate="txtCuit" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revCuit" runat="server" ControlToValidate="txtCuit" ValidationExpression="([0-9]{2}-[0-9]{8}-[0-9]{1})" ErrorMessage="* No es un numero de CUIT válido" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div id="divSaldo" runat="server" class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Saldo</p>
                            <asp:TextBox ID="txtSaldo" runat="server" CssClass="inputCentrado" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div style="padding: 25px 0 10px 0">
                            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio" Font-Bold="true" Font-Size="18px" />
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Calle</p>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="inputCentrado"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revCalle" runat="server" ControlToValidate="txtCalle" ValidationExpression="^(\s|.){1,100}$" ErrorMessage="* La calle puede contener hasta un máximo de 100 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Numero</p>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="inputCentrado"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ControlToValidate="txtNumero" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revNumero" runat="server" ControlToValidate="txtNumero" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Localidad</p>
                            <uc:ddlLocalidades runat="server" ID="ddlLocalidades" />
                            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidades$ddlLocalidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Latitud</p>
                            <asp:TextBox ID="txtLatitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La latitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Longitud</p>
                            <asp:TextBox ID="txtLongitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La longitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>

                        <asp:Button ID="btnAccion" runat="server" Text="Texto temporal" CssClass="botonImportante" OnClick="btnAccion_Click" />
                    </form>
                </div>
            </td>

            <!-- Mapa -->
            <td style="vertical-align: top">
                <br /><br />
                <div style="margin-left: 30px"">
                    <p style="color: #FEFFFF; font-family: Arial; font-size: 25px; font-weight: bold">Mapa</p>
                    <div id="mapa" style="width: 700px; height: 400px"></div>
                </div>                
            </td>
        </tr>
    </table>
    <script src="js/GoogleMaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB8wddZQ_zuj38hPkcihIUOWNaoUMc7K9Y&callback=initMap" defer></script>
</asp:Content>