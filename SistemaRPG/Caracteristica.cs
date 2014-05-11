using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    class Caracteristica
    {
        private int codCarac;
        private String nmCarac;
        private String tipoCarac;
        private int modCarac;
        //private Personagem personagem;

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
