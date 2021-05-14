using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IMedicoRepository
    {
        /// <summary>
        /// Faz a listagem de todos os médicos
        /// </summary>
        /// <returns>Objeto com suas informações</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Faz a busca de um médico através do seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto cadastrado com suas informações</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Faz a atualização de um médico existente
        /// </summary>
        /// <param name="medicoAtualizado">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        void Atualizar(Medico medicoAtualizado, int id);

        /// <summary>
        /// Faz a exclusão de um médico
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);
    }
}
