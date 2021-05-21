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
    interface IUsuarioRepository
    {
        /// <summary>
        /// Faz o acesso do usuário na sua "parte" da plataforma
        /// </summary>
        /// <param name="email">endereço do usuário</param>
        /// <param name="senha">Validação da identidade feita na plataforma do usuário</param>
        /// <returns>O usuário que foi buscado</returns>
        Usuario Login(string email, string senha);

    }
}
