using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Domains
{
    public class JogoDomain
    {

        public int idJogo { get; set; }

        public string nomeJogo { get; set; }

        public string descricao { get; set; }

        public DateTime dataLancamento { get; set; }

        public Double valor { get; set; }

        public int idEstudio { get; set; }
    }
}
