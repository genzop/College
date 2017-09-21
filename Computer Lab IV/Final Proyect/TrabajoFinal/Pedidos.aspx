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
        <div style="width: 900px; margin: 0 auto">
            <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                <asp:ListItem Text="Cliente" Value="Cliente.RazonSocial" />
                <asp:ListItem Text="Estado" Value="PedidoVenta.Estado" />
                <asp:ListItem Text="Fecha" Value="PedidoVenta.FechaPedido" />
                <asp:ListItem Text="Fecha de Entrega" Value="PedidoVenta.FechaEstimadaEntrega" />
            </asp:DropDownList>
            <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." style="margin-left: 10px" />            
            <asp:ImageButton ID="imgFind" runat="server" ImageUrl="~/img/find.png" Width="20" ImageAlign="AbsMiddle" style="padding-left: 10px" OnClick="imgFind_Click"/>
            <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20" ImageAlign="AbsMiddle" style="padding-left: 10px" OnClick="imgAdd_Click"/>            
            <br />
        </div>

        <div>
            <!-- Tabla Pedidos -->
            <asp:GridView ID="grdPedidos" runat="server" AutoGenerateColumns="False" CellPadding="6" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Font-Size="14px" AllowPaging="True" AllowSorting="True" BorderWidth="0px" Style="margin: 0 auto; margin-top: 20px; text-align: center; width: 900px" DataKeyNames="IdPedidoVenta">
                <AlternatingRowStyle BackColor="#F2F2F2" />
                <Columns>
                    <asp:BoundField DataField="NroPedido" HeaderText="N°" SortExpression="NroPedido" />
                    <asp:BoundField DataField="RazonSocial" HeaderText="Cliente" SortExpression="RazonSocial" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" SortExpression="FechaPedido" DataFormatString="{0:d}" />                                        
                    <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" DataFormatString="{0:C}"/>  
                    <asp:BoundField DataField="GastosEnvio" HeaderText="Gastos de Envio" SortExpression="GastosEnvio" DataFormatString="{0:C}"/>                  
                    <asp:BoundField DataField="MontoTotal" HeaderText="Total" SortExpression="MontoTotal" DataFormatString="{0:C}"/>
                    <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgPDF" runat="server" ImageUrl="~/img/pdf.png" Width="20px" OnCommand="imgPDF_Command" CommandArgument='<%# Eval("IdPedidoVenta") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdPedidoVenta") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="20px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este pedido?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdPedidoVenta") %>' ImageAlign="Left" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT PedidoVenta.IdPedidoVenta, PedidoVenta.FechaEstimadaEntrega, PedidoVenta.GastosEnvio, PedidoVenta.Estado, PedidoVenta.FechaPedido, PedidoVenta.NroPedido, PedidoVenta.SubTotal, PedidoVenta.MontoTotal, Cliente.RazonSocial FROM PedidoVenta INNER JOIN Cliente ON PedidoVenta.IdCliente = Cliente.IdCliente WHERE PedidoVenta.IdVendedor=@vendedor">
                   <SelectParameters>
                        <asp:SessionParameter Name="vendedor" Type="String"  SessionField="IdVendedor" />
                   </SelectParameters>
            </asp:SqlDataSource>   
            <br />         
        </div>

    </form>
</asp:Content>