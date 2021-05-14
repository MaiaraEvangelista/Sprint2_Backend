using System;
using System.Collections.Generic;

#nullable disable

namespace senai_MedicalGroup.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        //Atribuindo os valores 

        public int IdClinica { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string HorarioAbertura { get; set; }

        public string HorarioFechamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
