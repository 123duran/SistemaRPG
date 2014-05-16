using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    public class Aventura
    {
        private int codAventura;
        private String nomeAventura;
        private String senha;
        private Cadastro cadastro;

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

        public Cadastro Cadastro
        {
            get { return cadastro; }
            set { cadastro = value; }
        }
        
    }
}
