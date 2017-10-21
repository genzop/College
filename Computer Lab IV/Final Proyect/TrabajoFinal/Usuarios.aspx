<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Usuarios</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 0px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Usuarios" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
    </div>
    <br />

    <form runat="server">

        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Buscador -->
                <div style="width: 400px; margin: 0 auto">
                    <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." Style="margin-left: 10px" />
                    <asp:ImageButton ID="imgFind" runat="server" ImageUrl="~/img/find.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgFind_Click" CausesValidation="false" />
                    <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgAdd_Click" CausesValidation="false" />
                </div>
                <br />

                <asp:TextBox ID="txtError" runat="server" Text="ERROR: El usuario buscado no existe" Visible="false" />

                <!-- Formulario Usuario -->
                <div id="formUsuario" runat="server" class="create-page" style="padding-top: 0" visible="false">
                    <div class="create-form" style="padding-bottom: 30px">

                        <asp:HiddenField ID="hdnID" runat="server" />

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Nombre</p>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="inputCentrado" />
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Apellido</p>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="inputCentrado" />
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Nombre de usuario</p>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="inputCentrado" CausesValidation="true" />                            
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                                                                                    
                            <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtUsuario" ValidationExpression="^[\w]{0,8}" ErrorMessage="* El nombre de usuario puede contener hasta un máximo de 12 caracteres alfanuméricos" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                            
                            <asp:CustomValidator ID="cvUsuarioUnico" runat="server" OnServerValidate="cvUsuarioUnico_ServerValidate" ErrorMessage="* El nombre de usuario ya esta en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />                                                                                    
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Contraseña</p>
                            <asp:TextBox ID="txtContrasenia" runat="server" CssClass="inputCentrado" />
                            <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revContrasenia" runat="server" ControlToValidate="txtContrasenia" ValidationExpression="^[\w]{1,12}" ErrorMessage="* La contraseña puede contener hasta un máximo de 12 caracteres alfanuméricos" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>

                        <div class="editContent">
                            <p class="editContentTitle" style="font-weight: bold">Confirmar contraseña</p>
                            <asp:TextBox ID="txtConfirmarContrasenia" runat="server" CssClass="inputCentrado" />
                            <asp:RequiredFieldValidator ID="rfvConfirmarContrasenia" runat="server" ControlToValidate="txtConfirmarContrasenia" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:CompareValidator ID="cvContrasenias" runat="server" ControlToValidate="txtConfirmarContrasenia" ControlToCompare="txtContrasenia" ErrorMessage="* Las contraseñas no coinciden" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>

                        <asp:Table runat="server" Width="100%" CellSpacing="10">
                            <asp:TableRow>
                                <asp:TableCell Width="50%">
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botonImportante" OnClick="btnCancelar_Click" CausesValidation="false" />
                                </asp:TableCell>
                                <asp:TableCell Width="50%">
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="botonImportante" OnClick="btnGuardar_Click" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </form>

</asp:Content>

