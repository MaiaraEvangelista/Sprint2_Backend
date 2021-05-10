using senai.Inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Método de cadastro de um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Ojeto cadastrado e suas informações</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Método de listagem dos usuários
        /// </summary>
        /// <returns>Lista com todos os objetos</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Método de atualização 
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto atualizado</param>
        void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado);

        /// <summary>
        /// Método de exclusão
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Método de busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Método de login
        /// </summary>
        /// <param name="email">Parâmetro para login</param>
        /// <param name="id">Identificador</param>
        /// <returns>Usuario</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
