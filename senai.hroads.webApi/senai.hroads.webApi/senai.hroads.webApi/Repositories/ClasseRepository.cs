using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto por onde é chamado os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();

        public void Atualizar(int id, Classe classeAtualizada)
        {
            //Busca através do id
            Classe classeBuscada = ctx.Classes.Find(id);

            //Verifica se é nulo
            if (classeAtualizada.Cargos != null)
            {
                //Atribui os valores
                classeBuscada.Cargos = classeAtualizada.Cargos;

            }
            //Devolve atualizado
            ctx.Classes.Update(classeBuscada);

            //Salva no BD
            ctx.SaveChanges();
        }


        public Classe BuscarPorId(int id)
        {
            //Retorna o identificador buscado
            return ctx.Classes.FirstOrDefault( c => c.IdClasses == id);
        }


        public void Cadastrar(Classe novaClasse)
        {
            //Cria novo cadastro
            ctx.Classes.Add(novaClasse);

            //salva o novo cadastro
            ctx.SaveChanges();
        }


        public void Deletar(int id)
        {

            //Busca pelo id
            Classe classeBuscada = ctx.Classes.Find(id);

            //Remove 
            ctx.Remove(classeBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>lista</returns>
        public List<Classe> Listar()
        {
            //Retorna uma lista com todas as informações
            return ctx.Classes.ToList();
        }

    



    }
}
