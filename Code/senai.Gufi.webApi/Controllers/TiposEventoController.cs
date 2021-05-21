using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Gufi.webApi.Domains;
using senai.Gufi.webApi.Interfaces;
using senai.Gufi.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //Responsável pela rota
    //http://localhost:5000/api/tiposEventos
    [Route("api/[controller]")]

    //Responsável pelo controlador da Api
    [ApiController]
    public class TiposEventoController : ControllerBase
    {

        /// <summary>
        /// Método que vai receber todos os métodos impostos na interface
        /// </summary>
        private ITiposEventoRepository _tiposEventoRepository { get; set; }


        /// <summary>
        /// Instância o _tipos... para ter referência ao repository
        /// </summary>
        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }


        /// <summary>
        /// Método que faz a listagem de todos os tipos de eventos
        /// </summary>
        /// <returns>A lista com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Faz mu retorno chamando o método de listagem
                return Ok(_tiposEventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Método que faz a busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado e suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna uma resposta fazendo a busca pelo id
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Método que faz o cadastro de um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto cadastrado</param>
        /// <returns>Objeto cadastrado com suas novas informações</returns>
        [HttpPost]
        public IActionResult Post(TiposEvento novoTipoEvento)
        {
            try
            {
                //Faz a chamada para o método de cadastro
                _tiposEventoRepository.Cadastrar(novoTipoEvento);

                //Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Método que faz a atualização de um tipo de evento
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="eventoAtualizado">Objeto que vai ser atualizado</param>
        /// <returns>Objeto atualizado com suas informações</returns>
        [HttpPut]
        public IActionResult Put(int id, TiposEvento eventoAtualizado)
        {
            try
            {
                //Faz a chamada para o método de atualização
                _tiposEventoRepository.Atualizar(id, eventoAtualizado);

                //Retorna um status code
                return BadRequest(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Método que faz a exclusão de um tipo de evento
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método de exclusão
            _tiposEventoRepository.Deletar(id);

            //Retorna um status code

            return StatusCode(204);
        }

    }
}
