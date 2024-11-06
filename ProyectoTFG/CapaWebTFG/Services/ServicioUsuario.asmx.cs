using Newtonsoft.Json;
using ProyectoTFG.DAL;
using System;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CapaWebTFG.Services
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService] 
    public class ServicioUsuario : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]

        public string ObtenerDatosUsuario(int userId)
        {
            using (var context = new Contexto())
            {
                var usuario = context.Personas.FirstOrDefault(u => u.Persona_Id == userId);
                if (usuario == null)
                {
                    return JsonConvert.SerializeObject(new { success = false, message = "Usuario no encontrado" });
                }

                var datosUsuario = new
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    FechaNacimiento = usuario.Fecha_nacimiento.ToString("dd/MM/yyyy"),
                    FechaRegistro = usuario.Fecha_Registro.ToString("dd/MM/yyyy"),
                    Telefono = usuario.Telefono,
                    Direccion = usuario.Direccion
                };

                return JsonConvert.SerializeObject(new { success = true, data = datosUsuario });
            }
        }
    }
}
