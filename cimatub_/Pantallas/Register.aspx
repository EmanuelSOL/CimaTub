<%@ Page Title="" Language="C#" MasterPageFile="~/MP/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cimatub_.Pantallas.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenedor del formulario de registro -->
    <div id="register-container">
        <h2>Registro</h2>
        <input type="text" placeholder="Nombre Completo" id="register-name" required>
        <input type="email" placeholder="Correo Institucional" id="register-email" required>
        <input type="password" placeholder="Contraseña" id="register-password" required>
        <input type="password" placeholder="Repite Contraseña" id="register-password-confirm" required>

        <label for="es-docente">¿Eres docente?</label>
        <select id="es-docente">
            <option value="si">Sí</option>
            <option value="no">No</option>
        </select>

        <div id="carrera-container" style="display: none;">
            <label for="carrera">Selecciona Carrera</label>
            <select id="carrera">
                <option value="computacion">Computacion</option>
                <option value="Software">Software</option>
            </select>
        </div>

        <button id="register-button" type="submit">Registrarse</button>
        <a id="back-to-login" href="Login.aspx">Volver al login</a>
    </div>

    <script>
        document.getElementById('es-docente').addEventListener('change', function () {
            const carreraContainer = document.getElementById('carrera-container');
            carreraContainer.style.display = this.value === 'no' ? 'block' : 'none';
        });
    </script>
</asp:Content>