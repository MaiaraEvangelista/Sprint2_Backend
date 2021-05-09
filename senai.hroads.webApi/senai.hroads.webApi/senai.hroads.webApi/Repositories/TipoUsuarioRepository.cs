using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            //Busca através do id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //Verifica se é nulo
            if (tipoUsuarioAtualizado.Tipos != null)
            {
                //Atribui os valores
                tipoUsuarioBuscado.Tipos = tipoUsuarioAtualizado.Tipos;

            }
            //Devolve atualizado
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            //Salva no BD
            ctx.SaveChanges();

        }

        public TipoUsuario BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoUsuario)
        {
            //Cria novo cadastro
            ctx.TipoUsuarios.Add(novoUsuario);

            //salva o novo cadastro
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Busca pelo id
            TipoUsuario TipoBuscado = ctx.TipoUsuarios.Find(id);

            //Remove 
            ctx.Remove(TipoBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<TipoUsuario> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.TipoUsuarios.ToList();
        }

    }  
}
