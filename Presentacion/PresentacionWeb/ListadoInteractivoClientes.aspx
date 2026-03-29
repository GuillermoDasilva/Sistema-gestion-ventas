<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="ListadoInteractivoClientes.aspx.cs" Inherits="PresentacionWeb.ListadoInteractivoClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style7 {
            width: 832px;
            height: 78px;
        }
        .auto-style8 {
            width: 1220px;
            height: 78px;
        }
        .auto-style9 {
            width: 774px;
            height: 78px;
        }
        .auto-style3 {
            width: 832px;
            height: 278px;
        }
        .auto-style2 {
            width: 1220px;
            height: 278px;
        }
        .auto-style13 {
            width: 832px;
            height: 100px;
        }
        .auto-style14 {
            width: 1220px;
            height: 100px;
        }
        .auto-style15 {
            width: 774px;
            height: 100px;
        }
        .auto-style10 {
            width: 832px;
            height: 97px;
        }
        .auto-style11 {
            width: 1220px;
            height: 97px;
        }
        .auto-style12 {
            width: 774px;
            height: 97px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <strong>Listado interactivo Clientes<br />
        </strong>
        <br />
        <table class="auto-style26">
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style7">Seleccione el cliente</td>
                <td align="center" class="auto-style8">Ventas Asociadas</td>
                <td align="center" class="auto-style9">Articulos Comprados</td>
                <td align="center" class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3">
                    <asp:GridView ID="GridDatosClientes" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" OnSelectedIndexChanged="GridDatosClientes_SelectedIndexChanged" Width="455px">
                        <Columns>
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                            <asp:BoundField DataField="Telefono" HeaderText="Numero de Telefono" />
                            <asp:BoundField DataField="numTarjeta" HeaderText="Numero De Tarjeta" />
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
                <td align="center" class="auto-style2">
                    <asp:GridView ID="GridVentas" runat="server" AutoPostBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" OnSelectedIndexChanged="GridDatosVentas_SelectedIndexChanged" Width="440px">
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
                <td align="center" class="auto-style1">
                    <asp:GridView ID="GridArticulos" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" OnSelectedIndexChanged="GridArticulos_SelectedIndexChanged" Width="455px">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
                <td align="center" class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
                <td class="auto-style12"></td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnLimpiar" runat="server" Height="28px" onclick="btnLimpiar_Click" Text="Limpiar" Width="89px" />
        <br />
    </div>
</asp:Content>
