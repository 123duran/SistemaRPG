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

        public Cadastro SelecionaCadastro(string emailLogin, string senhaLogin)
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
                                            FROM Cadastro WHERE EMAIL = @email AND SENHA = @senha";

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
                                            WHERE nome = @usuario ;";

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

        public Cadastro SelecionaPersonagem(Cadastro c)
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

                        cmd.CommandText = @"SELECT ca.NOME AS Nome, ca.EMAIL AS Email, p.NOME_PER AS Personagem, p.RACA_PER AS Raça, p.FORCA_PER AS Força, p.TIPO_PER AS 'Tipo de Personagem', 
                                                p.NIVEL_PER AS Nível, p.HAB_PER AS Habilidade, p.RES_PER AS Resistência, p.ARM_PER AS Armadura, p.PV_PER AS 'Pontos de Vida', 
                                                p.PDF_PER AS 'Poder de Fogo', c.NOME_CAR AS Característica, c.MOD_CAR AS 'MOD', c.TIPO_CAR AS 'Tipo de Caracteristica'
                                                FROM Cadastro ca, Personagem p, Caracteristica c, Personagem_Caracteristica pc 
                                                WHERE ca.COD_PER = p.COD_PER 
                                                AND p.COD_PER = pc.COD_PER
                                                AND c.COD_CAR = pc.COD_CAR
                                                AND ca.NOME LIKE @nome ORDER BY ca.NOME";

                        SqlParameter parNome = new SqlParameter("@nome", c.Nome);
                        cmd.Parameters.Add(parNome);
                        drLogin = cmd.ExecuteReader();

                        while (drLogin.Read())
                        {
                            c.Nome = drLogin["Nome"].ToString();
                            c.Email = drLogin["Email"].ToString();
                            c.Personagem.NomePer = drLogin["Personagem"].ToString();
                            c.Personagem.RacaPer = drLogin["Raça"].ToString();
                            c.Personagem.ForcaPer = Convert.ToInt32(drLogin["Força"]);
                            c.Personagem.TipoPer = drLogin["Tipo de Personagem"].ToString();
                            c.Personagem.NivelPer = Convert.ToInt32(drLogin["Nível"]);
                            c.Personagem.HabPer = Convert.ToInt32(drLogin["Habilidade"]);
                            c.Personagem.ResPer = Convert.ToInt32(drLogin["Resistência"]);
                            c.Personagem.ArmPer = Convert.ToInt32(drLogin["Armadura"]);
                            c.Personagem.PvPer = Convert.ToInt32(drLogin["Pontos de Vida"]);
                            c.Personagem.PdfPer = Convert.ToInt32(drLogin["Poder de Fogo"]);
                            c.Personagem.Caracteristica.NmCarac = drLogin["Caracteristica"].ToString();
                            c.Personagem.Caracteristica.ModCarac = Convert.ToInt32(drLogin["MOD"]);
                            c.Personagem.Caracteristica.TipoCarac = drLogin["Tipo de Caracteristica"].ToString();
                        }
                        drLogin.Close();
                        return c;

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

        private int ConvertToInt32()
        {
            throw new NotImplementedException();
        }

        public void Gravar(Cadastro c)
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

                        SqlParameter parNome = new SqlParameter("@nome", c.Nome);
                        SqlParameter parEmail = new SqlParameter("@email", c.Email);
                        SqlParameter parSenha = new SqlParameter("@senha", c.Senha);
                        SqlParameter parPerfil = new SqlParameter("@perfil", c.Perfil);
                        SqlParameter parAtivo = new SqlParameter("@ativo", c.Ativo);

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
