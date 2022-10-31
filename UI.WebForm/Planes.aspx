<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs"  Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <asp:Panel ID="gridPanel" runat="server">
       <asp:GridView ID="gridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White"  OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" Height="157px" Width="485px" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           <Columns>
               <asp:BoundField HeaderText="Id Plan" DataField="ID"/>
               <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
               <asp:BoundField HeaderText="Especialidad" DataField="Especialidad"/>
               <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ButtonType="Button"/>
           </Columns>
           <EditRowStyle BackColor="#999999" />
           <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#E9E7E2" />
           <SortedAscendingHeaderStyle BackColor="#506C8C" />
           <SortedDescendingCellStyle BackColor="#FFFDF8" />
           <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
       </asp:GridView>
   </asp:Panel>

    <asp:Panel ID="gridActionsPanel" HorizontalAlign="Center" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" HorizontalAlign="Center" Visible="false" runat="server">
        <asp:Label ID="IDPlanLabel" runat="server" Text="ID Plan"></asp:Label>
        <asp:TextBox ID="IDPlanTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br/>

        <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="descripReq" runat="server" ErrorMessage="La descripcion del Plan no puede estar vacía"
         ControlToValidate ="DescripcionTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br/>

        <asp:Label ID="IDEspecialidadLabel" runat="server" Text="ID Especialidad"></asp:Label>
        <asp:TextBox ID="IDEspecialidadTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="IDEspReq" runat="server" ErrorMessage="El ID de la Especialidad del Plan no puede estar vacío"
         ControlToValidate ="IDEspecialidadTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
        <br />

        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>



</asp:Content>

