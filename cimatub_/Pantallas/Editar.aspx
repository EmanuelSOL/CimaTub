<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="cimatub_.Pantallas.Editar" %>


<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <div class="video-container">
        <button class="regresar-btn" onclick="window.history.back();">&lt;Regresar</button>

        <div class="main-layout">
            <div class="left-column">
                <div class="video-placeholder">
                    <iframe id="videoPlayer" width="100%" height="100%" src="https://www.youtube.com/embed/dQw4w9WgXcQ" frameborder="0" allowfullscreen></iframe>
                </div>
            </div>

            <div class="right-column">
                <h2 class="edit-title">Editar Video</h2>

                <div class="edit-form">
                    <label for="titulo" class="form-label">Título:</label>
                    <div class="text-box-video">
                        <asp:TextBox ID="txtTitulo" CssClass="form-input" BackColor="#999999" runat="server" />
                    </div>

                    <label for="descripcion" class="form-label">Descripción:</label>
                    <div>
                        <asp:TextBox ID="txtDescripcion" CssClass="no-resize" BackColor="#999999" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
                    </div>

                    <div class="form-row">
                        <div class="form-group">
                            <label for="carrera" class="form-label">Carrera:</label>
                            <asp:DropDownList ID="ddlCarrera" CssClass="form-dropdown carrera-dropdown" runat="server" AutoPostBack="true" />
                        </div>
                        <div class="form-group">
                            <label for="materia" class="form-label">Materia:</label>
                            <div class="materia-container">
                                <asp:TextBox ID="txtMateria" CssClass="materia-input" runat="server" Placeholder="Agrega o busca una materia..." />
                                <button type="button" class="materia-button add-button">+</button>
                                <button type="button" class="materia-button search-button">🔍</button>
                            </div>
                        </div>
                    </div>


                    <div class="form-actions">
                        <asp:Button ID="btnGuardar" CssClass="form-button save" Text="Guardar" runat="server" OnClick="GuardarVideo" />
                        <asp:Button ID="btnDescartar" CssClass="form-button discard" Text="Descartar" runat="server" OnClick="DescartarCambios" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
