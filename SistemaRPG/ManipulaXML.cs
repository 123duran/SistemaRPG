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
             XmlTextWriter writer = new XmlTextWriter(@"c:\teste\edados.xml", null);
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
              
    }
}
