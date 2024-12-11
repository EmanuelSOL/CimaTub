<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Filtrado.aspx.cs" Inherits="cimatub_.Pantallas.Filtrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/Historial.css") %>" rel="stylesheet" />

    <div class="container" style="margin-left: 5%;">
      <div class="header">
        <asp:Button ID="regresarBotonw" runat="server" CssClass="regresar-btn" Text="&lt; Regresar" OnClientClick="location.href='Inicio.aspx'; return false;" />
        <span class="textofiltrado">Filtrado por: </span>
        <asp:Literal ID="litMateriasSeleccionadas" runat="server"></asp:Literal>
      </div>

        <asp:Label ID="lblMateriaResultado" runat="server"  />

      <div class="content">
        <asp:ListView ID="lstVideos" runat="server">
            <ItemTemplate>

                <div class="video-item">

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

