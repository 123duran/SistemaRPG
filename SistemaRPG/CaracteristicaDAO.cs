using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class CaracteristicaDAO
    {
        public static readonly CaracteristicaDAO dao = new CaracteristicaDAO();

        public static CaracteristicaDAO getInstance()
        {
            return dao;
        }

        public void Gravar(Caracteristica c)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Caracteristica (NOME_CARAC, MOD_CARAC, TIPO_CARAC) VALUES (@nome, @mod, @tipo)";

                        SqlParameter parNome = new SqlParameter("@nome", c.NmCarac);
                        SqlParameter parMod = new SqlParameter("@mod", c.ModCarac);
                        SqlParameter parTipo = new SqlParameter("@tipo", c.TipoCarac);

                        cmd.Parameters.Add(parNome);
                        cmd.Parameters.Add(parMod);
                        cmd.Parameters.Add(parTipo);

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
