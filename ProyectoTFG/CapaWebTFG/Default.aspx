<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapaWebTFG.views.Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
    <link rel="stylesheet" href="css/main.css" />       
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.13.1/underscore-min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/backbone.js/1.4.0/backbone-min.js"></script>
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
                <a class="nav" aria-current="page" href="#caracteristicas">Conócenos</a>
            </li>
            <li class="nav-item">
                <a class="nav" href="#tarifas">Tarifas</a>
            </li>
            <li class="nav-item">
                <a class="boton_iniciar_sesion" href="../views/IniciarSesion.aspx">Iniciar sesión</a>
            </li>
        </ul>
    </nav>

    </header>

    <br/><br/><br/><br/><br/><br/><br/><br id ="tarifas" /><br/><br/><br/><br/><br/><br/><br/>
    
    <div class="main-content">

       <div class="cuadrados">
            <div class="cuadrado"onclick="location.href='../views/freeUser.aspx';" style="cursor: pointer;">
                <h3>Prúebalo gratis</h3>
            </div>
        </a>
        <div class="cuadrado" onclick="location.href='../views/registro.aspx';" style="cursor: pointer;">
            <h3>Tarifa Premium</h3>
            <p>24,99€/mes</p>
        </div>
    </div>

           <br/><br/><br/><br/><br/><br/><br id="caracteristicas"/><br/><br/><br/><br/><br/><br/><br/>

         <div class="cuadrados">
             <div class="cuadrado">
                 <h3>Personalización de Rutinas:</h3>
                 <p>Crea rutinas de entrenamiento personalizadas que se adapten a tus objetivos, nivel de experiencia y preferencias.</p>
             </div>

             <div class="cuadrado">
                 <h3>Seguimiento de Progreso:</h3>
                 <p>Monitorea tu progreso con herramientas de seguimiento que te permiten registrar tus entrenamientos, repeticiones y pesos utilizados.</p>
             </div>
             <div class="cuadrado">
                 <h3>Biblioteca de Ejercicios:</h3>
                 <p>Accede a una amplia biblioteca de ejercicios con descripciones, imágenes y videos demostrativos para garantizar una correcta ejecución.</p>
             </div>
         </div>
         <div class="cuadrados">
             <div class="cuadrado">
                 <h3>Planificación de Entrenamientos: </h3>
                 <p>Organiza tus sesiones de entrenamiento con un calendario interactivo que te ayudará a planificar y cumplir tus objetivos.</p>
             </div>

             <div class="cuadrado">
                 <h3>Asesoramiento de Expertos:</h3>
                 <p>Accede a recursos y asesoramiento de entrenadores y nutricionistas para maximizar tus resultados y mantener un estilo de vida saludable.</p>
             </div>
             <div class="cuadrado">
                 <h3>Ayuda Siempre Disponible:</h3>
                 <p>Ofrecemos soporte técnico y asesoría para resolver cualquier duda o problema que puedas tener con la aplicación, garantizando una experiencia de usuario fluida.</p>
             </div>
        </div>
        <div class="cuadrados">
             <div class="cuadrado">
                 <h3>Actualizaciones y Nuevos Contenidos</h3>
                 <p>Recibe actualizaciones regulares con nuevos ejercicios, rutinas y desafíos para mantenerte comprometido y emocionado por tu progreso.</p>
             </div>

             <div class="cuadrado">
                 <h3>Variedad de Estilos de Entrenamiento</h3>
                 <p>Ofrecemos una amplia gama de estilos de entrenamiento, desde HIIT y yoga hasta pilates y entrenamiento de fuerza, para mantener tu rutina fresca y emocionante.</p>
             </div>
             <div class="cuadrado">
                 <h3>Compromiso con la Salud y el Bienestar</h3>
                 <img class="imagen" src="../views/images/ods.jpg" />
             </div>
            
         </div>
    </div>
               <br/><br/><br/><br/><br/>

</asp:Content>
