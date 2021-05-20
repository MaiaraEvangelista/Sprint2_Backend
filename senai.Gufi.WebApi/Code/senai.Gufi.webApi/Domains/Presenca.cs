using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.Gufi.webApi.Domains
{
    /// <summary>
    /// Representa a classe Presença
    /// </summary>
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEventto { get; set; }

        //Faz a definiçaõ mostrando que esse campo tem a obrigação de ser preenchido
        [Required(ErrorMessage = "Esse campo sobre a situação de presença do usuário é obrigatória!")]
        public string Situacao { get; set; }

        public virtual Evento IdEventtoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
