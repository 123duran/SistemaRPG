using System;
using System.Collections.Generic;
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
    /// Interaction logic for WSelecionaJogador.xaml
    /// </summary>
    public partial class WSelecionaJogador : Window
    {
        public WSelecionaJogador()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro c = new Cadastro();
            CadastroDAO dao = CadastroDAO.getInstance();
            c.Nome = txtJogador.Text;

            dtJogadores.Columns.Clear();
            dtJogadores.Items.Clear();

            if (txtJogador.Text.Length != 0)
            {
                dao.SelecionaPersonagem(c);
            }
        }
    }
}
