<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="cimatub_.Pantallas.Editar" %>


<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/videos.css") %>" rel="stylesheet" />

    <div class="video-container">
      <button class="back-button" onclick="window.history.back();">Regresar</button>

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
            <asp:TextBox ID="txtTitulo" CssClass="form-input" runat="server" />

            <label for="descripcion" class="form-label">Descripción:</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-input" TextMode="MultiLine" Rows="4" runat="server" />

            <div class="form-row">
              <div class="form-group">
                <label for="carrera" class="form-label">Carrera:</label>
                <asp:DropDownList ID="ddlCarrera" CssClass="form-dropdown" runat="server" AutoPostBack="true" />
              </div>
              <div class="form-group">
                <label for="materia" class="form-label">Materia:</label>
                <asp:DropDownList ID="ddlMateria" CssClass="form-dropdown" runat="server" />
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