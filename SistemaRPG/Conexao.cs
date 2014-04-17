using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace SistemaRPG
{
    public class Conexao
    {

        private static string stringConec = @"Data Source=BRUNONOTE\SQLEXPRESS;Database=SistemaRPG;Integrated Security=True;Connect Timeout=30";
        private static SqlConnection cnn = null;

        public static SqlConnection obterConexao()
        {
            cnn = new SqlConnection(stringConec);
            try
            {
                cnn.Open();
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("ocorreu o seguinte erro: " + sqle);
                cnn = null;
            }
            return cnn;
        }

        public static void fecharConexao()
        {
            if(cnn != null)
                cnn.Close();
        }   
    }
}