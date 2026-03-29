<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <div style="text-align: center">
    
        <span class="auto-style1"><strong>Pagina Principal</strong></span><br />
        <br />
    
        <asp:LinkButton ID="lnkbtnMC" runat="server" OnClick="lnkbtnMC_Click" PostBackUrl="~/ABMCategorias.aspx">Mantenimiento de Categorias</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lnkbtnMA" runat="server" OnClick="lnkbtnMA_Click" PostBackUrl="~/ABMArticulos.aspx">Mantenimiento de Artículos</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lnkbtnMClientes" runat="server" OnClick="lnkbtnMClientes_Click" PostBackUrl="~/ABMClientes.aspx">Mantenimiento de Clientes</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="lnkbtnAltaVentas" runat="server" OnClick="lnkbtnAltaVentas_Click" PostBackUrl="~/AltaVenta.aspx">Alta Venta</asp:LinkButton>
    
        <br />
        <br />
        <asp:LinkButton ID="lnkbtnCerrarsesion" runat="server" OnClick="lnkbtnCerrarsesion_Click" PostBackUrl="~/LogueoEmpleado.aspx">Cerrar Sesión</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
