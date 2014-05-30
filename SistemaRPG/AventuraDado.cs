using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class AventuraDado
    {
        private int codDado;
        private Aventura aventura;
        private Personagem personagem;
        private int numero;
        private int ativo;

        public int CodDado
        {
            get { return codDado; }
            set { codDado = value; }
        }

        public Aventura Aventura
        {
            get { return aventura; }
            set { aventura = value; }
        }

        public Personagem Personagem
        {
            get { return personagem; }
            set { personagem = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }
    }
}
