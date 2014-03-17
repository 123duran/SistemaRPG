using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    class CaracteristicasBO
    {
        [XmlElement ("codCarac")]
        private int codCarac { get; set; }

        [XmlElement("nmCarac")]
        private String nmCarac { get; set; }

        [XmlElement("tipoCarac")]
        private String tipoCarac { get; set; }

        [XmlElement("modCarac")]
        private int modCarac { get; set; }
    }
}
