<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personas.aspx.cs" Inherits="UI.WebForm.personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="gvPersonas" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
            <asp:BoundField DataField="Plan" HeaderText="Plan" />
            <asp:BoundField DataField="TipoPersona" HeaderText="Tipo Persona" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="NuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="EditarLinkButton" runat="server" OnClick="EditarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="EliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="ApellidoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="DireccionTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Fecha Nacimiento"></asp:Label>
        <asp:TextBox ID="DateTimeTextBox" runat="server" TextMode="DateTime"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="PlanDropDownList" runat="server" OnLoad="PlanDropDownList_Load">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Tipo Persona"></asp:Label>
        <asp:DropDownList ID="TipoPersonaDropDownList" runat="server" OnLoad="TipoPersonaDropDownList_Load">
        </asp:DropDownList>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="AceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
