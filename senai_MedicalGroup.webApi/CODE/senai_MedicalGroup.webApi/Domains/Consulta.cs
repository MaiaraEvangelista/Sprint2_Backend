using System;
using System.Collections.Generic;

#nullable disable

namespace senai_MedicalGroup.webApi.Domains
{
    public partial class Consulta
    {
        //Atribuindo os valores 

        public int IdConsulta { get; set; }

        public int? IdPaciente { get; set; }

        public int? IdMedico { get; set; }

        public int? IdSituacao { get; set; }

        public string Horario { get; set; }

        public string DataConsulta { get; set; }

        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situaco IdSituacaoNavigation { get; set; }
    }
}
