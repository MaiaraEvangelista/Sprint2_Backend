using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface ITiposUsuariosRepository
    {
        /// <summary>
        /// Faz a lsitagem 
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        List<TiposUsuarios> ListarTodos();

        /// <summary>
        /// Faz a busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações </returns>
        TiposUsuarios BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de uma novo tipo usuário
        /// </summary>
        /// <param name="novoTipoU">Objeto cadastrado</param>
        void Cadastrar(TiposUsuarios novoTipoU);

        /// <summary>
        /// Faz a atualização de um tipo
        /// </summary>
        /// <param name="tipoAtualizado">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        void Atualizar(TiposUsuarios tipoAtualizado, int id);

        /// <summary>
        /// Faz a exclusão 
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);
    }
}
