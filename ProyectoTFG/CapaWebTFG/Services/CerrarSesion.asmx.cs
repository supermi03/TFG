//using System;
//using System.Web;
//using System.Web.Services;
//using Newtonsoft.Json;

//namespace CapaWebTFG.Services
//{
//    [WebService(Namespace = "http://tempuri.org/")]
//    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//    [System.ComponentModel.ToolboxItem(false)]
//    [System.Web.Script.Services.ScriptService]
//    public class ServicioCerrarSesion : WebService
//    {
//        [WebMethod(EnableSession = true)]
//        public string CerrarSesion()
//        {
//            try
//            {
//                // Eliminar la sesión
//                HttpContext.Current.Session["persona_Id"] = null;
//                HttpContext.Current.Session.Clear();
//                HttpContext.Current.Session.Abandon();

//                // Eliminar la cookie
//                if (HttpContext.Current.Request.Cookies["persona_Id"] != null)
//                {
//                    HttpCookie cookie = new HttpCookie("persona_Id")
//                    {
//                        Expires = DateTime.Now.AddDays(-1), // Establecer la cookie como expirada
//                        HttpOnly = true,
//                        Secure = HttpContext.Current.Request.IsSecureConnection
//                    };
//                    HttpContext.Current.Response.Cookies.Add(cookie);
//                }

//                // Devolver un mensaje de éxito
//                return JsonConvert.SerializeObject(new { success = true, message = "Sesión cerrada correctamente." });
//            }
//            catch (Exception ex)
//            {
//                return JsonConvert.SerializeObject(new { success = false, message = $"Error al cerrar la sesión: {ex.Message}" });
//            }
//        }
//    }
//}
