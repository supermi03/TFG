$(document).ready(function () {
    $('#solicitarCita').on('click', function (e) {
        e.preventDefault();

        // Obtener los valores de los campos del formulario
        var fecha = $('#fecha').val();
        var motivo = $('#motivo').val();
        var estado = $('#estado').val();
        var userId = sessionStorage.getItem("UserId");

        // Validar que todos los campos estén completos
        if (!fecha || !motivo || !estado) {
            alert("Por favor, complete todos los campos.");
            return;
        }

        // Llamar al servicio web para solicitar la cita
        $.ajax({
            type: "POST",
            url: "../Services/ServicioCitas.asmx/SolicitarCita",
            data: JSON.stringify({
                fecha: fecha,
                motivo: motivo,
                estado: estado,
                // Pasar el UserId para identificar al cliente
                userId: userId
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    alert("Cita solicitada con éxito.");
                    // Redirigir a la página de citas o refrescar
                    window.location.href = "../views/citasUser.aspx";
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error al solicitar la cita:", status, error);
                alert("Hubo un error al solicitar la cita.");
            }
        });
    });
});
