using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas.candidatos
{
    public partial class buscarCandidato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscar = txtNombreBuscar.Text;

            if (string.IsNullOrWhiteSpace(nombreBuscar))
            {
                Response.Write("<script>alert('El nombre del candidato es obligatorio para buscar.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PartidoPolitico, Plataforma FROM Candidatos WHERE Nombre = @Nombre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreBuscar);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPartidoPolitico.Text = reader["PartidoPolitico"].ToString();
                            txtPlataforma.Text = reader["Plataforma"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontró el candidato.');</script>");
                            LimpiarCampos();
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreBuscar.Text = "";
            txtPartidoPolitico.Text = "";
            txtPlataforma.Text = "";
        }
        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }
    }
}