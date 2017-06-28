<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="Rubros.aspx.cs" Inherits="Rubros" %>
<%@ MasterType virtualPath="~/Navegacion.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Rubros</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">

    <!-- Titulo -->
    <div style="text-align: center; padding: 40px 0px 20px 0px">
        <asp:label id="lblTitulo" runat="server" text="Rubros" ForeColor="#FEFFFF" Font-Names="Arial" font-bold="true" font-size="30px " style=""/>
    </div>     
    
    <form id="form1" runat="server">        

        <!-- Buscador -->
        <div style="width: 500px; margin: 0 auto">
            <asp:DropDownList ID="ddlBuscar" runat="server" Style="padding-left: 5px" Height="37px" BackColor="#f2f2f2">
                <asp:ListItem Text="Codigo" Value="hijo.Codigo" />
                <asp:ListItem Text="Denominacion" Value="hijo.Denominacion" />
                <asp:ListItem Text="Rubro Superior" Value="padre.Denominacion" />
            </asp:DropDownList>
            <asp:TextBox ID="txtBuscar" runat="server" Width="200px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Style="padding-left: 10px" />                        
        </div><br />
        
        <!-- Tabla Rubros -->
        <asp:GridView ID="grdRubros" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="6" ForeColor="#333333" GridLines="None" Font-Size="14px" style="margin: 0 auto; text-align: center; width: 500px" >
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>                
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" SortExpression="Denominacion" />                
                <asp:BoundField DataField="Denominacion1" HeaderText="Rubro Superior" SortExpression="Denominacion1" />
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdRubro") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este rubro?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdRubro") %>' ImageAlign="Left"/>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT hijo.IdRubro, hijo.Codigo, hijo.Denominacion, padre.Denominacion FROM Rubro AS hijo INNER JOIN Rubro AS padre ON hijo.IdRubroSuperior = padre.IdRubro WHERE NOT hijo.Denominacion='-'"></asp:SqlDataSource>
        <br />

        <!-- Agregar Rubro -->
        <div style="margin: 0 auto; width: 500px">
            <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/EditarRubro.aspx?id=0" Font-Bold="true" Font-Underline="false" ForeColor="#DEF2F1">
                <asp:Image ID="imgAdd" runat="server" ImageUrl="~/img/add.png" Width="20px" CssClass="verticalCentered" style="padding: 0 10px 0 0"/>
                <asp:Label ID="lblAdd" runat="server" Text="Agregar Rubro" />
            </asp:HyperLink>
        </div>
    </form>
</asp:Content>

