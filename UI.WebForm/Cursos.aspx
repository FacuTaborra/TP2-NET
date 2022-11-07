<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.WebForm.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 class="GridTitle" >Cursos</h1>
    <asp:Panel runat="server" ID="gridPanel">
         <asp:GridView  ID="GridViewCursos" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID"  CellPadding="4"  OnSelectedIndexChanged="GridViewCursos_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />            
             <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Comision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
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

    <asp:Panel ID="formPanel"  CssClass="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
        <div class="formDiv">    
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Materia:"></asp:Label>
                <asp:DropDownList ID="ddlMateria" CssClass="btn btn-secondary dropdown-toggle" data-toggle="dropdown" runat="server"></asp:DropDownList>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Comision:"></asp:Label>
                <asp:DropDownList ID="ddlComision" CssClass="btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Anio:"></asp:Label>
                <asp:TextBox ID="txtAnio" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Cupo:"></asp:Label>
                <asp:TextBox ID="txtCupo" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
            </div>
            </div>

            <asp:Panel ID="Panel1" CssClass="formActionPanel" runat="server" >
                <div class="actionPanel">
                    <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
                </div>
            </asp:Panel>
     </asp:Panel>
</asp:Content>
