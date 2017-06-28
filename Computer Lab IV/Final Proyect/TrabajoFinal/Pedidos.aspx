<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Pedidos.aspx.cs" Inherits="Pedidos" %>
<%@ MasterType virtualPath="~/Navegacion.master"%>

<asp:Content ID="cContenido1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Pedidos</title>
</asp:Content>

<asp:Content ID="cContenido2" ContentPlaceHolderID="cphContenido" runat="Server">
    <form id="form1" runat="server">

        <!-- Titulo -->
        <div style="text-align: center; padding: 40px 0px 0px 0px">
            <asp:Label ID="lblTitulo" runat="server" Text="Pedidos" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
        </div><br />

        <!-- Buscar -->
        <div style="width: 1300px; margin: 0 auto">
            <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                <asp:ListItem Text="Razon Social" Value="Cliente.RazonSocial" />
                <asp:ListItem Text="Estado" Value="PedidoVenta.Estado" />
                <asp:ListItem Text="Fecha" Value="PedidoVenta.FechaPedido" />
                <asp:ListItem Text="Fecha de Entrega" Value="PedidoVenta.FechaEstimadaEntrega" />
                <asp:ListItem Text="Calle" Value="Domicilio.Calle" />
                <asp:ListItem Text="Localidad" Value="Domicilio.Localidad" />
            </asp:DropDownList>
            <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Style="padding-left: 10px" />            
            <br />
        </div>

        <div>

            <!-- Tabla Pedidos -->
            <asp:GridView ID="grdPedidos" runat="server" AutoGenerateColumns="False" CellPadding="6" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Font-Size="14px" AllowPaging="True" AllowSorting="True" BorderWidth="0px" Style="margin: 0 auto; margin-top: 20px; text-align: center; width: 1300px" DataKeyNames="IdPedidoVenta">
                <AlternatingRowStyle BackColor="#F2F2F2" />
                <Columns>
                    <asp:BoundField DataField="NroPedido" HeaderText="N°" SortExpression="NroPedido" />
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" SortExpression="FechaPedido" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="FechaEstimadaEntrega" HeaderText="Fecha de Entrega" SortExpression="FechaEstimadaEntrega" DataFormatString="{0:d}" />                   
                    <asp:BoundField DataField="Calle" HeaderText="Calle" SortExpression="Calle" />
                    <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero" />
                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
                    <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" DataFormatString="{0:C}"/>  
                    <asp:BoundField DataField="GastosEnvio" HeaderText="Gastos de Envio" SortExpression="GastosEnvio" DataFormatString="{0:C}"/>                  
                    <asp:BoundField DataField="MontoTotal" HeaderText="Total" SortExpression="MontoTotal" DataFormatString="{0:C}"/>
                    <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdPedidoVenta") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este pedido?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdPedidoVenta") %>' ImageAlign="Left" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" Font-Size="15px" Height="40px"/>
                <PagerStyle BackColor="#17252a" ForeColor="White" HorizontalAlign="Center" Font-Bold="true" />
                <RowStyle BackColor="#FFFFFF" Font-Bold="true" Height="35px"/>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#66C2BE" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#2b7a78" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT PedidoVenta.IdPedidoVenta, PedidoVenta.FechaEstimadaEntrega, PedidoVenta.GastosEnvio, PedidoVenta.Estado, PedidoVenta.FechaPedido, PedidoVenta.NroPedido, PedidoVenta.SubTotal, PedidoVenta.MontoTotal, Cliente.RazonSocial, Domicilio.Calle, Domicilio.Numero, Domicilio.Localidad FROM ((PedidoVenta INNER JOIN Cliente ON PedidoVenta.IdCliente = Cliente.IdCliente) INNER JOIN Domicilio ON PedidoVenta.IdDomicilio = Domicilio.IdDomicilio) WHERE PedidoVenta.IdVendedor=@vendedor">
                   <SelectParameters>
                        <asp:SessionParameter Name="vendedor" Type="String"  SessionField="IdVendedor" />
                   </SelectParameters>
            </asp:SqlDataSource>   
            <br />         
        </div>

        <!-- Agregar Pedido -->
        <div style="margin: 0 auto; width: 1300px">
            <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/EditarPedido.aspx" Font-Bold="true" Font-Underline="false" ForeColor="#DEF2F1">
                <asp:Image ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20px" style="vertical-align:middle; padding-right: 10px"/>
                <asp:Label ID="lblAdd" runat="server" Text="Agregar Pedido" />
            </asp:HyperLink>
        </div>
    </form>
</asp:Content>