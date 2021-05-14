using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IConsultaRepository
    {
        /// <summary>
        /// Método de listagem 
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        List<Consulta> ListarTodos();


        /// <summary>
        /// Faz a busca do objeto pelo seu identificador
        /// </summary>
        /// <param name="id">Idnetificador do objeto</param>
        /// <returns>Objeto com suas informações</returns>
        Consulta BuscarPorId(int id);

        /// <summary>
        /// Faz um cadastro de um novo objeto
        /// </summary>
        /// <param name="novaConsulta">Objeto criado com suas informações</param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Faz a atualização de um objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="consultaAtualizada">Objeto atualizado e suas informações</param>
        void Atualizar(int id, Consulta consultaAtualizada);

        /// <summary>
        /// Faz o método de exclusão de um método
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

        /// <summary>
        /// Faz o agendamento de uma consulta com todas as informações
        /// </summary>
        /// <param name="agendamento">Objeto "atualizado" e suas informações</param>
        void AgendarConsulta(Consulta agendamento);

        /// <summary>
        /// Faz a alteração da situação de uma consulta
        /// </summary>
        /// <param name="situacao">Objeto alterado com suas informações</param>
        /// <param name="id">Identificador</param>
        void AlterarSituacao(string situacao, int id);

        /// <summary>
        /// Lista as consultas dos médicos, e dos pacientes
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        List<Consulta> ListarIndividualConsulta(int id);
    }
}
