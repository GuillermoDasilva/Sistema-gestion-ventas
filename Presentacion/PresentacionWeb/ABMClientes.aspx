<%@ Page Title="" Language="C#" MasterPageFile="~/UnaPMMenu.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="PresentacionWeb.ABMClientes" %>
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
        height: 56px;
    }
    .auto-style8 {
        width: 62px;
        height: 56px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
    <span class="auto-style4"><strong style="text-align: center">Mantenimiento Clientes</strong></span><br />
    <br />
    <table class="auto-style6" style="text-align: center; background-color: #C0C0C0; border: medium double #C0C0C0">
        <tr>
            <td>Cédula:</td>
            <td>
                <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td>Número de tarjeta:</td>
            <td>
                <asp:TextBox ID="txtNumTarjeta" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td>Teléfono:</td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                <br />
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" style="height: 26px" />
            </td>
            <td class="auto-style7"></td>
            <td class="auto-style8">
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
