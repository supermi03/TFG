$(document).ready(function () {
    // Obtener el ID de usuario de la sesión
    var userId = sessionStorage.getItem("UserId");
    alert(userId);
    // Llamada AJAX para obtener los datos del usuario
    $.ajax({
        type: "GET",
        url: "../Services/ServicioUsuario.asmx/ObtenerDatosUsuario",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d ? JSON.parse(response.d) : response;

            if (data.success) {
                // Rellenar la tabla con los datos del usuario
                $(".tabla-perfil tbody").html(`
                    <tr><td>Nombre</td><td>${data.data.Nombre} ${data.data.Apellido}</td></tr>
                    <tr><td>Correo Electrónico</td><td>${data.data.Email}</td></tr>
                    <tr><td>Fecha de Nacimiento</td><td>${data.data.FechaNacimiento}</td></tr>
                    <tr><td>Fecha de Registro</td><td>${data.data.FechaRegistro}</td></tr>
                    <tr><td>Teléfono</td><td>${data.data.Telefono}</td></tr>
                    <tr><td>Dirección</td><td>${data.data.Direccion}</td></tr>
                `);
            } else {
                alert("Error: " + data.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error en la llamada AJAX: ", xhr, status, error);
        }
    });
});
