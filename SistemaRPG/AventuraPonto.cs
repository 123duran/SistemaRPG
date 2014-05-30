using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class AventuraPonto
    {
        private int codPonto;
        private Aventura aventura;
        private string descAventura;
        private string texto;
        private DateTime data;

        public int CodPonto
        {
            get { return codPonto; }
            set { codPonto = value; }
        }

        public Aventura Aventura
        {
            get { return aventura; }
            set { aventura = value; }
        }

        public string DescAventura
        {
            get { return descAventura; }
            set { descAventura = value; }
        }

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
