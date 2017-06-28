<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="ObrasSociales.aspx.cs" Inherits="ObrasSociales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Obra Social</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br /><br />

    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Obras Sociales" CssClass="titulo"/>
    </div><br /><br />

    <!-- Agregar -->
    <div style="width: 800px; margin: 0 auto" >  
        <asp:DropDownList ID="ddlBuscar" runat="server" Height="30px"  style="padding-left: 5px">
            <asp:ListItem Value="Nombre" Text="Nombre" /> 
            <asp:ListItem Value="Direccion" Text="Direccion" />            
            <asp:ListItem Value="Localidad" Text="Localidad" />         
            <asp:ListItem Value="Telefono" Text="Telefono" />         
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" style="padding-left: 10px"/>             
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" style="margin-right: 20px"/><br /><br />
    </div>

    <div>
        <asp:GridView ID="grdObraSocial" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="ID_ObraSocial" DataSourceID="SqlDataSource1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="800px" style="margin: 0 auto" BackColor="White"     >
            <Columns>
                <asp:BoundField DataField="ID_ObraSocial" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_ObraSocial" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_ObraSocial") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este servicio?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_ObraSocial") %>' ImageAlign="Left" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Font-Size="14px"/>
            <RowStyle HorizontalAlign="Center" Font-Size="14px"/>
            <PagerStyle BackColor="#D8D8D8" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [ObraSocial] WHERE ([Habilitado] = @Habilitado)">
            <SelectParameters>
                <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>


