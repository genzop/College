<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="ObraSocialEditar.aspx.cs" Inherits="ObraSocialEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Editar Obra Social</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server"><br />

    <table style="margin: 0 auto; border-spacing: 40px">
        <tr>
            <td style="vertical-align: top">
                <!-- Formulario -->
                <div class="formulario" style="width: 320px">

                    <asp:Label ID="lblTitulo" runat="server" CssClass="subtitulo" Font-Size="20px"/><br /><br />

                    <div class="campoFormulario">
                        <span class="tituloInput">Nombre</span><br />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="input" /><br />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="ObraSocial" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Direccion</span><br />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="input" /><br />
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ValidationGroup="ObraSocial" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Localidad</span><br />
                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="input" Width="100%">
                            <asp:ListItem Text="Capital" Value="Capital"></asp:ListItem>
                            <asp:ListItem Text="General Alvear" Value="General Alvear"></asp:ListItem>
                            <asp:ListItem Text="Godoy Cruz" Value="Godoy Cruz"></asp:ListItem>
                            <asp:ListItem Text="Guaymallen" Value="Guaymallen"></asp:ListItem>
                            <asp:ListItem Text="Junin" Value="Junin"></asp:ListItem>
                            <asp:ListItem Text="La Paz" Value="La Paz"></asp:ListItem>
                            <asp:ListItem Text="Las Heras" Value="Las Heras"></asp:ListItem>
                            <asp:ListItem Text="Lavalle" Value="Lavalle"></asp:ListItem>
                            <asp:ListItem Text="Lujan de Cuyo" Value="Lujan de Cuyo"></asp:ListItem>
                            <asp:ListItem Text="Maipu" Value="Maipu"></asp:ListItem>
                            <asp:ListItem Text="Malargüe" Value="Malargüe"></asp:ListItem>
                            <asp:ListItem Text="Rivadavia" Value="Rivadavia"></asp:ListItem>
                            <asp:ListItem Text="San Carlos" Value="San Carlos"></asp:ListItem>
                            <asp:ListItem Text="San Martin" Value="San Martin"></asp:ListItem>
                            <asp:ListItem Text="San Rafael" Value="San Rafael"></asp:ListItem>
                            <asp:ListItem Text="Santa Rosa" Value="Santa Rosa"></asp:ListItem>
                            <asp:ListItem Text="Tunuyan" Value="Tunuyan"></asp:ListItem>
                            <asp:ListItem Text="Tupungato" Value="Tupungato"></asp:ListItem>
                        </asp:DropDownList>                        
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Telefono</span><br />
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="input" /><br />
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ValidationGroup="ObraSocial" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>


                    <div style="text-align: center">
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" ValidationGroup="ObraSocial" />
                    </div>

                </div>
            </td>
            <td style="vertical-align: top" id="tdPlanes" runat="server">

                <!-- Agregar -->
                <div style="width: 500px; margin: 0 auto"><br />
                    <span class="subtitulo">Planes</span>                  
                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" /><br />
                    <br />
                </div>

                <!-- Tabla Planes -->
                <asp:GridView ID="grdPlan" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_Plan" DataSourceID="SqlDataSource1"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="500px"
                    Style="margin: 0 auto" BackColor="White">
                    <Columns>
                        <asp:BoundField DataField="ID_Plan" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_Plan" />
                        <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" SortExpression="Denominacion" />
                        <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" DataFormatString="{0:P}"/>
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_Plan") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este plan?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_Plan") %>' ImageAlign="Left" />
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Plan] WHERE (([Habilitado] = @Habilitado) AND ([ID_ObraSocial] = @ID_ObraSocial))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                        <asp:QueryStringParameter Name="ID_ObraSocial" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource><br /><br />

                <!-- Formulario Plan -->
                <div class="formulario" id="formPlan" runat="server" style="width: 350px">

                    <asp:HiddenField ID="txtIDPlan" runat="server" />

                    <div class="campoFormulario">
                        <span class="tituloInput">Denominacion</span><br />
                        <asp:TextBox ID="txtDenominacion" runat="server" Width="100%" CssClass="input" />     
                        <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="Plan" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />                   
                    </div>

                    <div class="campoFormulario">
                        <span class="tituloInput">Descuento</span><br />
                        <asp:TextBox ID="txtDescuento" runat="server"  Width="100%" TextMode="Number" step="0.01" CssClass="input" />  
                        <asp:RequiredFieldValidator ID="rfvDescuento" runat="server" ControlToValidate="txtDescuento" ValidationGroup="Plan" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <div style="text-align: center">
                        <asp:Button ID="btnCancelarPlan" runat="server" OnClick="btnCancelarPlan_Click" Text="Cancelar" CssClass="colorButton" style="padding: 8px 25px; margin-right: 10px" CausesValidation="false"/>
                        <asp:Button ID="btnGuardarPlan" runat="server" OnClick="btnGuardarPlan_Click" Text="Guardar" CssClass="colorButton" style="padding: 8px 25px" ValidationGroup="Plan"/>
                    </div>
                </div>
                
            </td>
        </tr>
    </table>


</asp:Content>

