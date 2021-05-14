using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_MedicalGroup.webApi.Domains;
using senai_MedicalGroup.webApi.Interfaces;
using senai_MedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class ConsultaController : ControllerBase
    {
        //Vai receber os métodos definidos na interface
        private IConsultaRepository _consultaRepository { get; set; }
    
        //Instância o repositório para ter referência aos métodos
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todos as consultas
        /// </summary>
        /// <returns>Lista com todas as consultas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_consultaRepository.ListarTodos());
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
            return Ok(_consultaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novaConsulta">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            //Chama o método
            _consultaRepository.Cadastrar(novaConsulta);

            //Retorna um status
            return StatusCode(201);
        }


        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="novaConsulta">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Consulta novaConsulta)
        {
            //Chama o método
            _consultaRepository.Atualizar(id, novaConsulta);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Faz a exclusão do objeto
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        /// <returns>Objeto deletado, sem retorno de conteúdo</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Promove a exclusão da consulta
            _consultaRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

        /// <summary>
        /// Busca pela consulta individual de um paciente
        /// </summary>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("minhaIndividual")]   
        public IActionResult GetMyAppointments()
        {
            //Atualiza o registro
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //Retorna uma esposta
                return Ok(_consultaRepository.ListarIndividualConsulta(idUsuario));
            }
            //Caso dê erro
            catch (Exception codErro)
            {
                //Retorna uma mensagem e um 400
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado",
                    codErro
                });
            }
        }
    }
}
