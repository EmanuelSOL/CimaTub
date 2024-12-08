<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.Pantallas.Inicio" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <div class="video-container">
        <!-- Botón Regresar -->
        <button class="back-button" onclick="window.history.back();">Regresar</button>

        <!-- Layout Principal: Video a la izquierda, Retroalimentación y Comentarios a la derecha -->
        <div class="main-layout">
            <!-- Columna Izquierda: Video, Título, Descripción -->
            <div class="left-column">
                <div class="video-placeholder">
                    <!-- Video de la base de datos -->
                    <iframe id="videoPlayer" width="100%" height="400" src="<%# Eval("VideoUrl") %>" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                </div>
                <div class="video-meta">
                    <div class="user-info">
                        <img src="<%# Eval("UserProfileImage") %>" alt="User placeholder" class="user-image" />
                        <div class="user-details">
                            <p class="user-name"><%# Eval("UserName") %></p>
                            <p class="video-views"><%# Eval("Views") %> vistas</p>
                        </div>
                    </div>
                    <h2 class="video-title"><%# Eval("VideoTitle") %></h2>
                    <p class="video-description"><%# Eval("VideoDescription") %></p>
                </div>
            </div>

            <!-- Columna Derecha: Retroalimentación y Comentarios -->
            <div class="right-column">
                <!-- Retroalimentación -->
                <div class="feedback">
                    <h3>¿Qué te pareció el video?</h3>
                    <div class="buttons">
                        <!-- Botones de Like y Dislike con los valores dinámicos -->
                        <button class="like">☺︎ Me gustó: <%# Eval("LikesCount") %></button>
                        <button class="dislike">☹ No me gustó: <%# Eval("DislikesCount") %></button>
                    </div>
                </div>

                <!-- Comentarios -->
                <div class="comments">
                    <h3>Comentarios</h3>
                    <asp:Repeater ID="RepeaterComments" runat="server">
                        <ItemTemplate>
                            <div class="comment">
                                <p>
                                    <strong><%# Eval("Usuario") %>:</strong>
                                    <%# Eval("Comentario") %>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Formulario para Nuevo Comentario -->
                    <div class="new-comment">
                        <textarea placeholder="Escribe un comentario..." class="comment-box"></textarea>
                        <button class="submit-comment" onclick="submitComment()">Enviar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
