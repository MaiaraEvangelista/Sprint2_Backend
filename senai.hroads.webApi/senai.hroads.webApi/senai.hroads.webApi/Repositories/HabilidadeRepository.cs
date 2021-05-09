using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Habilidade HabilidadeAtualizada)
        {
            //Busca através do id
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            //Verifica se é nulo
            if (HabilidadeAtualizada.Técnicas != null)
            {
                //Atribui os valores
                HabilidadeBuscada.Técnicas = HabilidadeAtualizada.Técnicas;

            }
            //Devolve atualizado
            ctx.Habilidades.Update(HabilidadeBuscada);

            //Salva no BD
            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.Habilidades.FirstOrDefault( h => h.IdHabilidades== id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Cria novo cadastro
            ctx.Habilidades.Add(novaHabilidade);

            //salva o novo cadastro
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

            //Busca pelo id
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            //Remove 
            ctx.Remove(HabilidadeBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<Habilidade> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.Habilidades.ToList();
        }

        
    }
}
