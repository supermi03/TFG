using System;
using System.Web;
using System.Web.UI;

namespace CapaWebTFG.views
{
    public partial class RutinasUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está autenticado
            if (!User.Identity.IsAuthenticated)
            {
                // Redirigir al usuario a la página de inicio de sesión si no está autenticado
                Response.Redirect("~/views/IniciarSesion.aspx");
            }

            // Cargar los datos de la página solo si el usuario está autenticado
            if (!IsPostBack)
            {
            }
        }
    }
}
