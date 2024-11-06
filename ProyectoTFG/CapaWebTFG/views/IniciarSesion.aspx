<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="CapaWebTFG.views.IniciarSesion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />    
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="../Scripts/js/login.js"></script>
        <nav>
            <ul class="nav logo">
                <li class="nav-item">
                    <a class="nav" aria-current="page" href="#"></a>
                </li>
            </ul>
            <ul class="nav menu">
                <li class="nav-item">
                    <a class="nav" aria-current="page" href="../Default.aspx">Inicio</a>
                </li>
                <li class="nav-item">
                    <a class="nav" aria-current="page" href="../Default.aspx/#caracteristicas">Conócenos</a>
                </li>
                <li class="nav-item">
                    <a class="nav" href="../Default.aspx/#tarifas">Tarifas</a>
                </li>
                <li class="nav-item">
                    <a class="boton_iniciar_sesion" href="../views/IniciarSesion.aspx">Acceder</a>
                </li>
            </ul>
        </nav>
    </header>

    <br/><br/><br/>
    <div class="main-content">
        <div class="iniciar_sesion">
            <div class="cuadrado_iniciar_sesion">
                <h3 class="titulo">Iniciar Sesión</h3>
                <form id="FormInicioSesion">
                    <div class="form-group">
                        <label for="email">Correo Electrónico</label>
                        <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Ingresa tu correo" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingresa tu contraseña" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:CheckBox ID="recordarme" runat="server" />
                        <label for="recordarme">Recordarme</label>
                    </div>
<button id="boton_login" class="boton_iniciar_sesion" type="button">Iniciar Sesión</button>
                    <br><br> 
                    <a> ¿No tienes cuenta? Regístrate <a class="link_registro" href="../views/registro.aspx"> aquí</a></a>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
