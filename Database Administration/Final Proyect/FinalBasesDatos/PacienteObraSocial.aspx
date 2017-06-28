<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="PacienteObraSocial.aspx.cs" Inherits="PacienteObraSocial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />

    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" CssClass="titulo"/>
    </div><br /><br />

    <!-- Formulario -->
    <div class="formularioTom">   
         
        <b>Paciente:</b> <asp:Label ID="lblPaciente" runat="server" /><br /><br /><br />
        
          <asp:GridView ID="grdPlanPaciente" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_PacientePlan" DataSourceID="SqlDataSource2" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="700px" style="margin: 0 auto" BackColor="White">
            <Columns>                                                
                <asp:BoundField DataField="Nombre" HeaderText="Obra Social" SortExpression="Nombre" />
                <asp:BoundField DataField="Denominacion" HeaderText="Plan" SortExpression="Denominacion" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" SortExpression="FechaInicio" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" SortExpression="FechaFin" DataFormatString="{0:d}" />
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

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT PacientePlan.ID_PacientePlan, ObraSocial.Nombre, [Plan].Denominacion, PacientePlan.Estado, PacientePlan.FechaInicio, PacientePlan.FechaFin       
                    FROM ((PacientePlan 
                    INNER JOIN [Plan] on [Plan].ID_Plan = PacientePlan.ID_Plan)
                    INNER JOIN ObraSocial on ObraSocial.ID_ObraSocial = [Plan].ID_ObraSocial)                    
                    WHERE (PacientePlan.ID_Paciente = @ID_Paciente)
                    ORDER BY PacientePlan.FechaFin DESC">
            <SelectParameters>
                <asp:QueryStringParameter Name="ID_Paciente" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>


        <br /><br />
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnNuevoPlan" runat="server" Text="Nuevo Plan" OnClick="btnNuevoPlan_Click" CssClass="colorButton"/>
            </div>
        </div>
        <br /><br />
        <div class="row">
            <div class="col-md-3" id="newObraSocial" runat="server">
                <span class="tituloInput">Obra Social</span><br />
                <asp:DropDownList ID="ddlObraSocial" runat="server" CssClass="input" Width="100%" Height="40px" DataSourceID="SqlDataSource" DataTextField="Nombre" DataValueField="ID_ObraSocial"/>                
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [ObraSocial] WHERE ([Habilitado] = @Habilitado)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-md-3" id="newPlan" runat="server">
                <span class="tituloInput">Plan</span><br />
                <asp:DropDownList ID="ddlPlan" runat="server" CssClass="input" Width="100%" Height="40px" DataSourceID="SqlDataSource1" DataTextField="Denominacion" DataValueField="ID_Plan"/>                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Plan] WHERE ([Habilitado] = @Habilitado)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-md-3" id="fechaInicio" runat="server">
                <span class="tituloInput">Fecha de Inicio</span><br />
                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="input" />
            </div>
            <div class="col-md-3" id="fechaFin" runat="server">
                <span class="tituloInput">Fecha de Fin</span><br />
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="input" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8"></div>            
            <div class="col-md-4">
                <div style="text-align: center">     
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="colorButton" />               
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
                </div>
            </div>
        </div>

        <br /><br />

      
    </div><br /><br /><br /><br />


</asp:Content>

