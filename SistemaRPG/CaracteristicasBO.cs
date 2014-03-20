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
        public int codCarac { get; set; }

        [XmlElement("nmCarac")]
        public String nmCarac { get; set; }

        [XmlElement("tipoCarac")]
        public String tipoCarac { get; set; }

        [XmlElement("modCarac")]
        public int modCarac { get; set; }
    }
}
