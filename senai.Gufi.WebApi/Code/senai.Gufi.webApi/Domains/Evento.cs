﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.Gufi.webApi.Domains
{
    /// <summary>
    /// Representa a classe de eventos
    /// </summary>
    public partial class Evento
    {
        public Evento()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public int? IdTipoEvento { get; set; }
        public int? IdInstituicao { get; set; }
        public string NomeEvento { get; set; }
        public bool? AcessoLivre { get; set; }
        public DateTime DataEvento { get; set; }
        public string Descricao { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual TiposEvento IdTipoEventoNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
