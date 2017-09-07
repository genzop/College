<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Clientes</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 20px 0px">
        <asp:label id="lblTitulo" runat="server" text="Clientes" ForeColor="#FEFFFF" Font-Names="Arial" font-bold="true" font-size="30px " style=""/>
    </div>     
    <form id="form1" runat="server">

        <!-- Buscador -->
        <div style="width: 900px; margin: 0 auto">
            <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                <asp:ListItem Text="Razon Social" Value="Cliente.RazonSocial" />
                <asp:ListItem Text="Cuit" Value="Cliente.Cuit" />
                <asp:ListItem Text="Calle" Value="Domicilio.Calle" />
                <asp:ListItem Text="Localidad" Value="Domicilio.Localidad" />
            </asp:DropDownList>
            <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Style="padding-left: 10px" />                        
        </div><br />

        <!-- Tabla Clientes -->
        <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" CellPadding="6" ForeColor="#333333" GridLines="None" Font-Size="14px" AllowPaging="True" AllowSorting="True" BorderWidth="0px" CssClass="tablaCentrada" DataKeyNames="IdCliente" DataSourceID="SqlDataSource1" style="margin: 0 auto; text-align: center; width: 900px">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>                
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" ItemStyle-Height="22px" ItemStyle-Width="200px"/>
                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
                <asp:BoundField DataField="Calle" HeaderText="Calle" SortExpression="Calle" />
                <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero" />                
                <asp:BoundField DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdCliente") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este cliente?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdCliente") %>' ImageAlign="Left" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" Font-Size="15px" Height="40px"/>
            <PagerStyle BackColor="#17252a" ForeColor="White" HorizontalAlign="Center" Font-Bold="true" />
            <RowStyle BackColor="#FFFFFF" Font-Bold="true" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#66C2BE" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#2b7a78" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT Cliente.IdCliente, Cliente.RazonSocial, Cliente.Cuit, Cliente.Saldo, Domicilio.Calle, Domicilio.Numero, Domicilio.Localidad FROM Cliente INNER JOIN Domicilio ON Cliente.IdDomicilio = Domicilio.IdDomicilio"></asp:SqlDataSource>
        <br />

        <!-- Agregar Cliente -->
        <div style="margin: 0 auto; width: 900px">
            <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/EditarCliente.aspx?id=0" Font-Bold="true" Font-Underline="false" ForeColor="#DEF2F1">
                <asp:Image ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20px" CssClass="verticalCentered" style="padding: 0 10px 0 0"/>
                <asp:Label ID="lblAdd" runat="server" Text="Agregar Cliente" />
            </asp:HyperLink>
        </div>
    </form>
</asp:Content>

