<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogueoEmpleado.aspx.cs" Inherits="LogueoEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body style="background-color: #C0C0C0">
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%; text-align: center;">
            <caption class="auto-style1">
                <strong>Iniciar Sesión</strong></caption>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nombre de usuario: <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contraseña:
                    <asp:TextBox ID="txtPassUsu" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Nombre:
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogueo" runat="server" OnClick="btnLogueo_Click" Text="Ingresar"/>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
