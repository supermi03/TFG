$(document).ready(function () {
    $('#boton_login').on('click', function () {

        var email = $("#MainContent_email").val();
        var password = $("#MainContent_password").val();
        var recordarme = $("#recordarme").is(":checked"); // Verifica si se seleccion� "Recordarme"

        $.ajax({
            type: "POST",
            url: "../Services/ServicioLogin.asmx/IniciarSesion",
            data: JSON.stringify({
                email: $("#MainContent_email").val(),
                password: $("#MainContent_password").val(),
                recordarme: $("#recordarme").is(":checked") // Asumiendo que tienes un checkbox para "Recordarme"
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Intenta parsear la cadena JSON
                sessionStorage.setItem("UserId", response.userId); // Guarda el userId

                var data;
                try {
                    data = JSON.parse(response.d); // Analiza la cadena JSON
                } catch (e) {
                    console.error("Error al analizar JSON:", e);
                    return;
                }

                if (data.success) {
                    sessionStorage.setItem("UserId", data.userId); 
                    console.log("Redirigiendo a la p�gina principal...");
                    window.location.href = "../views/mainUser.aspx"; // Redirigir tras inicio de sesi�n
                } else {
                    alert("Datos erroneos");
                }
            },
            error: function (xhr, status, error) {
                // Aqu� el error puede ser undefined si no se captura correctamente
                console.error("Error en la llamada AJAX: ", xhr, status, error);
            }
        });

    });
});
