using senai.Inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Método de cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>Lista com os objetos e suas informações</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Método de atualização
        /// </summary>
        /// <param name="jogoAtualizado">Objeto e suas informações atualizadas</param>
        void AtualizarIdCorpo(JogoDomain jogoAtualizado);

        /// <summary>
        /// Método de exclusão
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Método de busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado e suas informações</returns>
        JogoDomain BuscarPorId(int id);
    }
}
