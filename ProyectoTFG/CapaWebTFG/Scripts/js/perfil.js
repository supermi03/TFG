$(document).ready(function () {
    // Obtener el ID de usuario de la sesión
    var userId = sessionStorage.getItem("UserId");

    if (!userId) {
        console.error("No se encontró el userId en sessionStorage.");
        return;
    }

    // Llamada AJAX para obtener los datos del usuario
    $.ajax({
        type: "GET",
        url: "../Services/ServicioUsuario.asmx/ObtenerDatosUsuario", // URL de tu servicio
        data: { userId: userId }, // Pasamos el userId como parámetro GET
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // La respuesta viene en un objeto con 'd' que contiene un string JSON
            var responseData = JSON.parse(response.d); // Parseamos el string JSON dentro de 'd'

            if (responseData.success) {
                // Rellenar la tabla con los datos del usuario
                $(".tabla-perfil tbody").html(`
                    <tr><td>Nombre</td><td>${responseData.data.Nombre} ${responseData.data.Apellido}</td></tr>
                    <tr><td>Correo Electrónico</td><td>${responseData.data.Email}</td></tr>
                    <tr><td>Fecha de Nacimiento</td><td>${responseData.data.FechaNacimiento}</td></tr>
                    <tr><td>Fecha de Registro</td><td>${responseData.data.FechaRegistro}</td></tr>
                    <tr><td>Teléfono</td><td>${responseData.data.Telefono}</td></tr>
                    <tr><td>Dirección</td><td>${responseData.data.Direccion}</td></tr>
                `);
            } else {
                alert("Error: " + responseData.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error en la llamada AJAX: ", xhr, status, error);
        }
    });
});
