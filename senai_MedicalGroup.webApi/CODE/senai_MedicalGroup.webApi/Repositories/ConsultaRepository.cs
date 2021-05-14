using Microsoft.EntityFrameworkCore;
using senai_MedicalGroup.webApi.Contexts;
using senai_MedicalGroup.webApi.Domains;
using senai_MedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Repositories
{
    /// <summary>
    /// Faz a herança com a interface para receber os métodos
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void AgendarConsulta(Consulta agendamento)
        {
            //Executa o método de agendamento
            ctx.Consultas.Add(agendamento);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarSituacao(string situacao, int id)
        {

            //Passa os valores para alteração
            Consulta consultaBuscada = ctx.Consultas
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdSituacaoNavigation)
                .FirstOrDefault(c => c.IdConsulta == id);


            switch (situacao)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    consultaBuscada.IdPaciente = 2;
                    break;

                case "3":
                    consultaBuscada.IdMedico = 3;
                    break;

                case "4":
                    consultaBuscada.IdConsulta = 4;
                        break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            //Faz a alteração 
            ctx.Consultas.Update(consultaBuscada);

            //Salva as alterações feitas
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            //Instância a consulta buscada e procura
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            //Verifica se é nulo
            if (consultaAtualizada.DataConsulta != null)
            {
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;

            }

            if (consultaAtualizada.Descricao != null)
            {
               consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }


            if (consultaAtualizada.Horario != null)
            {
                consultaBuscada.Horario = consultaAtualizada.Horario;
            }

            if (consultaAtualizada.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            if (consultaAtualizada.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            //Devolve com as atualizações
            ctx.Consultas.Update(consultaBuscada);

            //Salva
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            //Faz a busca pelo id e retorna as informações
            return ctx.Consultas.FirstOrDefault(con => con.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            //Executa o método e cadastra
            ctx.Consultas.Add(novaConsulta);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Faz a exclusão
            ctx.Consultas.Remove(BuscarPorId(id));

            //Salva a deleção
            ctx.SaveChanges();
        }

        public List<Consulta> ListarIndividualConsulta(int id)
        {
            //Retorna uma lista individual com todas as informações
            return ctx.Consultas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdSituacaoNavigation)
                .Where(c => c.IdConsulta == id)
                .ToList();
        }

        public List<Consulta> ListarTodos()
        {
            //Devolve a lista completa de todas as consultas
            return ctx.Consultas.ToList();
        }
    }
}
