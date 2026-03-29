<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="AltaVentas.aspx.cs" Inherits="PresentacionWeb.AltaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style2 {
            width: 100%;
            height: 246px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1" style="text-align: center">
    <strong><span class="auto-style3">Agregar Venta</span><br /></strong>
    <table class="auto-style2">
        <tr>
            <td>Artículos:
                        <asp:DropDownList ID="ddlArticulos" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Cantidad: 
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;Cliente:
                        <asp:DropDownList ID="ddlClientes" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Dirección : 
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
    <br />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
</div>
</asp:Content>
