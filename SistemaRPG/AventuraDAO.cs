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
        public static readonly AventuraDAO dao = new AventuraDAO();

        public static AventuraDAO getInstance()
        {
            return dao;
        }

        public int maxAventura()
        {
            SqlDataReader drAventura = null;
            int maxAvent = 0;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT COALESCE(MAX(COD_AVENTURA),MAX(COD_AVENTURA),0) AS maximum
                                            FROM Aventura";

                        drAventura = cmd.ExecuteReader();

                        
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

        public void Gravar(Aventura av)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Aventura (NOME_AVENTURA, SENHA) VALUES(@aventura, @senha)";

                        SqlParameter parAven = new SqlParameter("@aventura", av.NomeAventura);
                        SqlParameter parSenha = new SqlParameter("@senha", av.Senha);

                        cmd.Parameters.Add(parAven);
                        cmd.Parameters.Add(parSenha);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
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
