<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Componentes.aspx.cs" Inherits="Componentes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="componentes" BorderStyle="Outset" BorderWidth="2px" Font-Names="Arial" runat="server">
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset" Width="250px"></asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset" Width="400px" Font-Bold="true">COMPONENTES</asp:TableCell> 
            </asp:TableRow> 
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Caja de Texto</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:TextBox ID="cajaTexto" Text="" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Combo</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:DropDownList ID="combo" runat="server">
                        <asp:ListItem Value="Argentina">Argentina</asp:ListItem>
                        <asp:ListItem Value="Italia">Italia</asp:ListItem>
                        <asp:ListItem Value="Alemania">Alemania</asp:ListItem>
                        <asp:ListItem Value="Portugal">Portugal</asp:ListItem>
                    </asp:DropDownList>       
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Imagen</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:Image ID="imagen" ImageUrl="https://www.google.com.ar/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png" Height="50px" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">CheckBox</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:CheckBoxList ID="checkBoxList" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem>SI</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:CheckBoxList> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Hipervinculo</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:HyperLink ID="hipervinculo" NavigateUrl="http://www.google.com.ar/" Text="Google" Target="_blank" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Radio Button</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:RadioButtonList ID="radioButton" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem>Alta</asp:ListItem>
                        <asp:ListItem>Media</asp:ListItem>
                        <asp:ListItem>Baja</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Campo Oculto</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:HiddenField ID="campoOculto" Value="Esto no se ve" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">Boton</asp:TableCell>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset">
                    <asp:Button ID="boton" Text="Button" OnClick="boton_Click" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>            
        </asp:Table><br/>   

        <asp:Table ID="datosIngresados" BorderStyle="Outset" BorderWidth="2px" Font-Names="Arial" Font-Bold="true" runat="server">
            <asp:TableRow>
                <asp:TableCell BorderWidth="2px" BorderStyle="Inset" Width="660px" Text="Datos Ingresados"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="cajaTextoIngresada" BorderWidth="2px" BorderStyle="Inset" Text="Caja de Texto:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="comboIngresado" BorderWidth="2px" BorderStyle="Inset" Text="Combo:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="imagenIngresada" BorderWidth="2px" BorderStyle="Inset" Text="Imagen:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="checkBoxIngresado" BorderWidth="2px" BorderStyle="Inset" Text="CheckBox:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="hiperviculoIngresado" BorderWidth="2px" BorderStyle="Inset" Text="Hipervinculo:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="radioButtonIngresado" BorderWidth="2px" BorderStyle="Inset" Text="Radio Button:" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="campoOcultoIngresado" BorderWidth="2px" BorderStyle="Inset" Text="Campo Oculto:" runat="server"></asp:TableCell>
            </asp:TableRow>            
        </asp:Table>

    </form>
</body>
</html>
