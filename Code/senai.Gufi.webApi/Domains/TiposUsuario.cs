using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.Gufi.webApi.Domains
{
    /// <summary>
    /// representa a classe dos tipos de usuários
    /// </summary>
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        //Mostra que o campo é obrigatório
        [Required(ErrorMessage = "O tútulo de tipo de usuário é obrigatório!")]
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
