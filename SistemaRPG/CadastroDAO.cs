﻿using System;
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

        public void Gravar(Login l)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Cadastro (NOME, EMAIL, SENHA, PERFIL, ATIVO) VALUES (@nome, @email, @senha, @perfil, @ativo)";

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
