<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Rubros.aspx.cs" Inherits="Rubros" %>

<%@ MasterType VirtualPath="~/Navegacion.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Rubros</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 20px 0px">
        <asp:Label ID="lblTitulo" runat="server" Text="Rubros" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " Style="" />
    </div>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Buscador -->
                <div style="width: 700px; margin: 0 auto">
                    <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                        <asp:ListItem Text="Codigo" Value="hijo.IdRubro" />
                        <asp:ListItem Text="Denominacion" Value="hijo.Denominacion" />
                        <asp:ListItem Text="Rubro Superior" Value="padre.Denominacion" />
                    </asp:DropDownList>
                    <asp:TextBox ID="txtBuscar" runat="server" Width="300px" Placeholder="Buscar..." Style="padding-left: 10px" />
                    <asp:ImageButton ID="imgFind" runat="server" ImageUrl="~/img/find.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgFind_Click" />
                    <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20" ImageAlign="AbsMiddle" Style="margin-left: 10px" OnClick="imgAdd_Click" />
                </div>
                <br />

                <!-- Tabla Rubros -->
                <asp:GridView ID="grdRubros" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="6" ForeColor="#333333" GridLines="None" Font-Size="14px" Style="margin: 0 auto; text-align: center; width: 700px">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:BoundField DataField="IdRubro" HeaderText="Codigo" SortExpression="IdRubro" ItemStyle-Height="22" />
                        <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" SortExpression="Denominacion" />
                        <asp:BoundField DataField="Denominacion1" HeaderText="Rubro Superior" SortExpression="Denominacion1" />
                        <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdRubro") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere eliminar este rubro?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdRubro") %>' ImageAlign="Left" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT hijo.IdRubro, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion='-'"></asp:SqlDataSource>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

