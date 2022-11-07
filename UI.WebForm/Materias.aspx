<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.WebForm.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <h1 class="GridTitle" >Materias</h1>
    <div class="filtroDiv">
        <asp:Label  CssClass="formLabel" runat="server" Text="Filtrar por plan: "></asp:Label> <asp:dropDownList ID="ddlFiltroPlan"  CssClass="btn btn-secondary dropdown-toggle" runat="server" ></asp:dropDownList>
    </div>    
            <asp:Panel ID="Panel1" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="FiltrarLinkButton"  class="actionPanelLink" runat="server" OnClick="FiltrarLinkButton_Click">Filtrar</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>

     <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                <asp:BoundField HeaderText="HS Semanales" DataField="HSSemanales"/>
                <asp:BoundField HeaderText="HS Totales" DataField="HSTotales"/>
                <asp:BoundField HeaderText="Plan" DataField="Plan"/>
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
                <asp:Label ID="IDLabel" CssClass="formLabel" runat="server" Text="ID: " ></asp:Label>
                <asp:TextBox ID="IDTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label ID="DescripcionLabel" CssClass="formLabel" runat="server" Text="Decripcion: " ></asp:Label>
                <asp:TextBox ID="DescripcionTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DescripcionReq" runat="server" ErrorMessage="La Descripcion no puede estar vacía" ControlToValidate ="DescripcionTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="HSSemanalesLabel" CssClass="formLabel" runat="server" Text="HSSemanales: " ></asp:Label>
                <asp:TextBox ID="HSSemanalesTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="HSSemanalesReq" runat="server" ErrorMessage="El Campo no puede estar vacía" ControlToValidate ="HSSemanalesTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="HSTotalesLabel" CssClass="formLabel" runat="server" Text="HSTotales: " ></asp:Label>
                <asp:TextBox ID="HSTotalesTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="HSTotaleReq" runat="server" ErrorMessage="El Campo no puede estar vacía" ControlToValidate ="HSTotalesTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            <div class="formRow">
                <asp:Label ID="PlanLabel" CssClass="formLabel" runat="server" Text="Plan: " ></asp:Label>
                <asp:DropDownList ID="ddlPlan"  CssClass="btn btn-secondary dropdown-toggle" runat="server" OnLoad="ddlPlan_Load"></asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="PlanReq" runat="server" ErrorMessage="Seleccione un plan" ControlToValidate ="ddlPlan" ForeColor="Red">#</asp:RequiredFieldValidator>--%>        
            </div>

        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>
        <asp:Label ID="labelErrorFK" runat="server" ForeColor="Red" Text="No es posible eliminar la materia por tener cursos asociados" Visible="false"></asp:Label>
        
        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
    </asp:Panel>
</asp:Content>
