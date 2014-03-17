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
using System.Xml;

namespace SistemaRPG
{
    /// <summary>
    /// Interaction logic for WRolarLocal.xaml
    /// </summary>
    public partial class WRolarLocal : Window
    {
        public WRolarLocal()
        {
            InitializeComponent();
        }

        private void click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double i = 0;
            Random random = new Random();
            if (rbD6.IsChecked == true)
            {
                i = random.Next(1, 7);
                MessageBox.Show("Você tirou: " + i.ToString() + " no dado");
                try
                {
                    escreveXML(i);
                }
                catch (Exception error) {
                    MessageBox.Show(error.ToString());
                }
            }
            else if (rbD20.IsChecked == true) {
                i = random.Next(1, 21);
                MessageBox.Show("Você tirou: " + i.ToString() + " no dado");
                try
                {
                    escreveXML(i);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void escreveXML(double i) {

             
            XmlTextWriter writer = new XmlTextWriter(@"c:\teste\edados.xml", null);
            writer.WriteStartDocument();
            //escreve o elmento raiz
            writer.WriteStartElement("Resultado");
            //Escreve os sub-elementos
            writer.WriteElementString("Seu resultado foi", i.ToString());
            writer.WriteEndElement();
            //Escreve o XML para o arquivo e fecha o objeto escritor
            writer.Close();
            MessageBox.Show("Arquivo XML gerado com sucesso.");

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
