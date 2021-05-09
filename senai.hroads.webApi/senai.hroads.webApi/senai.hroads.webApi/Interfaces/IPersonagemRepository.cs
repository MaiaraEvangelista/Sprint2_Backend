using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Responsável pelo repositório
    /// </summary>
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Lista com todos os personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Faz a busca dos personagens pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto buscado e susas informações</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto atualizado</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Faz a atualização dos personagens
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="personagemAtualizado">Objeto atualizado</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Faz a deleção de um personagem
        /// </summary>
        /// <param name="id">Idetificador de um personagem</param>
        void Deletar(int id);


        

    }
}
