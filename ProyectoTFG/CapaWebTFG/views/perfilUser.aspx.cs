using System;
using System.Web;
using System.Web.UI;

namespace CapaWebTFG.views
{
    public partial class perfilUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                // Redirigir al inicio de sesión si el usuario no está autenticado
                Response.Redirect("../views/IniciarSesion.aspx");
            }
            else
            {
                // Asumiendo que ya tienes el UserId guardado en la sesión en el servidor.
                int userId = (int)Session["UserId"]; // El valor debe ser un int
                ClientScript.RegisterStartupScript(this.GetType(), "SetUserId", $"sessionStorage.setItem('UserId', '{userId}');", true);

            }
        }

    }
}
