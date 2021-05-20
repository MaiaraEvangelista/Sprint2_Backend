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
        /// 
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw
            }
        }

    
    
    
    }
}
