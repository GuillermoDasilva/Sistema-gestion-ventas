<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style2 {
            width: 1224px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        &nbsp;Venta pendientes<strong><br /></strong>
        <br />
        <table class="auto-style26">
            <tr>
                <td align="center" class="auto-style2">&nbsp;</td>
                <td align="center" class="auto-style2">&nbsp;</td>
                <td align="center" class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style2">&nbsp;</td>
                <td align="center" class="auto-style2">
                    <asp:GridView ID="GridVentas" runat="server" BackColor="White" AutoPostBack="True"
    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
    ForeColor="Black" GridLines="Horizontal" Width="440px"
    OnSelectedIndexChanged="GridDatosVentas_SelectedIndexChanged" HorizontalAlign="Center">
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
                <td align="center" class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2"></td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">
        <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
