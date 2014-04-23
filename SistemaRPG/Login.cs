﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    class Login
    {
        [XmlElement("codLogin")]
        private int codLogin;
        private String nome;
        private String email;
        private String senha;
        private String perfil;
        private int ativo;

        public int CodLogin
        {
            get { return codLogin; }
            set { codLogin = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public String Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        public int Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }
    }
}
