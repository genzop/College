<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="Servicios.aspx.cs" Inherits="Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Servicios</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server"><br /><br />
         
    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Servicios" CssClass="titulo"/>
    </div><br /><br />
    
    <!-- Barra Buscar y Agregar -->
    <div style="width: 500px; margin: 0 auto" >   
        <asp:DropDownList ID="ddlBuscar" runat="server" Height="30px"  style="padding-left: 5px">
            <asp:ListItem Value="Denominacion" Text="Denominacion" />
            <asp:ListItem Value="Precio" Text="Precio" />
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" style="padding-left: 10px"/>     
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" style="margin-right: 20px"/><br /><br />
    </div>
    
    <!-- Tabla -->
    <div>
        <asp:GridView ID="grdServicios" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"             
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal"
            Width="500px" DataKeyNames="ID_Servicio" DataSourceID="SqlDataSource1" style="margin: 0 auto" BackColor="White"  >
            <Columns>             
                <asp:BoundField DataField="ID_Servicio" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_Servicio" />
                <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" SortExpression="Denominacion" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_Servicio") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este servicio?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_Servicio") %>' ImageAlign="Left" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Servicio] WHERE ([Habilitado] = @Habilitado)">
            <SelectParameters>
                <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>


</asp:Content>

