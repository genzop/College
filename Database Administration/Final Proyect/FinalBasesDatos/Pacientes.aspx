<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="Pacientes.aspx.cs" Inherits="Paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Pacientes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server"><br /><br />

    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Pacientes" CssClass="titulo" />
    </div>
    <br />
    <br />

    <!-- Agregar -->
    <div style="width: 700px; margin: 0 auto">
        <asp:DropDownList ID="ddlBuscar" runat="server" Height="30px" Style="padding-left: 5px">
            <asp:ListItem Value="Nombre" Text="Nombre" />
            <asp:ListItem Value="Apellido" Text="Apellido" />
            <asp:ListItem Value="DNI" Text="DNI" />
            <asp:ListItem Value="ObraSocial" Text="Obra Social" />
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Style="padding-left: 10px" />
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" /><br />
        <br />
    </div>

    <div>
        <asp:GridView ID="grdPacientes" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_Paciente" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black"
            GridLines="Horizontal" Width="700px" Style="margin: 0 auto" BackColor="White" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID_Paciente" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_Paciente" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Dni" HeaderText="Dni" SortExpression="Dni" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_Paciente") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar a este paciente?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_Paciente") %>' ImageAlign="Left" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:Button ID="btnHistoriaClinica" runat="server" Text="Ver Historia Clínica" OnCommand="historiaClinica_Command" CommandArgument='<%# Eval("ID_Paciente") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:Button ID="btnObraSocial" runat="server" Text="Ver Obra Social" OnCommand="obraSocial_Command" CommandArgument='<%# Eval("ID_Paciente") %>' />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Paciente]"></asp:SqlDataSource>
    </div>




</asp:Content>

