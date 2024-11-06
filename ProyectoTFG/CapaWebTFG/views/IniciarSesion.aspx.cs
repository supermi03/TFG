using System;
using System.Web;
using System.Web.UI;

namespace CapaWebTFG.views
{
    public partial class IniciarSesion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el usuario ya está autenticado
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("../views/mainUser.aspx"); // Redirige si ya está autenticado
            }
        }
    }
}
