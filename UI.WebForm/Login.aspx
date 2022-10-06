<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebForm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="formLogin" Visible="true" runat="server">

        <table>
            <tr>
                <td>
                    <asp:Label ID="usrLabel" runat="server" Text="Nombre de Usuario: "></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="usrTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="usrReq" runat="server" ErrorMessage="Debe ingresar su nombre de usuario."
         ControlToValidate ="usrTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="passwordLabel" runat="server" Text="Clave : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="passwordReq" runat="server" ErrorMessage="Debe ingresar su clave."
         ControlToValidate ="passwordTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="validaciones" runat="server">
        <asp:ValidationSummary ID="errores" ForeColor="Red" runat="server"/>
        <asp:Label ID="usrExiste" runat="server" ForeColor="Red" Text="Usuario y/o contraseña inválidos." visible="false"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="LoginActionPanel" runat="server">
        <asp:LinkButton ID="ingresarLinkButton" runat="server" OnClick="ingresarLinkButton_Click">Iniciar Sesion</asp:LinkButton> 
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">Olvidé mi clave</asp:LinkButton>
    </asp:Panel>
</asp:Content>
