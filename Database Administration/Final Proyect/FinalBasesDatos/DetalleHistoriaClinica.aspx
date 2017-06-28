<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="DetalleHistoriaClinica.aspx.cs" Inherits="DetalleHistoriaClinica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />

    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Detalle de la Historia Clínica" CssClass="titulo"/>
    </div><br /><br />

    <!-- Formulario -->
    <div class="formularioTom">        

        <div class="row"> 
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Altura</span><br />
                <asp:TextBox ID="txtAltura" runat="server" CssClass="input" MaxLength="4" />                    
            </div>        
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Peso</span><br />
                <asp:TextBox ID="txtPeso" runat="server" CssClass="input" MaxLength="7" />                    
            </div>               
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Sintomas</span><br />
                <asp:TextBox ID="txtSintomas" runat="server" TextMode="MultiLine" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvSintomas" runat="server" ControlToValidate="txtSintomas" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>          
        </div>

        <div class="row">
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Diagnostico Presunto</span><br />
                <asp:TextBox ID="txtDiagnostico" runat="server" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvDiagnostico" runat="server" ControlToValidate="txtDiagnostico" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Pedido de Estudios</span><br />
                <asp:TextBox ID="txtPedidos" runat="server" TextMode="MultiLine" CssClass="input" />
                <asp:RequiredFieldValidator ID="rfvPedidos" runat="server" ControlToValidate="txtPedidos" ValidationGroup="Factura" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Derivaciones</span><br />
                <asp:TextBox ID="txtDerivaciones" runat="server" TextMode="MultiLine" CssClass="input" />                            
            </div>  
        </div>

        <div class="row">            
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Tratamiento</span><br />
                <asp:TextBox ID="txtTratamiento" runat="server" TextMode="MultiLine" CssClass="input" />                            
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Recetas</span><br />
                <asp:TextBox ID="txtReceta" runat="server" TextMode="MultiLine" CssClass="input" />                            
            </div>
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Próximo Control</span><br />
                <asp:TextBox ID="txtControl" runat="server" TextMode="Date" CssClass="input" />                        
            </div>                 
        </div>
        <div class="row">
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Alta</span><br />
                <asp:CheckBox ID="cbAlta" runat="server" />
            </div>  
        </div>


        <br/><br />


        <div style="text-align: center">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
        </div>
    
    </div>

</asp:Content>
