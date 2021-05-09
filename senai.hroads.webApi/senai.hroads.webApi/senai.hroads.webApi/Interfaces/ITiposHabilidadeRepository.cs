using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Responsável mpelo repositório
    /// </summary>
    interface ITiposHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>todos os tipos de habilidades</returns>
        List<TiposHabilidade> Listar();

        /// <summary>
        /// Busca os tipos de habilidade pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto procurado</returns>
        TiposHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Objeto cadastrado</param>
        void Cadastrar(TiposHabilidade novoTipo);

        /// <summary>
        /// Faz a atualização de um tipo de habilidade
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="tipoAtualizado">Objeto atualizado</param>
        void Atualizar(int id, TiposHabilidade tipoAtualizado);

        /// <summary>
        /// Faz a deleeçaõ de um tipo habilidade
        /// </summary>
        /// <param name="id">Idetificador</param>
        void Deletar(int id);



      









    }
}
