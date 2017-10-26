    <%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarCliente.aspx.cs" Inherits="EditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Editar Cliente</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 0px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Titulo Temporal" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>
    <br />

    <div class="create-form" style="max-width: 800px; padding: 30px">

        <!-- Formulario Cliente -->
        <form runat="server">

            <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell Width="33%" style="vertical-align: top">
                                <!-- Razon Social -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Razon Social</p>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="inputCentrado" />
                                    <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:RegularExpressionValidator ID="revRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ValidationExpression="^(\s|.){1,50}$" ErrorMessage="*La razon social puede contener hasta un máximo de 50 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:CustomValidator ID="cvRazonSocialUnica" runat="server" OnServerValidate="cvRazonSocialUnica_ServerValidate" ErrorMessage="* La razon social ingresada ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="33%" style="vertical-align: top">
                                <!-- Cuit -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Cuit</p>
                                    <asp:TextBox ID="txtCuit" runat="server" CssClass="inputCentrado"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCuit" runat="server" ControlToValidate="txtCuit" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:RegularExpressionValidator ID="revCuit" runat="server" ControlToValidate="txtCuit" ValidationExpression="(\d{2}-\d{8}-\d{1})" ErrorMessage="* No es un numero de CUIT válido" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:CustomValidator ID="cvCuitUnico" runat="server" OnServerValidate="cvCuitUnico_ServerValidate" ErrorMessage="* El cuit ingresado ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                            </asp:TableCell>
                            <asp:TableCell Width="34%" style="vertical-align: top">
                                <!-- Saldo -->
                                <div id="divSaldo" runat="server" class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Saldo</p>
                                    <asp:TextBox ID="txtSaldo" runat="server" CssClass="inputCentrado" ReadOnly="true"></asp:TextBox>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell Width="33%">
                                <!-- Calle -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Calle</p>
                                    <asp:TextBox ID="txtCalle" runat="server" CssClass="inputCentrado"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:RegularExpressionValidator ID="revCalle" runat="server" ControlToValidate="txtCalle" ValidationExpression="^(\s|.){1,50}$" ErrorMessage="* La calle puede contener hasta un máximo de 50 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Numero -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Numero</p>
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="inputCentrado"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ControlToValidate="txtNumero" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    <asp:RegularExpressionValidator ID="revNumero" runat="server" ControlToValidate="txtNumero" ValidationExpression="\d+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Pais -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Pais</p>
                                    <asp:DropDownList ID="ddlPaises" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourcePaises" DataTextField="Denominacion" DataValueField="IdPais" CssClass="drownDownList" />
                                    <asp:SqlDataSource ID="SqlDataSourcePaises" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Pais] ORDER BY [Denominacion]"></asp:SqlDataSource>
                                    <asp:CustomValidator ID="cvPaisVacio" runat="server" OnServerValidate="cvPaisVacio_ServerValidate" ErrorMessage="*Debe elegir un pais" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Provincia -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Provincia</p>
                                    <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceProvincias" DataTextField="Denominacion" DataValueField="IdProvincia" CssClass="drownDownList" OnDataBound="ddlProvincias_DataBound" />
                                    <asp:SqlDataSource ID="SqlDataSourceProvincias" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Provincia] WHERE ([IdPais] = @IdPais) ORDER BY [Denominacion]">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlPaises" Name="IdPais" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:CustomValidator ID="cvProvinciaVacia" runat="server" OnServerValidate="cvProvinciaVacia_ServerValidate" ErrorMessage="*Debe elegir una provincia" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Localidad -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Localidad</p>
                                    <asp:DropDownList ID="ddlLocalidades" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceLocalidades" DataTextField="Denominacion" DataValueField="IdLocalidad" CssClass="drownDownList" OnDataBound="ddlLocalidades_DataBound"/>
                                    <asp:SqlDataSource ID="SqlDataSourceLocalidades" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Localidad] WHERE ([IdProvincia] = @IdProvincia) ORDER BY [Denominacion]">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlProvincias" Name="IdProvincia" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:CustomValidator ID="cvLocalidadVacia" runat="server" OnServerValidate="cvLocalidadVacia_ServerValidate" ErrorMessage="*Debe elegir una localidad" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Latitud -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Latitud (para Google Maps)</p>
                                    <asp:TextBox ID="txtLatitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La latitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                                <!-- Longitud -->
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Longitud (para Google Maps)</p>
                                    <asp:TextBox ID="txtLongitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La longitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                </div>
                            </asp:TableCell>
                            <asp:TableCell>
                                <div class="editContent">
                                    <p class="editContentTitle" style="font-weight: bold">Mapa</p>
                                    <div id="mapa" style="width: 100%; height: 470px; margin-top: 5px", />                                        
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                    <asp:Button ID="btnAccion" runat="server" Text="Guardar" CssClass="botonImportante" OnClick="btnAccion_Click" Width="200px" Style="margin-top: 20px" />
                </ContentTemplate>
            </asp:UpdatePanel>


        </form>
    </div>

    <script src="js/GoogleMaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB8wddZQ_zuj38hPkcihIUOWNaoUMc7K9Y&callback=initMap" defer></script>
</asp:Content>
