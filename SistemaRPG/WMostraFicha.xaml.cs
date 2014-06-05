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
    /// Interaction logic for WMostraFicha.xaml
    /// </summary>
    public partial class WMostraFicha : Window
    {
        Personagem personagem;

        public WMostraFicha(Personagem p)
        {
            InitializeComponent();
            personagem = new Personagem();
            this.personagem = p;
        }

        public WMostraFicha()
        {
            InitializeComponent();
        }

        private void MostraFicha_Loaded(object sender, RoutedEventArgs e)
        {
           // txtArm.Text = personagem.ArmPer.ToString();

            CadastroDAO dao = new CadastroDAO();
            Personagem newPer = dao.SelecionaPersonagemUnicoPorCodPer(personagem.CodPer);
            populaTxts(newPer);
        }

        public void populaTxts(Personagem newPer) 
        {
            txtNomePer.Text = newPer.nomePer;
            txtArm.Text = newPer.ArmPer.ToString();


        }
    }
}
