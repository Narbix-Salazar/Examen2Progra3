using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVotar_Click(object sender, EventArgs e)
        {
            Response.Redirect("votaciones.aspx");
        }

        protected void btnResultados_Click(object sender, EventArgs e)
        {
            Response.Redirect("resultados.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}