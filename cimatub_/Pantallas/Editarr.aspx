<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="cimatub_.Pantallas.Editar" %>


<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Recursos/CSS/videos.css" rel="stylesheet" />

    <div class="video-container">

        <button class="regresar-btn" onclick="window.history.back();">&lt;Regresar</button>

        <div class="main-layout">
            <div class="left-column">
                <div class="video-placeholder">
                    <asp:Image ID="imgVideo" runat="server" width="100%" height="100%"/>
                </div>
            </div>

            <div class="right-column">
                <h2 class="edit-title">Editar Video</h2>

                <div class="edit-form">
                    <label for="titulo" class="form-label">Título:</label>
                    <div class="text-box-video">
                        <asp:TextBox ID="tbTitulo" CssClass="form-input" BackColor="#999999" runat="server" />
                    </div>

                    <label for="descripcion" class="form-label">Descripción:</label>
                    <div>
                        <asp:TextBox ID="tbDescripcion" CssClass="no-resize" BackColor="#999999" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
                    </div>

                    <div class="form-row">
                        <div class="form-group">
                            <label for="carrera" class="form-label">Carrera:</label>
                            <asp:DropDownList ID="ddlCarrera" CssClass="form-dropdown carrera-dropdown" runat="server" AutoPostBack="true" />
                        </div>
                        <div class="form-group">
                            <label for="materia" class="form-label">Materia:</label>
                            <div class="materia-container">
                                <asp:TextBox ID="tbMateria" CssClass="materia-input" runat="server" Placeholder="Agrega o busca una materia..." />
                                <button type="button" class="materia-button add-button">+</button>
                                <button type="button" class="materia-button search-button">🔍</button>
                            </div>
                        </div>
                    </div>

                    <p>Visibilidad</p>
                    <asp:CheckBox ID="cbVisibilidad" runat="server"/>
                    <asp:FileUpload ID="imgMiniatura" runat="server" />

                    <asp:Label ID="lblResultado"  runat="server"></asp:Label>

                    <div class="form-actions">
                        <asp:Button ID="btnGuardar" CssClass="form-button save" Text="Guardar" runat="server" OnClick="GuardarVideo" />
                        <asp:Button ID="btnDescartar" CssClass="form-button discard" Text="Descartar" runat="server" OnClick="DescartarCambios" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

</asp:Content>
