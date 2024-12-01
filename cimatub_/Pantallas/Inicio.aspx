<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="cimatub_.Pantallas.Inicio" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <ul class="list-group">
            <asp:Repeater ID="RepeaterCarreras" runat="server">
                <ItemTemplate>
                    <li class="list-group-item bg-dark text-white">
                        <button class="btn btn-link text-white" data-bs-toggle="collapse" data-bs-target="#<%# Eval("Id") %>" aria-expanded="false">
                            <%# Eval("NombreCarrera") %>
                        </button>
                        <ul id="<%# Eval("Id") %>" class="collapse">
                            <asp:Repeater ID="RepeaterMaterias" runat="server" DataSource='<%# Eval("Materias") %>'>
                                <ItemTemplate>
                                    <li class="list-group-item bg-secondary text-white">
                                        <button class="btn btn-link text-white"><%# Eval("NombreMateria") %></button>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <!--<div class="mt-4">
            <button class="btn btn-secondary">&lt; Regresar</button>
        </div> -->

        <div class="row g-3 mt-4">
            <asp:Repeater ID="RepeaterVideos" runat="server">
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="card bg-dark text-white">
                            <img src='<%# Eval("Imagen") %>' class="card-img-top" alt="Imagen destacada">
                            <div class="card-img-overlay d-flex justify-content-center align-items-center">
                                <button class="btn btn-light" onclick="window.location.href='<%# Eval("UrlVideo") %>'">▶</button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
