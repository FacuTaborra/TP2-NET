<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.WebForm.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
 
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="apellido"/>
                <asp:BoundField HeaderText="EMail" DataField="Email"/>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ButtonType="Button">
                    <ControlStyle CssClass="btnSeleccionar btn btn-outline-info" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#50c9c3" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" CssClass="gridActionPanel" HorizontalAlign="Center" runat="server">
        <div class="actionPanel">
            <asp:LinkButton ID="nuevoLinkButton"  class="actionPanelLink" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="editarLinkButton" class="actionPanelLink" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" class="actionPanelLink lastLink" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        </div>
   </asp:Panel>


    <asp:Panel ID="formPanel" CssClass="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
        <div class="formDiv">
            <div class="formRow">
                <asp:Label ID="nombreLabel"  CssClass="formLabel" runat="server" Text="Nombre: " ></asp:Label>
                <asp:TextBox ID="nombreTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="nombreReq" runat="server" ErrorMessage="El nombre no puede estar vacío"
                 ControlToValidate ="nombreTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="apellidoLabel"  CssClass="formLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="apellidoTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="apellidoReq" runat="server" ErrorMessage="El apellido no puede estar vacío"
                 ControlToValidate ="apellidoTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="emailLabel"  CssClass="formLabel" runat="server" Text="EMail: "></asp:Label>
                <asp:TextBox ID="emailTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="emailReq" runat="server" ErrorMessage="El email no puede estar vacío"
                 ControlToValidate ="emailTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="isValidEmail" runat="server" ErrorMessage="El email ingresado es inválido"
                    ControlToValidate="emailTextBox" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">#</asp:RegularExpressionValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="habilitadoLabel"  CssClass="formLabel" runat="server" Text="Habilitado: "></asp:Label>
                <div class="habilitadoBox"><asp:CheckBox ID="habilitadoCheckBox" runat="server" /></div>
            </div>
            <div class="formRow">
                <asp:Label ID="nombreUsuarioLabel"  CssClass="formLabel" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="nombreUsuarioTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="usrNameReq" runat="server" ErrorMessage="El nombre de usuario no puede estar vacío"
                 ControlToValidate ="nombreUsuarioTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="claveLabel"  CssClass="formLabel" runat="server" Text="Clave:"></asp:Label>
                <asp:TextBox ID="claveTextBox" runat="server" CssClass="form-control formTextBox mb-2 mr-sm-2" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="claveReq" runat="server" ErrorMessage="La clave no puede estar vacía"
                 ControlToValidate ="claveTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="long" runat="server" ErrorMessage="La clave debe tener 8 o más caracteres"
                 ControlToValidate="claveTextBox" OnServerValidate="ValidarLongClave_ServerValidate" ForeColor ="Red">*</asp:CustomValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="repetirClaveLabel"  CssClass="formLabel" runat="server" Text="Repetir Clave:"></asp:Label>
                <asp:TextBox ID="repetirClaveTextBox" runat="server"  CssClass="form-control formTextBox mb-2 mr-sm-2" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="repetirClaveReq" runat="server" ErrorMessage="Es necesario repetir la clave"
                ControlToValidate ="repetirClaveTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="IgualClave" runat="server" ErrorMessage="Las claves ingresadas no coinciden"
                 ControlToValidate="claveTextBox" ControlToCompare="repetirClaveTextBox" Operator ="Equal"  Type="String" ForeColor="Red">#</asp:CompareValidator>
            </div>
        </div>

        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>

        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
    </asp:Panel>


</asp:Content>
