<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="cimatub_.Pantallas.Perfil" %>

<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Recursos/CSS/Perfilpro.css" rel="stylesheet" />
    <div class="main-content">
        <div class="header">
            <button class="regresar-btn" onclick="window.history.back();">< Regresar</button>
            <h2 class="perfil-titulo">Perfil de usuario</h2>
        </div>

        <div class="profile-container">

            <div class="profile-info">
                <asp:Image ID="imgProfile" runat="server" Height="80" Width="80" />
                
                <div class="details">
                    <!-- Nombre de usuario -->
                    <h3><asp:Label ID="lblUserName" runat="server" Text="Nombre"></asp:Label></h3>
                    <!-- Rol de usuario -->
                    <p><asp:Label ID="lblRole" runat="server" Text="rol"></asp:Label></p>
                    <!-- Correo de usuario -->
                    <p><asp:Label ID="lblEmail" runat="server" Text="correo@ejemplo.com"></asp:Label></p>
                </div>
            </div>

        </div>
        <h5 class="main-content h5">Opciones</h5>
        <div class="options">
            <button class="history">Ver mi historial de videos</button>
            <button class="logout">Cerrar Sesion</button>
        </div>
    </div>

</asp:Content>