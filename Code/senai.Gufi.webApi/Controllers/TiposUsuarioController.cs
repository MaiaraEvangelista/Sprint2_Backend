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
    //Define que a resposta vai ser em json
    [Produces("application/json")]

    //Define a rota 
    [Route("api/[controller]")]

    //Define que é um controlador de Api
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {

        /// <summary>
        /// Instância o _tipoUsuario... que vai receber todos os métodos da interface
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
   
    
        /// <summary>
        /// Instância o _tipoUsuarioRepository para ter referência aos métodos do repositório
        /// </summary>
        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TiposUsuarioRepository();
        }
    
        
        /// <summary>
        /// Método que faz a listagem de todos os tipos de usuários
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Faz o retorno da listagem
                return Ok(_tipoUsuarioRepository.ListarTodos());
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
        /// <returns>Objetos com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Faz a busca pelo id
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    
    
        /// <summary>
        /// Método que faz o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                //Faz o cadastro de um novo tipo de usuário
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                //Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    

        /// <summary>
        /// Método que faz a atualizaçõa de um tipo de usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="TipoUsuarioAtualizado">Objeto atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario TipoUsuarioAtualizado )
        {
            try
            {
                //Faz a chamada para o método
                _tipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

                //Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Método de deleção de um tipo de usuário
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Faz a chamada para o método
                _tipoUsuarioRepository.Deletar(id);

                //Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    
    
    }
}
