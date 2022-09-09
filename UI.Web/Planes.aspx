<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <asp:Panel ID="gridPanel" runat="server">
       <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White"  OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="206px" Width="488px">
           <Columns>
               <asp:BoundField HeaderText="Id Plan" DataField="ID"/>
               <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
               <asp:BoundField HeaderText="Id Especialidad" DataField="IDEspecialidad"/>
               <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ButtonType="Button"> </asp:CommandField>
           </Columns>
           <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
           <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
           <RowStyle BackColor="White" ForeColor="#330099" />
           <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
           <SortedAscendingCellStyle BackColor="#FEFCEB" />
           <SortedAscendingHeaderStyle BackColor="#AF0101" />
           <SortedDescendingCellStyle BackColor="#F6F0C0" />
           <SortedDescendingHeaderStyle BackColor="#7E0000" />
       </asp:GridView>
   </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" >Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" >Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="IDPlanLabel" runat="server" Text="ID Plan"></asp:Label>
        <asp:TextBox ID="IDPlanTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br/>
        <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="IDEspecialidadLabel" runat="server" Text="ID Especialidad"></asp:Label>
        <asp:TextBox ID="IDEspecialidadTextBox" runat="server"></asp:TextBox>
    </asp:Panel>

    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" >Cancelar</asp:LinkButton>
    </asp:Panel>

</asp:Content>

