using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class Resultado
    {
        private int codResultado;
        private DateTime data;
        private String resultadoPartida;

        public int CodResultado
        {
            get { return codResultado; }
            set { codResultado = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public String ResultadoPartida
        {
            get { return resultadoPartida; }
            set { resultadoPartida = value; }
        }
    }
}
