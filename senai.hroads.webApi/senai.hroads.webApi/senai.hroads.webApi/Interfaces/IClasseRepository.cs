using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{/// <summary>
/// Responsável pelo repositório
/// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>todas as classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Busca as classes pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador das classes</param>
        /// <returns>A classe com suas informações</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">A nova classe criada</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe
        /// </summary>
        /// <param name="id">Identificador da classe atualizada</param>
        /// <param name="classeAtualizada">Objeto atualizado</param>
        void Atualizar(int id, Classe classeAtualizada);

        /// <summary>
        /// Faz a deleçãoi de uma classe
        /// </summary>
        /// <param name="id">Identificador da classe</param>
        void Deletar(int id);


       
    }
}
