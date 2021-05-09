using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasses { get; set; }
        public string Cargos { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
