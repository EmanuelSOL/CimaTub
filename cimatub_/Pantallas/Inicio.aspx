<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="cimatub_.Pantallas.Inicio" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Recursos/CSS/Inicio.css" rel="stylesheet" />

    <div class="container mt-4">
        <!-- Sección de videos destacados -->
        <div class="row">
            <h3 class="text-white">Destacados</h3>
            <asp:ListView ID="ListViewDestacados" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <LayoutTemplate>
                    <div class="d-flex flex-wrap justify-content-start"> <!-- Flexbox explícito -->
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="p2"> 
                        <!-- Aspect Ratio Box -->
                        <div class="aspect-ratio-box">
                            <asp:ImageButton 
                                ID="imgVideo"
                                runat="server"
                                ImageUrl='<%# Eval("Img") %>'
                                CssClass="video-thumbnail"
                                OnClick="VerVideo"
                                CommandArgument='<%# Eval("IdVideo") %>' 
                                width="600px"
                                height="300px"
                                style="margin-right:50px"
                            />
                        </div>
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
            <asp:ListView ID="ListViewRecomendados" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <LayoutTemplate>
                    <div class="d-flex flex-wrap justify-content-start"> <!-- Flexbox explícito -->
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder> <!-- Marcador de posición -->
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="p-2"> 
                        <div class="video-container">
                            <asp:ImageButton 
                                    ID="ImageButton1"
                                    runat="server"
                                    ImageUrl='<%# Eval("Img") %>'
                                    CssClass="video-thumbnail"
                                    OnClick="VerVideo"
                                    CommandArgument='<%# Eval("IdVideo") %>' 
                                    width="600px"
                                    height="300px"
                                    style="margin-right:50px"
                                />
                          <div class="video-info">
                              <h5 class="video-title"><%# Eval("Titulo") %></h5>
                          </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
