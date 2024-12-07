<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cimatub_.Pantallas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenedor del formulario de inicio de sesión -->
    <div id="login-container">
        <input id="login-email" type="email" placeholder="Correo Institucional" required>
        <input id="login-password" type="password" placeholder="Contraseña" required>
        <button id="login-button" type="submit">Iniciar Sesión</button>
        <a id="login-register-link" href="#">¿No estás registrado?</a>
    </div>
</asp:Content>