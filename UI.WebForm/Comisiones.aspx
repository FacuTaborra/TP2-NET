<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.WebForm.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:Panel ID="grid" runat="server">
    
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" />
                <asp:BoundField DataField="Plan" HeaderText="Plan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ButtonType="Button"/>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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

    <asp:Panel ID="gridActionPanel" HorizontalAlign="Center"  runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" runat="server">
        <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="DescReq" runat="server" ErrorMessage="Ingrese una descripción" ControlToValidate="txtDescripcion" ForeColor="Red">#</asp:RequiredFieldValidator>--%>
        <br />
    
        <asp:Label ID="AnioEspecialidadLabel" runat="server" Text="Año Especialidad"></asp:Label>
        <asp:TextBox ID="txtAnioEspecialidad" runat="server"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="anioEspReq" runat="server" ErrorMessage="Ingrese una Año" ControlToValidate="txtAnioEspecialidad" ForeColor="Red">#</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="anioInRange" runat="server" ErrorMessage="Año Inválido. El año será válido desde 1990 hasta 2030" MaximumValue="2030" MinimumValue="1990" ControlToValidate="txtAnioEspecialidad" ForeColor="Red">#</asp:RangeValidator>--%>
        <br />

        <asp:Label ID="PlanLabel" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="ddlPlanes" runat="server">
        </asp:DropDownList>
        <br />
        
        <%--<asp:ValidationSummary ID="errores" ForeColor="Red" runat="server"/>--%>

        <asp:Panel ID="formActionPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
         </asp:Panel>
   </asp:Panel>


</asp:Content>
