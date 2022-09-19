<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 101px;
        }
        .auto-style3 {
            width: 101px;
        }
        .auto-style4 {
            width: 101px;
            height: 48px;
        }
        .auto-style5 {
            height: 48px;
        }
        .auto-style6 {
            width: 100%;
            height: 124px;
        }
        .auto-style7 {
            height: 26px;
            width: 60px;
        }
        .auto-style8 {
            height: 23px;
            width: 60px;
        }
        .auto-style9 {
            width: 60px;
            height: 48px;
        }
        .auto-style10 {
            width: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style6">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style8"></td>
                <td class="auto-style1">
        <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td aria-sort="none" class="auto-style9">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style7">
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>
        <asp:Button ID="btnIgresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:LinkButton ID="lnkRecordarClave" runat="server" OnClick="lnkRecordarClave_Click">Olvidé mi Clave</asp:LinkButton>
                </td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
