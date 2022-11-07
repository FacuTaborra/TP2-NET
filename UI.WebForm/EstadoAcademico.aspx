<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.WebForm.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 class="GridTitle" >Estado Académico</h1>

    <asp:Panel runat="server" ID="gridPanel">
         <asp:GridView  ID="GridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID"  CellPadding="4"  ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />            
             <Columns>
                
                <asp:BoundField DataField="Curso.Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Condicion" HeaderText="Estado" />
                <asp:BoundField DataField="Curso.PlanComision" HeaderText="Plan" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#50c9c3" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </asp:Panel>

</asp:Content>
