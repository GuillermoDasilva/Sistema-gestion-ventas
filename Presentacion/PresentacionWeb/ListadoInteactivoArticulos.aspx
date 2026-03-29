<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="ListadoInteactivoArticulos.aspx.cs" Inherits="PresentacionWeb.ListadoInteactivoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style12 {
            width: 240px;
            height: 26px;
        }
        .auto-style27 {
            width: 218px;
            height: 26px;
        }
        .auto-style10 {
            width: 240px;
            height: 28px;
        }
        .auto-style28 {
            width: 218px;
            height: 28px;
        }
        .auto-style18 {
            width: 240px;
        }
        .auto-style29 {
            width: 218px;
        }
        .auto-style26 {
            width: 100%;
            height: 287px;
            margin-left: 0px;
        }
        .auto-style31 {
            width: 443px;
            height: 31px;
        }
        .auto-style32 {
            width: 446px;
            height: 31px;
        }
        .auto-style23 {
            width: 443px;
            height: 189px;
        }
        .auto-style24 {
            width: 446px;
            height: 189px;
        }
        .auto-style37 {
            width: 443px;
            height: 30px;
        }
        .auto-style38 {
            width: 446px;
            height: 30px;
        }
        .auto-style16 {
            width: 443px;
        }
        .auto-style17 {
            width: 446px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <strong>Listado interactivo Articulos<br />
        </strong>
        <br />
        <table align="center">
            <tr>
                <td align="left" class="auto-style12">Seleccione la categoria </td>
                <td class="auto-style27">
                    <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" Width="165px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" class="auto-style10">Articulos dentro de la categoria</td>
                <td class="auto-style28">
                    <asp:DropDownList ID="ddlArticulos" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="ddlArticulo_SelectedIndexChanged" Width="165px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" class="auto-style18">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" class="auto-style18">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style26">
            <tr>
                <td class="auto-style31">Datos articulos</td>
                <td align="center" class="auto-style32">Ventas del articulo</td>
                <td align="center" class="auto-style32">Datos de la venta</td>
            </tr>
            <tr>
                <td class="auto-style23">
                    <asp:GridView ID="GridDatosArticulo" runat="server" AutoPostBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" OnSelectedIndexChanged="GridDatosArticulo_SelectedIndexChanged" Width="440px" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            <asp:BoundField DataField="tamaño" HeaderText="Tamaño" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
                <td align="center" class="auto-style24">
                    <asp:GridView ID="GridDatosVentas" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridDatosVentas_SelectedIndexChanged" Width="455px">
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Número de venta" />
                            <asp:BoundField DataField="FechaVenta" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Venta" SortExpression="FechaVenta" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
                <td align="center" class="auto-style24">
                    <asp:GridView ID="GridDatosVentasCompleta" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridDatosVentasCompleta_SelectedIndexChanged" Width="455px">
                        <Columns>
                            <asp:BoundField DataField="DireccionCliente" HeaderText="Direeccion" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="FechaVenta" />
                            <asp:BoundField DataField="CedulaCliente" HeaderText="Cedula Cliente" />
                            <asp:BoundField DataField="NombreCliente" HeaderText="Nombre Cliente" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Tarjeta" HeaderText="Numero de tarjeta" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style38"></td>
                <td class="auto-style38">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">
                    <asp:Button ID="btnLimpiar" runat="server" Height="28px" onclick="btnLimpiar_Click" Text="Limpiar" Width="89px" />
                </td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
