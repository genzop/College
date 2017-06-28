<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="MedicoEditar.aspx.cs" Inherits="MedicoEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Editar Medico</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br />

    <table style="margin: 0 auto; border-spacing: 40px">
        <tr>
            <td style="vertical-align: top">
                <!-- Formulario -->
                <div class="formulario" style="width: 320px">

                    <asp:Label ID="lblTitulo" runat="server" CssClass="subtitulo" /><br /><br />                    

                    <div class="campoFormulario">
                        <span class="tituloInput">Nombre</span><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="input" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Apellido</span><br />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="input" />
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Matricula</span><br />
                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="input" />
                        <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div style="text-align: center">
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
                    </div>
                </div>
            </td>

            <td style="vertical-align: top" id="tdEspecialidades" runat="server">

                <div style="width: 400px; margin: 0 auto; margin-top: 30px">
                    <span class="subtitulo">Especialidades</span>   
                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" />                    
                </div><br />

                <asp:GridView ID="grdEspecialidades" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="400px" style="margin: 0 auto" BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="Denominacion" HeaderText="Especialidad" SortExpression="Denominacion" />
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar a esta especialidad?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_MedicoEspecialidad") %>' ImageAlign="Left" />
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT MedicoEspecialidad.ID_MedicoEspecialidad, Especialidad.Denominacion FROM Especialidad INNER JOIN MedicoEspecialidad ON Especialidad.ID_Especialidad = MedicoEspecialidad.ID_Especialidad WHERE (MedicoEspecialidad.Habilitado = @Habilitado) AND (MedicoEspecialidad.ID_Medico = @Medico)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                        <asp:QueryStringParameter DefaultValue="" Name="Medico" QueryStringField="id" />
                    </SelectParameters>
                </asp:SqlDataSource><br /><br />

                <div class="formulario" id="formEspecialidad" runat="server" visible="false" style="width: 350px">
                    <asp:Label ID="lblTituloEspecialidad" runat="server" Text="Agregar Especialidad" CssClass="subtitulo" Font-Size="14"/><br /><br />
                    <div class="campoFormulario">
                        <asp:DropDownList ID="ddlEspecialidades" runat="server" DataSourceID="SqlDataSource2" DataTextField="Denominacion" DataValueField="ID_Especialidad" CssClass="input" Width="100%"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Especialidad] WHERE ([Habilitado] = @Habilitado)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div style="text-align: center">                        
                        <asp:Button ID="btnCancelarEsp" runat="server" OnClick="btnCancelarEsp_Click" Text="Cancelar" CssClass="colorButton" style="padding: 8px 25px; margin-right: 10px" CausesValidation="false"/>
                        <asp:Button ID="btnGuardarEsp" runat="server" OnClick="btnGuardarEsp_Click" Text="Guardar" CssClass="colorButton" style="padding: 8px 25px" ValidationGroup="Detalle"/>
                    </div>
                </div>

            </td>
        </tr>
    </table>


</asp:Content>

