using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_MedicalGroup.webApi.Domains;
using senai_MedicalGroup.webApi.Interfaces;
using senai_MedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Controllers
{
    //Define que a resposta vai ser em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class PacienteController : ControllerBase
    {
        //Vai receber os métodos definidos na interface
        private IPacienteRepository _pacienteRepository { get; set; }


        //Instância o repository para ter referência aos métodos
        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacienteRepository.ListarTodos());
        }

        /// <summary>
        /// Faz a busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_pacienteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz um cadastro 
        /// </summary>
        /// <param name="novoPaciente">Objeto cadastrado</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            //Chama o método para o cadastro
            _pacienteRepository.Cadastrar(novoPaciente);

            //Retorna um status code 
            return StatusCode(201);
        }


        /// <summary>
        /// Faz a atualização 
        /// </summary>
        /// <param name="pacienteAtualizado">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Paciente pacienteAtualizado, int id)
        {
            //Chama o método
            _pacienteRepository.Atualizar(pacienteAtualizado, id);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Faz a exclusão
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Sem conteúdo, método executado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //chama o método
            _pacienteRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }

    }
}
