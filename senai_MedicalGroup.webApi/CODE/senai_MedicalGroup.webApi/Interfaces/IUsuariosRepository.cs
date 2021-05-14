using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IUsuariosRepository
    {

        /// <summary>
        /// Faz a listagem de todos os usuários
        /// </summary>
        /// <returns>Objeto com suas infromações</returns>
        List<Usuarios> ListarTodos();

        /// <summary>
        /// Faz a busac pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Faz o login de um usuário
        /// </summary>
        /// <param name="email">Endereço de entrada do usuário</param>
        /// <param name="senha">Identificador único para certificação de acesso</param>
        /// <returns>Usuário logado</returns>
        Usuarios Login(string email, string senha);

        /// <summary>
        /// Faz o cadastro de um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto cadastrado</param>
        void Cadastrar(Usuarios novoUsuario);


        /// <summary>
        /// Faz a atualização de um usuário
        /// </summary>
        /// <param name="email">Identificador</param>
        /// <param name="usuarioAtualizado">Onjeto atualizado</param>
        void AtualizarEmail( string email, Usuarios usuarioAtualizado);

        /// <summary>
        /// Faz a atualização da senha do usuário
        /// </summary>
        /// <param name="senha">Passe</param>
        /// <param name="usuarioAtualizado">Objeto atualizado</param>
        void AtualizarSenha(string senha, Usuarios usuarioAtualizado);

        /// <summary>
        /// Faz a exclusão de um usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

    }
}
