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
    public class TiposUsuariosController : ControllerBase
    {
        //Instância a interface para receber os métodos
        private ITiposUsuariosRepository _tiposUsuario { get; set; }

        //Instância o repository para ter referência aos métodos
        public TiposUsuariosController()
        {
            _tiposUsuario = new TiposUsuariosRepository();
        }

        /// <summary>
        /// Faz a listagem 
        /// </summary>
        /// <returns>Objetos e suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a lista
            return Ok(_tiposUsuario.ListarTodos());
        }


        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a busca
            return Ok(_tiposUsuario.BuscarPorId(id));
        }


        /// <summary>
        /// Faz o cadastro 
        /// </summary>
        /// <param name="novoTipoU">Objeto cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuarios novoTipoU)
        {
            //Chama o método
            _tiposUsuario.Cadastrar(novoTipoU);

            //Retorna um status
            return StatusCode(201);
        }

        /// <summary>
        /// Faz a atualização
        /// </summary>
        /// <param name="tipoAtualizado">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto atualizado com suas informações</returns>
        [HttpPut("{id}")]
        public IActionResult Put(TiposUsuarios tipoAtualizado, int id)
        {
            //Chama o método
            _tiposUsuario.Atualizar(tipoAtualizado, id);

            //Retorna um status
            return StatusCode(204);
        }

        /// <summary>
        /// Faz a exclusão
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Sem conteúdo, objeto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete( int id)
        {
            //Chama o método
            _tiposUsuario.Deletar(id);

            //Retorna um status
            return StatusCode(404);
        }

    }
}
