using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class ResultadoDAO
    {
        private static readonly ResultadoDAO dao = new ResultadoDAO();

        public static ResultadoDAO getInstance()
        {
            return dao;
        }

        public void Gravar(Resultado r)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Resultado (DATA, RESULTADO) VALUES(@data, @res)";

                        SqlParameter parData = new SqlParameter("@data", r.Data);
                        SqlParameter parRes = new SqlParameter("@res", r.ResultadoPartida);
                        cmd.Parameters.Add(parData);
                        cmd.Parameters.Add(parRes);

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex) 
                    { 
                        throw ex; 
                    }
                }
            }
            catch (Exception e) 
            { 
                throw e; 
            }
        }
    }
}
