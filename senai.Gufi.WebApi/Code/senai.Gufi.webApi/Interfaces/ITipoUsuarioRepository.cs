
using senai.Gufi.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Interfaces
{
    /// <summary>
    /// Responsável por dizer quais são os métodos que o repositório vai precisar implementar em seu escopo
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Faz a listagem de todos os tipos de usuários
        /// </summary>
        /// <returns>Objeto listado</returns>
        List<TiposUsuario> ListarTodos();

        /// <summary>
        /// Faz a abusca do tipo de usuário pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O tipo usuário procurado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto cadastrado</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);


        /// <summary>
        /// Faz a atualização de um usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="TipoUsuarioAtualizado">Objeto atualizado</param>
        void Atualizar(int id, TiposUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Faz a exclusão do objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);
    }
}
