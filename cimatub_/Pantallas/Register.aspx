<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cimatub_.Pantallas.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/Reg.css?v=@DateTime.Now.Ticks") %>" rel="stylesheet" />
    <div class="strip-container">
        <div class="bicolor-strip-green"></div>
        <div class="bicolor-strip-amarilla"></div>
    </div>
    <div class="strip-container">
        <div class="bicolor-strip-green-right"></div>
        <div class="bicolor-strip-amarilla-right"></div>
    </div>
    <div>

    </div>
    <!-- Botón como contenedor principal -->
    <asp:Panel ID="panelCamara" runat="server">
        <!-- Botón personalizado para cargar imagen -->
        <button id="camara-logo" class="upload-button" type="button" onclick="document.getElementById('<%= FileUploadControl.ClientID %>').click();">
            <img id="imagenVistaPrevia" src="<%= ResolveUrl("~/Recursos/Imagenes/camara.png") %>" alt="Vista previa" class="camera-icon" />
        </button>

        <!-- Control FileUpload oculto -->
        <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="file-upload" onchange="mostrarImagen(event)" style="display: none;" />
    </asp:Panel>



    <div id="register-container">

        <label for="tbNombreCompleto">Nombre Completo</label>
        <asp:TextBox ID="tbNombreCompleto" runat="server" CssClass="form-control" placeholder="Ingresa tu nombre completo" TextMode="SingleLine" required="true"></asp:TextBox>
        <label for="tbCorreo">Correo Institucional</label>
        <asp:TextBox ID="tbCorreo" runat="server" CssClass="form-control" placeholder="@uabc.edu.mx" TextMode="Email" required="true"></asp:TextBox>
        <label for="tbContraseña1">Contraseña</label>
        <asp:TextBox ID="tbContraseña1" runat="server" CssClass="form-control" placeholder="Ingresa tu contrasena" TextMode="Password" required="true"></asp:TextBox>
        <label for="tbContraseña2">Repetir Contraseña</label>
        <asp:TextBox ID="tbContraseña2" runat="server" CssClass="form-control" placeholder="Vuelve a ingresa tu contrasena" TextMode="Password" required="true"></asp:TextBox>
        <label for="cbDocente">¿Eres docente?</label>

        <div class="docente-check-container">
            <div class="docente-options">
                <span>Sí</span>
                <label class="form-option">
                    <asp:RadioButton 
                        ID="rbDocenteSi" 
                        runat="server" 
                        GroupName="Docente" 
                        AutoPostBack="true" 
                        OnCheckedChanged="rbDocente_CheckedChanged" />
                </label>
                <span>No</span>
                <label class="form-option">
                    <asp:RadioButton 
                        ID="rbDocenteNo" 
                        runat="server" 
                        GroupName="Docente" 
                        AutoPostBack="true" 
                        OnCheckedChanged="rbDocente_CheckedChanged" />
                </label>
            </div>
        </div>

        <div id="Div1" runat="server" visible="false">
            <label for="ddCarreras">Selecciona Carrera</label>
            <asp:DropDownList ID="ddCarreras" runat="server" CssClass="form-control">
                <asp:ListItem Text="Computación" Value="computacion"></asp:ListItem>
                <asp:ListItem Text="Software" Value="software"></asp:ListItem>
            </asp:DropDownList>
        </div>


        <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="RegistrarUsuario" />
        <br />
        <a id="login-register-link" href="Login.aspx">Volver al login</a>
         <div id="shadow-bottom"></div>
    </div>

</asp:Content>