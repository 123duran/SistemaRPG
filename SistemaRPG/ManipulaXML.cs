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
         public void escrever(PerBO ficha){         
             XmlTextWriter writer = new XmlTextWriter(@"c:\rpg\ficha.xml", null);
             writer.WriteStartDocument();
             //escreve o elmento raiz
             writer.WriteStartElement("Ficha");
             //Escreve os sub-elementos
             writer.WriteElementString("resPer",ficha.resPer.ToString());
             writer.WriteElementString("pdvPer", ficha.pdvPer.ToString());
             writer.WriteElementString("imgPer", ficha.imgPer.ToString());
             writer.WriteEndElement();
             //Escreve o XML para o arquivo e fecha o objeto escritor
             writer.Close();
         }

         public PerBO lerFicha(string caminhoXML)
         {
             //Cria instância de uM documento
             XmlDocument oXML = new XmlDocument();

             //Define o caminho do arquivo XML
             string arquivoXML = caminhoXML;

             //carrega o arquivo XML
             oXML.Load(arquivoXML);

             //Lê o filho de um Nó Pai específico e adiciona no Objeto
             PerBO ficha = new PerBO();
             ficha.resPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[0].InnerText);
             ficha.pdvPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[1].InnerText);
             ficha.imgPer = Convert.ToInt32(oXML.SelectSingleNode("Ficha").ChildNodes[2].InnerText);

             return ficha;
         }
    }
}
