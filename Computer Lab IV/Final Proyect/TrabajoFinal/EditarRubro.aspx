<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarRubro.aspx.cs" Inherits="EditarRubro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Editar Rubro</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 0px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Rubro" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>
    <br />

    <div class="create-page" style="padding-top: 0">
        <div class="create-form">

            <!-- Formulario Rubro -->
            <form runat="server">

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Codigo</p>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="inputCentrado" ReadOnly="true"/>                    
                </div>

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Denominacion</p>
                    <asp:TextBox id="txtDenominacion" runat="server" TextMode="MultiLine" Rows="4" cssclass="inputCentrado" style="resize: none"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                    <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationExpression="^(\s|.){1,100}$" ErrorMessage="* La denominacion puede contener hasta un máximo de 100 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>    
                    <asp:CustomValidator ID="cvRubroUnico" runat="server" OnServerValidate="cvRubroUnico_ServerValidate" ErrorMessage="*Esta denominacion ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                </div>

                <div class="editContent">
                    <p class="editContentTitle" style="font-weight: bold">Rubro Superior</p>
                    <asp:DropDownList ID="ddlRubroSuperior" runat="server" CssClass="drownDownList" DataSourceID="LinqDataSource1" DataTextField="Denominacion" DataValueField="IdRubro" style="margin-bottom: 10px"/>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" Select="new (IdRubro, Denominacion)" TableName="Rubros" />
                    <asp:CustomValidator ID="cvRubroSuperior" runat="server" OnServerValidate="cvRubroSuperior_ServerValidate" ErrorMessage="* Este rubro no puede ser asignado como rubro superior" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>
                </div>               
                
                <asp:button id="btnAccion" runat="server" text="Guardar" cssclass="botonImportante" OnClick="btnAccion_Click"/>
            </form>
        </div>
    </div>
</asp:Content>

