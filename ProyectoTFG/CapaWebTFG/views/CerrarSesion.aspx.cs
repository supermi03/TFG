using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWebTFG.views
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Elimina los datos del usuario de la sesión
            Session.Clear(); // Limpia todas las variables de sesión
            Session.Abandon(); // Abandona la sesión

            // Redirige a la página de inicio de sesión
            Response.Redirect("../views/IniciarSesion.aspx"); // Asegúrate de que este sea el nombre correcto de tu página de inicio de sesión
        }
    }
}