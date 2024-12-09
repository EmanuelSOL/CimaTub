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
                <img alt="foto de usuario" height="80" src="~/Recursos/Imagenes/logo.png" width="80" />
                <div class="details">
                    <h3>Adriana Valles</h3>
                    <p>Docente</p>
                    <p>adriana.valles.89@uabc.edu.mx</p>
                </div>
            </div>

        </div>
            <div class="options">
                <button class="history">Ver mi historial de videos</button>
                <button class="logout">Cerrar Sesion</button>
            </div>
    </div>

</asp:Content>