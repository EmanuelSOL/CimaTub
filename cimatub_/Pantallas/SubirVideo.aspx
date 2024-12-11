<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="SubirVideo.aspx.cs" Inherits="cimatub_.Pantallas.SubirVideo" %>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Recursos/CSS/videos.css" rel="stylesheet" />

    <div class="video-container">
        
        <div class="header">
            <asp:Button ID="regresarBotonw" runat="server" CssClass="regresar-btn" Text="&lt; Regresar" OnClientClick="location.href='Inicio.aspx'; return false;" />
            <span class="textohistorial">Subir Video</span>
        </div>

        <div class="main-layout">
            <div class="left-column">
                <asp:Label ID="lblRegistroMiniatura" runat="server" Text="Estado miniatura: " CssClass="registro-label" />
                <asp:Label ID="lblEstadoMiniatura" runat="server" Text="No subida" CssClass="estado-label" />

                <div class="video-placeholder">
                    <button id="subir-video" class="upload-button" type="button" onclick="document.getElementById('<%= fileUpload.ClientID %>').click();">
                        <div id="preview-container" class="subir">
                            <img id="imgPreview" src="/Recursos/Imagenes/subirvideo.png" class="preview-image" />

                        </div>
                    </button>
                    <asp:FileUpload ID="fileUpload" runat="server" OnChange="previewImage()" CssClass="file-upload" style="display: none;" />
                </div>

                <div class="miniatura-section">
                    <asp:Label ID="lblRegistroVideo" runat="server" Text="Estado video: " CssClass="registro-label" />
                    <asp:Label ID="lblEstadoVideo" runat="server" CssClass="estado-label" Text="" />

                    <button id="miniatura" class="miniaturaclass" type="button" onclick="document.getElementById('<%= imgMiniatura2.ClientID %>').click();">
                        Subir Video
                    </button>
                    <asp:FileUpload ID="imgMiniatura2" runat="server" style="display: none;" OnChange="previewThumbnail()" />
                    <asp:Image ID="imagenVistaPrevia" runat="server" style="display: none; width: 100px; height: 100px; margin-top: 10px;" />
                </div>

            </div>

            <div class="right-column">
                <div class="edit-form">
                    <asp:Label ID="lblRegistroMateria" runat="server" Text="Registro de Materia" CssClass="registro-label" />
                    
                    <label for="titulo" class="labels">Título:</label>
                    <div class="text-box-video">
                        <asp:TextBox ID="tbTitulo2" CssClass="texto" runat="server" />
                    </div>

                    <label for="descripcion" class="labels">Descripción:</label>
                    <div>
                        <asp:TextBox ID="tbDescripcion2" CssClass="texto" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
                    </div>

                    <div class="form-row">
                        <div class="form-group carrera-section">
                            <label for="carrera" class="labels">Carrera:</label>
                            <asp:DropDownList ID="ddlCarrera2" CssClass="carrerasss" runat="server" AutoPostBack="false" />
                        </div>

                        <div class="form-group materia-section">
                            <label for="materia" class="labels">Materia:</label>
                            <div class="materias-container">
                                <asp:TextBox ID="tbMateria2" CssClass="materias-textbox" runat="server" Placeholder="Agrega o busca una materia..." />
                                <asp:Button ID="btnRegMateria2" runat="server" OnClick="RegistrarMateria" class="materia-button add-button" Text="+" />
                            </div>
                            <div id="dropdownMaterias2" class="materia-button" style="display: none;">
                                <asp:DropDownList CssClass="materiassss" runat="server" AutoPostBack="true">
                                    <asp:ListItem ID="ddMaterias2" Text="Selecciona una materia" Value="" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <asp:CheckBox Text="Visibilidad = " TextAlign="Left" ID="cbVisibilidad" runat="server" />

                    <div class="form-actions">
                        <asp:Button ID="btnGuardar" CssClass="opciones save" Text="Subir" runat="server" OnClick="GuardarVideo" />
                        <asp:Button ID="btnDescartar" CssClass="opciones discard" Text="Descartar" runat="server" OnClick="DescartarCambios" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <script>
        function previewImage() {
            var fileUpload = document.getElementById('<%= fileUpload.ClientID %>');
            var imgPreview = document.getElementById('imgPreview');
            var lblEstadoVideo = document.getElementById('<%= lblEstadoVideo.ClientID %>');
            var lblEstadoMiniatura = document.getElementById('<%= lblEstadoMiniatura.ClientID %>');

            if (fileUpload.files && fileUpload.files[0]) {
                var reader = new FileReader();
                lblEstadoMiniatura.innerText = "Miniatura cargada correctamente."; 
                reader.onload = function (e) {
                    imgPreview.src = e.target.result;
                    imgPreview.style.display = 'block';
                };
                reader.readAsDataURL(fileUpload.files[0]);
            }
        }



        function previewThumbnail() {
            var fileUpload = document.getElementById('<%= imgMiniatura2.ClientID %>');
            var imagenVistaPrevia = document.getElementById('<%= imagenVistaPrevia.ClientID %>');
            var lblEstadoVideo = document.getElementById('<%= lblEstadoVideo.ClientID %>');
            var lblEstadoMiniatura = document.getElementById('<%= lblEstadoMiniatura.ClientID %>');

            if (fileUpload.files && fileUpload.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    imagenVistaPrevia.src = e.target.result;
                    imagenVistaPrevia.style.display = 'block';
                    lblEstadoVideo.innerText = "Video cargado correctamente."; 
                };
                reader.readAsDataURL(fileUpload.files[0]);
            }
        }

    </script>
</asp:Content>
