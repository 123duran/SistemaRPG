using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class PartidaDAO
    {
        private static readonly PartidaDAO dao = new PartidaDAO();

        public static PartidaDAO getInstance()
        {
            return dao;
        }

        public void InserirPersonagem(Personagem per)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Partida_Personagem (COD_PER, COD_PARTIDA) VALUES (@per, @partida)";

                        SqlParameter parPer = new SqlParameter("@per", per.CodPer);
                        SqlParameter parPartida = new SqlParameter("@partida", per.Partida.CodPartida);
                        cmd.Parameters.Add(parPer);
                        cmd.Parameters.Add(parPartida);

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

        public List<PartidaPersonagem> SelecionaPartida(PartidaPersonagem p)
        {
            SqlDataReader drPartida = null;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT p.COD_PARTIDA, av.DESC_AVENTURA FROM Partida p 
                                            INNER JOIN Aventura av 
                                            ON p.COD_AVENTURA = av.COD_AVENTURA 
                                            INNER JOIN Cadastro c 
                                            ON av.COD_LOGIN = c.COD_LOGIN
                                            WHERE c.COD_LOGIN = @cod";

                        SqlParameter parLogin = new SqlParameter("@cod", p.partida);
                        cmd.Parameters.Add(parLogin);

                        List<PartidaPersonagem> pList = new List<PartidaPersonagem>();

                        drPartida = cmd.ExecuteReader();
                        while (drPartida.Read())
                        {
                            p = new PartidaPersonagem();
                            p.partida = drPartida["AVENTURA"].ToString();

                            pList.Add(p);
                        }
                        drPartida.Close();
                        return pList;
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
            catch (SqlException e) 
            { 
                throw e; 
            }
        }

        public int obterPartidaPorNome(string nomePar)
        {
            SqlDataReader drPartida = null;
            int codPar = 0;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT COD_PARTIDA 
                                            FROM Partida
                                            WHERE DESC_PARTIDA = @desc_partida";

                        SqlParameter parDesc = new SqlParameter("@desc_partida", nomePar);
                        cmd.Parameters.Add(parDesc);
                        drPartida = cmd.ExecuteReader();
                        
                        while (drPartida.Read())
                        {
                            codPar = Convert.ToInt32(drPartida["COD_PARTIDA"]);
                        }
                        drPartida.Close();
                        return codPar;
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

        public int maxPartida()
        {
            SqlDataReader drPartida = null;
            int maxPart = 0;
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"SELECT COALESCE(MAX(COD_PARTIDA),MAX(COD_PARTIDA),0) AS maximum
                                            FROM Partida";

                        drPartida = cmd.ExecuteReader();


                        while (drPartida.Read())
                        {

                            maxPart = Convert.ToInt32(drPartida["maximum"]);
                        }
                        drPartida.Close();
                        return maxPart;
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

        public void GravarPerPar(int codPar, int codPer) 
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = @"INSERT INTO Partida_Personagem (COD_PARTIDA, COD_PER) VALUES (@codPar, @codPer)";

                        SqlParameter parPartida = new SqlParameter("@codPar", codPar);
                        SqlParameter parPer = new SqlParameter("@codPer", codPer);

                        cmd.Parameters.Add(parPartida);
                        cmd.Parameters.Add(parPer);
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

        public void Gravar(string nomePar, int codAv)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Partida (COD_AVENTURA, DESC_PARTIDA) VALUES (@codAv, @desc + GETDATE())";

                        SqlParameter parAv = new SqlParameter("@codAv", codAv);
                        SqlParameter parDesc = new SqlParameter("@desc", nomePar);
                        cmd.Parameters.Add(parAv);
                        cmd.Parameters.Add(parDesc);

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
