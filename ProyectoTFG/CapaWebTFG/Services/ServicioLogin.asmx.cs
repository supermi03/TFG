using Newtonsoft.Json;
using ProyectoTFG.Modelos;
using System;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using ProyectoTFG.DAL;
using BCrypt.Net;
using System.Web.Security;

namespace CapaWebTFG.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ServicioLogin : WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string IniciarSesion(string email, string password, bool recordarme)
        {
            try
            {
                using (var context = new Contexto())
                {
                    // Buscar al usuario por email
                    var persona = context.Personas.FirstOrDefault(p => p.Email == email);
                    if (persona == null)
                    {
                        return JsonConvert.SerializeObject(new { success = false, message = "El email no está registrado." });
                    }

                    // Verificar la contraseña
                    if (string.IsNullOrEmpty(persona.Password) || !BCrypt.Net.BCrypt.Verify(password, persona.Password))
                    {
                        return JsonConvert.SerializeObject(new { success = false, message = "Contraseña incorrecta." });
                    }

                    // Si la autenticación fue exitosa, establecer FormsAuthentication
                    FormsAuthentication.SetAuthCookie(persona.Persona_Id.ToString(), recordarme);

                    // Almacenar UserId como int en la sesión
                    HttpContext.Current.Session["UserId"] = persona.Persona_Id;

                    return JsonConvert.SerializeObject(new { success = true, message = "Inicio de sesión exitoso.", userId = persona.Persona_Id });
                }
            }
            catch (Exception ex)
            {
                // Se puede loguear el error para mayor detalle
                return JsonConvert.SerializeObject(new { success = false, message = "Ocurrió un error durante el inicio de sesión. Inténtelo de nuevo." });
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string CerrarSesion()
        {
            try
            {
                // Cerrar sesión con FormsAuthentication
                FormsAuthentication.SignOut();
                HttpContext.Current.Session.Abandon(); // Abandonar la sesión

                return JsonConvert.SerializeObject(new { success = true, message = "Sesión cerrada exitosamente." });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = "Ocurrió un error al cerrar la sesión." });
            }
        }
    }
}
