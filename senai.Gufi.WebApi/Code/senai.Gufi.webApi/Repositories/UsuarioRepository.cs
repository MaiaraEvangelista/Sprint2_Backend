using senai.Gufi.webApi.Contexts;
using senai.Gufi.webApi.Domains;
using senai.Gufi.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Repositories
{
    /// <summary>
    /// Responsável pelos métodos do repositório. Faz a herança com a interface para receber os métodos 
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Faz a chamada dos métodos do Entity Framework Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Método que faz o login do usuário
        /// </summary>
        /// <param name="email">Endereço usado pelo usuário para fazer sua conexão</param>
        /// <param name="senha">Confirmação que garante que o email é do usuário</param>
        /// <returns>Usuário logado</returns>
        public Usuario Login(string email, string senha)
        {
            //Retorna o usuário logado
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
