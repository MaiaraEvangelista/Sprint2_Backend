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
    interface IPresencaRepository
    {
        /// <summary>
        /// Faz a listagem das presenças
        /// </summary>
        /// <returns>Todas as presenças em um evento</returns>
        List<Presenca> ListarTodos();

        /// <summary>
        /// faz a busca de uma presença pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto buscado com suas informações</returns>
        Presenca BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de uma nova presença
        /// </summary>
        /// <param name="novaPresenca">Objeto cadastrado</param>
        void Cadastrar(Presenca novaPresenca);

        /// <summary>
        /// Faz a atualização de uma presença
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="presencaAtualizada">Objeto atualizado</param>
        void Atualizar(int id, Presenca presencaAtualizada);

        /// <summary>
        /// Faz a exclusão de uma presença
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);

        /// <summary>
        /// Lista as presenças de um usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado e listado</returns>
        List<Presenca> MinhasPresencas(int id);

        /// <summary>
        /// Faz a inscrição de um usuário, marca presença em um evento
        /// </summary>
        /// <param name="marcar">Confirmação de inscrição do usuário</param>
        void MarcarEvento(Presenca marcar);


        /// <summary>
        /// Altera o status de uma presença 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="status">Que mostra se a presença foi confirmada, desmarcada, recusada </param>
        /// <returns>Objeto com suas informações</returns>
        void AprovarRecusar(int id, string status);
    }
}
