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
    public partial class votantesagregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonAgregar_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }

            DateTime birthDate;
            if (!DateTime.TryParse(fechaNacimiento, out birthDate))
            {
                Response.Write("<script>alert('Fecha de nacimiento inválida.');</script>");
                return;
            }

            int age = CalculateAge(birthDate);
            if (age < 18)
            {
                Response.Write("<script>alert('No se permite el registro de menores de 18 años.');</script>");
                return;
            }

            // Verificar si el ID ya existe
            if (ExisteVotante(cedula))
            {
                Response.Write("<script>alert('El ID ya está en uso.');</script>");
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Votantes (ID, Nombre, Contraseña, FechaNacimiento, Direccion, Correo) " +
                               "VALUES (@ID, @Nombre, @Contraseña, @FechaNacimiento, @Direccion, @Correo)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", cedula);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", birthDate);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Correo", correo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Response.Write("<script>alert('Votante agregado exitosamente.');</script>");
            LimpiarCampos();
        }

        private bool ExisteVotante(string id)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Votantes WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
        }



        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capas/AdminMenu.aspx");
        }

        private void LimpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtContraseña.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
    }
}