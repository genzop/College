<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="Facturacion.aspx.cs" Inherits="Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Facturacion</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />
        
    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Facturacion" CssClass="titulo"/>
    </div><br /><br />

    <!-- Buscador -->
    <div style="width: 700px; margin: 0 auto" >      
        <asp:DropDownList ID="ddlBuscar" runat="server" Height="30px"  style="padding-left: 5px">
            <asp:ListItem Value="Paciente.Nombre + ' ' + Paciente.Apellido" Text="Paciente" />    
            <asp:ListItem Value="Factura.Tipo" Text="Tipo" />    
            <asp:ListItem Value="Factura.Fecha" Text="Fecha" />    
            <asp:ListItem Value="Factura.Estado" Text="Estado" />          
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" style="padding-left: 10px"/>       
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" style="margin-right: 20px"/><br /><br />
    </div>

    <!-- Tabla -->
    <div>
        <asp:GridView ID="grdFacturas" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_Factura" DataSourceID="SqlDataSource1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="700px" style="margin: 0 auto" BackColor="White">
            <Columns>
                <asp:BoundField DataField="ID_Factura" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_Factura" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" ReadOnly="True" SortExpression="Paciente" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_Factura") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar a esta factura?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_Factura") %>' ImageAlign="Left" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT Factura.ID_Factura, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Factura.Tipo, Factura.Fecha, Factura.Estado, Factura.Total FROM Factura INNER JOIN Paciente ON Factura.ID_Paciente = Paciente.ID_Paciente WHERE Factura.Habilitado = 'true'"></asp:SqlDataSource>
    </div>

</asp:Content>