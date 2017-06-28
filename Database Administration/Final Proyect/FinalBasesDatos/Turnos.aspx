<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="Turnos.aspx.cs" Inherits="Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <title>Turnos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server"><br /><br />

    <!-- Titulo -->
    <div style="text-align: center">
        <asp:Label ID="lblTitulo" runat="server" Text="Turnos" CssClass="titulo" />
    </div>
    <br />
    <br />

    <!-- Buscador -->
    <div style="width: 700px; margin: 0 auto">
        <asp:DropDownList ID="ddlBuscar" runat="server" Height="30px" Style="padding-left: 5px">
            <asp:ListItem Value="Turno.FechaHora" Text="Fecha" />
            <asp:ListItem Value="Turno.Estado" Text="Estado" />
            <asp:ListItem Value="Paciente.Nombre + ' ' + Paciente.Apellido" Text="Paciente" />
            <asp:ListItem Value="Medico.Nombre + ' ' + Medico.Apellido" Text="Medico" />
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscar" runat="server" Height="30px" Placeholder="Buscar..." OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Style="padding-left: 10px" />
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" /><br />
        <br />
    </div>

    <div>
        <asp:GridView ID="grdTurnos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_Turno"
            DataSourceID="SqlDataSource1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black"
            GridLines="Horizontal" Width="700px" Style="margin: 0 auto" BackColor="White">
            <Columns>
                <asp:BoundField DataField="ID_Turno" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_Turno" />
                <asp:BoundField DataField="FechaHora" HeaderText="Fecha/Hora" SortExpression="FechaHora"/>
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" ReadOnly="True" SortExpression="Paciente" />
                <asp:BoundField DataField="Medico" HeaderText="Medico" ReadOnly="True" SortExpression="Medico" />
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_Turno") %>' />
                    </ItemTemplate>

                    <HeaderStyle BackColor="#333333"></HeaderStyle>

                    <ItemStyle BackColor="White" Width="40px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere eliminar el registro?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_Turno") %>' ImageAlign="Left" />
                    </ItemTemplate>

                    <HeaderStyle BackColor="#333333"></HeaderStyle>

                    <ItemStyle BackColor="White" Width="30px"></ItemStyle>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" 
            SelectCommand="SELECT Turno.ID_Turno, Turno.FechaHora, Turno.Estado, Paciente.Nombre + ' ' + Paciente.Apellido AS Paciente, Medico.Nombre + ' ' + Medico.Apellido AS Medico FROM Turno INNER JOIN Paciente ON Turno.ID_Paciente = Paciente.ID_Paciente INNER JOIN Medico ON Turno.ID_Medico = Medico.ID_Medico"></asp:SqlDataSource>
    </div>

</asp:Content>

