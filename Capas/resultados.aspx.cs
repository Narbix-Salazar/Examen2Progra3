using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Examen__2.Capas
{
    public partial class resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResultados();
            }
        }

        private void LoadResultados()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT C.Nombre, ISNULL(SUM(V.VotoID), 0) AS VotosTotales, " +
                               "ISNULL(CAST(SUM(V.VotoID) AS DECIMAL) / (SELECT COUNT(*) FROM Votos) * 100, 0) AS PorcentajeVotos " +
                               "FROM Candidatos C LEFT JOIN Votos V ON C.CandidatoID = V.CandidatoID " +
                               "GROUP BY C.Nombre";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptResultados.DataSource = dt;
                rptResultados.DataBind();
            }
        }

        protected void ButtonResultados_Click(object sender, EventArgs e)
        {
            resultsPanel.Visible = true;

            // Lógica para calcular el ganador y total de votos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryTotalVotos = "SELECT SUM(VotosTotales) FROM Resultados";
                SqlCommand cmdTotalVotos = new SqlCommand(queryTotalVotos, conn);
                int totalVotos = (int)cmdTotalVotos.ExecuteScalar();
                lblTotalVotos.Text = totalVotos.ToString();

                string queryGanador = "SELECT TOP 1 CandidatoID, (SELECT Nombre FROM Candidatos WHERE CandidatoID = Resultados.CandidatoID) AS Nombre FROM Resultados ORDER BY VotosTotales DESC";
                SqlCommand cmdGanador = new SqlCommand(queryGanador, conn);
                SqlDataReader reader = cmdGanador.ExecuteReader();
                if (reader.Read())
                {
                    lblGanador.Text = reader["Nombre"].ToString();
                }
            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}