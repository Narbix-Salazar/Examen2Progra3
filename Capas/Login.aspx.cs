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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            string id = Usuario.Text.Trim();
            string contraseña = Contraseña.Text.Trim();

            // Cadena de conexión
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            // Consulta SQL para validar usuario y obtener el nombre
            string query = "SELECT Nombre FROM VOTANTES WHERE ID = @ID AND Contraseña = @Contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Contraseña", contraseña); // Asegúrate de que la contraseña esté cifrada en la base de datos

                try
                {
                    connection.Open();
                    LoginStatus.Text = "Conexión con la base de datos exitosa.";

                    string nombreUsuario = (string)command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(nombreUsuario))
                    {
                        // Usuario válido
                        Session["VotanteID"] = id; // Guarda el ID del votante en la sesión
                        LoginStatus.Text = $"¡Ingreso exitoso! Bienvenido, {nombreUsuario}.";
                        Response.Redirect("Menu.aspx");
                    }
                    else
                    {
                        // Usuario no válido
                        LoginStatus.Text = "Usuario o contraseña incorrectos.";
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepción
                    LoginStatus.Text = "Error al conectar con la base de datos: " + ex.Message;
                }
            }
            
        }
        protected void ButtonAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}