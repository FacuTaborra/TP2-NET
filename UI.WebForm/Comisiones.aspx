<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.WebForm.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:Panel ID="grid" runat="server">
        <asp:GridView  ID="GridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" />
                <asp:BoundField DataField="Plan" HeaderText="Plan" />
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
                <asp:Label ID="DescripcionLabel" CssClass="formLabel" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control formTextBox mb-2 mr-sm-2"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DescReq" runat="server" ErrorMessage="Ingrese una descripción" ControlToValidate="txtDescripcion" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="AnioEspecialidadLabel" CssClass="formLabel" runat="server" Text="Año Especialidad"></asp:Label>
                <asp:TextBox ID="txtAnioEspecialidad" CssClass="form-control formTextBox mb-2 mr-sm-2"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="anioEspReq" runat="server" ErrorMessage="Ingrese una Año" ControlToValidate="txtAnioEspecialidad" ForeColor="Red">#</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="anioInRange" runat="server" ErrorMessage="Año Inválido. El año será válido desde 1990 hasta 2030" MaximumValue="2030" MinimumValue="1990" ControlToValidate="txtAnioEspecialidad" ForeColor="Red">#</asp:RangeValidator>
            </div>            
            <div class="formRow">
                <asp:Label ID="PlanLabel" CssClass="formLabel" runat="server" Text="Plan"></asp:Label>
                <asp:DropDownList ID="ddlPlanes" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
        <asp:ValidationSummary ID="errores" ForeColor="Red" runat="server"/>
        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
   </asp:Panel>


</asp:Content>
