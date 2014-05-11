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
            CadastroDAO dao = new CadastroDAO();
            if (txtJogador.Text.Length != 0)
            {
                dtJogadores.ItemsSource = dao.SelecionaPersonagem();
            }
 

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            PersonagemPartida p = new PersonagemPartida();
            CadastroDAO dao = new CadastroDAO();
            PartidaDAO partidaDao = new PartidaDAO();
            Cadastro cad = new Cadastro();
            cad.CodLogin = 1;
            p.Partida.Aventura.Cadastro = cad;
            cmbPartida.ItemsSource = partidaDao.SelecionaPartida(p);
            dtJogadores.ItemsSource = dao.SelecionaPersonagem();
            
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            Cadastro cadast =  (Cadastro)dtJogadores.SelectedItem;
            AdicionaLista(cadast);
            dtSelecionados.ItemsSource = listCad;
            dtSelecionados.Items.Refresh();
           
        }

        private DataGrid  RemoveLista(DataGrid grid0)
        {
            //listCad.RemoveAt(linha);
            var grid = grid0;
            var mygrid = grid0;

             if (grid0.SelectedIndex >= 0) 
            {
                for (int i = 0; i <= grid0.SelectedItems.Count; i++)
                { 
                mygrid.Items.Remove(mygrid.SelectedItems[i]);
                };
            }

            return mygrid;
        }


        private void AdicionaLista(Cadastro cadast)
        {

            listCad.Add(cadast);
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            dtSelecionados = RemoveLista(dtSelecionados);
            dtSelecionados.Items.Refresh();
        }


    }
}
