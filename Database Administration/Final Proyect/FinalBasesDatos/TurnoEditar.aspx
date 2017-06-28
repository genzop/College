<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="TurnoEditar.aspx.cs" Inherits="TurnoEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <title>Gestionar Turno</title>
    <style type="text/css">
        .auto-style1 {
            padding: 8px;
            margin-top: 5px;
        }

        .auto-style2 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <br /><br /><br />

    <!-- Formulario -->
    <div class="formulario" style="width: 350px">

        <asp:Label ID="lblTitulo" runat="server" CssClass="subtitulo" /><br />
        <br />

        <div class="campoFormulario">
            <span class="tituloInput">Fecha/Hora</span><br />
            <asp:TextBox ID="txtFechaHora" runat="server" Placeholder="yyyy-MM-dd HH:mm:ss" CssClass="auto-style1" Width="100%" />
            <asp:RegularExpressionValidator ValidationExpression="^\d{4}[-/.]\d{1,2}[-/.]\d{1,2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d$"
                ID="revFechaHora" runat="server" ControlToValidate="txtFechaHora" ErrorMessage="* Ingrese una fecha y hora valida (yyyy-MM-dd HH:mm:ss)" Display="Dynamic" CssClass="validacion"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvFechaHora" runat="server" ControlToValidate="txtFechaHora" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
        </div>

        <div class="campoFormulario">
            <span class="tituloInput">Estado</span><br />
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="auto-style1" Width="100%">
                <asp:ListItem Value="">Seleccione una opcion</asp:ListItem>
                <asp:ListItem Value="Reservado">Reservado</asp:ListItem>
                <asp:ListItem Value="Presente">Presente</asp:ListItem>
                <asp:ListItem Value="En curso">En curso</asp:ListItem>
                <asp:ListItem Value="Atendido">Atendido</asp:ListItem>
                <asp:ListItem Value="Cancelado">Cancelado</asp:ListItem>
                <asp:ListItem Value="Suspendido">Suspendido</asp:ListItem>
                <asp:ListItem Value="Ausente"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
        </div>

        <div class="campoFormulario">
            <span class="tituloInput">Paciente</span><br />
            <asp:DropDownList ID="ddlPaciente" runat="server" DataSourceID="SqlDataSource2" DataTextField="NombreCompleto" DataValueField="ID_Paciente" CssClass="input" Width="100%"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT ID_Paciente, Nombre + ' ' + Apellido AS NombreCompleto FROM Paciente"></asp:SqlDataSource>
        </div>

        <div class="campoFormulario">
            <span class="tituloInput">Medico</span><br />
            <asp:DropDownList ID="ddlMedico" runat="server" DataSourceID="SqlDataSource3" DataTextField="NombreCompleto" DataValueField="ID_Medico" CssClass="input" Width="100%"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT ID_Medico, Nombre + ' ' + Apellido AS NombreCompleto FROM Medico"></asp:SqlDataSource>
        </div>

        <div style="text-align: center">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
        </div>
    </div>
</asp:Content>

