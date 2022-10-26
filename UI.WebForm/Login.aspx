<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="UI.WebForm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Table ID="loginPanel" runat="server">
                   <asp:TableRow>
                        <asp:TableCell><asp:Label ID="labelUsrName" Text="Nombre de usuario:" runat="server"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtUsrName" runat="server"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:RequiredFieldValidator ID="usrNameReq" runat="server" ControlToValidate="txtUsrName" ErrorMessage="Ingrese su nombre de usuario." ForeColor="Red"></asp:RequiredFieldValidator></asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                        <asp:TableCell><asp:Label ID="labelPassword" Text="Contraseña:" runat="server"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></asp:TableCell>   
                        <asp:TableCell><asp:RequiredFieldValidator ID="passReq" runat="server" ControlToValidate="txtPassword" forecolor="Red" ErrorMessage="Ingrese su contraseña."></asp:RequiredFieldValidator></asp:TableCell>
                   </asp:TableRow>
               </asp:Table>  
              <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" /> <br />
                <asp:Label ID="labelErrorInicio" Text="Nombre de usuario y/o contraseña incorrectos." ForeColor="Red" Visible="false" runat="server"></asp:Label>
</asp:Content>
