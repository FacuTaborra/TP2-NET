<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosComision.aspx.cs" Inherits="UI.WebForm.AlumnosComision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 class="GridTitle">Cargar Notas Alumnos</h1>
<asp:Panel runat="server" ID="gridPanel">
         <asp:GridView  ID="GridView" CssClass="table table-striped" runat="server" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" HorizontalAlign="Center" SelectedRowStyle-ForeColor="White" DataKeyNames="ID"  CellPadding="4"   ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />            
             <Columns>
                <%--<asp:BoundField DataField="ID" HeaderText="ID" />--%>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="NombreYApellido" HeaderText="Alumno" />
                <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                <asp:BoundField DataField="ValorNota" HeaderText="Nota" />
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
            <asp:LinkButton ID="cargarNotaLinkButton"  class="actionPanelLink" runat="server" OnClick="cargarNotaLinkButton_Click"  >Cargar Nota</asp:LinkButton>         
        </div>
    <asp:Label ID="SeleccionarLabel" runat="server" ForeColor="Red" Text="Seleccione un alumno" Visible="false"></asp:Label>
   </asp:Panel>

   <asp:Panel ID="formPanel" CssClass="formPanel" Visible="false" HorizontalAlign="Center" runat="server">
        <div class="formDiv">
             <div class="formRow">
                <asp:Label ID="Label1" CssClass="formLabel" runat="server" Text="Legajo: " ></asp:Label>
                <asp:TextBox ID="legajoTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label ID="AlumnoLabel" CssClass="formLabel" runat="server" Text="Alumno: " ></asp:Label>
                <asp:TextBox ID="AlumnoTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server" Enabled="False"></asp:TextBox>
            </div>
            <div class="formRow">
                <asp:Label ID="notaLabel" CssClass="formLabel" runat="server" Text="Nota: " ></asp:Label>
                <asp:TextBox ID="NotaTextBox" CssClass="form-control formTextBox mb-2 mr-sm-2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="notaReq" runat="server" ErrorMessage="Por favor, ingrese una nota" ControlToValidate ="NotaTextBox" ForeColor="Red">#</asp:RequiredFieldValidator>
            </div>
            
        <asp:ValidationSummary ID="Errores" ForeColor="Red" runat="server"/>
        <asp:Label ID="labelNotaInvalida" runat="server" ForeColor="Red" Text="La nota ingresada es inválida." Visible="false"></asp:Label>
        <asp:Label ID="labelNotasValidas" runat="server" ForeColor="Red" Text="La nota debe ser un número enero entre 0 y 10" Visible="false"></asp:Label>
         </div>
        
        <asp:Panel ID="formActionPanel" CssClass="formActionPanel" runat="server" >
            <div class="actionPanel">
                <asp:LinkButton ID="aceptarLinkButton"  class="actionPanelLink" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton"  class="actionPanelLink lastLink" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </div> 
        </asp:Panel>
            </asp:Panel>

</asp:Content>
