using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void AtualizarEmail(int id, Usuario usuarioAtualizado)
        {
            //Busca através do id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se é diferente de nulo
            if (usuarioAtualizado.EmailUsuario != null)
            {
                //Atribui os valores
                UsuarioBuscado.EmailUsuario = usuarioAtualizado.EmailUsuario;
            }

            //Faz a atualização
            ctx.Usuarios.Update(UsuarioBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void AtualizarSenha(int id, Usuario usuarioAtualizado)
        {
            //Busca através do id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se é diferente de nulo
            if (usuarioAtualizado.SenhaUsuario != null)
            {
                //Atribui os valores
                UsuarioBuscado.SenhaUsuario = usuarioAtualizado.SenhaUsuario;
            }

            //Faz a atualização
            ctx.Usuarios.Update(UsuarioBuscado);

            //Salva a atualização
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            //Cria novo cadastro
            ctx.Usuarios.Add(novoUsuario);

            //salva o novo cadastro
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Busca através do id "Instancia"
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            //Faz a deleção
            ctx.Usuarios.Remove(UsuarioBuscado);

            //Salva o delete
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<Usuario> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.Usuarios.ToList();
        }

       

        public Usuario Login(string senha, string email)
        {
            //Verificaçaõ de veracidade
            return ctx.Usuarios.FirstOrDefault(e => e.EmailUsuario == email && e.SenhaUsuario == senha);
        }
    }
    
}
