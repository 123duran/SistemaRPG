﻿using System;
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

                        cmd.CommandText = "INSERT INTO Personagem (COD_CAR, NOME_PER, IMG_PER, RACA_PER, FORCA_PER, TIPO_PER, NIVEL_PER, HAB_PER, RES_PER, ARM_PER, PV_PER, PDF_PER)" +
                            "VALUES (@carac, @nome, @img, @raca, @forca, @tipo, @nivel, @hab, @res, @arm, @pv, @pdf)";

                        SqlParameter parCarac = new SqlParameter("@carac", p.Caracteristica.CodCarac);
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

                        cmd.Parameters.Add(parCarac);
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
