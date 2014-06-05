using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class PersonagemDAO
    {
        public static readonly PersonagemDAO dao = new PersonagemDAO();

        public static PersonagemDAO getInstance()
        {
            return dao;
        }

        public void Gravar(Personagem p)
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "INSERT INTO Personagem (NOME_PER, IMG_PER, RACA_PER, FORCA_PER, TIPO_PER, NIVEL_PER, HAB_PER, RES_PER, ARM_PER, PV_PER, PDF_PER, COD_LOGIN, VANTAGENS, DESVANTAGENS, INVENTARIO, BACKGROUND XP)" +
                            "VALUES (@nome, @img, @raca, @forca, @tipo, @nivel, @hab, @res, @arm, @pv, @pdf, @codlogin, @vantagens, @desvantagens, @inventario, @background, 0)";

                        SqlParameter parNome = new SqlParameter("@nome", p.NomePer);
                        SqlParameter parImg = new SqlParameter("@img", p.ImgPer);
                        SqlParameter parRaca = new SqlParameter("@raca", p.RacaPer);
                        SqlParameter parForca = new SqlParameter("@forca", p.ForcaPer);
                        SqlParameter parTipo = new SqlParameter("@tipo", p.TipoPer);
                        SqlParameter parNivel = new SqlParameter("@nivel", p.NivelPer);
                        SqlParameter parHab = new SqlParameter("@hab", p.HabPer);
                        SqlParameter parRes = new SqlParameter("@res", p.ResPer);
                        SqlParameter parArm = new SqlParameter("@arm", p.ArmPer);
                        SqlParameter parPv = new SqlParameter("@pv", p.PvPer);
                        SqlParameter parPdf = new SqlParameter("@pdf", p.PdfPer);
                        SqlParameter parCod = new SqlParameter("@codlogin", Cadastro.Cad.CodLogin);
                        SqlParameter parVan = new SqlParameter("@vantagens", p.Vantagens);
                        SqlParameter parDesvan = new SqlParameter("@desvantagens", p.Desvantagens);
                        SqlParameter parInvent = new SqlParameter("@inventario", p.Inventario);
                        SqlParameter parBackground = new SqlParameter("@background", p.Background);

                        cmd.Parameters.Add(parNome);
                        cmd.Parameters.Add(parImg);
                        cmd.Parameters.Add(parRaca);
                        cmd.Parameters.Add(parForca);
                        cmd.Parameters.Add(parTipo);
                        cmd.Parameters.Add(parNivel);
                        cmd.Parameters.Add(parHab);
                        cmd.Parameters.Add(parRes);
                        cmd.Parameters.Add(parArm);
                        cmd.Parameters.Add(parPv);
                        cmd.Parameters.Add(parPdf);
                        cmd.Parameters.Add(parCod);
                        cmd.Parameters.Add(parVan);
                        cmd.Parameters.Add(parDesvan);
                        cmd.Parameters.Add(parInvent);
                        cmd.Parameters.Add(parBackground);

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
