<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarPedido.aspx.cs" Inherits="EditarPedido" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/ddlLocalidades.ascx" TagPrefix="uc1" TagName="ddlLocalidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" runat="Server">
    <title>Editar Pedido</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

    <form runat="server">

        <!-- Titulo -->
        <div style="text-align: center; padding: 40px 0px 0px 0px">
            <asp:Label ID="lblTitulo" runat="server" Text="Titulo Temporal" ForeColor="#FEFFFF" Font-Names="Arial" Font-Bold="true" Font-Size="30px " />
        </div>
        <br />

        <!-- Formulario Pedido -->
        <div style="padding-right: 30px; margin-top: 10px">
            <div class="formPedidos" style="width: 1000px; margin-left: auto; margin-right: auto">

                <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true" />
                <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hiddenID" runat="server" />

                        <asp:Table runat="server" Style="width: 100%">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 20%; vertical-align: top">
                                    <div class="editContent">
                                        <p class="editContentTitle">Numero</p>
                                        <asp:TextBox ID="txtNumero" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumero" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                        <asp:RegularExpressionValidator ID="revNumero" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumero" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    </div>
                                </asp:TableCell><asp:TableCell Style="width: 20%; vertical-align: top">
                                    <div class="editContent">
                                        <p class="editContentTitle">Cliente</p>
                                        <asp:DropDownList ID="ddlCliente" runat="server" CssClass="drownDownList" DataSourceID="LinqDataSource1" DataTextField="RazonSocial" DataValueField="IdCliente" AutoPostBack="true" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" Select="new (IdCliente, RazonSocial)" TableName="Clientes">
                                        </asp:LinqDataSource>
                                    </div>
                                </asp:TableCell><asp:TableCell Style="width: 20%; vertical-align: top">
                                    <div class="editContent">
                                        <p class="editContentTitle">Estado</p>
                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="drownDownList">
                                            <asp:ListItem Text="-" />
                                            <asp:ListItem Value="Pendiente" Text="Pendiente" />
                                            <asp:ListItem Value="Enviado" Text="Enviado" />
                                            <asp:ListItem Value="Entregado" Text="Entregado" />
                                            <asp:ListItem Value="Anulado" Text="Anulado" />
                                        </asp:DropDownList>
                                    </div>
                                </asp:TableCell><asp:TableCell Style="width: 20%; vertical-align: top">
                                    <div class="editContent">
                                        <p class="editContentTitle">Fecha Pedido</p>
                                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" />
                                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ValidationGroup="Pedido" ControlToValidate="txtFecha" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    </div>
                                </asp:TableCell><asp:TableCell Style="width: 20%; vertical-align: top">

                                    <div class="editContent">
                                        <p class="editContentTitle">Fecha de Entrega</p>
                                        <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" />
                                        <asp:RequiredFieldValidator ID="rfvFechaEntrega" runat="server" ValidationGroup="Pedido" ControlToValidate="txtFechaEntrega" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                        <asp:CompareValidator ID="compvFechaEntrega" runat="server" ValidationGroup="Pedido" Type="Date" ControlToValidate="txtFechaEntrega" ControlToCompare="txtFecha" Operator="GreaterThanEqual" ErrorMessage="* La fecha de entrega debe ser mayor o igual a la fecha en la que se hizo el pedido" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <!-- Domicilio -->
                        <asp:Table runat="server" Style="width: 100%">
                            <asp:TableRow>
                                <asp:TableCell Style="width: 25%">
                                    <div class="editContent">
                                        <p class="editContentTitle" style="font-weight: bold">Calle</p>
                                        <asp:TextBox ID="txtCalle" runat="server" CssClass="inputCentrado" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="editContent">
                                        <p class="editContentTitle" style="font-weight: bold">Numero</p>
                                        <asp:TextBox ID="txtNumeroCalle" runat="server" CssClass="inputCentrado" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="editContent">
                                        <p class="editContentTitle" style="font-weight: bold">Localidad</p>
                                        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="inputCentrado" AutoPostBack="true" Enabled="false" />
                                    </div>

                                    <div class="editContent">
                                        <p class="editContentTitle" style="font-weight: bold">Latitud</p>
                                        <asp:TextBox ID="txtLatitud" runat="server" CssClass="inputCentrado" AutoPostBack="true" Enabled="false" />
                                    </div>

                                    <div class="editContent">
                                        <p class="editContentTitle" style="font-weight: bold">Longitud</p>
                                        <asp:TextBox ID="txtLongitud" runat="server" CssClass="inputCentrado" AutoPostBack="true" Enabled="false" />
                                    </div>
                                </asp:TableCell><asp:TableCell>
                            <div style="padding-top: 13px"></div>
                            <div id="mapa" style="width: 94%; height: 323px; margin-left: 30px"></div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <!-- Detalles -->
                        <asp:Table runat="server" Style="margin-left: auto; margin-right: auto">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <p id="lblDetalles" runat="server" style="color: #000000; font-family: Arial; font-size: 25px; font-weight: bold">Detalles</p>
                                </asp:TableCell><asp:TableCell>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/img/addDark.png" Width="20px" CausesValidation="false" OnClick="imgbtnAdd_Click" Style="padding-left: 5px; padding-top: 5px" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div style="box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); width: 80%; margin-left: auto; margin-right: auto; margin-bottom: 20px">
                            <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Font-Size="14px" BorderWidth="0px" Style="text-align: center; width: 100%" CssClass="tablaDetalles">
                                <AlternatingRowStyle BackColor="#F2F2F2" />
                                <Columns>
                                    <asp:BoundField DataField="Articulo" HeaderText="Articulo" SortExpression="Articulo" />
                                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" DataFormatString="{0:C}" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" DataFormatString="{0:C}" />
                                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" DataFormatString="{0:p}" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:C}" />
                                    <asp:TemplateField ItemStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/editDark.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdPedidoVentaDetalle") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/deleteDark.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este detalle?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdPedidoVentaDetalle") %>' ImageAlign="Left" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#FFFFFF" />
                                <FooterStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#3aafa9" Font-Bold="True" ForeColor="White" Font-Size="15px" Height="40px" />
                                <PagerStyle BackColor="#17252a" ForeColor="White" HorizontalAlign="Center" Font-Bold="true" />
                                <RowStyle BackColor="#FFFFFF" Font-Bold="true" Height="40px" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#66C2BE" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#2b7a78" />
                            </asp:GridView>
                        </div>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                        <br />
                        <div>
                        </div>

                        <!-- Formulario Detalle -->
                        <div id="formularioDetalle" runat="server" class="formPedidos" style="margin: 0 auto; width: 80%; padding: 20px; margin-bottom: 50px" visible="false">

                            <div>
                                <asp:HiddenField ID="hiddenFila" runat="server" />
                            </div>

                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Articulo</p>
                                            <asp:DropDownList ID="ddlArticulo" runat="server" DataSourceID="LinqDataSourceArticulos" DataTextField="Denominacion" DataValueField="IdArticulo" Style="margin-right: 0px" CssClass="drownDownList" AutoPostBack="true" OnSelectedIndexChanged="cambiaSubTotalDetalle"></asp:DropDownList>
                                            <asp:LinqDataSource ID="LinqDataSourceArticulos" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" OrderBy="Denominacion" Select="new (IdArticulo, Denominacion)" TableName="Articulos"></asp:LinqDataSource>
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Precio Unitario</p>
                                            <asp:TextBox ID="txtPrecioUnitario" runat="server" Enabled="false" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Cantidad</p>
                                            <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="true" OnTextChanged="cambiaSubTotalDetalle" />
                                            <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ValidationGroup="Detalle" ControlToValidate="txtCantidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                            <asp:RegularExpressionValidator ID="revCantidad" runat="server" ValidationGroup="Detalle" ControlToValidate="txtCantidad" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Sub Total</p>
                                            <asp:TextBox ID="txtSubTotalSinDescuento" runat="server" Enabled="false" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Descuento</p>
                                            <asp:TextBox ID="txtDescuento" runat="server" AutoPostBack="true" OnTextChanged="cambiaSubTotalDetalle" />
                                            <asp:RequiredFieldValidator ID="rfvDescuento" runat="server" ValidationGroup="Detalle" ControlToValidate="txtDescuento" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                            <asp:RangeValidator ID="rngvDescuento" runat="server" ValidationGroup="Detalle" ControlToValidate="txtDescuento" Type="Double" MinimumValue="0,0" MaximumValue="100,0" ErrorMessage="* El descuento debe ser un numero decimal entre 0 y 100" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell Width="16%">
                                        <div class="editContent">
                                            <p class="editContentTitle">Total</p>
                                            <asp:TextBox ID="txtSubTotalDetalle" runat="server" ReadOnly="true" />
                                            <asp:RegularExpressionValidator ID="revSubTotalDetalle" ValidationGroup="Detalle" runat="server" ControlToValidate="txtSubTotalDetalle" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* Debe ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <table style="margin: 0 auto; border-spacing: 40px 0">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botonImportante" Width="140px" OnClick="btnCancelar_Click" CausesValidation="false" /></td>
                                    <td>
                                        <asp:Button ID="btnAccionDetalle" runat="server" ValidationGroup="Detalle" Text="Guardar" CssClass="botonImportante" Width="140px" OnClick="btnAccionDetalle_Click" CausesValidation="true" /></td>
                                </tr>
                            </table>
                        </div>

                        <!-- Totales -->
                        <asp:Table runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Width="30%">
                                    <div class="editContent" id="campoVendedor" runat="server" visible="false">
                                        <p class="editContentTitle">Vendedor</p>
                                        <asp:DropDownList ID="ddlVendedor" runat="server" CssClass="drownDownList" DataSourceID="SqlDataSource2" DataTextField="NombreCompleto" DataValueField="IdVendedor"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT IdVendedor, Nombre + ' ' + Apellido AS NombreCompleto FROM Vendedor  WHERE IdVendedor != 20"></asp:SqlDataSource>
                                    </div>
                                </asp:TableCell>
                                <asp:TableCell Width="15%">
                            <div></div>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <div class="editContent">
                                        <p class="editContentTitle">Sub Total</p>
                                        <asp:TextBox ID="txtSubTotal" runat="server" Text="0" ReadOnly="true" CssClass="inputCentrado" Style="text-align: right" />
                                    </div>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <div class="editContent">
                                        <p class="editContentTitle">Gastos de envio</p>
                                        <asp:TextBox ID="txtGastosEnvio" runat="server" Text="0" AutoPostBack="true" OnTextChanged="cambiarGastosEnvio" Style="text-align: right" />
                                        <asp:RegularExpressionValidator ID="revGastosEnvio" runat="server" ValidationGroup="Pedido" ControlToValidate="txtGastosEnvio" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* EL gasto de envio solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                    </div>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <div class="editContent">
                                        <p class="editContentTitle">Total</p>
                                        <asp:TextBox ID="txtMontoTotal" runat="server" Text="0" ReadOnly="true" CssClass="inputCentrado" Style="text-align: right" />
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div class="editContent" style="text-align: right">
                            <asp:CheckBox ID="cboxPagado" runat="server" Text="Pagado" TextAlign="Left" Font-Bold="true" />
                        </div>
                        <br />
                        <asp:Button ID="btnAccion" runat="server" ValidationGroup="Pedido" Text="Guardar" CssClass="botonImportante" Width="200px" OnClick="btnAccion_Click" Style="margin-top: 20px" />
                    </ContentTemplate>


                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtGastosEnvio" EventName="TextChanged"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
    </form>
    <br />
    <br />
    <br />

    <script src="js/GoogleMaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB8wddZQ_zuj38hPkcihIUOWNaoUMc7K9Y&callback=initMap" defer></script>

</asp:Content>

