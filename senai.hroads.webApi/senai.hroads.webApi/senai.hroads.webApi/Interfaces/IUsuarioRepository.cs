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
    interface IUsuarioRepository
    {
        /// <summary>
        /// Faz a listagem dos usuários
        /// </summary>
        /// <returns></returns>
        List<Usuario> Listar();

        /// <summary>
        /// Faz a busca do usuário pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto cadastrado</param>
        void Cadastrar(Usuario novoUsuario);


        /// <summary>
        /// Faz a atualização de um usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="usuarioAtualizado">Onjeto atualizado</param>
        void AtualizarEmail(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Faz a atualização da senha do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        void AtualizarSenha(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Faz a deleção de um usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

        
        Usuario Login(string senha, string email);

      
    }
}
