<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriasPlan.aspx.cs" Inherits="UI.WebForm.MateriasPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <h1 class="GridTitle" >Materias del plan <asp:Label ID="descPlan" runat="server" ></asp:Label></h1>

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView  ID="gridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                <asp:BoundField HeaderText="HS Semanales" DataField="HSSemanales"/>
                <asp:BoundField HeaderText="HS Totales" DataField="HSTotales"/>
                <asp:BoundField HeaderText="Plan" DataField="Plan"/>
                
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#50c9c3" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
