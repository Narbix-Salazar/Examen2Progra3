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
    public partial class votantesbuscar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaBuscar.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                Response.Write("<script>alert('Por favor, ingrese una cédula para buscar.');</script>");
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
                        txtFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy-MM-dd");
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtCorreo.Text = reader["Correo"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró ningún votante con esa cédula.');</script>");
                    }
                }
            }
        }


        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }
    }
}
    