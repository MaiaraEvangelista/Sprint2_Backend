using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela Generos) do banco de dados
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        public string nome { get; set; }


    }
}
