using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SistemaAgendamento.Repository
{
    internal class Repository
    {
        public int GravarConsultados(string Solicitacoes)
        {
            int NRegistros;


            SqlConnection conexao = ConexaoBanco();
            SqlCommand cmd = new SqlCommand($"update Fila_Andamento set[status]='{Solicitacoes}' where numero_processo='{Solicitacoes}'", conexao);
            conexao.Open();
            try
            {
                NRegistros = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return NRegistros;
        }

        public static SqlConnection ConexaoBanco()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = "VC0003\\SQLEXPRESS01",
                InitialCatalog = "Compromissos",
                UserID = "loteador",
                TrustServerCertificate = true,
                Password = "mediterraneo"
            };
            string conexao = builder.ConnectionString;
            SqlConnection conexaoBanco = new SqlConnection(conexao);
            return conexaoBanco;
        }
    }
}
