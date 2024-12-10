<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.Pantallas.video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="video-container">
        
        <!-- Botón Regresar -->
        <asp:Button ID="btnRegresar" CssClass="back-button" runat="server" Text="&lt;Regresar" OnClick="btnRegresar_Click" />
    
        <div class="main-layout">
            <!-- Columna izquierda: Video y detalles -->
            <div class="left-column">
                <!-- Contenedor del Video -->
                <div class="video-placeholder">
                    <div class="video-wrapper">
                        <iframe id="videoPlayer" src='<%# ResolveUrl(VideoUrl) %>' frameborder="0" allowfullscreen></iframe>
                    </div>
                </div>

                <!-- Información del Video -->
                <div class="video-info">
                    <div class="video-header">
                        <img src="<%# UserProfileImage %>" alt="Foto del usuario" class="user-image" />
                        <div class="video-details">
                            <h3 class="user-name"><%# UserName %></h3>
                            <p class="video-title"><%# VideoTitle %></p>
                        </div>
                        <span class="video-views"><%# Views %> vistas</span>
                    </div>
                    <p class="video-description"><%# VideoDescription %></p>
                </div>
            </div>

                
      
                

            <!-- Columna derecha: Feedback y comentarios -->
            <div class="right-column">
                <asp:Button ID="btnEditar" runat="server" OnClick="Editar" width="100px"/>

               <div class="feedback">


                    <h3>¿Qué te pareció el video?</h3>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="buttons">
                                <asp:Button 
                                    ID="btnLike" 
                                    CssClass="btn like" 
                                    runat="server" 
                                    OnClick="Like" 
                                    Text="Me gustó" />

                                <asp:Button 
                                    ID="btnDislike" 
                                    CssClass="btn dislike" 
                                    runat="server" 
                                    OnClick="Dislike" 
                                    Text="No me gustó " />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnLike" EventName="Click"/>
                            <asp:AsyncPostBackTrigger ControlID="btnDislike" EventName="Click"/>
                        </Triggers>
                </asp:UpdatePanel>
                </div>
                <hr class="career-divider" />


                <!-- Sección de Comentarios -->
                <div class="comments">

                    <asp:Repeater ID="rptComments" runat="server">
                        <ItemTemplate>
                            <div class="comment">
                                <div class="comment-header">
                                    <p class="comment-user-name"><%# Eval("Nombre") %></p>
                                </div>
                                <p class="comment-text"><%# Eval("Contenido") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Formulario para nuevo comentario -->
                    <div class="barrabusqueda">
                        <!-- Barra de búsqueda -->
                        <asp:TextBox ID="TextoBuscar" runat="server" CssClass="search-bar" placeholder="Comentar..."></asp:TextBox>
    
                        <!-- Separador -->
                        <span class="auth-separator">|</span>
                        <asp:ImageButton 
                            ID="enviar" 
                            runat="server"
                            ImageUrl="https://img.icons8.com/?size=100&id=12582&format=png&color=FFFFFF" 
                            CssClass="send-btn"
                            OnClick="Comentar"/>
                        <!-- Botón para cancelar -->
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>