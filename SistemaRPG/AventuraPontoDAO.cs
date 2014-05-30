using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class AventuraPontoDAO
    {
        public static readonly AventuraPontoDAO dao = new AventuraPontoDAO();

        public static AventuraPontoDAO getInstance()
        {
            return dao;
        }

        public void gravarPonto(int codAv, string descAv, string texto)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"INSERT INTO AventuraPonto (COD_AVENTURA, DESC_AVENTURA, TEXTO, DATA) VALUES (@codAv, @descAv, @texto, GETDATE())";

                        SqlParameter parAv = new SqlParameter("@codAv", codAv);
                        SqlParameter parDesc = new SqlParameter("@descAv", descAv);
                        SqlParameter parTexto = new SqlParameter("@texto", texto);

                        cmd.Parameters.Add(parAv);
                        cmd.Parameters.Add(parDesc);
                        cmd.Parameters.Add(parTexto);

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
