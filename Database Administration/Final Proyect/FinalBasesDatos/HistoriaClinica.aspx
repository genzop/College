<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="HistoriaClinica.aspx.cs" Inherits="HistoriaClinica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Historía Clínica</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />


    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Historia Clínica" CssClass="titulo"/>
    </div><br /><br />

    <div class="formularioTom">        

        <div id="historiaID" runat="server"></div>
        
        
        <div class="row">
            <div class="col-md-3">
                <div class="campoFormulario">
                <span class="tituloInput">Grupo Sanguineo</span><br />
                <asp:dropdownlist ID="txtGrupoSanguineo" runat="server" CssClass="input">                    
                    <asp:listitem Text="" Value=""></asp:listitem>
                    <asp:listitem Text="A+" Value="A+" /> 
                    <asp:listitem Text="A-" Value="A-" /> 
                    <asp:listitem Text="B+" Value="B+" /> 
                    <asp:listitem Text="B-" Value="B-" />                    
                    <asp:listitem Text="AB+" Value="AB+" />                                        
                    <asp:listitem Text="AB-" Value="AB-" />                                        
                    <asp:listitem Text="O+" value="O+" />                                        
                    <asp:listitem Text="O-" value="O-" />                                        
                </asp:dropdownlist>               
                <asp:RequiredFieldValidator ID="rfvGrupoSanguineo" runat="server" ControlToValidate="txtGrupoSanguineo" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />        
                </div>        
            </div>
            <div class="col-md-3">
                <div class="campoFormulario">
                    <span class="tituloInput">Antecedentes Familiares</span><br />
                    <asp:TextBox ID="txtAntecedentes" runat="server" CssClass="input" />            
                    <asp:RequiredFieldValidator ID="rfvAntecedentes" runat="server" ControlToValidate="txtAntecedentes" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                </div>  
            </div>
            <div class="col-md-3">
                <div class="campoFormulario">
                    <span class="tituloInput">Alergias</span><br />
                    <asp:TextBox ID="txtAlergias" runat="server" CssClass="input"/>            
                    <asp:RequiredFieldValidator ID="rfvAlergias" runat="server" ControlToValidate="txtAlergias" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                </div>  
            </div>
            <div class="col-md-3">
                <div class="campoFormulario">
                    <span class="tituloInput">Enfermedades</span><br />
                    <asp:TextBox ID="txtEnfermedades" runat="server" CssClass="input"/>            
                    <asp:RequiredFieldValidator ID="rfvEnfermedades" runat="server" ControlToValidate="txtEnfermedades" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                </div>  
            </div>
        </div>                
            
        <br />
            <asp:Button ID="btnNuevaConsulta" runat="server" OnCommand="btnNuevaConsulta_Command" Text="Nueva Consulta" CssClass="colorButton" CommandArgument='<%# Eval("ID_HistoriaClinica") %>'/>


        <br />
            
        <br />

        <asp:GridView ID="grdDetalleHistoriaClinica" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_ConsultaHistoriaClinica" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" 
            GridLines="Horizontal" Width="700px" style="margin: 0 auto" BackColor="White" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID_ConsultaHistoriaClinica" HeaderText="Consulta N°" InsertVisible="False" ReadOnly="True" SortExpression="ID_ConsultaHistoriaClinica" />
                <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />
                <asp:BoundField DataField="Altura" HeaderText="Altura" SortExpression="Altura" />
                <asp:BoundField DataField="Sintomas" HeaderText="Sintomas" SortExpression="Sintomas" />
                <asp:BoundField DataField="DiagnosticoPresunto" HeaderText="Diagnostico Presunto" SortExpression="DiagnosticoPresunto" />
                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" SortExpression="Tratamiento" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:Button ID="btnVerConsulta" runat="server" Text="Ver Consulta" OnCommand="btnVerConsulta_Command" CommandArgument='<%# Eval("ID_ConsultaHistoriaClinica") %>'/>                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Font-Size="14px" />
            <RowStyle HorizontalAlign="Center" Font-Size="14px" />
            <PagerStyle BackColor="#D8D8D8" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [ConsultaHistoriaClinica] WHERE ([ID_HistoriaClinica] = @ID_HistoriaClinica)">
            <SelectParameters>
                <asp:QueryStringParameter Name="ID_HistoriaClinica" QueryStringField="historia" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />                
        <br />                

        <div style="text-align: center">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
        </div>
    </div>


</asp:Content>

