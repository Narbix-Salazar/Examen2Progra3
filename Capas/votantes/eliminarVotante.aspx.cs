using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas.votantes
{
    public partial class votanteseliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                Response.Write("<script>alert('Por favor, ingrese la cédula.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Votantes WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", cedula);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtContraseña.Text = reader["Contraseña"].ToString();
                        txtFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy-MM-dd");
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtCorreo.Text = reader["Correo"].ToString();

                        // Campos deshabilitados para edición
                        txtNombre.Enabled = false;
                        txtContraseña.Enabled = false;
                        txtFechaNacimiento.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtCorreo.Enabled = false;
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró el votante con la cédula proporcionada.');</script>");
                    }
                    conn.Close();
                }
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                Response.Write("<script>alert('Por favor, ingrese la cédula para eliminar.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Eliminar registros relacionados en la tabla Votos
                string deleteVotesQuery = "DELETE FROM Votos WHERE VotanteID = @ID";
                using (SqlCommand deleteVotesCmd = new SqlCommand(deleteVotesQuery, conn))
                {
                    deleteVotesCmd.Parameters.AddWithValue("@ID", cedula);
                    deleteVotesCmd.ExecuteNonQuery();
                }

                // Eliminar registro en la tabla Votantes
                string deleteVotanteQuery = "DELETE FROM Votantes WHERE ID = @ID";
                using (SqlCommand deleteVotanteCmd = new SqlCommand(deleteVotanteQuery, conn))
                {
                    deleteVotanteCmd.Parameters.AddWithValue("@ID", cedula);
                    int rowsAffected = deleteVotanteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Votante eliminado exitosamente.');</script>");
                        // Limpiar los campos después de eliminar
                        txtCedula.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        txtFechaNacimiento.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtCorreo.Text = string.Empty;

                        // Habilitar campos nuevamente
                        txtNombre.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtFechaNacimiento.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtCorreo.Enabled = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('No se pudo eliminar el votante.');</script>");
                    }
                }

                conn.Close();
            }
        }

protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }
    }
}