<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="PacienteEditar.aspx.cs" Inherits="PacienteEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Editar Paciente</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />

    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" CssClass="titulo"/>
    </div><br /><br />

    <!-- Formulario -->
    <div class="formularioTom">        

        <div class="row">        
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Nombre</span><br />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input" />    
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />        
            </div>        
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Apellido</span><br />
                <asp:TextBox ID="txtApellido" runat="server" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Sexo</span><br />
                <asp:dropdownlist ID="txtSexo" runat="server" CssClass="input">                    
                    <asp:listitem value =""></asp:listitem > 
                    <asp:listitem value ="M">Masculino</asp:listitem >                    
                    <asp:listitem value ="F">Femenino</asp:listitem >                                        
                </asp:dropdownlist>                 
                <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="txtSexo" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>          
        </div>

        <div class="row">
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">DNI</span><br />
                <asp:TextBox ID="txtDNI" runat="server" CssClass="input" MaxLength="8"/>            
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Fecha de Nacimiento</span><br />
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="input" />
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" ValidationGroup="Factura" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Estado Civil</span><br />
                <asp:dropdownlist ID="txtEstadoCivil" runat="server" CssClass="input">                    
                    <asp:listitem value =""></asp:listitem > 
                    <asp:listitem value ="S">Soltero</asp:listitem > 
                    <asp:listitem value ="C">Casado</asp:listitem > 
                    <asp:listitem value ="V">Viudo</asp:listitem >                    
                    <asp:listitem value ="D">Divorciado</asp:listitem >                                        
                </asp:dropdownlist>                            
                <asp:RequiredFieldValidator ID="rfvEstadoCivil" runat="server" ControlToValidate="txtEstadoCivil" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
        </div>

        <div class="row">
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Domicilio</span><br />
                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvDomicilio" runat="server" ControlToValidate="txtDomicilio" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Localidad</span><br />
                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Teléfono</span><br />
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="input" MaxLength="10" />            
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>  
        </div>

        <div class="row">
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Email</span><br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input"/>                            
            </div>  
            <div class="campoFormulario col-md-4">
                <span class="tituloInput">Ocupación</span><br />
                <asp:TextBox ID="txtOcupacion" runat="server" CssClass="input" />            
                <asp:RequiredFieldValidator ID="rfvOcupacion" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
            </div>                          
        </div>
        <br /><br />
        <div style="text-align: center">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
        </div>
    </div>

</asp:Content>

