<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="cimatub_.Pantallas.Inicio" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Recursos/CSS/Inicio.css" rel="stylesheet" />

    <div class="container mt-4">
        <!-- Sección de videos destacados -->
        <div class="row">
            <h3 class="text-white">Destacados</h3>
            <asp:ListView ID="ListViewDestacados" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-sm-6 col-md-3 mb-4">
                        <a href="DetallesVideo.aspx?id=<%# Eval("IdVideo") %>" class="d-block">
                            <div class="video-container">
                                <asp:ImageButton 
                                    ID="imgVideo"
                                    runat="server"
                                    ImageUrl='<%# Eval("Img") %>'
                                    CssClass="video-thumbnail"
                                    OnClick="VerVideo"
                                    CommandArgument='<%# Eval("IdVideo") %>' 
                                    />
                                    
                            </div>
                        </a>
                        <div class="video-info">
                            <h5 class="video-title"><%# Eval("Titulo") %></h5>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <!-- Sección de videos recomendados -->
        <div class="row mt-5">
            <h3 class="text-white">Probablemente te interese...</h3>
            <asp:ListView ID="ListViewRecomendados" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-sm-6 col-md-3 mb-4">
                        <a href="DetallesVideo.aspx?id=<%# Eval("IdVideo") %>" class="d-block">
                            <div class="video-container">
                                <img src='<%# Eval("Img") %>' class="video-thumbnail" alt="Video Thumbnail">
                            </div>
                        </a>
                        <div class="video-info">
                            <h5 class="video-title"><%# Eval("Titulo") %></h5>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>