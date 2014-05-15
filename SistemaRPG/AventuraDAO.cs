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

        public List<Aventura> populaAventura(int codlogin )
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

                        cmd.CommandText = @"SELECT av.AVENTURA AS Aventura FROM AVENTURA av INNER JOIN CADASTRO c
                                            ON av.COD_LOGIN = c.COD_LOGIN WHERE c.COD_LOGIN = @cod AND c.PERFIL = 'Administrador' AND c.ATIVO = 1 ORDER BY 1";

                        SqlParameter parAv = new SqlParameter("@cod", codlogin);
                        cmd.Parameters.Add(parAv);

                        List<Aventura> aventura = new List<Aventura>();
                        Aventura av = null;
                        drAventura = cmd.ExecuteReader();

                        while (drAventura.Read())
                        {
                        
                        av = new Aventura();
                            av.NomeAventura = drAventura["Aventura"].ToString();

                            aventura.Add(av);
                       }
                        drAventura.Close();
                        return aventura;
                    }
                    catch (SqlException ex)
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

                        cmd.CommandText = "INSERT INTO Aventura (AVENTURA, SENHA) VALUES(@aventura, @senha)";

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
