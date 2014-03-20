using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    class Login
    {
        [XmlElement ("codLogin")]
        public int codLogin { get; set; }

        public String nome { get; set; }

        public String email { get; set; }

        public String senha { get; set; }

        //Criar o método de consulta no banco de dados
    }
}
