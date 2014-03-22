using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SistemaRPG
{
    public class Banco
    {
        public SqlConnection conexao()
        {
            string conec = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\RPG\SistemaRPG.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cn = new SqlConnection(conec);
            return cn;
        }
        public SqlConnection abrirConexao()
        {
            SqlConnection cn = conexao();
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void fecharConexao(SqlConnection cn)
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public System.Data.DataTable executeQuery(string sql)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(sql, abrirConexao());
                sqlComm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string executeQueryComStringRetorno(string sql)
        {
            try
            {
                string dado;
                SqlCommand sqlComm = new SqlCommand(sql, abrirConexao());
                sqlComm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dado = dt.Rows[0][0].ToString();
                return dado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}