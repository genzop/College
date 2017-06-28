<%@ Page Title="" Language="C#" MasterPageFile="~/BarraNavegacion.master" AutoEventWireup="true" CodeFile="FacturaEditar.aspx.cs" Inherits="FacturaEditar" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
    <title>Editar Factura</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

    <table style="margin: 0 auto; margin-top: 40px">
        <tr>
            <td style="vertical-align: top">

                <!-- Formulario -->
                <div class="formulario" style="width: 330px">

                    <div style="margin-bottom: 30px">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="subtitulo"/>
                    </div>                 

                    <!-- Paciente -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Paciente</span><br />
                        <asp:DropDownList ID="ddlPaciente" runat="server" DataSourceID="SqlDataSource1" DataTextField="NombreCompleto" DataValueField="ID_Paciente" CssClass="input" Width="100%" OnSelectedIndexChanged="ddlPaciente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT ID_Paciente, Nombre + ' ' + Apellido AS NombreCompleto FROM Paciente"></asp:SqlDataSource>
                    </div>

                    <!-- Tipo Factura -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Tipo</span><br />
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="input" Width="100%">
                            <asp:ListItem Text="A" Value="A" />
                            <asp:ListItem Text="B" Value="B" />
                            <asp:ListItem Text="C" Value="C" />
                        </asp:DropDownList>
                    </div>

                    <!-- Fecha -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Fecha</span><br />
                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="input" Width="100%"/>
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" ValidationGroup="Factura" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <!-- Estado -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Estado</span><br />
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="input" Width="100%">
                            <asp:ListItem Text="Impaga" Value="Impaga" />
                            <asp:ListItem Text="Pagada" Value="Pagada" />
                        </asp:DropDownList>
                    </div>

                    <!-- SubTotal -->
                    <div class="campoFormulario">
                        <span class="tituloInput">SubTotal</span><br />
                        <asp:TextBox ID="txtSubTotal" runat="server" Width="100%" CssClass="input" ReadOnly="true" AutoPostBack="true" OnTextChanged="actualizarTotal"/>
                    </div>

                    <!-- IVA -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Iva</span><br />
                        <asp:TextBox ID="txtIva" runat="server" TextMode="Number" step="0.01" Width="100%" CssClass="input" AutoPostBack="true" OnTextChanged="actualizarTotal"/>                          
                        <asp:RequiredFieldValidator ID="rfvIva" runat="server" ControlToValidate="txtIva" ValidationGroup="Factura" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>

                    <!-- Descuento -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Descuento</span><br />
                        <asp:TextBox ID="txtDescuento" runat="server" Width="100%" CssClass="input" ReadOnly="true" AutoPostBack="true"  OnTextChanged="actualizarTotal"/>
                    </div>

                    <!-- Total -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Total</span><br />
                        <asp:TextBox ID="txtTotal" runat="server" Width="100%" CssClass="input" ReadOnly="true" />
                    </div>

                    <div style="text-align: center">                        
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="colorButton" />
                    </div>
                </div>
            </td>
            <td style="vertical-align: top; padding-left: 100px" id="tdDetalles" runat="server">

                <!-- Agregar -->
                <div style="width: 500px; margin: 0 auto; margin-top: 30px">
                    <span class="subtitulo">Detalles</span>                    
                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/img/add.png" OnClick="btnAdd_Click" Width="20px" ImageAlign="Right" Style="margin-right: 20px" /><br />
                    <br />
                </div>

                <!-- Tabla Detalles -->
                <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="7" ForeColor="Black" GridLines="Horizontal" Width="500px" style="margin: 0 auto" BackColor="White" AllowSorting="True" DataSourceID="SqlDataSource2" DataKeyNames="ID_FacturaDetalle" >
                    <Columns>
                        <asp:BoundField DataField="ID_FacturaDetalle" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_FacturaDetalle" />                        
                        <asp:BoundField DataField="Denominacion" HeaderText="Servicio" SortExpression="Denominacion" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal" DataFormatString="{0:C}" />
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("ID_FacturaDetalle") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-BackColor="#333333" ItemStyle-BackColor="#FFFFFF" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar a esta factura?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("ID_FacturaDetalle") %>' ImageAlign="Left" />
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

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT FacturaDetalle.ID_FacturaDetalle, FacturaDetalle.ID_Factura ,Servicio.Denominacion, FacturaDetalle.Cantidad, FacturaDetalle.SubTotal FROM FacturaDetalle INNER JOIN Servicio ON FacturaDetalle.ID_Servicio = Servicio.ID_Servicio WHERE FacturaDetalle.ID_Factura = @IdFactura AND FacturaDetalle.Habilitado = 'true'">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="IdFactura" QueryStringField="id" />
                    </SelectParameters>
                </asp:SqlDataSource><br /><br />

                <!-- Formulario Detalle -->
                <div class="formulario" id="formDetalle" runat="server" visible="false" style="width: 350px">

                    <div style="margin-bottom: 30px">
                        <asp:Label ID="lblTituloDetalle" runat="server" CssClass="subtitulo" Font-Size="20px"/>
                    </div> 

                    <asp:HiddenField ID="txtIdDetalle" runat="server" />

                    <!-- Servicio -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Servicio</span><br />
                        <asp:DropDownList ID="ddlServicio" runat="server" DataSourceID="SqlDataSource3" DataTextField="Denominacion" DataValueField="ID_Servicio" CssClass="input" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="actualizarSubTotalDetalle"></asp:DropDownList>                        
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FinalBaseDatosConnectionString %>" SelectCommand="SELECT * FROM [Servicio] WHERE ([Habilitado] = @Habilitado)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="true" Name="Habilitado" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>

                    <!-- Cantidad -->
                    <div class="campoFormulario">
                        <span class="tituloInput">Cantidad</span><br />
                        <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Width="100%" CssClass="input" AutoPostBack="true" OnTextChanged="actualizarSubTotalDetalle" />                          
                        <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad" ValidationGroup="Detalle" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" CssClass="validacion" />
                    </div>                    

                    <!-- SubTotal -->
                    <div class="campoFormulario">
                        <span class="tituloInput">SubTotal</span><br />
                        <asp:TextBox ID="txtSubTotalDetalle" runat="server" Width="100%" CssClass="input" ReadOnly="true" />                             
                    </div>

                    <div style="text-align: center">                        
                        <asp:Button ID="btnCancelarDetalle" runat="server" OnClick="btnCancelarDetalle_Click" Text="Cancelar" CssClass="colorButton" style="padding: 8px 25px; margin-right: 10px" CausesValidation="false"/>
                        <asp:Button ID="btnGuardarDetalle" runat="server" OnClick="btnGuardarDetalle_Click" Text="Guardar" CssClass="colorButton" style="padding: 8px 25px" ValidationGroup="Detalle"/>
                    </div>
                </div>
            </td>
        </tr>
    </table><br /><br />
    
    

</asp:Content>

