<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrativos.aspx.cs" Inherits="UI.WebForm.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Legajo" DataField="Legajo"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="Direccion" DataField="Direccion"/>
                <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNacimiento"/>
                <asp:BoundField HeaderText="EMail" DataField="Email"/>
                <asp:BoundField HeaderText="Teléfono" DataField="Telefono"/>
                <asp:BoundField HeaderText="Tipo Persona" DataField="TipoPersona"/>
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
                <asp:Label ID="legajoLabel"  CssClass="formLabel" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="legajoTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="legajoReq" runat="server" ErrorMessage="El legajo no puede estar vacío"
                 ControlToValidate ="legajoTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
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
                <asp:Label ID="direccionLabel"  CssClass="formLabel" runat="server" Text="Direccion: "></asp:Label>
                <asp:TextBox ID="direcTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="direccReq" runat="server" ErrorMessage="La dirección no puede estar vacía"
                 ControlToValidate ="direcTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="fechaNacLabel"  CssClass="formLabel" runat="server" Text="Fecha de nacimiento: "></asp:Label>
                <asp:TextBox ID="fechaNacTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="fechaNacReq" runat="server" ErrorMessage="La fecha de nacimiento no puede estar vacía"
                 ControlToValidate ="fechaNacTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            ¿<div class="formRow">
                <asp:Label ID="telefonoLabel"  CssClass="formLabel" runat="server" Text="Fecha de nacimiento: "></asp:Label>
                <asp:TextBox ID="telefonoTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="telReq" runat="server" ErrorMessage="El telefono no puede estar vacío"
                 ControlToValidate ="telefonoTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="PlanLabel" visible="false" CssClass="formLabel" runat="server" Text="Plan: " ></asp:Label>
                <asp:DropDownList ID="ddlPlan" visible="false"  CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="PlanReq" runat="server" ErrorMessage="Seleccione un plan" ControlToValidate ="ddlPlan" ForeColor="Red">#</asp:RequiredFieldValidator>--%>        
            </div>
            <div class="formRow">
                <asp:Label ID="tipoPersonaLabel" CssClass="formLabel" runat="server" Text="Tipo Persona: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoPersona"  CssClass="btn btn-secondary dropdown-toggle" runat="server">
                    <asp:ListItem>Administrador</asp:ListItem>
                    <asp:ListItem>Alumno</asp:ListItem>
                    <asp:ListItem>Profesor</asp:ListItem>
                    <asp:ListItem>Seleccionar</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="PlanReq" runat="server" ErrorMessage="Seleccione un plan" ControlToValidate ="ddlPlan" ForeColor="Red">#</asp:RequiredFieldValidator>--%>        
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
