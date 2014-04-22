using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaRPG
{
    /// <summary>
    /// Interaction logic for WDadosJogadores.xaml
    /// </summary>
    public partial class WDadosJogadores : Window
    {
        public WDadosJogadores()
        {
            InitializeComponent();
        }

        private void btnSair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbJogador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Selecionar()
        {
            try
            {
                using (SqlConnection con = Conexao.obterConexao())
                {
                    try
                    {
                        cbJogador.Items.Clear();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "SELECT DISTINCT(NOME) FROM Cadastro WHERE ATIVO = 1 ORDER BY 1";

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cbJogador.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
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
            finally
            {
                Conexao.fecharConexao();
            }
        }

        private void frmDadosJogadores(object sender, RoutedEventArgs e)
        {
            Selecionar();
        }

    }
}
