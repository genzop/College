<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trabajo Final</title>
    <link href="css/estilos.css" rel="stylesheet" />
</head>
<body>
    <div class="signUp-page">
        <div class="form">

            <!-- Formulario Registracion -->
            <form class="register-form" runat="server">
                <asp:Image ID="imgUtnLogo" runat="server" ImageUrl="~/img/logo-utn.png" />

                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" />   
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*No puedes dejar este campo en blanco." Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         

                <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" />   
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="*No puedes dejar este campo en blanco." Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>         

                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" CausesValidation="true"/>              
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*No puedes dejar este campo en blanco." Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>          
                <asp:CustomValidator ID="cvUsuario" runat="server" OnServerValidate="cvUsuario_ServerValidate" ErrorMessage="*Ese nombre de usuario ya está en uso" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>          
                <asp:RegularExpressionValidator ID="revUsuario" runat="server" ControlToValidate="txtUsuario" ValidationExpression="^[\w]{0,8}" ErrorMessage="* El nombre de usuario puede contener hasta un máximo de 12 caracteres alfanuméricos" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>   

                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" placeholder="Contraseña" />
                <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="*No puedes dejar este campo en blanco." Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                          
                <asp:RegularExpressionValidator ID="revContrasenia" runat="server" ControlToValidate="txtContrasenia" ValidationExpression="^[\w]{1,12}" ErrorMessage="* La contraseña puede contener hasta un máximo de 12 caracteres alfanuméricos" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>   

                <asp:TextBox ID="txtConfirmarContrasenia" runat="server" TextMode="Password" placeholder="Confirmar contraseña" />
                <asp:RequiredFieldValidator ID="rfvConfirmarContrasenia" runat="server" ControlToValidate="txtConfirmarContrasenia" ErrorMessage="*No puedes dejar este campo en blanco." Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>          
                <asp:CompareValidator ID="cvContrasenias" runat="server" ControlToValidate="txtConfirmarContrasenia" ControlToCompare="txtContrasenia" ErrorMessage="*Las contraseñas no coinciden" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>          

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" CssClass="botonImportante" style="margin-top: 20px"/>
                <p class="message">¿Ya tenes una cuenta? <a href="Ingresar.aspx">Ingresa</a></p>
            </form>
        </div>
    </div>
</body>
</html>