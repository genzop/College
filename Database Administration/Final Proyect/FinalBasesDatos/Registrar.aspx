<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar</title>
    <link href="css/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="formRegistrar" runat="server" style="padding-top: 50px">
        <div class="formulario">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/logo-utn.png"  Width="200px"/><br />         
                
            <!-- Tipo de Usuario -->  
            <div class="campoFormulario">         
                <span class="tituloInput">Tipo de Usuario</span>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" CssClass="input" Width="100%" Height="40px" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="Denominacion" DataValueField="ID_TipoUsuario"/>                
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [TipoUsuario] WHERE ([Habilitado] = @Habilitado)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>

            <!-- Medico -->
            <div class="campoFormulario" id="campoMedico" runat="server" visible="false">                              
                <span class="tituloInput">Medico</span>
                <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="True" CssClass="input" Width="100%" Height="40px" DataSourceID="SqlDataSource1" DataTextField="NombreCompleto" DataValueField="ID_Medico"/>                             
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT ID_Medico, Nombre + ' ' + Apellido AS NombreCompleto FROM Medico "></asp:SqlDataSource>                             
            </div>

            <!-- Nombre de usuario -->
            <div class="campoFormulario">                
                <span class="tituloInput">Usuario</span>        
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="input"/><br />
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />                
                <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtUsuario" ValidationExpression="\b[A-Za-z]{1,20}\b" ErrorMessage="* El usuario puede contener hasta 20 caracteres alfabeticos" Display="Dynamic" CssClass="validacion" />                
                <asp:CustomValidator ID="cvUsuario" runat="server" OnServerValidate="cvUsuario_ServerValidate" ErrorMessage="* El nombre de usuario ya esta en uso" Display="Dynamic" CssClass="validacion" />                
            </div>

            <!-- Contraseña -->
            <div class="campoFormulario">                
                <span class="tituloInput">Contraseña</span>              
                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" CssClass="input"/><br />
                <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />                
                <asp:RegularExpressionValidator ID="revContrasenia" runat="server" ControlToValidate="txtContrasenia" ValidationExpression="\b\w{1,20}\b" ErrorMessage="* La contraseña puede contener hasta 20 caracteres alfanumericos" Display="Dynamic" CssClass="validacion" />                
            </div>

            <!-- Confirmar contraseña -->
            <div class="campoFormulario">                
                <span class="tituloInput">Confirmar contraseña</span> 
                <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" CssClass="input"/><br />
                <asp:RequiredFieldValidator ID="rfvConfirmar" runat="server" ControlToValidate="txtConfirmar" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />                
                <asp:CompareValidator ID="cvConfirmar" runat="server" ControlToValidate="txtConfirmar" ControlToCompare="txtContrasenia" Operator="Equal" ErrorMessage="* Las contraseñas no coinciden" Display="Dynamic" CssClass="validacion" />     
            </div>

            <div>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" CssClass="colorButton"/><br /><br />
                <asp:HyperLink ID="hlIngresar" runat="server" Text="Ingresar" NavigateUrl="~/LogIn.aspx" CssClass="link"/>
            </div>
        </div>
    </form>
    <br /><br />
</body>
</html>
