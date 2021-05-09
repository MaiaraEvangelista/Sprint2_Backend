using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            //Busca através do id
            Personagem personagemBuscado = ctx.Personagens.Find(id);

            //Verifica se é nulo
            if (personagemAtualizado.Nomes != null)
            {
                //Atribui os valores
                personagemBuscado.Nomes = personagemAtualizado.Nomes;

            }
            //Devolve atualizado
            ctx.Personagens.Update(personagemBuscado);

            //Salva no BD
            ctx.SaveChanges();

            if (personagemAtualizado.DataAtualização !=null)
            {
                personagemBuscado.DataAtualização = personagemAtualizado.DataAtualização;

            }

            //Devolve atualizado
            ctx.Personagens.Update(personagemBuscado);

            //Salva no BD
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            //Cria novo cadastro
            ctx.Personagens.Add(novoPersonagem);

            //salva o novo cadastro
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {

            //Busca pelo id
            Personagem personagemBuscado = ctx.Personagens.Find(id);

            //Remove 
            ctx.Remove(personagemBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<Personagem> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.Personagens.ToList();
        }

       
    }
}
