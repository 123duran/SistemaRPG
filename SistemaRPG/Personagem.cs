using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SistemaRPG
{
    /// <summary>
    /// Personagem
    /// </summary>
    public class Personagem 
    {
        [XmlElement("codPer")]
        private int codPer;

        [XmlElement ("nomePer")]
       public String nomePer;

        [XmlElement("imgPer")]
        private int imgPer;

        [XmlElement("tipoPer")]
        private String tipoPer;

        [XmlElement("racaPer")]
        private String racaPer;

        [XmlElement("nivelPer")]
        private int nivelPer;

        [XmlElement("forcaPer")]
        private int forcaPer;

        [XmlElement("resPer")]
        private int resPer;

        [XmlElement("habPer")]
        private int habPer;

        [XmlElement("armPer")]
        private int armPer;

        [XmlElement("pvPer")]
        private int pvPer;

        [XmlElement("pdfPer")]
        private int pdfPer;

        [XmlElement("Vantagens")]
        private string vantagens;

        [XmlElement("Desvantagens")]
        private string desvantagens;

        private Partida partida;
        private Cadastro cadastro;
        private Caracteristica caracteristica;


        public int CodPer
        {
            get { return codPer; }
            set { codPer = value; }
        }


        public String Desvantagens
        {
            get { return desvantagens; }
            set { desvantagens = value; }
        }


        public String Vantagens
        {
            get { return vantagens; }
            set { vantagens = value; }
        }

        public String NomePer
        {
            get { return nomePer; }
            set { nomePer = value; }
        }

        public int ImgPer
        {
            get { return imgPer; }
            set { imgPer = value; }
        }

        public String TipoPer
        {
            get { return tipoPer; }
            set { tipoPer = value; }
        }

        public String RacaPer
        {
            get { return racaPer; }
            set { racaPer = value; }
        }

        public int NivelPer
        {
            get { return nivelPer; }
            set { nivelPer = value; }
        }

        public int ForcaPer
        {
            get { return forcaPer; }
            set { forcaPer = value; }
        }

        public int ResPer
        {
            get { return resPer; }
            set { resPer = value; }
        }
            
        public int HabPer
        {
            get { return habPer; }
            set { habPer = value; }
        }
                
        public int ArmPer
        {
            get { return armPer; }
            set { armPer = value; }
        }
                    
        public int PvPer
        {
            get { return pvPer; }
            set { pvPer = value; }
        }

        public int PdfPer
        {
            get { return pdfPer; }
            set { pdfPer = value; }
        }

        public Cadastro Cadastro
        {
            get { return cadastro; }
            set { cadastro = value; }
        }

        public Caracteristica Caracteristica
        {
            get { return caracteristica; }
            set { caracteristica = value; }
        }

        public Partida Partida
        {
            get { return partida; }
            set { partida = value; }
        }
    }
}
