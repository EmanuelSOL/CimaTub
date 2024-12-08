<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cimatub_.Pantallas.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="<%= ResolveUrl("~/recursos/CSS/Login.css") %>" rel="stylesheet" />
    <div id="camara-logo">
        <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="file-upload" onchange="mostrarImagen(event)" />
        <label for="FileUploadControl">
            <img id="imagenVistaPrevia" src="<%= ResolveUrl("~/Recursos/Imagenes/camara.png") %>" alt="camara" class="camera-icon" />
        </label>
    </div>
    <div id="register-container">

        <label for="tbNombreCompleto">Nombre Completo</label>
        <asp:TextBox ID="tbNombreCompleto" runat="server" CssClass="form-control" placeholder="" TextMode="SingleLine" required="true"></asp:TextBox>
        <label for="tbCorreo">Correo Institucional</label>
        <asp:TextBox ID="tbCorreo" runat="server" CssClass="form-control" placeholder="" TextMode="Email" required="true"></asp:TextBox>
        <label for="tbContraseña1">Contraseña</label>
        <asp:TextBox ID="tbContraseña1" runat="server" CssClass="form-control" placeholder="" TextMode="Password" required="true"></asp:TextBox>
        <label for="tbContraseña2">Repetir Contraseña</label>
        <asp:TextBox ID="tbContraseña2" runat="server" CssClass="form-control" placeholder="" TextMode="Password" required="true"></asp:TextBox>
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

        <a id="back-to-login" href="Login.aspx">Volver al login</a>
    </div>

</asp:Content>