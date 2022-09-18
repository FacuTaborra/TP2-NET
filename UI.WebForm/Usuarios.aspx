<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.WebForm.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="apellido"/>
                <asp:BoundField HeaderText="EMail" DataField="Email"/>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado"/>
                <asp:CommandField SelectText="Seleccioar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>


    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " ></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreReq" runat="server" ErrorMessage="El nombre no puede estar vacío"
         ControlToValidate ="nombreTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="apellidoReq" runat="server" ErrorMessage="El apellido no puede estar vacío"
         ControlToValidate ="apellidoTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="emailReq" runat="server" ErrorMessage="El email no puede estar vacío"
         ControlToValidate ="emailTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="isValidEmail" runat="server" ErrorMessage="El email ingresado es inválido"
            ControlToValidate="emailTextBox" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">#</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="usrNameReq" runat="server" ErrorMessage="El nombre de usuario no puede estar vacío"
         ControlToValidate ="nombreUsuarioTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="claveReq" runat="server" ErrorMessage="La clave no puede estar vacía"
         ControlToValidate ="claveTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="longClave" runat="server" ErrorMessage="La clave debe tener 8 caracteres o más"
         ControlToValidate="claveTextBox" OnServerValidate="ValidarLongClave_ServerValidate" ForeColor ="Red">#</asp:CustomValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave:"></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="repetirClaveReq" runat="server" ErrorMessage="Es necesario repetir la clave"
        ControlToValidate ="repetirClaveTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="IgualClave" runat="server" ErrorMessage="Las claves ingresadas no coinciden"
         ControlToValidate="claveTextBox" ControlToCompare="repetirClaveTextBox" Operator ="Equal"  Type="String" ForeColor="Red">#</asp:CompareValidator>
        <br />

        
        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>

        <br />
        <asp:Panel ID="formActionPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
         </asp:Panel>
    </asp:Panel>


</asp:Content>
