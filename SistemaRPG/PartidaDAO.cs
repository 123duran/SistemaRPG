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

        public List<PersonagemPartida> SelecionaPartida(PersonagemPartida p)
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

                        cmd.CommandText = @"SELECT p.COD_PARTIDA, av.AVENTURA FROM Partida p 
                                            INNER JOIN Aventura av 
                                            ON p.COD_AVENTURA = av.COD_AVENTURA 
                                            INNER JOIN Cadastro c 
                                            ON av.COD_LOGIN = c.COD_LOGIN
                                            WHERE c.COD_LOGIN = @COD_LOGIN";

                        SqlParameter parLogin = new SqlParameter("@COD_LOGIN", //p.Partida.Aventura.Cadastro.CodLogin);
                        cmd.Parameters.Add(parLogin);

                        List<PersonagemPartida> perPartida = new List<PersonagemPartida>();
                        
                        drPartida = cmd.ExecuteReader();
                        while (drPartida.Read())
                        {
                            p = new PersonagemPartida();
                            p.Partida.CodPartida = Convert.ToInt32(drPartida["COD_PARTIDA"]);
                            p.Partida.Aventura.NomeAventura = drPartida["AVENTURA"].ToString();

                            perPartida.Add(p);
                        }
                        drPartida.Close();
                        return perPartida;
                    }
                    catch (SqlException ex) 
                    { 
                        throw ex; 
                    }
                }
            }
            catch (SqlException e) 
            { 
                throw e; 
            }
        }

        public void Gravar(Partida p)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Partida (DESCRICAO) VALUES (@desc)";

                        SqlParameter parDesc = new SqlParameter("@desc", p.Descricao);
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
