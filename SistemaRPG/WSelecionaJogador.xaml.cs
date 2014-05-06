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
            
 

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            CadastroDAO dao = new CadastroDAO();
            dtJogadores.ItemsSource = dao.SelecionaPersonagem();
            
        }

        private void dtJogadores_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
