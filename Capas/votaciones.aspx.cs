using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen__2.Capas
{
    public partial class votaciones : System.Web.UI.Page
    {
        private int ObtenerVotanteID()
        {
            // Verificar si el valor en la sesión es null
            if (Session["VotanteID"] == null)
            {
                return 0; // O manejar el caso según sea necesario
            }

            // Verificar si el valor en la sesión es del tipo esperado
            if (Session["VotanteID"] is int)
            {
                return (int)Session["VotanteID"];
            }

            // Si no es del tipo esperado, devolver un valor predeterminado o manejar el error
            int votanteID;
            if (int.TryParse(Session["VotanteID"].ToString(), out votanteID))
            {
                return votanteID;
            }

            return 0; // O manejar el caso según sea necesario
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatos();
            }
        }

        private void CargarCandidatos()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CandidatoID, Nombre, PartidoPolitico, Plataforma FROM Candidatos";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    rptCandidatos.DataSource = reader;
                    rptCandidatos.DataBind();
                }
            }
        }

        protected void btnVotar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int candidatoID = int.Parse(btn.CommandArgument);
            int votanteID = ObtenerVotanteID();

            if (votanteID == 0)
            {
                VotacionStatus.Text = "Error: Usuario no autenticado o sesión inválida.";
                return;
            }

            string checkVoteQuery = "SELECT COUNT(*) FROM Votos WHERE VotanteID = @VotanteID";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                SqlCommand checkVoteCmd = new SqlCommand(checkVoteQuery, conn);
                checkVoteCmd.Parameters.AddWithValue("@VotanteID", votanteID);

                try
                {
                    conn.Open();
                    int votosExistentes = (int)checkVoteCmd.ExecuteScalar();

                    if (votosExistentes > 0)
                    {
                        VotacionStatus.Text = "Error: Ya has votado.";
                        return;
                    }

                    // Registrar el voto
                    string insertVoteQuery = "INSERT INTO Votos (VotanteID, CandidatoID, FechaVoto) VALUES (@VotanteID, @CandidatoID, @FechaVoto)";
                    SqlCommand insertVoteCmd = new SqlCommand(insertVoteQuery, conn);
                    insertVoteCmd.Parameters.AddWithValue("@VotanteID", votanteID);
                    insertVoteCmd.Parameters.AddWithValue("@CandidatoID", candidatoID);
                    insertVoteCmd.Parameters.AddWithValue("@FechaVoto", DateTime.Now.Date);

                    insertVoteCmd.ExecuteNonQuery();

                    VotacionStatus.Text = "Muchas gracias por votar tu voto fue registrado con éxito.";
                }
                catch (Exception ex)
                {
                    VotacionStatus.Text = "Error al conectar con la base de datos: " + ex.Message;
                }
            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}
