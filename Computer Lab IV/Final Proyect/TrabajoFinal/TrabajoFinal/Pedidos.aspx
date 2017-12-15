<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Pedidos.aspx.cs" Inherits="Pedidos" %>

<%@ MasterType VirtualPath="~/Navegacion.master" %>

<asp:Content ID="cContenido1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Pedidos</title>
</asp:Content>

<asp:Content ID="cContenido2" ContentPlaceHolderID="cphContenido" runat="Server">
    <form id="form1" runat="server">

        <!-- Titulo -->
        <div style="text-align: center; padding: 40px 0px 0px 0px">
            <asp:Label ID="lblTitulo" runat="server" Text="Pedidos" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
        </div>
        <br />

        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Buscar -->
                <div style="width: 1100px; margin: 0 auto">
                    <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                        <asp:ListItem Text="Numero" Value="Pedido.IdPedido" />
                        <asp:ListItem Text="Cliente" Value="Cliente.RazonSocial" />
                        <asp:ListItem Text="Estado" Value="Pedido.Estado" />
                        <asp:ListItem Text="Fecha" Value="Pedido.FechaPedido" />
                        <asp:ListItem Text="Fecha de Entrega" Value="Pedido.FechaEntrega" />
                    </asp:DropDownList>
                    <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..."  />
                    <asp:ImageButton ID="imgFind" runat="server" ImageUrl="~/img/find.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgFind_Click" />
                    <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgAdd_Click" />
                    <br />
                </div>

                <div>
                    <!-- Tabla Pedidos -->
                    <asp:GridView ID="grdPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True"  CellPadding="6" ForeColor="#333333" GridLines="None" Font-Size="14px" Style="margin: 0 auto; margin-top: 20px; text-align: center; width: 1100px">
                        <AlternatingRowStyle BackColor="#F2F2F2" />
                        <Columns>
                            <asp:BoundField DataField="IdPedido" HeaderText="N°" SortExpression="IdPedido" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="RazonSocial" HeaderText="Cliente" SortExpression="RazonSocial" />                                                        
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" SortExpression="FechaPedido" DataFormatString="{0:d}" ItemStyle-Width="70px"  />
                            <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha de entrega" SortExpression="FechaEntrega" DataFormatString="{0:d}" ItemStyle-Width="70px"  />
                            <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" SortExpression="SubTotal" DataFormatString="{0:C}" ItemStyle-Width="80px"  />
                            <asp:BoundField DataField="GastosEnvio" HeaderText="Gastos de envio" SortExpression="GastosEnvio" DataFormatString="{0:C}" ItemStyle-Width="80px"  />
                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C}" ItemStyle-Width="80px"  />                                                        
                            <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="20px" OnClientClick="return confirm('¿Esta seguro que quiere eliminar este pedido?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdPedido") %>' ImageAlign="Left" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" Font-Size="15px" Height="40px" />
                        <PagerStyle BackColor="#17252a" ForeColor="White" HorizontalAlign="Center" Font-Bold="true" />
                        <RowStyle BackColor="#FFFFFF" Font-Bold="true" Height="35px" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#66C2BE" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#2b7a78" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado,Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente WHERE Pedido.IdVendedor=@vendedor">
                        <SelectParameters>
                            <asp:SessionParameter Name="vendedor" Type="String" SessionField="IdVendedor" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</asp:Content>
