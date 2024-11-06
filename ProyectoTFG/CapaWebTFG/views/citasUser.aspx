<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../Scripts/js/citas.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.13.1/underscore-min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/backbone.js/1.4.0/backbone-min.js"></script>
    <link rel="stylesheet" href="../css/citas.css" />
    <link rel="stylesheet" href="../css/styles.css" />
    <link rel="stylesheet" href="../css/user.css" />

    <nav id="navUser">
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
                <a class="boton_iniciar_sesion" href="../views/CerrarSesion.aspx">Cerrar sesión</a>
            </li>
        </ul>
    </nav>

    <div id="citas-container">
        <h2>Solicitar Cita con el Entrenador</h2>
        <form id="cita-form">
            <div class="form-group">
                <label for="fecha">Fecha</label>
                <input type="date" id="fecha" class="form-control" required>
            </div>
            <div class="form-group">
                <label for="motivo">Motivo</label>
                <textarea id="motivo" class="form-control" rows="3" required></textarea>
            </div>
            <div class="form-group">
                <label for="estado">Estado</label>
                <select id="estado" class="form-control">
                    <option value="Pendiente">Pendiente</option>
                    <option value="Confirmada">Confirmada</option>
                    <option value="Cancelada">Cancelada</option>
                </select>
            </div>
            <input id="solicitarCita" type="button" class="boton_iniciar_sesion" value ="Solicitar Cita"/>
        </form>
    </div>

</asp:Content>
