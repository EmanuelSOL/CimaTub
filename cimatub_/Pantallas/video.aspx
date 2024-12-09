<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.Pantallas.video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <div class="video-container">
        <!-- Botón Regresar -->

        <asp:Button ID="btnRegresar" CssClass="back-button" runat="server" Text="&lt;Regresar" OnClick="Regresar" />

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

                        <asp:Button ID="btnLike" CssClass="like" runat="server" Text="☺︎ Me gustó" OnClick="btnLike_Click" />
                        <asp:Label ID="lblLikesCount" runat="server" Text="<%# LikesCount %>"></asp:Label>

                        <asp:Button ID="btnDislike" CssClass="dislike" runat="server" Text="☹ No me gustó" OnClick="btnDislike_Click" />
                        <asp:Label ID="lblDislikesCount" runat="server" Text="<%# DislikesCount %>"></asp:Label>
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

                    <!-- Formulario para nuevo comentario -->
                    <div class="new-comment">
                        <asp:TextBox ID="txtNewComment" CssClass="comment-box" runat="server" TextMode="MultiLine" Placeholder="Escribe un comentario..."></asp:TextBox>
                        <asp:Button ID="btnSubmitComment" CssClass="submit-comment" runat="server" Text="Enviar" OnClick="btnSubmitComment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
