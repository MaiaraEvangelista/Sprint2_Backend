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
    interface ITiposEventoRepository
    {
        /// <summary>
        /// Método que faz a listagem de todos os tipos
        /// </summary>
        /// <returns>Todos os eventos</returns>
        List<TiposEvento> ListarTodos();

        /// <summary>
        /// Busca um tipo de evento pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado</returns>
        TiposEvento BuscarPorId(int id);


        /// <summary>
        /// Faz o cadastro de um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">O tipo cadastrado</param>
        void Cadastrar(TiposEvento novoTipoEvento);

        /// <summary>
        /// Faz a atualizaão de um evento 
        /// </summary>
        /// <param name="id">Identificador do evento</param>
        /// <param name="eventoAtualizado">Objeto com novas informações</param>
        void Atualizar(int id, TiposEvento eventoAtualizado);

        /// <summary>
        /// Faz a exclusão de um evento
        /// </summary>
        /// <param name="id">Identificador do evento usado</param>
        void Deletar(int id);
    }
}
