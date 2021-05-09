using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TiposHabilidadeRepository : ITiposHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, TiposHabilidade tipoAtualizado)
        {
            //Busca através do id
            TiposHabilidade tipoBuscado = ctx.TiposHabilidades.Find(id);

            //Verifica se é nulo
            if (tipoAtualizado.Tipos != null)
            {
                //Atribui os valores
                tipoBuscado.Tipos = tipoAtualizado.Tipos;

            }
            //Devolve atualizado
            ctx.TiposHabilidades .Update(tipoBuscado);

            //Salva no BD
            ctx.SaveChanges();

        }

        public TiposHabilidade BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.TiposHabilidades.FirstOrDefault(th => th.IdTiposHabilidades == id);
        }

        public void Cadastrar(TiposHabilidade novoTipo)
        {
            //Cria novo cadastro
            ctx.TiposHabilidades.Add(novoTipo);

            //salva o novo cadastro
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

            //Busca pelo id
            TiposHabilidade TipoHabilidadeBuscada = ctx.TiposHabilidades .Find(id);

            //Remove 
            ctx.Remove(TipoHabilidadeBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<TiposHabilidade> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.TiposHabilidades.ToList();
        }

        
    }
}
