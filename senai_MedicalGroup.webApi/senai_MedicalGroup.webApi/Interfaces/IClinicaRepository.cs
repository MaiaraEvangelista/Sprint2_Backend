using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IClinicaRepository
    {
        /// <summary>
        /// Método de listagem 
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Faz a busca do objeto pelo seu identificador
        /// </summary>
        /// <param name="id">Idnetificador do objeto</param>
        /// <returns>Objeto com suas informações</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Faz um cadastro de um novo objeto
        /// </summary>
        /// <param name="novaClinica">Objeto criado com suas informações</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Faz a atualização de um objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="ClinicaAtualizada">Objeto atualizado e suas informações</param>
        void Atualizar(int id, Clinica ClinicaAtualizada);

        /// <summary>
        /// Faz a exclusão de um objeto
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        void Deletar(int id);
    }
}
