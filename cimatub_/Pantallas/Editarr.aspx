<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Editarr.aspx.cs" Inherits="cimatub_.Pantallas.Editar" %>


<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Recursos/CSS/editarr.css" rel="stylesheet" />


    <div class="video-container">

        <div class="header">
            <asp:Button ID="regresarBotonw" runat="server" CssClass="regresar-btn" Text="&lt; Regresar" OnClientClick="location.href='Inicio.aspx'; return false;" />
            <span class="textohistorial">Editar video</span>
        </div>

        <div class="main-layout">
            <div class="left-column">
                <!-- Contenedor para la imagen que actúa como botón para subir la miniatura -->
                <div class="video-placeholder">
                    <asp:Image ID="imgVideo" runat="server" width="100%" height="100%" 
                               style="cursor:pointer;" 
                               OnClientClick="document.getElementById('<%= fileUpload.ClientID %>').click();" />
                    <asp:FileUpload ID="fileUpload" runat="server" OnChange="previewImage()" 
                                    CssClass="file-upload" style="display: none;" />
                </div>
            </div>

            <div class="right-column">
                <div class="edit-form">
                    <label for="titulo" class="labels">Título:</label>
                    <div class="text-box-video">
                        <asp:TextBox ID="tbTitulo" CssClass="texto"  runat="server" />
                    </div>

                    <label for="descripcion" class="labels">Descripción:</label>
                    <div>
                        <asp:TextBox ID="tbDescripcion" CssClass="texto"  TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-row">
                            <!-- Sección de Carrera -->
                            <div class="form-group carrera-section">
                                <label for="carrera" class="labels">Carrera:</label>
                                <asp:DropDownList ID="ddlCarrera" CssClass="carrerasss" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCarreraSelect" />
                            </div>

                            <!-- Sección de Materia -->
                            <div class="form-group materia-section">
                                <label for="materia" class="labels">Materia:</label>
                                <div class="materias-container">
                                    <asp:TextBox ID="tbMateria" CssClass="materias-textbox" runat="server" Placeholder="Agrega o busca una materia..." />
                                    <asp:Button ID="btnRegMateria" runat="server" OnClick="RegistrarMateria" class="materia-button add-button" Text="+"/>
                                    <button type="button" class="btn materia-button" onclick="toggleDropdown()">🔍</button>
                                </div>
                                <div id="dropdownMaterias" class="materia-button" style="display: none;">
                                    <asp:DropDownList ID="ddlMateria" CssClass="materiassss" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddMateriaSelect" />
                                </div>
                            </div>
                        </div>
                    <asp:Label ID="lblResultadoMateria" runat="server"></asp:Label>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRegMateria" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMateria" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlCarrera" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                    
                    <asp:CheckBox text="Visibilidad = " TextAlign="Left" ID="cbVisibilidad" runat="server" />

                    <!-- FileUpload oculto -->
                    <asp:FileUpload ID="imgMiniatura" runat="server" Visible="false" OnChange="mostrarImagen(event)" />

                    <!-- Vista previa de la imagen seleccionada -->
                    <asp:Image ID="imagenVistaPrevia" runat="server" style="display:none; width: 100px; height: 100px; margin-top: 10px;" />


                    <div class="form-actions">
                        <asp:Button ID="btnGuardar" CssClass="opciones save" Text="Guardar" runat="server" OnClick="GuardarVideo" />
                        <asp:Button ID="btnDescartar" CssClass="opciones discard" Text="Descartar" runat="server" OnClick="DescartarCambios" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>
        // Función para mostrar la vista previa de la imagen seleccionada
        function mostrarImagen(event) {
            var output = document.getElementById('imagenVistaPrevia');
            output.src = URL.createObjectURL(event.target.files[0]); // Muestra la imagen seleccionada
            output.style.display = 'block'; // Hace visible la miniatura
        }
        function previewImage() {
            var fileUpload = document.getElementById('<%= fileUpload.ClientID %>');
            var imgVideo = document.getElementById('<%= imgVideo.ClientID %>');

            // Verificar si hay archivos seleccionados
            if (fileUpload.files && fileUpload.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    // Cambiar la imagen de vista previa con el archivo cargado
                    imgVideo.src = e.target.result;
                };

                // Leer el archivo como una URL de datos (base64)
                reader.readAsDataURL(fileUpload.files[0]);
            }
        }

        // Función para mostrar u ocultar el dropdown de materias
        function toggleDropdown() {
            const dropdown = document.getElementById('dropdownMaterias');
            if (dropdown.style.display === 'none' || dropdown.style.display === '') {
                dropdown.style.display = 'inline-block'; // Mostrar
            } else {
                dropdown.style.display = 'none'; // Ocultar
            }
        }
    </script>

</asp:Content>