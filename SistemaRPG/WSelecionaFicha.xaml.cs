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
    /// Interaction logic for WSelecionaFicha.xaml
    /// </summary>
    public partial class WSelecionaFicha : Window
    {
        public WSelecionaFicha()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void cmbAventura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string codAventura = "";

            Aventura a = (Aventura)cmbAventura.SelectedItem;

            // através da combobox preenche a variável que será usada para voltar uma lista de int
            //tal lista de int irá ser passada para outra função que retorna os jogadores cadastrados naquela aventura
            CadastroDAO cadDao = new CadastroDAO();

            // dtJogAven.Items.Clear();
            List<Personagem> listaNaoSelec = new List<Personagem>();

            listaNaoSelec = cadDao.SelecionaPersonagemPorCodPer(cadDao.SelecionaPersonagemEspecifico(a.NomeAventura));

            this.dtJogAven.ItemsSource = listaNaoSelec;

            foreach (Personagem p in listaNaoSelec)
            {
                MessageBox.Show(p.NomePer);
            }


            dtJogAven.Items.Refresh();
            //   dtJogPar.ItemsSource = cadSelec;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            AventuraDAO avDao = AventuraDAO.getInstance();
            CadastroDAO cadDao = new CadastroDAO();

            cmbAventura.ItemsSource = avDao.populaAventura();
        }
    }
}
