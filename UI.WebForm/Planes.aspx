<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs"  Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     
       <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
               <asp:BoundField HeaderText="Id Plan" DataField="ID"/>
               <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
               <asp:BoundField HeaderText="Especialidad" DataField="Especialidad"/>
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
                <asp:Label ID="IDPlanLabel"  CssClass="formLabel" runat="server" Text="ID Plan"></asp:Label>
                <asp:TextBox ID="IDPlanTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label ID="DescripcionLabel"  CssClass="formLabel" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="DescripcionTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="descripReq" runat="server" ErrorMessage="La descripcion del Plan no puede estar vacía"
                 ControlToValidate ="DescripcionTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="IDEspecialidadLabel"  CssClass="formLabel" runat="server" Text="ID Especialidad"></asp:Label>
                <asp:DropDownList ID="ddlEspecialidad" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>

        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
       </asp:Panel>
    </asp:Panel>



</asp:Content>

