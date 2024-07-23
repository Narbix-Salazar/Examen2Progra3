using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonagregarCandidato_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatos/agregarCandidato.aspx");
        }
        protected void ButtonmodificarCandidato_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatos/modificarCandidato.aspx");
        }
        protected void ButtonbuscarCandidato_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatos/buscarCandidato.aspx");
        }
        protected void ButtoneliminarCandidato_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatos/eliminarCandidato.aspx");
        }









        protected void ButtonagregarVotante_Click(object sender, EventArgs e)
        {
            Response.Redirect("votantes/agregarVotante.aspx");
        }
        protected void ButtonmodificarVotante_Click(object sender, EventArgs e)
        {
            Response.Redirect("votantes/modificarVotante.aspx");
        }
        protected void ButtonbuscarVotante_Click(object sender, EventArgs e)
        {
            Response.Redirect("votantes/buscarVotante.aspx");
        }
        protected void ButtoneliminarVotante_Click(object sender, EventArgs e)
        {
            Response.Redirect("votantes/eliminarVotante.aspx");
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
