<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="cimatub_.Pantallas.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/Historial.css") %>" rel="stylesheet" />

    <div class="container">
      <div class="header">
        <asp:Button ID="regresarBotonw" runat="server" CssClass="regresar-btn" Text="&lt; Regresar" OnClientClick="location.href='Inicio.aspx'; return false;" />
        <span class="textohistorial">Historial</span>
      </div>
      <div class="content">
        <asp:ListView ID="lstVideos" runat="server">
            <ItemTemplate>
                <!-- Contenedor de cada video -->
                <div class="video-item">
                    <!-- Miniatura del video -->
                    <asp:ImageButton 
                         ID="imgMiniatura" 
                         runat="server" 
                         CssClass="video-thumbnail"
                         ImageUrl='<%# Eval("Img") %>'
                         OnClick="VerVideo" 
                         CommandArgument='<%# Eval("IdVideo") %>' 
                         width="200px" height="100px" />

                    <div class="video-info">
                        <h3 class="video-title"><%# Eval("Titulo") %></h3>
                        <p class="video-description"><%# Eval("Descripcion") %></p>
                    </div>
                    
                </div>
                <div class="video-divider-container">
                    <hr class="video-divider" />
                </div>
            </ItemTemplate>
        </asp:ListView>
      </div>
    </div>

    
</asp:Content>