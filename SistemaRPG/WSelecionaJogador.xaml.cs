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
        List<Cadastro> listCad = new List<Cadastro>();
        WLogin wLogin = new WLogin();
        public WSelecionaJogador()
        {        
            InitializeComponent();        
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            CadastroDAO dao = CadastroDAO.getInstance();
            if (txtJogador.Text.Length != 0)
            {
                dtJogadores.ItemsSource = dao.SelecionaPersonagem();
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            int login;
            login = wLogin.getLogin;
            //login = 3;
            AventuraDAO avDao = AventuraDAO.getInstance();
            CadastroDAO cadDao = CadastroDAO.getInstance();

            //Populando a comboBox
            cmbPartida.ItemsSource = avDao.populaAventura(login);

            //Populando a dataGrid
            dtJogadores.ItemsSource = cadDao.SelecionaPersonagem();

            MessageBox.Show(wLogin.getLogin.ToString());
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro cadast =  (Cadastro)dtJogadores.SelectedItem;
            AdicionaLista(cadast);
            dtSelecionados.ItemsSource = listCad;
            dtSelecionados.CanUserAddRows = false;
            dtSelecionados.Items.Refresh();
        }

        private void AdicionaLista(Cadastro cadast)
        {
            listCad.Add(cadast);
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtSelecionados.SelectedIndex >= 0)
            {
                listCad.RemoveAt(dtSelecionados.SelectedIndex);
            }
            dtSelecionados.Items.Refresh();
        }

        private void btGravar_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
