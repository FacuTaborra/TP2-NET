<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComisionesProfesor.aspx.cs" Inherits="UI.WebForm.ComisionesProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    
    <h1 class="GridTitle" >Comisiones Profesor </h1>
        <asp:Label ID="prueba" runat="server"></asp:Label>
        <asp:Panel runat="server" ID="gridPanel">
         <asp:GridView  ID="GridView" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID"  CellPadding="4"   ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView_SelectedIndexChanged1">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />            
             <Columns>
                <asp:BoundField DataField="ComisionCurso" HeaderText="Comision" />
                <asp:BoundField DataField="MateriaCurso" HeaderText="Materia" />
                <asp:BoundField DataField="AñoCalendarioCurso" HeaderText="Año Calendario" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:BoundField DataField="PlanCurso" HeaderText="Plan" />
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
            <asp:LinkButton ID="alumnosComLinkButton"  class="actionPanelLink" runat="server" OnClick="alumnosComLinkButton_Click" >Ver Alumnos Comision</asp:LinkButton>
        </div>
   </asp:Panel>


</asp:Content>
