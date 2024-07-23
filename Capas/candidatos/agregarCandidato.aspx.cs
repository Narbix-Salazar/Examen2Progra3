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
    public partial class agregarCandidato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string partidoPolitico = ddlPartidoPolitico.SelectedValue;
            string plataforma = ddlPlataforma.SelectedValue;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(partidoPolitico) || string.IsNullOrWhiteSpace(plataforma))
            {
                Response.Write("<script>alert('Todos los campos son obligatorios.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Candidatos (Nombre, PartidoPolitico, Plataforma) " +
                               "VALUES (@Nombre, @PartidoPolitico, @Plataforma)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@PartidoPolitico", partidoPolitico);
                    cmd.Parameters.AddWithValue("@Plataforma", plataforma);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Response.Write("<script>alert('Candidato agregado exitosamente.');</script>");
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            ddlPartidoPolitico.SelectedIndex = 0;
            ddlPlataforma.SelectedIndex = 0;
        }
        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }
    }
}