<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="../css/iniciar_sesion_styles.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../Scripts/js/user.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.13.1/underscore-min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/backbone.js/1.4.0/backbone-min.js"></script>
    <link rel="stylesheet" href="../css/styles.css" />
    <link rel="stylesheet" href="../css/user.css" />

    <nav>
        <a href="../Default.aspx"<ul class="nav logo">

        </ul></a>
        <ul class="nav menu">
            <li class="nav-item">
                <a class="nav" aria-current="page" href="../Default.aspx">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav" aria-current="page" href="../views/freeRutinas.aspx/">Rutinas</a>
            </li>
            <li class="nav-item">
                <a class="boton_iniciar_sesion" href="../views/IniciarSesion.aspx">Iniciar sesión</a>
            </li>
        </ul>
    </nav>
    <body>


    
        <div id="select_ejercicios">
            <label for="categoria-select">Selecciona una categoría:</label>
                <select id="categoria-select">
                    <option value="all">Todas</option>
                    <option value="cardio">Cardio</option>
                    <option value="pecho">Pecho</option>
                    <option value="espalda">Espalda</option>
                    <option value="pierna">Pierna</option>
                    <option value="brazo">Brazo</option>
                    <option value="hombro">Hombro</option>

                </select>
            <div id="ejercicios-container">
            </div>
        </div>

    </body>
</asp:Content>
