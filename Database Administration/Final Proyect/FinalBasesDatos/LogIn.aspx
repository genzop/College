<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LogIn</title>
    <link href="css/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogIn" runat="server" style="margin-top: 100px"><br />
        <div class="formulario">

            <!-- Logo UTN -->
            <div>
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/logo-utn.png"  Width="250px"/>
            </div>

            <!-- Usuario -->
            <div class="campoFormulario">                
                <span class="tituloInput">Usuario</span>               
                <asp:TextBox ID="txtUsuario" runat="server" class="input"/><br />
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                <asp:CustomValidator ID="cstvUsuario" runat="server" OnServerValidate="cstvUsuario_ServerValidate" ErrorMessage="* El usuario no existe" Display="Dynamic" CssClass="validacion" />
            </div>

            <!-- Contraseña -->
            <div class="campoFormulario">
                <span class="tituloInput">Contraseña</span>
                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" CssClass="input"/><br />
                <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                <asp:CustomValidator ID="cstvContrasenia" runat="server" OnServerValidate="cstvContrasenia_ServerValidate" ErrorMessage="* La contraseña no es correcta" Display="Dynamic" CssClass="validacion" />
            </div>

            <div style="text-align: center">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="colorButton"/><br /><br />
                <asp:HyperLink ID="hlRegistrar" runat="server" Text="Registrarse" NavigateUrl="~/Registrar.aspx" CssClass="link"/>
            </div>
        </div>
    </form>
</body>
</html>
