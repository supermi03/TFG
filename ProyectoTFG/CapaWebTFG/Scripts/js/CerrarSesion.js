$(document).ready(function () {
    $('#cerrarSesionLink').on('click', function (e) {
        e.preventDefault(); // Evita que el botón recargue la página

        // Hacer una llamada AJAX para cerrar sesión
        $.ajax({
            type: "POST",
            url: "../Services/ServicioLogin.asmx/CerrarSesion", // URL del método de cierre de sesión
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Redirigir a la página de inicio de sesión
                window.location.href = "../views/IniciarSesion.aspx"; // Cambia a tu página de inicio de sesión
            },
            error: function (xhr, status, error) {
                console.error("Error al cerrar sesión:", error);
            }
        });
    });
});
