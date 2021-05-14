using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface ISituacoRepository
    {
        /// <summary>
        /// Faz a listagrm das situações
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        List<Situaco> ListarTodos();

        /// <summary>
        /// Faz a busca de uma situação pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objetos com suas informações</returns>
        Situaco BuscarPorId(int id);

        /// <summary>
        /// Faz o cadasrtro de uma situação
        /// </summary>
        /// <param name="novaSituacao">Objeto cadastrado</param>
        void Cadastrar(Situaco novaSituacao);

        /// <summary>
        /// Faz a atualização de uma situação
        /// </summary>
        /// <param name="situacaoAtualizada">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        void Atualizar(Situaco situacaoAtualizada, int id);

        /// <summary>
        /// Faz a exclusão de uma situação
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);
    }
}
