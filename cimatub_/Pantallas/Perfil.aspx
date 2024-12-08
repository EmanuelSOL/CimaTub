<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="cimatub_.Pantallas.Perfil" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/Perfil.css") %>" rel="stylesheet" />
    <div id="perfil-contenedor">
        <!-- Información del perfil -->
        <div id="perfil-informacion">
            <asp:Label ID="lblNombre" runat="server" CssClass="perfil-nombre"></asp:Label>
            <asp:Label ID="lblRol" runat="server" CssClass="perfil-rol"></asp:Label>
            <asp:Label ID="lblCorreo" runat="server" CssClass="perfil-correo"></asp:Label>
            <div id="perfil-opciones">
                <asp:Button ID="btnHistorial" runat="server" Text="Ver mi historial de videos" CssClass="perfil-boton perfil-boton-historial" OnClick="VerHistorial" />
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="perfil-boton perfil-boton-cerrar" OnClick="CerrarSesion" />
            </div>
        </div>
        <!-- Foto del perfil -->
        <div id="perfil-foto-contenedor">
            <asp:Image ID="imgFotoPerfil" runat="server" CssClass="perfil-foto" AlternateText="Foto de Perfil" />
        </div>
    </div>
</asp:Content>
