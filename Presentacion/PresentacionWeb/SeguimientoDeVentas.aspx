<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="SeguimientoDeVentas.aspx.cs" Inherits="PresentacionWeb.SeguimientoDeVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style2 {
            width: 219px;
        }
        .auto-style3 {
            width: 194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        Seguimiento de ventas<br />
        <br />
        <div align="center">
        </div>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Ingrese el codigo de la venta:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCodigoventa" runat="server" Width="142px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="114px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Formulario" Width="114px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Width="114px" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Width="114px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
