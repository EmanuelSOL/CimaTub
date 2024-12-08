<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cimatub_.Pantallas.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="camara-logo">
        <img src="<%= ResolveUrl("~/Recursos/Imagenes/camara.png") %>" alt="camara" />
    </div>
    <div id="register-container">

        <asp:TextBox ID="tbCorreo" runat="server" CssClass="form-control" placeholder="Correo Institucional" TextMode="Email" required="true"></asp:TextBox>

        <asp:TextBox ID="tbContraseña1" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" required="true"></asp:TextBox>

        <asp:TextBox ID="tbContraseña2" runat="server" CssClass="form-control" placeholder="Repite Contraseña" TextMode="Password" required="true"></asp:TextBox>

        <label for="cbDocente">¿Eres docente?</label>
        <asp:CheckBox ID="cbDocente" runat="server" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="cbDocente_CheckedChanged" />

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