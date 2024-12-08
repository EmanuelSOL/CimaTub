<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.Pantallas.Inicio" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <div class="video-container">
        <!-- Botón Regresar -->
        <button class="back-button" onclick="window.history.back();">&lt;Regresar</button>

        <div class="main-layout">
            <div class="left-column">
                <!-- Video -->
                <div class="video-placeholder">
                    <iframe id="videoPlayer" width="100%" height="400" src="<%# VideoUrl %>" frameborder="0" allowfullscreen></iframe>
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

            <div class="right-column">
                <div class="feedback">
                    <h3>¿Qué te pareció el video?</h3>
                    <div class="buttons">
                        <button class="like">☺︎ Me gustó: <%# LikesCount %></button>
                        <button class="dislike">☹ No me gustó: <%# DislikesCount %></button>
                    </div>
                </div>

                <div class="comments">
                    <h3>Comentarios</h3>
                    <asp:Repeater ID="RepeaterComments" runat="server">
                        <ItemTemplate>
                            <div class="comment">
                                <div class="comment-header">
                                    <img src="<%# Eval("UserImage") %>" alt="Foto del usuario" class="comment-user-image" />
                                    <p class="comment-user-name"><%# Eval("Usuario") %></p>
                                </div>
                                <p class="comment-text"><%# Eval("Comentario") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="new-comment">
                        <textarea placeholder="Escribe un comentario..." class="comment-box"></textarea>
                        <button class="submit-comment" onclick="submitComment()">Enviar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
