using senai_MedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Interfaces
{
    //Responsável por iniciar os métodos
    interface IPacienteRepository
    {
        /// <summary>
        /// Faz a listagem de todos os pacientes
        /// </summary>
        /// <returns>Os objetos com suas informações</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um paciente pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto com suas informações</returns>
        Paciente BuscarPorId(int id);

        /// <summary>
        /// Faz o cadastro de um paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto cadastrado com suas informações</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Faz a atualização de um paciente existente
        /// </summary>
        /// <param name="pacienteAtualizado">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        void Atualizar(Paciente pacienteAtualizado, int id);

        /// <summary>
        /// Faz a exclusão de um paciente
        /// </summary>
        /// <param name="id">Identificador</param>
        void Deletar(int id);
    }
}
