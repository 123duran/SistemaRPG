using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class AventuraDadoDAO
    {
        public static readonly AventuraDadoDAO dao = new AventuraDadoDAO();

        public static AventuraDadoDAO getInstance()
        {
            return dao;
        }

        public void gravarDado(int codAv, int codPer, int num)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"INSERT INTO AventuraDado (COD_AVENTURA, COD_PER, NUMERO, ATIVO) VALUES (@codAv, @codPer, @num, 1)";

                        SqlParameter parAv = new SqlParameter("@codAv", codAv);
                        SqlParameter parPer = new SqlParameter("@codPer", codPer);
                        SqlParameter parNum = new SqlParameter("@num", num);

                        cmd.Parameters.Add(parAv);
                        cmd.Parameters.Add(parPer);
                        cmd.Parameters.Add(parNum);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        Conexao.fecharConexao();
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
