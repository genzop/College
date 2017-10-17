<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Localidades.aspx.cs" Inherits="Localidades" %>

<%@ MasterType VirtualPath="~/Navegacion.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Localidades</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />                
                <table style="margin: 0 auto; border-spacing: 50px 0px">
                    <tr>
                        <td style="vertical-align: top">
                            <!-- Paises -->
                            <div style="text-align: center; padding: 40px 0px 20px 0px">
                                <asp:Label ID="lblTituloPaises" runat="server" Text="Paises" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
                            </div>

                            <div id="paises" runat="server" style="width: 340px; margin: 0 auto">
                                <asp:DropDownList ID="ddlPaises" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourcePaises" DataTextField="Denominacion" DataValueField="IdPais" CssClass="drownDownList" Width="230px" Style="margin-top: 0px" />
                                <asp:SqlDataSource ID="SqlDataSourcePaises" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Pais] ORDER BY [Denominacion]"></asp:SqlDataSource>
                                <asp:ImageButton ID="imgAddPais" runat="server" ImageUrl="~/img/add.png" Width="20px" OnClick="imgAddPais_Click" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgEditPais" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnClick="imgEditPais_Click" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgDeletePais" runat="server" ImageUrl="~/img/delete.png" Width="20px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este pais?')" OnClick="imgDeletePais_Click" Style="margin: 0px 0px 0px 8px" />
                            </div>                            
                        </td>
                        <td style="vertical-align: top">
                            <!-- Provincias -->
                            <div style="text-align: center; padding: 40px 0px 20px 0px">
                                <asp:Label ID="lblTituloProvincias" runat="server" Text="Provincias" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
                            </div>

                            <div id="provincias" runat="server" style="width: 340px; margin: 0 auto">
                                <asp:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceProvincias" DataTextField="Denominacion" DataValueField="IdProvincia" CssClass="drownDownList" Width="230px" Style="margin-top: 0px" OnDataBound="ddlProvincias_DataBound"/>
                                <asp:SqlDataSource ID="SqlDataSourceProvincias" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Provincia] WHERE ([IdPais] = @IdPais) ORDER BY [Denominacion]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlPaises" Name="IdPais" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:ImageButton ID="imgAddProvincia" runat="server" ImageUrl="~/img/add.png" OnClick="imgAddProvincia_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgEditProvincia" runat="server" ImageUrl="~/img/edit.png" OnClick="imgEditProvincia_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgDeleteProvincia" runat="server" ImageUrl="~/img/delete.png" OnClientClick="return confirm('¿Esta seguro que quiere borrar esta provincia?')" OnClick="imgDeleteProvincia_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                            </div>                                                       
                        </td>
                        <td style="vertical-align: top">
                            <!-- Localidades -->
                            <div style="text-align: center; padding: 40px 0px 20px 0px">
                                <asp:Label ID="lblTituloLocalidades" runat="server" Text="Localidades" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
                            </div>

                            <div id="localidades" runat="server" style="width: 340px; margin: 0 auto">
                                <asp:DropDownList ID="ddlLocalidades" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceLocalidades" DataTextField="Denominacion" DataValueField="IdLocalidad" CssClass="drownDownList" Width="230px" Style="margin-top: 0px" />
                                <asp:SqlDataSource ID="SqlDataSourceLocalidades" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Localidad] WHERE ([IdProvincia] = @IdProvincia) ORDER BY [Denominacion]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlProvincias" Name="IdProvincia" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:ImageButton ID="imgAddLocalidad" runat="server" ImageUrl="~/img/add.png" OnClick="imgAddLocalidad_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgEditLocalidad" runat="server" ImageUrl="~/img/edit.png" OnClick="imgEditLocalidad_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                                <asp:ImageButton ID="imgDeleteLocalidad" runat="server" ImageUrl="~/img/delete.png" OnClientClick="return confirm('¿Esta seguro que quiere borrar esta localidad?')" OnClick="imgDeleteLocalidad_Click" Width="20px" Style="margin: 0px 0px 0px 8px" />
                            </div>                            
                        </td>
                    </tr>
                </table><br /><br />

                <div style="text-align: center; padding: 40px 0px 20px 0px">
                    <asp:Label ID="lblFormulario" runat="server" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="28px " />
                </div>

                <div id="formulario" runat="server" class="create-form" visible="false" style="margin-bottom: 50px">                                      

                    <asp:HiddenField ID="hdnID" runat="server" />
                    <asp:HiddenField ID="hdnTipo" runat="server" />

                    <div class="editContent">
                        <p class="editContentTitle" style="font-weight: bold">Denominacion</p>
                        <asp:TextBox ID="txtDenominacion" runat="server" TextMode="MultiLine" Rows="4" CssClass="inputCentrado" Style="resize: none"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ValidationGroup="formGroup" ControlToValidate="txtDenominacion" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ValidationGroup="formGroup" ControlToValidate="txtDenominacion" ValidationExpression="^(\s|.){1,50}$" ErrorMessage="* La denominacion puede contener hasta un máximo de 200 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                        
                        <asp:CustomValidator ID="csvDenominacionUnica" runat="server" ValidationGroup="formGroup" OnServerValidate="csvDenominacionUnica_ServerValidate" ErrorMessage="*Esta denominacion ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                        
                    </div>

                    <div id="paisesFormulario" runat="server" class="editContent" visible="false">
                        <p class="editContentTitle" style="font-weight: bold">Pais</p>
                        <asp:DropDownList ID="ddlPaisesFormulario" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourcePaisesFormulario" DataTextField="Denominacion" DataValueField="IdPais" CssClass="drownDownList" />
                        <asp:SqlDataSource ID="SqlDataSourcePaisesFormulario" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Pais] ORDER BY [Denominacion]"></asp:SqlDataSource>                         
                    </div>

                    <div id="provinciasFormulario" runat="server" class="editContent" visible="false">
                        <p class="editContentTitle" style="font-weight: bold">Provincia</p>
                        <asp:DropDownList ID="ddlProvinciasFormulario" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceProvinciasFormulario" DataTextField="Denominacion" DataValueField="IdProvincia" CssClass="drownDownList" />
                        <asp:SqlDataSource ID="SqlDataSourceProvinciasFormulario" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT * FROM [Provincia] WHERE ([IdPais] = @IdPais) ORDER BY [Denominacion]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPaisesFormulario" Name="IdPais" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:CustomValidator ID="cvProvinciaVacia" runat="server" OnServerValidate="cvProvinciaVacia_ServerValidate" ValidationGroup="formGroup" ErrorMessage="*Debe elegir una provincia" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                        
                    </div><br />

                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" CssClass="botonImportante" Width="45%" style="margin-right: 10px" />                    
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="botonImportante" Width="45%" ValidationGroup="formGroup" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

