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
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades 
        /// </summary>
        /// <returns>uma lista das habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca as habilidades pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto com suas informações</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto criado</param>
        void Cadastrar(Habilidade novaHabilidade);


        /// <summary>
        /// Faz a atualização de uma habilidade
        /// </summary>
        /// <param name="id">Identificador da habilidade</param>
        void Atualizar(int id, Habilidade HabilidadeAtualizada);

        /// <summary>
        /// Faz a deleeção de uma habilidade
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);


     
    
    
    
    
    }
}
