using System;
using System.Collections.Generic;

#nullable disable

namespace senai.Gufi.webApi.Domains
{
    /// <summary>
    /// Representa a classe de instituição
    /// </summary>
    public partial class Instituicao
    {
        public Instituicao()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
