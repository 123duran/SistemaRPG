using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaRPG
{
    class AventuraDAO
    {

        public int maxAventura()
        {
            SqlDataReader drAventura = null;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT max(cod_aventura) as maximum
                                            FROM Aventura";

                        drAventura = cmd.ExecuteReader();

                        int maxAvent = 0;
                        while (drAventura.Read())
                        {
                             maxAvent = Convert.ToInt32(drAventura["maximum"]);
                        }
                        drAventura.Close();
                        return maxAvent;
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
