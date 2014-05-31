using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SistemaRPG
{
    class ManipulaXML
    {
         public void escrever(Personagem ficha){         
             XmlTextWriter writer = new XmlTextWriter(@"c:\rpg\ficha.xml", null);
             writer.WriteStartDocument();
             //escreve o elmento raiz
             writer.WriteStartElement("Ficha");
             //Escreve os sub-elementos
             writer.WriteElementString("resPer",ficha.ResPer.ToString());
             writer.WriteElementString("pdvPer", ficha.PvPer.ToString());
             writer.WriteElementString("imgPer", ficha.ImgPer.ToString());
             writer.WriteElementString("vantagens", ficha.Vantagens.ToString());
             writer.WriteElementString("desvantagens", ficha.Desvantagens.ToString());
             writer.WriteElementString("nome", ficha.NomePer.ToString());
             writer.WriteElementString("raca", ficha.RacaPer.ToString());
             writer.WriteElementString("habilidade", ficha.HabPer.ToString());
             writer.WriteElementString("forca", ficha.ForcaPer.ToString());
             writer.WriteElementString("nivel", ficha.NivelPer.ToString());
             writer.WriteElementString("pdfPer", ficha.PdfPer.ToString());
             writer.WriteElementString("tipo", ficha.TipoPer.ToString());
             writer.WriteElementString("arm", ficha.ArmPer.ToString());
             writer.WriteElementString("codper", ficha.CodPer.ToString());
             writer.WriteElementString("inventario", ficha.Inventario.ToString());
             writer.WriteElementString("background", ficha.Background.ToString());
             writer.WriteElementString("codlogin", Cadastro.Cad.CodLogin.ToString());


             writer.WriteEndElement();
             //Escreve o XML para o arquivo e fecha o objeto escritor
             writer.Close();
         }

         public Personagem lerFicha(string caminhoXML)
         {
             //Cria instância de uM documento
             XmlDocument oXML = new XmlDocument();

             //Define o caminho do arquivo XML
             string arquivoXML = caminhoXML;

             //carrega o arquivo XML
             oXML.Load(arquivoXML);

             //Lê o filho de um Nó Pai específico e adiciona no Objeto
             Personagem ficha = new Personagem();
             ficha.ResPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[0].InnerText);
             ficha.PvPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[1].InnerText);
             ficha.ImgPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[2].InnerText);
             ficha.Vantagens = oXML.SelectSingleNode("Ficha").ChildNodes[3].InnerText;
             ficha.Desvantagens = oXML.SelectSingleNode("Ficha").ChildNodes[4].InnerText;
             ficha.NomePer = oXML.SelectSingleNode("Ficha").ChildNodes[5].InnerText;
             ficha.RacaPer = oXML.SelectSingleNode("Ficha").ChildNodes[6].InnerText;
             ficha.HabPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[7].InnerText);
             ficha.ForcaPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[8].InnerText);
             ficha.NivelPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[9].InnerText);
             ficha.PdfPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[10].InnerText);
             ficha.TipoPer = oXML.SelectSingleNode("Ficha").ChildNodes[11].InnerText;
             ficha.ArmPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[12].InnerText);
             ficha.CodPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[13].InnerText);
             ficha.Inventario = oXML.SelectSingleNode("Ficha").ChildNodes[14].InnerText;
             ficha.Background = oXML.SelectSingleNode("Ficha").ChildNodes[15].InnerText;
             Cadastro.Cad.CodLogin = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[16].InnerText);             


             return ficha;
         }
    }
}
