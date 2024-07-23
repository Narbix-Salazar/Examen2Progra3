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
    public partial class eliminarCandidato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscar = txtNombreBuscar.Text.Trim();

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

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            string nombreEliminar = txtNombreBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreEliminar))
            {
                Response.Write("<script>alert('El nombre del candidato es obligatorio para eliminar.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Eliminar registros relacionados en la tabla Votos
                string deleteVotesQuery = "DELETE FROM Votos WHERE CandidatoID IN (SELECT CandidatoID FROM Candidatos WHERE Nombre = @Nombre)";
                using (SqlCommand deleteVotesCmd = new SqlCommand(deleteVotesQuery, conn))
                {
                    deleteVotesCmd.Parameters.AddWithValue("@Nombre", nombreEliminar);
                    deleteVotesCmd.ExecuteNonQuery();
                }

                // Eliminar el candidato
                string deleteCandidatoQuery = "DELETE FROM Candidatos WHERE Nombre = @Nombre";
                using (SqlCommand deleteCandidatoCmd = new SqlCommand(deleteCandidatoQuery, conn))
                {
                    deleteCandidatoCmd.Parameters.AddWithValue("@Nombre", nombreEliminar);
                    int rowsAffected = deleteCandidatoCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Candidato eliminado exitosamente.');</script>");
                        LimpiarCampos();
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró el candidato para eliminar.');</script>");
                    }
                }

                conn.Close();
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