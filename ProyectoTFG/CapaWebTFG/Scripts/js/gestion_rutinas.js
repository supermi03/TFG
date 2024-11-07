$(document).ready(function () {
    // Llamada inicial para cargar las rutinas
    obtenerRutinas();

    // Función para obtener las rutinas desde el servidor
    function obtenerRutinas() {
        $.ajax({
            type: "POST",
            url: "../Services/ServicioRutina.asmx/ObtenerRutinas",  // URL del servicio
            dataType: "json",  // Asegúrate de que el tipo de respuesta sea JSON
            success: function (response) {
                console.log(response);  // Verifica la respuesta aquí

                if (response.success) {
                    $('#resultadoRutinas').empty();  // Limpiar el contenedor antes de mostrar los resultados
                    var table = $('<table class="table"></table>');
                    var tableHeader = `
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Fecha</th>
                            <th>Ejercicios</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                `;
                    table.append(tableHeader);
                    var tableBody = $('<tbody></tbody>');

                    // Recorrer las rutinas y mostrarlas en la tabla
                    response.rutinas.forEach(function (rutina) {
                        // Recorriendo la propiedad Ejercicios dentro de cada Rutina
                        var ejerciciosHtml = rutina.Ejercicios.map(function (entrenamiento) {
                            // Crear HTML para cada ejercicio dentro de un entrenamiento
                            return entrenamiento.Ejercicios.map(function (ejercicio) {
                                return `<p>-${ejercicio.Nombre} - ${ejercicio.Series} series x ${ejercicio.Repeticiones} repeticiones - ${ejercicio.Peso} - ${ejercicio.Tiempo}</p>`;
                            }).join('');
                        }).join('');  // Unir todos los ejercicios

                        // Crear una fila para cada rutina
                        var tableRow = `
                        <tr>
                            <td>${rutina.Nombre}</td>
                            <td>${new Date(rutina.Ejercicios[0].Fecha).toLocaleDateString()}</td>
                            <td>${ejerciciosHtml}</td>
                            <td>
                                <button class="btn btn-primary editarRutina" data-id="${rutina.Rutina_Id}">Editar</button>
                                <button class="btn btn-danger eliminarRutina" data-id="${rutina.Rutina_Id}">Eliminar</button>
                            </td>
                        </tr>
                    `;
                        tableBody.append(tableRow);  // Agregar la fila a la tabla
                    });

                    table.append(tableBody);  // Añadir el cuerpo de la tabla
                    $('#resultadoRutinas').append(table);  // Mostrar la tabla en el contenedor
                } else {
                    alert(response.message || 'No se pudieron cargar las rutinas.');
                }
            },
            error: function () {
                alert('Hubo un problema al cargar las rutinas.');
            }
        });
    }

    // Función para cargar los ejercicios en el modal
    function obtenerEjercicios() {
        $.ajax({
            type: "GET",
            url: "../Services/ServicioRutina.asmx/ObtenerEjercicios",
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    var dropdown = $('<select id="dropdownEjercicios" class="form-control"></select>');
                    dropdown.append('<option value="">Selecciona un ejercicio</option>');
                    response.ejercicios.forEach(function (ejercicio) {
                        dropdown.append(`<option value="${ejercicio.Ejercicio_Id}">${ejercicio.Nombre}</option>`);
                    });
                    $('#nuevoEjerciciosContainer').html(dropdown); // Mostrar el dropdown en el modal
                } else {
                    alert('No se pudieron cargar los ejercicios.');
                }
            },
            error: function () {
                alert('Hubo un problema al cargar los ejercicios.');
            }
        });
    }

    // Función para abrir el modal de agregar rutina
    $('#boton_agregar_rutina').on('click', function () {
        obtenerEjercicios(); // Cargar los ejercicios cuando se abre el modal
        $('#modalAgregarRutina').show();
    });

    // Función para cerrar el modal de agregar rutina
    $('#cerrarAgregarModalRutina').on('click', function () {
        $('#modalAgregarRutina').hide();
    });

    // Función para guardar la nueva rutina con los ejercicios
    $('#guardarNuevaRutina').on('click', function () {
        var fecha = $('#nuevaFecha').val();
        var ejercicios = [];

        // Recoger los ejercicios seleccionados y sus detalles
        $('#dropdownEjercicios option:selected').each(function () {
            var ejercicioId = $(this).val();
            if (ejercicioId) {
                ejercicios.push({
                    Ejercicio_Id: ejercicioId,
                    // Aquí puedes agregar más detalles como series, repeticiones, etc.
                });
            }
        });

        var nuevaRutina = {
            Fecha: fecha,
            Ejercicios: ejercicios
        };

        $.ajax({
            type: "POST",
            url: "../Services/ServicioRutina.asmx/AgregarRutina",  // URL del servicio
            data: JSON.stringify({ rutina: nuevaRutina }),
            contentType: "application/json",
            success: function (response) {
                if (response.d.success) {
                    obtenerRutinas();  // Recargar las rutinas
                    $('#modalAgregarRutina').hide();
                } else {
                    alert('No se pudo agregar la rutina');
                }
            },
            error: function () {
                alert('Hubo un error al guardar la rutina.');
            }
        });
    });

    // Función para eliminar una rutina
    $(document).on('click', '.eliminarRutina', function () {
        var rutinaId = $(this).data('id');  // Obtener el ID de la rutina

        // Confirmación antes de eliminar
        if (confirm("¿Estás seguro de que deseas eliminar esta rutina?")) {
            // Hacer la solicitud AJAX para eliminar la rutina
            $.ajax({
                type: "POST",
                url: "../Services/ServicioRutina.asmx/EliminarRutina",  // URL del servicio
                data: JSON.stringify({ rutinaId: rutinaId }),  // Enviar el ID de la rutina
                contentType: "application/json",  // Tipo de contenido
                success: function (response) {
                    var result = JSON.parse(response);
                    if (result.success) {
                        // Si la eliminación fue exitosa, actualizar la lista de rutinas
                        obtenerRutinas();
                        alert('Rutina eliminada exitosamente.');
                    } else {
                        alert('Error al eliminar la rutina: ' + result.message);
                    }
                },
                error: function () {
                    alert('Hubo un error al eliminar la rutina.');
                }
            });
        }
    });

    // Función para abrir el modal de editar rutina
    $(document).on('click', '.editarRutina', function () {
        var rutinaId = $(this).data('id');

        $.ajax({
            type: "POST",
            url: `../Services/ServicioRutina.asmx/ObtenerRutinaPorId`,  // URL corregida
            data: JSON.stringify({ rutinaId: rutinaId }),
            contentType: "application/json",
            success: function (response) {
                if (response.d.success) {
                    var rutina = response.d.rutina;
                    $('#editRutina_Id').val(rutina.Rutina_Id);
                    $('#editFecha').val(new Date(rutina.Fecha).toLocaleDateString());
                    // Agregar ejercicios al contenedor
                    var ejerciciosHtml = rutina.Ejercicios.map(function (ejercicio) {
                        return `<p>${ejercicio.Nombre}</p>`;
                    }).join('');
                    $('#editEjerciciosContainer').html(ejerciciosHtml);
                    $('#modalEditarRutina').show();
                } else {
                    alert('No se pudo obtener la rutina.');
                }
            },
            error: function () {
                alert('Hubo un error al obtener la rutina.');
            }
        });
    });

    // Función para cerrar el modal de editar rutina
    $('#cerrarModalEditarRutina').on('click', function () {
        $('#modalEditarRutina').hide();
    });

    // Función para guardar los cambios de la rutina editada
    $('#guardarCambiosRutina').on('click', function () {
        var rutinaId = $('#editRutina_Id').val();
        var nuevaFecha = $('#editFecha').val();
        var rutinaActualizada = {
            Rutina_Id: rutinaId,
            Fecha: nuevaFecha,
            // Otros datos de la rutina si es necesario
        };

        $.ajax({
            type: "POST",
            url: "../Services/ServicioRutina.asmx/ActualizarRutina",  // URL corregida
            data: JSON.stringify({ rutina: rutinaActualizada }),
            contentType: "application/json",
            success: function (response) {
                if (response.d.success) {
                    obtenerRutinas();  // Recargar las rutinas
                    $('#modalEditarRutina').hide();
                } else {
                    alert('No se pudieron guardar los cambios.');
                }
            },
            error: function () {
                alert('Hubo un error al guardar los cambios.');
            }
        });
    });
});
