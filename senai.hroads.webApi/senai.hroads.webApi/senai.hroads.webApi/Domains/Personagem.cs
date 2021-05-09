using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nomes { get; set; }
        public string VidaMáxima { get; set; }
        public string ManaMáxima { get; set; }
        public string DataAtualização { get; set; }
        public string DataCriação { get; set; }
        public int? IdClasses { get; set; }

        public virtual Classe IdClassesNavigation { get; set; }
    }
}
