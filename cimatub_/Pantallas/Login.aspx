<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cimatub_.Pantallas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="<%= ResolveUrl("~/recursos/CSS/Login.css?v=@DateTime.Now.Ticks") %>" rel="stylesheet" />
    <div id="login-container">
        <div class="strip_left">
            <div class="bicolor-strip-green"></div>
            <div class="bicolor-strip-amarilla"></div>
        </div>
        
        <div class="strip_left">
            <div class="bicolor-strip-green-right"></div>
            <div class="bicolor-strip-amarilla-right"></div>
        </div>

        <label for="Correo_institucional" class="form-label">Correo institucional</label>
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Correo Institucional" CssClass="input-text" TextMode="Email" required="true"></asp:TextBox>

        <label for="Contraseña" class="form-label">Contraseña</label>
        <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" CssClass="input-text" TextMode="Password" required="true"></asp:TextBox>


        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="button" OnClick="login" />

        <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        <br> <!-- Fuerza el salto de línea -->
        <a id="login-register-link" href="Register.aspx">¿No estás registrado?</a>
        <div id="shadow-bottom"></div>

    </div>
</asp:Content>