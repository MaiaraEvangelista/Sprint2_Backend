using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Responsável pelo repositório
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Faz a alistagem dos tipos usuários
        /// </summary>
        /// <returns></returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Fa za busca de um tipo de usuário pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto buscado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto cadastrado</param>
        void Cadastrar(TipoUsuario novoUsuario);

        /// <summary>
        /// Faz a atualização de um tipo de usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <param name="tipoUsuarioAtualizado">Objeto atualizado</param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Faz a deleção de um Tipo usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

        
    }
}
