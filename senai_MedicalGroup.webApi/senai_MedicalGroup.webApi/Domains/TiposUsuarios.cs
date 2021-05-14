using System;
using System.Collections.Generic;

#nullable disable

namespace senai_MedicalGroup.webApi.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTiposUsuario { get; set; }
        public string Tipos { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
