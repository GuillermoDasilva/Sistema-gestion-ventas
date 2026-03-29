<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMCategorias.aspx.cs" Inherits="ABMCategorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


        .auto-style4 {
            text-decoration: underline;
            font-size: large;
        }
        .auto-style1 {
            width: 100%;
        }
        </style>
</head>
<body style="background-color: #C0C0C0">
    <form id="form2" runat="server">
    <div style="text-align: center">
    
        <span class="auto-style4"><strong>Mantenimiento Categorías</strong></span><br />
        <br />
        <table class="auto-style1" style="text-align: center; background-color: #C0C0C0; border: medium double #C0C0C0">
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
                <td>&nbsp;</td>
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
    </form>
    </body>
</html>
