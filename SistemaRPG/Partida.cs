using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRPG
{
    class Partida
    {
        private int codPartida;
        private string descricao;
        private Aventura aventura;
        private Resultado resultado;

        public int CodPartida
        {
            get { return codPartida; }
            set { codPartida = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public Aventura Aventura
        {
            get { return aventura; }
            set { aventura = value; }
        }

        public Resultado Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
       
    }
}
