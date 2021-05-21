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
    /// Classe responsável pelos métodos do repositório. Faz herança com a interface para receber os métodos
    /// </summary>
    public class TiposUsuarioRepository : ITipoUsuarioRepository
    {

        /// <summary>
        /// Método que faz a chamada dos métodos do Entity Framework Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Método que faz atualização das suas informações
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="TipoUsuarioAtualizado">Objeto com as informações atualizadas</param>
        public void Atualizar(int id, TiposUsuario TipoUsuarioAtualizado)
        {
            //Faz a busca pelo identificador 
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);


            //Verifica se é diferente de nulo
            if (TipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                //Atribui os valores
                tipoUsuarioBuscado.TituloTipoUsuario = TipoUsuarioAtualizado.TituloTipoUsuario;
            }

            //Acresceta e fa a atualização
            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);

            //Salva as informações atualizadas
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a busca através do identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            //Retorna o que foi encontrado nas buscas 
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Faz o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto cadastrado com suas informações</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            //Adiciona o novo tipo de usuário
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de um tipo de usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Deletar(int id)
        {
            //Faz a busca do tipo de usuário através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            //Faz a exclusão do usuário encontrado
            ctx.TiposUsuarios.Remove(tipoUsuarioBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método que faz a listagem de todos os tipos de usuários encontrados no sistema
        /// </summary>
        /// <returns>Objeto com suas devidas informações</returns>
        public List<TiposUsuario> ListarTodos()
        {
            //Retorna a lista com todos os usuários e suas informações 
            return ctx.TiposUsuarios.ToList();
        }
    }
}
