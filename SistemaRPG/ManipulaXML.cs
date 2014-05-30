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
             writer.WriteElementString("desvantagens", ficha.Vantagens.ToString());
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

             return ficha;
         }
    }
}
