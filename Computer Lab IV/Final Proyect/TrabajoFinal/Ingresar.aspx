<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ingresar.aspx.cs" Inherits="Ingresar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trabajo Final</title>
    <link href="css/estilos.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="/img/icon.png" />
</head>
<body>
    <div class="login-page">
        <div class="form">
            <!-- Formulario de LogIn --> 
            <form class="login-form" runat="server">                
                <asp:Image ID="imgUtnLogo" runat="server" ImageUrl="~/img/logo-utn.png" />

                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" />      
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="* Es necesario ingresar un usuario" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         
                <asp:CustomValidator ID="cvUsuario" runat="server" OnServerValidate="cvUsuario_ServerValidate" ErrorMessage="* El usuario ingresado no existe" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         

                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" placeholder="Contraseña" />
                <asp:CustomValidator ID="cvContrasenia" runat="server" OnServerValidate="cvContrasenia_ServerValidate" ErrorMessage="* Contraseña incorrecta" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/><br /><br />

                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="botonImportante"/>

                <p class="message">¿No estás registrado? <a href="Registrar.aspx">Crear una cuenta</a></p>
            </form>
        </div>
    </div>
</body>
</html>