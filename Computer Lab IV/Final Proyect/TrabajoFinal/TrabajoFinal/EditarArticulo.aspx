﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarArticulo.aspx.cs" Inherits="EditarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Editar Articulo</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 0px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Artículo" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>
    <br />

    <div class="create-page" style="padding-top: 0">
        <div class="create-form">

            <!-- Formulario Articulo -->
            <form runat="server">

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Codigo</p>
                    <asp:textbox id="txtCodigo" runat="server" ReadOnly="true" cssclass="inputCentrado" />                    
                </div>

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Denominacion</p>
                    <asp:TextBox ID="txtDenominacion" runat="server" CssClass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                    <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationExpression="^(\s|.){1,100}$" ErrorMessage="* La denominacion puede contener hasta un máximo de 100 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />    
                    <asp:CustomValidator ID="cvArticuloUnico" runat="server" OnServerValidate="cvArticuloUnico_ServerValidate" ErrorMessage="*Esta denominacion ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                </div>
                
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Precio de Compra</p>
                    <asp:textbox id="txtPrecioCompra" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rvfPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                             
                    <asp:RegularExpressionValidator ID="revPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ValidationExpression="(\d*[,])?\d+" ErrorMessage="* El precio de compra solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                                            
                </div>
                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Precio de Venta</p>
                    <asp:textbox id="txtPrecioVenta" runat="server" cssclass="inputCentrado" />
                    <asp:RequiredFieldValidator ID="rfvPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                    <asp:RegularExpressionValidator ID="revPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta" ValidationExpression="(\d*[,])?\d+" ErrorMessage="* El precio de venta solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                                          
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
                <asp:Table runat="server" Style="margin: 0 auto" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false" CssClass="botonImportante" OnClick="btnCancelar_Click" Style="margin-right: 20px" Width="140px" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button ID="btnAccion" runat="server" Text="Guardar" CssClass="botonImportante" OnClick="btnAccion_Click"  Width="140px"  />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </form>
        </div>
    </div>
</asp:Content>

