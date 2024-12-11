<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Administración.aspx.cs" Inherits="cimatub_.Pantallas.Administración" %>


<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Recursos/CSS/administracion.css" rel="stylesheet" />
    <div class="main-content">
        <div class="header">
            <button class="regresar-btn" onclick="window.history.back();">< Regresar</button>
            <h2 class="perfil-titulo">Administración</h2>
        </div>

        <div class="register-container" id="agregar" runat="server">
            <h3>Registrar Carrera</h3>
    
            <div class="form-container">
                <asp:TextBox ID="tbRegCarrera" runat="server" placeholder="Nombre de la Carrera" CssClass="textbox-separado"></asp:TextBox>
                <div>
                    <asp:label runat="server" ID="LblCarrera"> </asp:label>
                    <asp:Button ID="btnRegCarrera" CssClass="btn like" runat="server" Text="Registrar carrera" OnClick="RegistrarCarrera" />
                </div>

                <br />
                <h3>Registrar Materia</h3>
                <div class="form-container" id="materiaContainer" runat="server">
                    <asp:TextBox ID="tbRegMateria" runat="server" placeholder="Nombre de la Materia" CssClass="textbox-separado"></asp:TextBox>
                    <div>
                        <asp:DropDownList ID="ddlCarreras" CssClass="carrerasss dropdown-separado" runat="server">
                            <asp:ListItem Text="Seleccione una carrera" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:label ID="LblMateria" runat="server"></asp:label>
                        <asp:Button ID="btnRegMateria" CssClass="btn like" runat="server" Text="Registrar Materia" OnClick="RegistrarMateria" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
