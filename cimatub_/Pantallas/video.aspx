<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="cimatub_.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <button class="btn btn-secondary">&lt; Regresar</button>
        </div>
        <div class="mb-4">
            <iframe class="w-100" height="500" 
                    src="https://www.youtube.com/embed/dQw4w9WgXcQ"
                    title="Video" 
                    allow="autoplay; encrypted-media" 
                    allowfullscreen>
            </iframe>
        </div>
        <h2 class="mb-3 text-white">Este es el título del video</h2>
        <p class="mb-4 text-white">Descripción<br> ejemplo<br> ejemplo<br> ejemplo</p>
        <div>
            <p class="text-white">¿Qué te pareció el video?</p>
            <div class="d-flex mb-3">
                <button class="btn btn-success me-2">Me Gusta</button> 
                <button class="btn btn-danger">No Me Gusta</button>
            </div>
            <div>
                <h3 class="text-white">Comentarios</h3>
                <div class="mb-3">
                    <p class="text-white"><strong>Usuario 1:</strong> ¡Este video es increíble!</p>
                    <p class="text-white"><strong>Usuario 2:</strong> Muy informativo, gracias por compartirlo.</p>
                </div>
                <form>
                    <div class="mb-3">
                        <textarea class="form-control" placeholder="Escribe tu comentario aquí..." rows="4" required></textarea>
                    </div>
                    <button type="submit" class="btn btn-primary">Comentar</button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
