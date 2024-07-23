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
    public partial class votantesmodificar : System.Web.UI.Page
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

                        // Habilitar los campos para edición
                        txtNombre.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtFechaNacimiento.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtCorreo.Enabled = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró el votante con la cédula proporcionada.');</script>");
                    }
                    conn.Close();
                }
            }
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string fechaNacimiento = txtFechaNacimiento.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña) ||
                string.IsNullOrEmpty(fechaNacimiento) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(correo))
            {
                Response.Write("<script>alert('Todos los campos deben ser llenados.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Votantes SET Nombre = @Nombre, Contraseña = @Contraseña, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion, Correo = @Correo WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", cedula);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Correo", correo);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Votante modificado exitosamente.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se pudo modificar el votante.');</script>");
                    }
                }
            }
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos del formulario
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;

            // Deshabilitar los campos de edición
            txtNombre.Enabled = false;
            txtContraseña.Enabled = false;
            txtFechaNacimiento.Enabled = false;
            txtDireccion.Enabled = false;
            txtCorreo.Enabled = false;
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }
    }
}