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
    public class ClinicaController : ControllerBase
    {
        //Vai receber os métodos que foram definidos na interface
        private IClinicaRepository _clinicaRepository { get; set; }

        // Instância o repository para ter referência dos métodos
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Lista todos as clinicas
        /// </summary>
        /// <returns>Lista com todas as clinicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_clinicaRepository.ListarTodos());
        }

        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna  a resposta buscada pelo id
            return Ok(_clinicaRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novaClinica">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            //Chama o método
            _clinicaRepository.Cadastrar(novaClinica);

            //Retorna um status
            return StatusCode(201);
        }


        /// <summary>
        /// Faz a exclusão do objeto
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        /// <returns>Objeto deletado, sem retorno de conteúdo</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Promove a exclusão da clinica
            _clinicaRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="novaClinica">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Clinica novaClinica)
        {
            //Chama o método
            _clinicaRepository.Atualizar(id, novaClinica);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}
