<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rmASP.aspx.cs" Inherits="ParcialLab4PanettieriGino" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="tabla" BorderWidth="1px" Font-Names="Verdana" Font-Size="12" runat="server">
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px" Width="200px">Apellido</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:TextBox ID="apellido" Text="" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Nombre</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:TextBox ID="nombre" Text="" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Sexo</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:RadioButtonList ID="sexo" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Nacionalidad</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:DropDownList ID="nacionalidad" runat="server">
                        <asp:ListItem Value="Argentina">Argentina</asp:ListItem>
                        <asp:ListItem Value="Mexico">Mexico</asp:ListItem>
                        <asp:ListItem Value="Francia">Francia</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Bloqueado</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:CheckBox ID="bloqueado" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Edad</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:TextBox ID="edad" Text="" runat="server"/>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="1px">Antecedentes</asp:TableCell>
                <asp:TableCell BorderWidth="1px" Width="400px">
                    <asp:TextBox ID="antecedentes" Text="" TextMode="MultiLine" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="boton" Text="Enviar" OnClick="boton_Click" runat="server"/>
                </asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
    </form>
    <asp:Table ID="tabla2" BorderWidth="1px" Font-Names="Verdana" Font-Size="12" runat="server">
            <asp:TableRow>
                <asp:TableCell ID="apellidoIngresado" BorderWidth="1px" Width="600px" runat="server">Apellido: </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="nombreIngresado" BorderWidth="1px" Width="600px" runat="server">Nombre: </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow>
                <asp:TableCell ID="sexoIngresado" BorderWidth="1px" Width="600px" runat="server">Sexo: </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow>
                <asp:TableCell ID="nacionalidadIngresado" BorderWidth="1px" Width="600px" runat="server">Nacionalidad: </asp:TableCell>
            </asp:TableRow>
          <asp:TableRow>
                <asp:TableCell ID="bloqueadoIngresado" BorderWidth="1px" Width="600px" runat="server">Bloqueado: </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell ID="edadIngresado" name="edadIngresado" BorderWidth="1px" Width="600px" runat="server">Edad: </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="antecedentesIngresado" BorderWidth="1px" Width="600px" runat="server">Antecedentes: </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</body>
</html>
