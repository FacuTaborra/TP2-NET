<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionCurso.aspx.cs" Inherits="UI.WebForm.InscripcionCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 class="GridTitle" >Inscripcion a curso 2022 </h1>
  
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
            <asp:LinkButton ID="InscibirLinkButton"  class="actionPanelLink" runat="server" OnClick="InscibirLinkButton_Click" >Inscribirse</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" class="actionPanelLink lastLink" runat="server" OnClick="CancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        </div>
   </asp:Panel>


    <asp:Panel ID="formPanel"  CssClass="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
        <div class="formDiv">    
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="ID curso:"></asp:Label>
                <asp:TextBox ID="txtCurso" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Materia:"></asp:Label>
                <asp:TextBox ID="txtMateria" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Comision:"></asp:Label>
                <asp:TextBox ID="txtComision" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Plan:"></asp:Label>
                <asp:TextBox ID="txtPlan" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Año Especialidad:"></asp:Label>
                <asp:TextBox ID="txtAnioEsp" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label runat="server" CssClass="formLabel" Text="Año Cursado:"></asp:Label>
                <asp:TextBox ID="txtAnioCurso" CssClass="form-control formTextBox mb-2 mr-sm-2" enabled="false" runat="server"></asp:TextBox>
            </div>
        </div>

            <asp:Panel ID="Panel1" CssClass="formActionPanel" runat="server" >
                <div class="actionPanel">
                    <asp:LinkButton ID="finalizarLinkButton"  class="actionPanelLink" runat="server" OnClick="finalizarLinkButton_Click">Finalizar Inscripcion</asp:LinkButton>
                    <asp:LinkButton ID="cancelarInscLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="CancelarInscLinkButton_Click">Cancelar</asp:LinkButton>
                </div>
            </asp:Panel>
     </asp:Panel>
</asp:Content>
