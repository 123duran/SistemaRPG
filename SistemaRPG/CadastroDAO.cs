using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaRPG
{
    class CadastroDAO
    {
        private static readonly CadastroDAO dao = new CadastroDAO();

        public static CadastroDAO getInstance()
        {
            return dao;
        }

        public void SelecionaCadastro(string emailLogin, string senhaLogin)
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

                        cmd.CommandText = @"SELECT COD_LOGIN, EMAIL, SENHA, PERFIL, ATIVO
                                            FROM Cadastro WHERE EMAIL = @email AND SENHA = @senha";

                        SqlParameter parEmail = new SqlParameter("@email", emailLogin);
                        SqlParameter parSenha = new SqlParameter("@senha", senhaLogin);

                        cmd.Parameters.Add(parEmail);
                        cmd.Parameters.Add(parSenha);

                        drLogin = cmd.ExecuteReader();
                        //Cadastro cad = new Cadastro();

                        while (drLogin.Read())
                        {
                            Cadastro.Cad.CodLogin = Convert.ToInt32(drLogin["COD_LOGIN"]);
                            Cadastro.Cad.Email = drLogin["EMAIL"].ToString();
                            Cadastro.Cad.Senha = drLogin["SENHA"].ToString();
                            Cadastro.Cad.Perfil = drLogin["PERFIL"].ToString();
                            Cadastro.Cad.Ativo = Convert.ToInt32(drLogin["ATIVO"]);
                        }
                        drLogin.Close();
                        //return Cadastro.Cad;
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

        public List<Cadastro> SelecionaPersonagem()
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

                        cmd.CommandText = @"SELECT  c.NOME AS Nome, c.EMAIL AS Email, p.COD_PER, p.NOME_PER AS Personagem 
                                            FROM Cadastro c INNER JOIN Personagem p
                                            ON c.COD_LOGIN = p.COD_LOGIN 
                                            WHERE c.ATIVO = 1 ORDER BY c.NOME";
                        
                        drLogin = cmd.ExecuteReader();
                        List<Cadastro> c = new List<Cadastro>();
                        Cadastro cad = null;

                        while (drLogin.Read())
                        {
                            cad = new Cadastro();
                            Personagem p = new Personagem();
                            p.CodPer = Convert.ToInt32(drLogin["cod_per"]);
                            p.nomePer = drLogin["Personagem"].ToString();
                            
                            cad.Nome = drLogin["Nome"].ToString();
                            cad.Email = drLogin["Email"].ToString();


                            cad.Personagem = p;

                            c.Add(cad);
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
            catch (Exception error)
            {
                throw error;
            }

        }

        public Personagem SelecionaPersonagem(Personagem p)
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

                        cmd.CommandText = @"SELECT c.NOME AS Nome, c.EMAIL AS Email, p.NOME_PER AS Personagem 
                                            FROM Cadastro c INNER JOIN Personagem p
                                            ON c.COD_LOGIN = p.COD_LOGIN 
                                            WHERE c.ATIVO = 1  AND c.NOME = @nome OR c.EMAIL = @email OR p.NOME_PER = @per
                                            ORDER BY c.NOME";

                        SqlParameter parNome =  new SqlParameter("@nome", p.Cadastro.Nome);
                        SqlParameter parEmail = new SqlParameter("@email", p.Cadastro.Email);
                        SqlParameter parNomePer = new SqlParameter("@per", p.NomePer);
                        drLogin = cmd.ExecuteReader();

                        Personagem per = null;

                        while (drLogin.Read())
                        {
                            per = new Personagem();
                            per.Cadastro.Nome = drLogin["Nome"].ToString();
                            per.Cadastro.Email = drLogin["Email"].ToString();
                            per.NomePer = drLogin["Personagem"].ToString();
                        }
                        drLogin.Close();
                        return per;
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
                                                AND c.COD_CAR = pc.COD_CAR";
                                                
                        drLogin = cmd.ExecuteReader();

                        while (drLogin.Read())
                        {
                            c.Nome = drLogin["Nome"].ToString();
                            c.Email = drLogin["Email"].ToString();
                            c.Personagem.NomePer = drLogin["Personagem"].ToString();
                          /*  c.Personagem.RacaPer = drLogin["Raça"].ToString();
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
                            c.Personagem.Caracteristica.TipoCarac = drLogin["Tipo de Caracteristica"].ToString();*/
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
