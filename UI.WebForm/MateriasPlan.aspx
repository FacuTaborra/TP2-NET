<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriasPlan.aspx.cs" Inherits="UI.WebForm.MateriasPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <h1 class="GridTitle" >Materias</h1>
    <div class="filtroDiv">
        <asp:Label  CssClass="formLabel" runat="server" Text="Filtrar por plan: "></asp:Label> <asp:dropDownList ID="ddlPlan"  CssClass="btn btn-secondary dropdown-toggle" runat="server" OnLoad="descPlan_Load" ></asp:dropDownList>
    </div>    
            <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="FiltrarLinkButton"  class="actionPanelLink" runat="server" OnClick="FiltrarLinkButton_Click">Filtrar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
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
</asp:Content>
