<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaVenta.aspx.cs" Inherits="AltaVenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            font-size: large;
            height: 553px;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style2 {
            width: 100%;
            height: 246px;
        }
        </style>
</head>
<body style="background-color: #C0C0C0">
    <form id="form2" runat="server">
        <div class="auto-style1" style="text-align: center">
            <strong><span class="auto-style3">Agregar Venta</span><br />
            </strong>
            <table class="auto-style2">
                <tr>
                    <td>Artículos:
                        <asp:DropDownList ID="ddlArticulos" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Cantidad: <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;Cliente:
                        <asp:DropDownList ID="ddlClientes" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Dirección : <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
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
    </form>
</body>
</html>
