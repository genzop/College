<%@ Page Title="" Language="C#" MasterPageFile="~/Navegacion.master" AutoEventWireup="true" CodeFile="EditarPedido.aspx.cs" Inherits="EditarPedido" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="~/ddlLocalidades.ascx" TagPrefix="uc1" TagName="ddlLocalidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
    <title>Editar Pedido</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    
    <form runat="server">
        <asp:Table ID="tablaSeparadora" runat="server" Style="margin: 0 auto; width: 1100px">
            <asp:TableRow>
                <asp:TableCell Width="30%">

                    <!-- Formulario Pedido -->
                    <div style="padding-right: 30px; margin-top: 40px">
                        <div class="formPedidos">

                            <div style="margin: 10px 0">
                                <asp:Label ID="lblTitulo" runat="server" Text="Titulo Temporal" Font-Names="Arial" Font-Bold="true" Font-Size="25px"/><br /><br />
                            </div>                            

                            <asp:HiddenField ID="hiddenID" runat="server" />                            

                            <div class="editContent">
                                <p class="editContentTitle">Numero</p>
                                <asp:TextBox ID="txtNumero" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumero" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                <asp:RegularExpressionValidator ID="revNumero" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumero" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle">Cliente</p>
                                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="drownDownList" DataSourceID="LinqDataSource1" DataTextField="RazonSocial" DataValueField="IdCliente"></asp:DropDownList>
                                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" Select="new (IdCliente, RazonSocial)" TableName="Clientes">
                                </asp:LinqDataSource>
                            </div>

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

                            <div class="editContent">
                                <p class="editContentTitle">Fecha Pedido</p>
                                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ValidationGroup="Pedido" ControlToValidate="txtFecha" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle">Fecha de Entrega</p>
                                <asp:TextBox ID="txtFechaEntrega" runat="server" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="rfvFechaEntrega" runat="server" ValidationGroup="Pedido" ControlToValidate="txtFechaEntrega" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                <asp:CompareValidator ID="compvFechaEntrega" runat="server" ValidationGroup="Pedido" Type="Date" ControlToValidate="txtFechaEntrega" ControlToCompare="txtFecha" Operator="GreaterThanEqual" ErrorMessage="* La fecha de entrega debe ser mayor o igual a la fecha en la que se hizo el pedido" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle">Sub Total</p>
                                <asp:TextBox ID="txtSubTotal" runat="server" ReadOnly="true" CssClass="inputCentrado" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle">Gastos de envio</p>
                                <asp:TextBox ID="txtGastosEnvio" runat="server" AutoPostBack="true" OnTextChanged="cambiaTotal" />
                                <asp:RegularExpressionValidator ID="revGastosEnvio" runat="server" ValidationGroup="Pedido" ControlToValidate="txtGastosEnvio" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* EL gasto de envio solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>                                            
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle">Total</p>
                                <asp:TextBox ID="txtMontoTotal" runat="server" ReadOnly="true" CssClass="inputCentrado" />
                            </div>

                            <div style="padding: 25px 0 10px 0">
                                <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio" Font-Bold="true" Font-Size="18px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold">Calle</p>
                                <asp:TextBox ID="txtCalle" runat="server" CssClass="inputCentrado"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ValidationGroup="Pedido" ControlToValidate="txtCalle" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                <asp:RegularExpressionValidator ID="revCalle" runat="server" ValidationGroup="Pedido" ControlToValidate="txtCalle" ValidationExpression="^(\s|.){1,100}$" ErrorMessage="* La calle puede contener hasta un máximo de 100 caracteres" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold">Numero</p>
                                <asp:TextBox ID="txtNumeroCalle" runat="server" CssClass="inputCentrado"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumeroCalle" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumeroCalle" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                                <asp:RegularExpressionValidator ID="revNumeroCalle" runat="server" ValidationGroup="Pedido" ControlToValidate="txtNumeroCalle" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold">Localidad</p>
                                <uc1:ddlLocalidades runat="server" ID="ddlLocalidades" />
                                <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ValidationGroup="Pedido" ControlToValidate="ddlLocalidades$ddlLocalidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold">Latitud</p>
                                <asp:TextBox ID="txtLatitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revLatitud" runat="server" ValidationGroup="Pedido" ControlToValidate="txtLatitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La latitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <div class="editContent">
                                <p class="editContentTitle" style="font-weight: bold">Longitud</p>
                                <asp:TextBox ID="txtLongitud" runat="server" CssClass="inputCentrado" AutoPostBack="true"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revLongitud" runat="server" ValidationGroup="Pedido" ControlToValidate="txtLongitud" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* La longitud solo puede ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            </div>

                            <asp:Button ID="btnAccion" runat="server" ValidationGroup="Pedido" Text="Texto temporal" CssClass="botonImportante" Width="200px" OnClick="btnAccion_Click" />
                        </div>
                    </div>
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <br /> 
                    <!-- Tabla Detalles -->
                    <p id="lblDetalles" runat="server" style="color: #FEFFFF; font-family: Arial; font-size: 25px; font-weight: bold">Detalles</p>

                    <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Font-Size="14px" AllowPaging="True" AllowSorting="True" BorderWidth="0px" Style="text-align: center; width: 100%" DataSourceID="SqlDataSource1" CssClass="tablaDetalles" DataKeyNames="IdPedidoVentaDetalle">
                        <AlternatingRowStyle BackColor="#F2F2F2" />
                        <Columns>
                            <asp:BoundField DataField="Denominacion" HeaderText="Articulo" SortExpression="Denominacion" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            <asp:BoundField DataField="PorcentajeDescuento" HeaderText="Descuento" SortExpression="PorcentajeDescuento"  DataFormatString="{0:p}" />
                            <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" DataFormatString="{0:C}"/>
                            <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/img/edit.png" Width="20px" OnCommand="imgEdit_Command" CommandArgument='<%# Eval("IdPedidoVentaDetalle") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-BackColor="#17252a" ItemStyle-BackColor="#17252a" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/img/delete.png" Width="18px" OnClientClick="return confirm('¿Esta seguro que quiere borrar este cliente?')" OnCommand="imgDelete_Command" CommandArgument='<%# Eval("IdPedidoVentaDetalle") %>' ImageAlign="Left" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrabajoFinalConnectionString %>" SelectCommand="SELECT PedidoVentaDetalle.IdPedidoVentaDetalle, PedidoVentaDetalle.Cantidad, PedidoVentaDetalle.PorcentajeDescuento, PedidoVentaDetalle.SubTotal, Articulo.Denominacion FROM PedidoVentaDetalle INNER JOIN Articulo ON PedidoVentaDetalle.IdArticulo = Articulo.IdArticulo WHERE PedidoVentaDetalle.IdPedidoVenta=@pedidoVenta">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="pedidoVenta" QueryStringField="id" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <div>
                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/img/addDetalle.png" Width="150px" CausesValidation="false" OnClick="imgbtnAdd_Click"/>                                                                
                    </div>                   
                                   
                    <!-- Formulario Detalle -->      
                    <div id="formularioDetalle" runat="server" class="formPedidos" style="margin: 0 auto" visible="false">
                        <div style="padding: 10px 0px 20px 0px" visible="false">
                            <asp:Label ID="lblTituloDetalle" runat="server" Text="Titulo Temporal" ForeColor="Black" Font-Names="Arial" Font-Bold="true" Font-Size="25px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle">Articulo</p>
                            <asp:DropDownList ID="ddlArticulo" runat="server" DataSourceID="LinqDataSourceArticulos" DataTextField="Denominacion" DataValueField="IdArticulo" style="margin-right: 0px" CssClass="drownDownList" AutoPostBack="true" OnSelectedIndexChanged="cambiaSubTotalDetalle"></asp:DropDownList>
                            <asp:LinqDataSource ID="LinqDataSourceArticulos" runat="server" ContextTypeName="BaseDatosDataContext" EntityTypeName="" OrderBy="Denominacion" Select="new (IdArticulo, Denominacion)" TableName="Articulos"></asp:LinqDataSource>
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle">Cantidad</p>
                            <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="true" OnTextChanged="cambiaSubTotalDetalle"/>
                            <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ValidationGroup="Detalle" ControlToValidate="txtCantidad" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RegularExpressionValidator ID="revCantidad" runat="server" ValidationGroup="Detalle" ControlToValidate="txtCantidad" ValidationExpression="[0-9]+" ErrorMessage="* Debe ser un numero entero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle">Descuento</p>
                            <asp:TextBox ID="txtDescuento" runat="server" AutoPostBack="true" OnTextChanged="cambiaSubTotalDetalle"/>
                            <asp:RequiredFieldValidator ID="rfvDescuento" runat="server" ValidationGroup="Detalle" ControlToValidate="txtDescuento" ErrorMessage="* Este campo es obligatorio" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                            <asp:RangeValidator ID="rngvDescuento" runat="server" ValidationGroup="Detalle" ControlToValidate="txtDescuento" Type="Double" MinimumValue="0,0" MaximumValue="100,0" ErrorMessage="* El descuento debe ser un numero decimal entre 0 y 100" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px"/>        
                        </div>
                        <div class="editContent">
                            <p class="editContentTitle">Sub Total</p>
                            <asp:TextBox ID="txtSubTotalDetalle" runat="server" ReadOnly="true"/>                             
                            <asp:RegularExpressionValidator ID="revSubTotalDetalle" ValidationGroup="Detalle" runat="server" ControlToValidate="txtSubTotalDetalle" ValidationExpression="[+-]?([0-9]*[,])?[0-9]+" ErrorMessage="* Debe ser un numero" Display="Dynamic" ForeColor="#ff0000" Font-Bold="true" Font-Size="11px" />
                        </div>
                        <table style="margin: 0 auto">
                            <tr>
                                <td><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botonImportante" Width="140px" OnClick="btnCancelar_Click" CausesValidation="false"/></td>
                                <td><asp:Button ID="btnAccionDetalle" runat="server" ValidationGroup="Detalle" Text="Texto temporal" CssClass="botonImportante" Width="140px" OnClick="btnAccionDetalle_Click" CausesValidation="true"/></td>
                            </tr>
                        </table>                        
                    </div>
                    <p style="color: #FEFFFF; font-family: Arial; font-size: 25px; font-weight: bold">Mapa</p>
                    <div id="mapa" style="width: 100%; height: 400px"></div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form><br /><br /><br />
    <script src="js/GoogleMaps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB8wddZQ_zuj38hPkcihIUOWNaoUMc7K9Y&callback=initMap" defer></script>    
</asp:Content>  