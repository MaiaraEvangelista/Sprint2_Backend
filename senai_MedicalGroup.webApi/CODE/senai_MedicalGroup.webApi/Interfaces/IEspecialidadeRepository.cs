using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Método que faz a listagem das especialidades
        /// </summary>
        /// <returns>Os objetod com suas informações</returns>
        List<Especialidade> ListarTodos();

        /// <summary>
        /// Faz a busca de uma especialidade pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado e suas informações</returns>
        Especialidade BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto cadastrado</param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// Faz a atualização de uma especialidade
        /// </summary>
        /// <param name="especialidadeAtualizada">Ojeto atualizado</param>
        /// <param name="id">Identificador</param>
        void Atualizar(Especialidade especialidadeAtualizada, int id);

        /// <summary>
        /// Faz a exclusão de uma especialidade
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

    }
}
