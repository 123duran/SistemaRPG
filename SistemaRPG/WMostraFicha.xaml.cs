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
            mostraImagem(newPer.ImgPer);
        }

        /// <summary>
        /// Popoula a tela para que a ficha seja visualizada pelo usuário
        /// </summary>
        /// <param name="newPer"></param>
        public void populaTxts(Personagem newPer) 
        {
            txtNomePer.Text = newPer.nomePer;
            txtArm.Text = newPer.ArmPer.ToString();
            txtForca.Text = newPer.ForcaPer.ToString();
            txtHabil.Text = newPer.HabPer.ToString();
            txtPDF.Text = newPer.PdfPer.ToString();
            txtRaca.Text = newPer.RacaPer.ToString();
            txtRes.Text = newPer.ResPer.ToString();
            txtBG.Text = newPer.Background.ToString();
            txtDesv.Text = newPer.Desvantagens.ToString();
            txtVan.Text = newPer.Vantagens.ToString();
            txtHPMax.Text = (newPer.ResPer * 2).ToString();//calcula o HP máximo do personagem usando a regra "HP máximo = Resistncia * 2"
                                }
        public void mostraImagem(int codImg) 
        { 
            switch(codImg)
            {case 2:
                   //MessageBox.Show(codImg.ToString());
                    imgPer.Source= new BitmapImage(new Uri (@"Imagens/$(KGrHqN,!o0FIvYBWPOeBSPy3UMWyg~~60_35.JPG", UriKind.Relative));
                break;
            }
                

        }
    }
}
