using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório
    /// </summary>
    interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoDeDado NomeParametro) *o tipo de retorno é uma lista*;
        /// <summary>
        /// Método é a listagem de todos os generos
        /// </summary>
        /// <returns>Listar os generos</returns>
        List<GeneroDomain> ListaGeral();


        /// <summary>
        /// Método busca o elemento definido atráves do id
        /// </summary>
        /// <param name="id">id do genero procurado</param>
        /// <returns>o genero procurado com suas informações</returns>
        GeneroDomain BuscasPorId(int id);

        /// <summary>
        /// Cadastra um novo genero sugerido
        /// </summary>
        /// <param name="novoGenero">Cadastramento com as informações de um novo genero</param>
        //Ação sem retorno
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Atualiza o genero já existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualiza o genero passando o id pela url
        /// </summary>
        /// <param name="id">o id (numero) do genero que será atualizado</param>
        /// <param name="genero">genero que vai ser atualizado</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);


        /// <summary>
        /// Deleta o genero atrávés do id
        /// </summary>
        /// <param name="id">(chave primária) id que será buscado para ser deletado</param>
        void Deletar(int id);

    }
}
