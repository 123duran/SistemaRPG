using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    /// <summary>
    /// Personagem
    /// </summary>
    class PerBO 
    {
        [XmlElement("codPer")]
        public String codPer { get; set; }

        [XmlElement ("nomePer")]
        public String nomePer { get; set; }

        [XmlElement("tipoPer")]
        public String tipoPer { get; set; }

        [XmlElement("racaPer")]
        public String racaPer { get; set; }

        [XmlElement("nivelPer")]
        public int nivelPer { get; set; }

        [XmlElement("forcaPer")]
        public int forcaPer { get; set; }

        [XmlElement("resPer")]
        public int resPer { get; set; }

        [XmlElement("habPer")]
        public int habPer { get; set; }

        [XmlElement("armPer")]
        public int armPer { get; set; }

        [XmlElement("pdvPer")]
        public int pdvPer { get; set; }

        [XmlElement("pdfPer")]
        public int pdfPer { get; set; }

        public CaracteristicasBO caracBO =null;
    }
}
