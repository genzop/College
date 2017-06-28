<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="ServicioEditar.aspx.cs" Inherits="ServicioEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Editar Servicio</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br />
   
    <table style="margin: 0 auto; border-spacing: 40px">
        <tr>
            <td style="vertical-align: top">
                <!-- Formulario -->
                <div class="formulario" style="width: 320px">

                    <asp:Label ID="lblTitulo" runat="server" CssClass="subtitulo" Font-Size="15" /><br />
                    <br />

                    <div class="campoFormulario">
                        <span class="tituloInput">Denominacion</span><br />
                        <asp:TextBox ID="txtDenominacion" runat="server" CssClass="input" />
                        <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Precio</span><br />
                        <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" step="0.01" CssClass="input" />
                        <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div style="text-align: center">
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
                    </div>
                </div>
            </td>

            <td style="vertical-align: top" id="tdEditar" runat="server"><br />
                
                <div style="width: 400px; margin: 0 auto; margin-top: 10px">
                    <span class="subtitulo">Medicos</span>   
                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" />                    
                </div><br />

                <asp:GridView ID="grdMedicos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_MedicoServicio" DataSourceID="SqlDataSource2" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="400px" style="margin: 0 auto" BackColor="White">
                    <Columns>                        
                        <asp:BoundField DataField="NombreCompleto" HeaderText="Medico" SortExpression="NombreCompleto" />
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar a este medico')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_MedicoServicio") %>' ImageAlign="Left" />
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

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT MedicoServicio.ID_MedicoServicio, Medico.Nombre + ' ' + Medico.Apellido AS NombreCompleto FROM Medico INNER JOIN MedicoServicio ON Medico.ID_Medico = MedicoServicio.ID_Medico WHERE (MedicoServicio.Habilitado = @Habilitado) AND (MedicoServicio.ID_Servicio = @Servicio)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" />
                        <asp:QueryStringParameter DefaultValue="" Name="Servicio" QueryStringField="id" />
                    </SelectParameters>
                </asp:SqlDataSource><br /><br />

                <div class="formulario" id="formMedicos" runat="server" visible="false" style="width: 350px">
                    <asp:Label ID="lblTituloMedicos" runat="server" Text="Agregar Medico" CssClass="subtitulo" Font-Size="15"/><br /><br />

                    <div class="campoFormulario">
                        <asp:DropDownList ID="ddlMedicos" runat="server" DataSourceID="SqlDataSource1" DataTextField="NombreCompleto" DataValueField="ID_Medico" CssClass="input" Width="100%"></asp:DropDownList>   
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT [Habilitado], [ID_Medico], Nombre + ' ' + Apellido AS NombreCompleto FROM [Medico] WHERE ([Habilitado] = @Habilitado)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>

                    <div style="text-align: center">                        
                        <asp:Button ID="btnCancelarMed" runat="server" OnClick="btnCancelarMed_Click" Text="Cancelar" CssClass="colorButton" style="padding: 8px 25px; margin-right: 10px" CausesValidation="false"/>
                        <asp:Button ID="btnGuardarMed" runat="server" OnClick="btnGuardarMed_Click" Text="Guardar" CssClass="colorButton" style="padding: 8px 25px" ValidationGroup="Detalle"/>
                    </div>
                </div>

            </td>
        </tr>
    </table>
    
    
</asp:Content>

