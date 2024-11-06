using Newtonsoft.Json;
using ProyectoTFG.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using ProyectoTFG.DAL;

namespace CapaWebTFG.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ServicioRutina : WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ObtenerRutinas()
        {
            try
            {
                using (var context = new Contexto()) // Suponiendo que tienes un contexto de base de datos
                {
                    var rutinas = context.Rutinas
                        .Select(r => new
                        {
                            r.Rutina_Id,
                            r.Nombre,
                            r.Descripcion,
                            Ejercicios = r.Entrenamientos
                                .Select(e => new
                                {
                                    e.Fecha,
                                    Ejercicios = e.EntrenamientoEjercicios.Select(ee => new
                                    {
                                        ee.Ejercicios.Nombre,
                                        ee.Series,
                                        ee.Repeticiones,
                                        ee.Peso,
                                        ee.Tiempo
                                    }).ToList()
                                }).ToList()
                        }).ToList();

                    // Devolver respuesta JSON directamente
                    Context.Response.ContentType = "application/json";
                    var response = new { success = true, rutinas };
                    Context.Response.Write(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception ex)
            {
                // En caso de error, devolver un JSON con el error
                Context.Response.ContentType = "application/json";
                var response = new { success = false, message = ex.Message };
                Context.Response.Write(JsonConvert.SerializeObject(response));
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string EliminarRutina(int rutinaId)
        {
            try
            {
                using (var context = new Contexto())
                {
                    var rutina = context.Rutinas.Find(rutinaId);
                    if (rutina == null)
                    {
                        return JsonConvert.SerializeObject(new { success = false, message = "Rutina no encontrada." });
                    }

                    // Eliminar los entrenamientos asociados a la rutina
                    var entrenamientos = context.Entrenamientos.Where(e => e.Rutina_Id == rutinaId).ToList();
                    context.Entrenamientos.RemoveRange(entrenamientos);

                    // Finalmente eliminar la rutina
                    context.Rutinas.Remove(rutina);
                    context.SaveChanges();

                    return JsonConvert.SerializeObject(new { success = true, message = "Rutina eliminada exitosamente." });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string ObtenerEjercicios(int pageNumber = 1, int pageSize = 10)
        {
        try
        {
            using (var context = new Contexto())
            {
                // Implementar paginación
                var ejerciciosQuery = context.Ejercicios
                    .OrderBy(e => e.Nombre) // O cualquier criterio que desees
                    .Skip((pageNumber - 1) * pageSize) // Saltar los ejercicios de las páginas anteriores
                    .Take(pageSize); // Limitar la cantidad de ejercicios a la página actual

                var ejercicios = ejerciciosQuery.Select(e => new
                {
                    e.Ejercicios_Id,
                    e.Nombre
                }).ToList();

                return JsonConvert.SerializeObject(new { success = true, ejercicios });
            }
        }
        catch (Exception ex)
        {
            // En caso de error, registrar el error y devolver un mensaje genérico
            return JsonConvert.SerializeObject(new { success = false, message = "Ocurrió un error al obtener los ejercicios." });
        }
}
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string ObtenerPersonas()
        {
            try
            {
                using (var context = new Contexto())
                {
                    var personas = context.Personas.Select(p => new
                    {
                        p.Persona_Id,
                        p.Nombre
                    }).ToList();

                    return JsonConvert.SerializeObject(new { success = true, personas });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string AgregarRutina(int personaId, List<int> ejerciciosSeleccionados)
        {
            try
            {
                using (var context = new Contexto())
                {
                    // Crear una nueva rutina
                    var rutina = new Rutina
                    {
                        Nombre = "Nueva rutina",
                        Descripcion = "Descripción de la rutina",
                        Persona_Id = personaId // Asociar la rutina a la persona
                    };

                    context.Rutinas.Add(rutina);
                    context.SaveChanges(); // Guardar la rutina

                    // Crear un nuevo entrenamiento
                    var entrenamiento = new Entrenamiento
                    {
                        Fecha = DateTime.Now,
                        Persona_Id = personaId,
                        Rutina_Id = rutina.Rutina_Id // Asociar la rutina al entrenamiento
                    };

                    context.Entrenamientos.Add(entrenamiento);
                    context.SaveChanges(); // Guardar el entrenamiento y generar el ID

                    // Obtener el Entrenamiento_Id generado
                    var entrenamientoId = entrenamiento.Entrenamiento_Id;

                    // Asociar los ejercicios seleccionados con el entrenamiento
                    var listaEntrenamientoEjercicios = ejerciciosSeleccionados.Select(ejercicioId => new Entrenamiento_Ejercicios
                    {
                        Ejercicios_Id = ejercicioId,
                        Entrenamiento_Id = entrenamientoId, // Usar el ID obtenido después de guardar
                        Series = 3, // Asume un valor predeterminado o obtener de otra fuente
                        Repeticiones = 10, // Lo mismo para repeticiones
                        Peso = "20kg", // Valor predeterminado o de la entrada
                        Tiempo = "30 segundos" // Tiempo predeterminado
                    }).ToList();

                    // Asociar los ejercicios al entrenamiento
                    entrenamiento.EntrenamientoEjercicios = listaEntrenamientoEjercicios;
                    context.SaveChanges(); // Guardar cambios finales

                    return JsonConvert.SerializeObject(new { success = true, message = "Rutina agregada exitosamente." });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }



        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string ObtenerRutinaPorId(int rutinaId)
        {
            try
            {
                using (var context = new Contexto())
                {
                    var rutina = context.Rutinas
                        .Where(r => r.Rutina_Id == rutinaId)
                        .Select(r => new
                        {
                            r.Rutina_Id,
                            r.Nombre,
                            r.Descripcion,
                            Ejercicios = r.Entrenamientos.Select(e => new
                            {
                                e.Fecha,
                                Ejercicios = e.EntrenamientoEjercicios.Select(ee => new
                                {
                                    ee.Ejercicios.Nombre,
                                    ee.Series,
                                    ee.Repeticiones,
                                    ee.Peso,
                                    ee.Tiempo
                                }).ToList()
                            }).FirstOrDefault()
                        }).FirstOrDefault();

                    if (rutina == null)
                    {
                        return JsonConvert.SerializeObject(new { success = false, message = "Rutina no encontrada." });
                    }

                    return JsonConvert.SerializeObject(new { success = true, rutina });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }







        //[WebMethod]
        //[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        //public string ActualizarRutina(int rutinaId, string nombre, string descripcion, List<Entrenamiento_Ejercicios> ejercicios)
        //{
        //    try
        //    {
        //        using (var context = new Contexto())
        //        {
        //            // Obtener la rutina a actualizar
        //            var rutina = context.Rutinas.Find(rutinaId);
        //            if (rutina == null)
        //            {
        //                return JsonConvert.SerializeObject(new { success = false, message = "Rutina no encontrada." });
        //            }

        //            // Actualizar la información de la rutina
        //            rutina.Nombre = nombre;
        //            rutina.Descripcion = descripcion;

        //            // Actualizar los ejercicios de la rutina
        //            var entrenamiento = context.Entrenamientos.FirstOrDefault(e => e.Rutina_Id == rutinaId);
        //            if (entrenamiento != null)
        //            {
        //                // Eliminar los ejercicios antiguos
        //                context.Entrenamiento_Ejercicios.RemoveRange(entrenamiento.EntrenamientoEjercicios);

        //                // Agregar los nuevos ejercicios
        //                entrenamiento.EntrenamientoEjercicios = ejercicios;
        //            }

        //            // Guardar los cambios
        //            context.SaveChanges();

        //            return JsonConvert.SerializeObject(new { success = true, message = "Rutina actualizada exitosamente." });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
        //    }
        //}

    }
}
