﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.WebForm.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

     <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                <asp:BoundField HeaderText="HS Semanales" DataField="HSSemanales"/>
                <asp:BoundField HeaderText="HS Totales" DataField="HSTotales"/>
                <asp:BoundField HeaderText="Plan" DataField="IDPlan"/>
                <asp:CommandField SelectText="Seleccioar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="IDLabel" runat="server" Text="ID: " ></asp:Label>
        <asp:TextBox ID="IDTextBox" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="DescripcionLabel" runat="server" Text="Decripcion: " ></asp:Label>
        <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="DescripcionReq" runat="server" ErrorMessage="La Descripcion no puede estar vacía" ControlToValidate ="DescripcionTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="HSSemanalesLabel" runat="server" Text="HSSemanales: " ></asp:Label>
        <asp:TextBox ID="HSSemanalesTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="HSSemanalesReq" runat="server" ErrorMessage="El Campo no puede estar vacía" ControlToValidate ="HSSemanalesTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="HSTotalesLabel" runat="server" Text="HSTotales: " ></asp:Label>
        <asp:TextBox ID="HSTotalesTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="HSTotaleReq" runat="server" ErrorMessage="El Campo no puede estar vacía" ControlToValidate ="HSTotalesTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PlanLabel" runat="server" Text="Plan: " ></asp:Label>
        <asp:TextBox ID="PlanTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PlanReq" runat="server" ErrorMessage="El Campo no puede estar vacía" ControlToValidate ="PlanTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>        
        <br />

        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>

        <asp:Panel ID="formActionPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
         </asp:Panel>
    </asp:Panel>



</asp:Content>
