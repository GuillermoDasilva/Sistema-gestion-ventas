<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="ABMCategoria.aspx.cs" Inherits="PresentacionWeb.ABMCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">



        .auto-style4 {
            text-decoration: underline;
            font-size: large;
        }
        .auto-style5 {
            text-decoration: underline;
            width: 1546px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <span class="auto-style4"><strong>Mantenimiento Categorías</strong></span><br />
        <br style="text-align: center" />
        <table class="auto-style5" style="text-align: center; background-color: #C0C0C0; border: medium double #C0C0C0">
            <tr>
                <td>Código:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                    <br />
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lnkbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
</asp:Content>
