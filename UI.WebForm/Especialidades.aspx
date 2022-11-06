<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.WebForm.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
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
                <asp:Label ID="IDLabel" runat="server" CssClass="formLabel" Text="ID: " ></asp:Label>
                <asp:TextBox ID="IDTextBox" runat="server" CssClass="form-control formTextBox mb-2 mr-sm-2" enable="false" Enabled="False"></asp:TextBox>
            </div>
            <div class="formRow">
            <asp:Label ID="descripcionLabel" CssClass="formLabel" runat="server" Text="Descripción: " ></asp:Label>
            <asp:TextBox ID="descripcionTextBox" type="text" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="descripcionReq" runat="server" ErrorMessage="El campo descripcion no puede estar vacío"
             ControlToValidate ="descripcionTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>
        </div>

        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
     </asp:Panel>
    
</asp:Content>
