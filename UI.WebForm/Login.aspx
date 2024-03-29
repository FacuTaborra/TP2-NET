﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebForm.Login1" %>


<!doctype html>
<html lang="es">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Ingresar</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <link href="Styles/StylesLogin.css" rel="stylesheet" type="text/css" />
  </head>
  <body>
      <div class="LoginPage">
          <div class="contentLogin">
                <div class="imgLogin">
                   <img src="Images/logo-utn.png"/>
                   <span>Sistema de Gestión</span>
                </div>
                <div class="formLogin">
                <form id="formLogin" runat="server">
                        <div class="loginRow">
                            <asp:Label ID="labelUsrName" class="formLabel" Text="Nombre de usuario:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtUsrName" class="formTxt" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="usrNameReq" runat="server" ControlToValidate="txtUsrName" ErrorMessage="Ingrese su nombre de usuario." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="loginRow">
                            <asp:Label ID="labelPassword" class="formLabel" Text="Contraseña:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtPassword" type="password" class="formTxt" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="passReq" runat="server" ControlToValidate="txtPassword" forecolor="Red" ErrorMessage="Ingrese su contraseña."></asp:RequiredFieldValidator>
                        </div>
                        <div class="loginRow" ID="divErrorInicio" visible="false" runat="server">                        
                            <asp:Label ID="labelErrorInicio" Text="Nombre de usuario y/o contraseña incorrectos." ForeColor="Red" runat="server"></asp:Label>
                        </div>                        
                        <asp:Button ID="btnIngresar" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </form>
                </div>

          </div>
      </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
  </body>
</html>
