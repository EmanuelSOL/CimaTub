<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaBackend.aspx.cs" Inherits="cimatub_.PruebaBackend" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnListarCarreras" runat="server" Text="Listar Carreras" OnClick="ListarCarreras" />
            <br /><br />
            <asp:GridView ID="gvCarreras" runat="server" AutoGenerateColumns="true" />

            <asp:TextBox ID="tbIdCarrera" runat="server" Text="0"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Listar Materias" OnClick="ListarMateriasPorIdCarrera" />
            <br /><br />


            <asp:GridView ID="gvMaterias" runat="server" AutoGenerateColumns="true" />
            
            <asp:TextBox ID="tbRegCarrera" runat="server" Text=""></asp:TextBox>

            <asp:Button ID="btnRegCarrera" runat="server" Text="Registrar carrera" OnClick="RegistrarCarrera"/>

            <asp:Label ID="lblResRegCarrera" runat="server" Text =""></asp:Label>
             
            <div>
                <asp:Button ID="btnDestacados" runat="server" Text="Destacados" OnClick="ListarDestacados" />
                <asp:Repeater ID="rptVideos" runat="server">
                    <ItemTemplate>
                        <div>
            
                            
                            <a href="#" >
                                <asp:Image runat="server" ImageUrl='<%# Eval("Img") %>'
                                    Width="400" Height="200" AlternateText="Imagen" />
                            </a>
                            <h3><%# Eval("Titulo") %></h3>
                            <iframe width="560" height="315" src='<%# Eval("Preview") %>' frameborder="0" allowfullscreen></iframe>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>



            <asp:DropDownList ID="ddCarreras" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddCarreraSelect">
                <asp:ListItem Text="Selecciona una carrera" Value="" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddMaterias" runat="server" AutoPostBack="true">
                <asp:ListItem Text="Selecciona una materia" Value="" />
            </asp:DropDownList>

            <asp:Button ID="btnVideosCarrera" runat="server" Text="Aplicar filtro carrera" OnClick="FiltrarPorCarrera"/>
            <asp:Button ID="btnVideosMateria" runat="server" Text="Aplicar filtro materia" OnClick="FiltrarPorMateria"/>

            <asp:GridView ID="gvVideosFiltrados" runat="server" ></asp:GridView>

            <asp:Label ID="lblVideosFiltrados" runat="server" Text=""></asp:Label>

            <p>Toma la misma carrera que esta en el dropDown</p>

            <asp:TextBox ID="tbRegMateria" runat="server" placeholder="Materia" ></asp:TextBox>

            <asp:Button ID="btnRegMateria" runat="server" OnClick="RegistrarMateria" Text="Registrar Materia"/>
            <asp:Label ID="lblRegMateria" runat="server" ></asp:Label>

           <p>
               <br />
               <br />
               <br />
               <br />
           </p>
            <asp:FileUpload ID="img" runat="server"/>
            
            <p>Nombre Completo</p>
            <asp:TextBox ID="tbNombreCompleto" runat="server"  ></asp:TextBox>

            <p>Correo Institucional</p>
            <asp:TextBox ID="tbCorreo" runat="server"></asp:TextBox>

            <p>Contraseña</p>
            <asp:TextBox ID="tbContraseña1" runat="server"></asp:TextBox>
            <p>RepiteContraseña</p>
            <asp:TextBox ID="tbContraseña2" runat="server"></asp:TextBox>
            <p>¿Eres docente?</p>
            <p>En caso de registrar alumno usara el dropDown de alumnos</p>
            <asp:CheckBox ID="cbDocente" runat="server"/>

            
            <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="RegistrarUsuario"/>
            <asp:Label ID="lblRegistro" runat="server" ></asp:Label>



            <p>
                <br />
                <br />
                <br />
                Registrar video

            </p>
            <p>Campo de video</p>
            <asp:FileUpload ID="fileVideo" runat="server" />

            <p>Campo de miniatura</p>
            <asp:FileUpload ID="miniatura" runat="server" />

            <p>Titulo</p>
            <asp:TextBox ID="tbTitulo" runat="server"  placeholder="Titulo"></asp:TextBox>
            <p>Descripción</p>
            <asp:TextBox ID="tbDescripcion" runat="server"  placeholder="Descripcion"></asp:TextBox>

            <p>Toma los seleccionados en los drop down en caso de que no haya materia registrarla</p>
            <p>Carrera</p>
            <p>Materia</p>
            <asp:Label ID="lblCarrera" runat="server" ></asp:Label>
            <asp:Label ID="lblMateria" runat="server" ></asp:Label>

            <p>privado</p>
            <asp:CheckBox ID="cbOculto" runat="server" />
            <asp:Button ID="btnRegVideo" runat="server" Text="Subir video" OnClick="SubirVideo" />
            <asp:Label ID="lblRegVideo" runat="server" ></asp:Label>


            <p>
                Buscar usuario
            </p>



            <p>
                <br />
                <br />
                <br />
                Login
            </p>
            <asp:TextBox ID="tbLoginCorreo" runat="server" placeholder="Correo"></asp:TextBox>
            <asp:TextBox ID="tbLoginContrasena" runat="server" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server"  Text="Login" OnClick="Login"/>
            <asp:Image ID="imgPerfil" runat="server" />
            <asp:Label ID="lblLogin" runat="server" ></asp:Label>

         </div>
    </form>
</body>
</html>
