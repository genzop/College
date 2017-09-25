<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Articulos.aspx.cs" Inherits="Articulos" %>

<%@ MasterType VirtualPath="~/Navegacion.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Articulos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 20px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Artículos" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
    </div>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Buscador -->
        <div style="width: 900px; margin: 0 auto">
            <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                <asp:ListItem Text="Codigo" Value="Articulo.Codigo" />
                <asp:ListItem Text="Denominacion" Value="Articulo.Denominacion" />
                <asp:ListItem Text="Rubro" Value="Rubro.Denominacion" />
                <asp:ListItem Text="Precio de compra" Value="Articulo.PrecioCompra" />
                <asp:ListItem Text="Iva" Value="Articulo.Iva" />
                <asp:ListItem Text="Precio de venta" Value="Articulo.PrecioVenta" />
            </asp:DropDownList>
            <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." Style="padding-left: 10px" />
            <asp:ImageButton ID="imgFind" runat="server" ImageUrl="~/img/find.png" Width="20" ImageAlign="AbsMiddle" Style="padding-left: 10px" OnClick="imgFind_Click" />
            <asp:ImageButton ID="imgPDF" runat="server" ImageUrl="~/img/pdf.png" Width="20px" ImageAlign="AbsMiddle" Style="padding-left: 10px" OnClick="imgPDF_Click" />
            <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20" ImageAlign="AbsMiddle" Style="padding-left: 10px" OnClick="imgAdd_Click" />

        </div>
        <br />

        <!-- Tabla Articulos -->
        <asp:GridView ID="grdArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdArticulo" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="6" ForeColor="#333333" GridLines="None" Font-Size="14px" Style="margin: 0 auto; text-align: center; width: 900px">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" ItemStyle-Height="22px" />
                <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" SortExpression="Denominacion" />
                <asp:BoundField DataField="Denominacion1" HeaderText="Rubro" SortExpression="Denominacion1" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio de Compra" SortExpression="PrecioCompra" DataFormatString="{0:C}" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Iva" HeaderText="Iva" SortExpression="Iva" DataFormatString="{0:p}" ItemStyle-Width="60px" />
                <asp:BoundField DataField="PrecioVenta" HeaderText="Precio de Venta" SortExpression="PrecioVenta" DataFormatString="{0:C}" ItemStyle-Width="150px" />
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdArticulo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este articulo?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdArticulo") %>' ImageAlign="Left" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" Font-Size="15px" Height="40px" />
            <PagerStyle BackColor="#17252a" ForeColor="White" HorizontalAlign="Center" Font-Bold="true" />
            <RowStyle BackColor="#FFFFFF" Font-Bold="true" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#66C2BE" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#2b7a78" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT Articulo.IdArticulo, Articulo.Denominacion, Articulo.Codigo, Articulo.PrecioCompra, Articulo.PrecioVenta, Articulo.Iva, Rubro.Denominacion FROM Articulo INNER JOIN Rubro ON Articulo.IdRubro = Rubro.IdRubro"></asp:SqlDataSource>
        <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

