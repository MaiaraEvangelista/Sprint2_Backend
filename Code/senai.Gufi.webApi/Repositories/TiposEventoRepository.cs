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
    /// Responsável pelo repositório. Faz a herança com a interface para obter os métodos
    /// </summary>
    public class TiposEventoRepository : ITiposEventoRepository
    {

        /// <summary>
        /// Responsável por fazer a chamada dos métodos do Entity Framework Core
        /// </summary>
        GufiContext ctx = new GufiContext();


        /// <summary>
        /// Responsável por fazer a atualização dos eventos
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="eventoAtualizado">Objeto com suas novas informações </param>
        public void Atualizar(int id, TiposEvento eventoAtualizado)
        {
            //Faz a busca através do identificador
            TiposEvento tipoEventoBuscado = ctx.TiposEventos.Find(id);

            //Verifica se é diferente de nulo, ou seja, se foi informado
            if (eventoAtualizado.TituloEvento != null)
            {
                //Atribui os valores encontrados
                tipoEventoBuscado.TituloEvento = eventoAtualizado.TituloEvento;
            }

            //Faz a atuialização no que foi buscado
            ctx.TiposEventos.Update(tipoEventoBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a busca de um tipo de evento através do identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        public TiposEvento BuscarPorId(int id)
        {
            //Retorna o tipo de evento que corresponde ao id usado na busca
            return ctx.TiposEventos.FirstOrDefault(e => e.IdTipoEvento == id);
        }

        /// <summary>
        /// Faz o cadastro de um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Ojeto cadastrado</param>
        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            //Faz o cadastro de um tipo novo
            ctx.TiposEventos.Add(novoTipoEvento);

            //Salva o que foi feitpo
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de um tipo de evento
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Deletar(int id)
        {
            //Faz a busca pelo identificador para a exclusão
            TiposEvento tipoEventoBuscado = ctx.TiposEventos.Find(id);

            //Faz a exclusão do tipo de evento encontrado pelo identificador procurado
            ctx.TiposEventos.Remove(tipoEventoBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem de todos os tipos de evento
        /// </summary>
        /// <returns>Todos os objetos com suas devidas informações</returns>
        public List<TiposEvento> ListarTodos()
        {
            //Faz a listagem de todos os tipos de eventos que contém em seu banco
            return ctx.TiposEventos.ToList();
        }
    }
}
