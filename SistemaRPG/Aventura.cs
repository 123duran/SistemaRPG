using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class Aventura
    {
        private int codAventura;
        private String nomeAventura;
        private String senha;

        public int CodAventura
        {
            get { return codAventura; }
            set { codAventura = value; }
        }

        public String NomeAventura
        {
            get { return nomeAventura; }
            set { nomeAventura = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
