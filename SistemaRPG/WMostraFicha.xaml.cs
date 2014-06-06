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
            populaTxts(newPer);//preenche todos os campos da tela
            mostraImagem(newPer.ImgPer);//preenche a imagem da ficha
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
            if(newPer.ResPer > 0)
            txtHPMax.Text = (newPer.ResPer * 2).ToString();//calcula o HP máximo do personagem usando a regra "HP máximo = Resistncia * 2"
        }
        /// <summary>
        /// Mostra a imagem de acordo com o que foi gravado na ficha
        /// </summary>
        /// <param name="codImg"></param>
        public void mostraImagem(int codImg)
        {
            if (codImg > 0)
            {
                switch (codImg)
                {
                    case 1://Humano
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/human.JPEG", UriKind.Relative));
                        break;
                    case 2://elfo
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/elf.JPEG", UriKind.Relative));
                        break;
                        case 3://bárbaro
                        //MessageBox.Show(codImg.ToString());
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/$(KGrHqN,!o0FIvYBWPOeBSPy3UMWyg~~60_35.JPG", UriKind.Relative));
                        break;
                    case 4://Ladino
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/images1.JPEG", UriKind.Relative));
                        break;
                    case 5: //Anão
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/dwarf.JPEG", UriKind.Relative));
                        break;
                    case 6://Orc
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/orcface1.JPEG", UriKind.Relative));
                        break;
                    case 7://Paladino
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/197.JPEG", UriKind.Relative));
                        break;
                    case 8://Mago/Feiticeiro
                        imgPer.Source = new BitmapImage(new Uri(@"Imagens/mago.JPEG", UriKind.Relative));
                        break;
                }
            }



        }
    }
}
