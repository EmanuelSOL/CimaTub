<%@ Page Title="" Language="C#" MasterPageFile="~/MP/General.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="cimatub_.Pantallas.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Button ID="btnRegresar" runat="server" OnClick="Regresar" />

   <asp:ListView ID="lstVideos" runat="server">
        <ItemTemplate>
            <div>
                <asp:ImageButton 
                     ID="imgMiniatura" 
                     runat="server" 
                     ImageUrl='<%# Eval("Img") %>'
                     OnClick="VerVideo" 
                     CommandArgument='<%# Eval("IdVideo") %>' 
                     width="200px" height="100px"/>

                <h3><%# Eval("Titulo") %></h3>
                <p><%# Eval("Descripcion") %></p>
            </div>
        </ItemTemplate>
   </asp:ListView>

    
</asp:Content>
