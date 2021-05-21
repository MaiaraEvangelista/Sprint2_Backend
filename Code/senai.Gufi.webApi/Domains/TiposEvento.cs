using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.Gufi.webApi.Domains
{/// <summary>
/// Representa a tabela de tipos eventos
/// </summary>
    public partial class TiposEvento
    {
        public TiposEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }

        //Mostra que esse campo é uma parte obrigatória a ser preenchida
        [Required(ErrorMessage = "Este campo não pode ser pulado pois é obrigatório!")]
        public string TituloEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
