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

        public List<Aventura> populaAventuraEspecifica(string codAventura)
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

                        cmd.CommandText = @"SELECT 
                                            av.DESC_AVENTURA AS Aventura,
                                            av.cod_Aventura
                                            FROM AVENTURA av 
                                            INNER JOIN CADASTRO c
                                            ON av.COD_LOGIN = c.COD_LOGIN
                                            WHERE 
                                            AV.COD_AVENTURA = @COD_AVENTURA    
                                            AND    c.COD_LOGIN = @CODLOGIN
                                            AND c.PERFIL = 'Administrador' 
                                            AND c.ATIVO = 1 ORDER BY 1";

                        SqlParameter parCodLog = new SqlParameter("@CODLOGIN", Cadastro.Cad.CodLogin);
                        cmd.Parameters.Add(parCodLog);
                        SqlParameter parCodAv = new SqlParameter("@COD_AVENTURA", Cadastro.Cad.CodLogin);
                        cmd.Parameters.Add(parCodAv);

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

        public List<Aventura> populaAventura()
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

                        cmd.CommandText = @"SELECT 
                                            av.DESC_AVENTURA AS Aventura,
                                            av.cod_Aventura
                                            FROM AVENTURA av 
                                            INNER JOIN CADASTRO c
                                            ON av.COD_LOGIN = c.COD_LOGIN WHERE c.COD_LOGIN = @cod AND c.PERFIL = 'Administrador' AND c.ATIVO = 1 ORDER BY 1";

                        SqlParameter parAv = new SqlParameter("@cod", Cadastro.Cad.CodLogin);
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

                        cmd.CommandText = "INSERT INTO Aventura (DESC_AVENTURA, SENHA,cod_login) VALUES(@aventura, @senha,@codlogin)";

                        SqlParameter parAven = new SqlParameter("@aventura", av.NomeAventura);
                        SqlParameter parSenha = new SqlParameter("@senha", av.Senha);
                        SqlParameter parLogin = new SqlParameter("@codlogin", Cadastro.Cad.CodLogin);

                        cmd.Parameters.Add(parLogin);
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
