using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    interface IFilmeRepository
    {
        /// <summary>
        /// Método apresenta a listagem de todos os filmes 
        /// </summary>
        /// <returns>A listagem dos filmes</returns>
        //se refere a uma listagem de todos os filmes
        List<FilmeDomain> ListaGeral();


        /// <summary>
        /// Método busca filme por id
        /// </summary>
        /// <param name="id">id do filme procurado</param>
        /// <returns>Filme procurado pelo id (identificador)</returns>
        FilmeDomain BuscasPorId(int id);


        /// <summary>
        /// Método faz o cadastramento de um novo filme
        /// </summary>
        /// <param name="novoFilme">Cadastramento usando as informações de um mnovo filme</param>
        // Um método sem retorno
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        /// Método atualiza a sessão filmes usando o corpo da requisição
        /// </summary>
        /// <param name="filme">Atualiza os filmes com novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);


        /// <summary>
        /// Método atualiza os filmes pela url
        /// </summary>
        /// <param name="id">id (identificador/número) que vai ser atualizado</param>
        /// <param name="filme">Objeto que vai ser atualizado</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);


        /// <summary>
        /// Método que deleta o elemento pelo id escolhido
        /// </summary>
        /// <param name="id">(identificador/ numero) selecionado para o delete</param>
        void Deletar(int id);
    }
}
