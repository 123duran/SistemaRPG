using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class PartidaPersonagem
    {
        private Personagem personagem;
        private Partida partida;

        public Personagem Personagem
        {
            get { return personagem; }
            set { personagem = value; }
        }

        public Partida Partida
        {
            get { return partida; }
            set { partida = value; }
        }
    }
}
