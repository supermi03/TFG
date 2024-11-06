<%@ Page Title="Gestión de Rutinas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="CapaWebTFG.views.gestion_rutinas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />
        <link rel="stylesheet" href="../css/admin.css" />

        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="../Scripts/js/gestion_rutinas.js"></script>
        <nav>
            <a href="../Default.aspx">
                <ul class="nav logo"></ul>
            </a>
            <ul class="nav menu">
                <li class="nav-item">
                    <a class="nav" aria-current="page" href="../views/gestion_usuarios.aspx">Gestión de Usuarios</a>
                </li>
                <li class="nav-item">
                    <a class="nav" aria-current="page" href="gestion_citas.aspx">Gestión de Citas</a>
                </li>
                <li class="nav-item">
                    <a class="nav" href="gestion_notificaciones.aspx">Gestión de Notificaciones</a>
                </li>
                <li class="nav-item">
                    <a class="nav" href="gestion_ejercicios.aspx">Gestión de Ejercicios</a>
                </li>
                <li class="nav-item">
                    <a class="nav" href="gestion_rutinas.aspx">Gestión de Rutinas</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1">
        <div class="container">
            <div class="content mt-4">
                <h2>Gestión de Rutinas</h2>
                <button type="button" id="boton_agregar_rutina">Añadir Rutina</button>
                <div id="resultadoRutinas"></div>
            </div>
        </div>
    </form>

<div id="modalEditarRutina" class="modal" style="display:none;">
    <div class="modal-content">
        <h2>Editar Rutina</h2>
        <input type="hidden" id="editRutina_Id" />
        
        <!-- Fecha de la rutina -->
        <label>Fecha:</label>
        <input type="date" id="editFecha" />
        
        <!-- Dropdown de ejercicios disponibles -->
        <label>Añadir Ejercicio:</label>
        <select id="dropdownEjercicios">
            <!-- Opciones se cargarán desde la base de datos -->
        </select>
        <button id="btnAgregarEjercicio">Añadir Ejercicio</button>

        <!-- Contenedor de ejercicios de la rutina -->
        <div id="editEjerciciosContainer">
            <!-- Aquí se mostrarán los ejercicios añadidos a la rutina -->
        </div>

        <button id="guardarCambiosRutina">Guardar Cambios</button>
        <button id="cerrarModalEditarRutina">Cerrar</button>
    </div>
</div>

<div id="modalAgregarRutina" class="modal" style="display:none;">
    <div class="modal-content">
        <h2>Agregar Nueva Rutina</h2>
        <label for="nuevoNombre">Nombre:</label>
        <input type="text" id="nuevoNombre" required><br>
        <label for="fecha">Fecha:</label>
        <input type="date" id="nuevoFecha" required><br>
        <label for="ejercicios">Ejercicios:</label>
        <div id="nuevoEjerciciosContainer"></div>
        <button type="button" id="guardarNuevaRutina">Guardar</button>
        <button type="button" id="cerrarAgregarModalRutina">Cerrar</button>
    </div>
</div>
<div id="modalDetallesEjercicio" class="modal" style="display:none;">
    <div class="modal-content">
        <h2>Detalles del Ejercicio</h2>
        <p id="ejercicioSeleccionado"></p>
        <label for="series">Series:</label>
        <input type="number" id="series" required><br>
        <label for="repeticiones">Repeticiones:</label>
        <input type="number" id="repeticiones" required><br>
        <label for="peso">Peso:</label>
        <input type="text" id="peso" required><br>
        <label for="tiempo">Tiempo:</label>
        <input type="text" id="tiempo" required><br>
        <button type="button" id="guardarDetallesEjercicio">Guardar Detalles</button>
        <button type="button" id="cerrarModalDetallesEjercicio">Cerrar</button>
    </div>
</div>

</asp:Content>
