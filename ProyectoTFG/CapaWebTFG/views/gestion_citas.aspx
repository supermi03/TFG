<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  Inherits="CapaWebTFG.views.gestion_citas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />   
        <link rel="stylesheet" href="../css/admin.css" />     

        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.13.1/underscore-min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/backbone.js/1.4.0/backbone-min.js"></script>
        <script src="../Scripts/js/gestion_citas.js"></script>
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

                <h2>Lista de Citas</h2>
                <button id="boton_agregar">Añadir Cita</button>

                <div id="resultado"></div>

             </div>
        </div>
    </form>


<div id="modalEditar" class="modal" style="display:none;">
    <div class="modal-content">

        <h2>Editar Cita</h2>
        <input type="hidden" id="citasId" />
        <label>Citas_Id:</label>
        <input type="text" id="editCitas_Id" disabled/>
        <br />
        <label>Fecha:</label>
        <input type="text" id="editFecha" />
        <br />
        <label>Motivo:</label>
        <input type="text" id="editMotivo" />
        <br />
        <label>Persona_Id:</label>
        <input type="text" id="editPersona_Id" />
        <br/>
        <label for="estado">Estado</label>
        <select id="editEstado">
            <option value="Pendiente">Pendiente</option>
            <option value="Confirmada">Confirmada</option>
            <option value="Cancelada">Cancelada</option>
        </select>
        <button id="guardarCambios">Guardar Cambios</button>
        <button id="cerrarModal">Cerrar</button>
    </div>
</div>

<div id="modalAgregar" class="modal" style="display:none;">
    <div class="modal-content">

        <h2>Agregar Nueva Cita</h2>    
        <label for="Fecha">Fecha:</label>
        <input type="date" id="nuevoFecha" required><br>
    
        <label for="Motivo">Motivo:</label>
        <input type="text" id="nuevoMotivo" required><br>
    
        <label for="Persona_Id">Persona_Id:</label>
        <input type="text" id="nuevoPersona_Id" required><br>
    
        <label for="estado">Estado</label>
        <select id="nuevoEstado">
            <option value="Pendiente">Pendiente</option>
            <option value="Confirmada">Confirmada</option>
            <option value="Cancelada">Cancelada</option>
        </select>

        <button id="guardarNuevaCita">Guardar</button>
        <button id="cerrarAgregarModal">Cerrar</button>
     </div>
</div>

</asp:Content>
