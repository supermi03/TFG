﻿<%@ Page Title="Iniciar Sesion" Language="C#" AutoEventWireup="true" CodeBehind="Rutinas.aspx.cs" Inherits="CapaWebTFG.views.Rutinas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" >
    <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />   
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="../Scripts/js/rutinas.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.13.1/underscore-min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/backbone.js/1.4.0/backbone-min.js"></script>
    <link rel="stylesheet" href="../css/styles.css" /> 
    <link rel="stylesheet" href="../css/user.css" />    

    <nav>
        <ul class="nav logo">
            <li class="nav-item">
                <a class="nav" aria-current="page" href="#"></a>
            </li>
        </ul>
        <ul class="nav menu">
            <li class="nav-item">
                <a class="nav" aria-current="page" href="../views/Rutinas.aspx">Rutinas</a>
            </li>
            <li class="nav-item">
                <a class="nav" aria-current="page" href="../views/citasUser.aspx">Citas</a>
            </li>
            <li class="nav-item">
                <a class="nav" href="../views/perfilUser.aspx">Perfil</a>
            </li>
            <li class="nav-item">
                <a class="boton_iniciar_sesion" href="../views/CerrarSesion.aspx">Cerrar Sesión</a>
            </li>
        </ul>
    </nav>
    <body>
        <div id="resultadoRutinas">



        </div>

    </body>



</asp:Content>
