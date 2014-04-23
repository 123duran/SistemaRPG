using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    class Caracteristicas
    {
        [XmlElement ("codCarac")]
        private int codCarac;

        [XmlElement("nmCarac")]
        private String nmCarac;

        [XmlElement("tipoCarac")]
        private String tipoCarac;

        [XmlElement("modCarac")]
        private int modCarac;

        public int CodCarac
        {
            get { return codCarac; }
            set { codCarac = value; }
        }

        public String NmCarac
        {
            get { return nmCarac; }
            set { nmCarac = value; }
        }

        public String TipoCarac
        {
            get { return tipoCarac; }
            set { tipoCarac = value; }
        }

        public int ModCarac
        {
            get { return modCarac; }
            set { modCarac = value; }
        }
    }
}
