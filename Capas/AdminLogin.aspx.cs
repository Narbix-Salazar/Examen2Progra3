using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            string usuario = Usuario.Text.Trim();
            string contraseña = Contraseña.Text.Trim();

            // Cadena de conexión
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            // Consulta SQL para validar usuario y obtener el nombre
            string query = "SELECT NombreAdmin FROM admini WHERE NombreAdmin = @NombreAdmin AND Contraseña = @Contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreAdmin", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                try
                {
                    connection.Open();
                    string nombreAdmin = (string)command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(nombreAdmin))
                    {
                        // Usuario válido
                        Response.Write($"<script>alert('Administrador {usuario} ha ingresado correctamente.');</script>");
                        Response.Redirect("AdminMenu.aspx");
                    }
                    else
                    {
                        // Usuario no válido
                        Response.Write("<script>alert('Usuario o contraseña incorrectos.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepción
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}