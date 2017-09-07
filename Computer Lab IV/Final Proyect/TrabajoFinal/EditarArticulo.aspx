<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarArticulo.aspx.cs" Inherits="EditarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Editar Articulo</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 0px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Titulo Temporal" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>
    <br />

    <div class="create-page" style="padding-top: 0">
        <div class="create-form">

            <!-- Formulario Articulo -->
            <form runat="server">

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Denominacion</p>
                    <asp:TextBox ID="txtDenominacion" runat="server" CssClass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                    <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationExpression="^(\s|.){1,200}$" ErrorMessage="* La denominacion puede contener hasta un máximo de 200 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />    
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Codigo</p>
                    <asp:textbox id="txtCodigo" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo" ValidationExpression="^(\s|.){1,20}$" ErrorMessage="* El codigo puede contener hasta un máximo de 20 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                        
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Precio de Compra</p>
                    <asp:textbox id="txtPrecioCompra" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rvfPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                             
                    <asp:RegularExpressionValidator ID="revPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* El precio de compra solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                                            
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">IVA</p>
                    <asp:textbox id="txtIVA" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvIVA" runat="server" ControlToValidate="txtIVA" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                    <asp:RangeValidator ID="rngvIVA" runat="server" ControlToValidate="txtIVA" Type="Double" MinimumValue="0,0" MaximumValue="100,0" ErrorMessage="* El IVA debe ser un numero decimal entre 0 y 100" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>        
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Precio de Venta</p>
                    <asp:textbox id="txtPrecioVenta" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                    <asp:RegularExpressionValidator ID="revPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* El precio de venta solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                                          
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Rubro</p>
                    <asp:DropDownList ID="ddlRubro" runat="server" CssClass="drownDownList" style="margin-bottom: 10px" DataSourceID="LinqDataSource1" DataTextField="Denominacion" DataValueField="IdRubro"></asp:DropDownList>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" Select="new (IdRubro, Denominacion)" TableName="Rubros" Where="Denominacion != @Denominacion">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="-" Name="Denominacion" Type="String" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                </div>               
                
                <asp:button id="btnAccion" runat="server" text="Texto temporal" cssclass="botonImportante" OnClick="btnAccion_Click"/>
            </form>
        </div>
    </div>
</asp:Content>

