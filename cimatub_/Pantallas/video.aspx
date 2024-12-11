<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.Pantallas.video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />
    <div class="video-container">
        
        <!-- Botón Regresar -->
        <asp:Button ID="Button1" CssClass="back-button" runat="server" Text="&lt;Regresar" OnClick="btnRegresar_Click" />
        <asp:Button ID="btnEditar"  runat="server" Text="Editar" OnClick="Editar" />
    
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
                <asp:UpdatePanel ID="upReaccion" runat="server" >
                    <ContentTemplate>
                        <div class="feedback">
                             <h3>¿Qué te pareció el video?</h3>
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
                                     Text="No me gustó" />
                             </div>
                         </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnLike" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDislike" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               




                <hr class="career-divider" />
                <!-- Sección de Comentarios -->
                <div class="comments">
                    <asp:Panel ID="pnlComentar" runat="server">
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
                            <asp:TextBox ID="tbComentario" runat="server" CssClass="search-bar" placeholder="Comentar..."></asp:TextBox>
    
                            <!-- Separador -->
                            <span class="auth-separator">|</span>
                            <asp:ImageButton 
                                ID="btnComentar"
                                runat="server"
                                CssClass="send-btn"
                                OnClick="Comentar"
                                ImageUrl="https://img.icons8.com/?size=100&id=12582&format=png&color=FFFFFF"
                                />
                       
                            <!-- Botón para cancelar -->
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>