using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class CadastroDAO
    {
        private static readonly CadastroDAO dao = new CadastroDAO();

        public static CadastroDAO getInstance()
        {
            return dao;
        }

        public Cadastro Seleciona(string emailLogin, string senhaLogin)
        {
            SqlDataReader drLogin = null;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT EMAIL, SENHA, PERFIL, ATIVO
                                            FROM Cadastro 
                                            WHERE EMAIL = @email AND SENHA = @senha";

                        SqlParameter parEmail = new SqlParameter("@email", emailLogin);
                        SqlParameter parSenha = new SqlParameter("@senha", senhaLogin);

                        cmd.Parameters.Add(parEmail);
                        cmd.Parameters.Add(parSenha);

                        drLogin = cmd.ExecuteReader();
                        Cadastro cad = new Cadastro();

                        while (drLogin.Read())
                        {
                            cad.Email = drLogin["EMAIL"].ToString();
                            cad.Senha = drLogin["SENHA"].ToString();
                            cad.Perfil = drLogin["PERFIL"].ToString();
                            cad.Ativo = Convert.ToInt32(drLogin["ATIVO"]);
                        }
                        drLogin.Close();
                        return cad;
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

        public Boolean checaUsu(string usuario)
        {
            SqlDataReader drLogin = null;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT nome
                                            FROM Cadastro
                                            WHERE nome = @usuario ;"
                            ;

                        SqlParameter parUsu = new SqlParameter("@usuario", usuario);
                        cmd.Parameters.Add(parUsu);
                        drLogin = cmd.ExecuteReader();
                        if (drLogin.HasRows)
                        {
                            return true;
                        }
                        else
                        {

                            return false;
                        }
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

        public void Gravar(Cadastro l)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"INSERT INTO Cadastro (NOME, EMAIL, SENHA, PERFIL, ATIVO) VALUES (@nome, @email, @senha, @perfil, @ativo)";

                        SqlParameter parNome = new SqlParameter("@nome", l.Nome);
                        SqlParameter parEmail = new SqlParameter("@email", l.Email);
                        SqlParameter parSenha = new SqlParameter("@senha", l.Senha);
                        SqlParameter parPerfil = new SqlParameter("@perfil", l.Perfil);
                        SqlParameter parAtivo = new SqlParameter("@ativo", l.Ativo);

                        cmd.Parameters.Add(parNome);
                        cmd.Parameters.Add(parEmail);
                        cmd.Parameters.Add(parSenha);
                        cmd.Parameters.Add(parPerfil);
                        cmd.Parameters.Add(parAtivo);

                        cmd.ExecuteNonQuery();
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
    }
}
