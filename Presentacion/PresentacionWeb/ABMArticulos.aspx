<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="PresentacionWeb.ABMArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .auto-style4 {
            text-decoration: underline;
            font-size: large;
        }
        .auto-style5 {
            width: 62px;
        }
        .auto-style6 {
            text-decoration: underline;
            width: 1545px;
        }
        .auto-style7 {
            width: 181px;
        }
        .auto-style8 {
            width: 158px;
        }
        .auto-style9 {
            width: 181px;
            height: 26px;
        }
        .auto-style10 {
            width: 158px;
            height: 26px;
        }
        .auto-style11 {
            width: 62px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <span class="auto-style4"><strong>Mantenimiento Artículos</strong></span><br />
        <br />
        <table class="auto-style6" style="text-align: center; background-color: #C0C0C0; border: medium double #C0C0C0">
            <tr>
                <td class="auto-style9">Código:</td>
                <td class="auto-style10" style="text-align: center">
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style7">Nombre:</td>
                <td class="auto-style8" style="text-align: center">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Precio:</td>
                <td class="auto-style8" style="text-align: center">
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style7">Tipo:</td>
                <td class="auto-style8" style="text-align: center">
                    <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style7">Tamaño:</td>
                <td class="auto-style8" style="text-align: center">
                    <asp:TextBox ID="txtTamaño" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style7">Categoría</td>
                <td class="auto-style8" style="text-align: center">
                    <asp:DropDownList ID="ddlCategoria" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                    <br />
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td class="auto-style8" style="text-align: center"></td>
                <td class="auto-style5">
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
