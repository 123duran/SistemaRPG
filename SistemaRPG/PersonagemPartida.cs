using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class PersonagemPartida
    {
        private Personagem personagem = new Personagem();
        private Partida partida = new Partida();

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
