<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Controles.aspx.cs" Inherits="Controles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="border: 2px outset; font-family:Arial">
            <tr>
                <td style="border: 2px inset; width:250px"></td>
                <td style="border: 2px inset; width:400px; font-weight: bold">COMPONENTES</td>
            </tr>
            <tr>
                <td style="border: 2px inset">Caja de Texto</td>
                <td style="border: 2px inset">
                    <input type="text" id="cajaTexto" name="cajaTexto" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Combo</td>
                <td style="border: 2px inset">
                    <select id="combo" name="combo" runat="server">
                        <option value="Argentina">Argentina</option>
                        <option value="Italia">Italia</option>
                        <option value="Alemania">Alemania</option>
                        <option value="Portugal">Portugal</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Imagen</td>
                <td style="border: 2px inset">
                    <img src="https://www.google.com.ar/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png" id="imagen" style="height:50px" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">CheckBox</td>
                <td style="border: 2px inset">
                    <input type="checkbox" id="checkboxSi" name="checkboxSi" value="Si"  runat="server"/>SI
                    <input type="checkbox" id="checkboxNo" name="checkboxNo" value="No"  runat="server"/>NO
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Hipervinculo</td>
                <td style="border: 2px inset">
                    <a href="http://www.google.com.ar" id="hipervinculo" runat="server">Google</a>
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Radio Button</td>
                <td style="border: 2px inset">
                    <input type="radio" id="radio1" name="radio" value="Alta" runat="server"/>Alta
                    <input type="radio" id="radio2" name="radio" value="Media" runat="server"/>Media
                    <input type="radio" id="radio3" name="radio" value="Baja" runat="server"/>Baja
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Campo Oculto</td>
                <td style="border: 2px inset">
                    <input type="hidden" id="hidden" name="hidden" value="Este texto no se ve" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="border: 2px inset">Boton</td>
                <td style="border: 2px inset">
                    <button id="button" onserverclick="botonClick" runat="server">
                        Button
                    </button>
                </td>
            </tr>
        </table><br/>      
        <table style="border: 2px outset; font-family:Arial; font-weight:bold">
            <tr>
                <td style="border: 2px inset; width:660px" runat="server">
                    Datos Ingresados
                </td>                
            </tr>
            <tr>
                <td id="cajaTextoIngresada" style="border: 2px inset; width:650px" runat="server">
                    Caja de Texto:
                </td>                
            </tr>
            <tr>
                <td id="comboIngresado" style="border: 2px inset; width:650px" runat="server">
                    Combo:
                </td>                
            </tr>
            <tr>
                <td id="imagenIngresada" style="border: 2px inset; width:650px" runat="server">
                    Imagen:
                </td>                
            </tr>
            <tr>
                <td  id="checkboxIngresado" style="border: 2px inset; width:650px" runat="server">
                    Checkbox:
                </td>                
            </tr>
            <tr>
                <td id="hipervinculoIngresado" style="border: 2px inset; width:650px" runat="server">
                    Hipervinculo:
                </td>                
            </tr>
            <tr>
                <td id="radioButtonIngresado" style="border: 2px inset; width:650px" runat="server">
                    Radio Button:
                </td>                
            </tr>
            <tr>
                <td id="campoOcultoIngresado" style="border: 2px inset; width:650px" runat="server">
                    Campo Oculto:
                </td>                
            </tr>         
        </table>

    </form>
</body>
</html>
