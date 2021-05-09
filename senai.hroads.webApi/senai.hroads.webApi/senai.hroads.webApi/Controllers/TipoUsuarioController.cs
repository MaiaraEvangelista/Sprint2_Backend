using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //rota = http://localhost:5000/api/TipoUsuario
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        /// <summary>
        /// Vai receber todos os métodos definidos na interface
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos usuarios
        /// </summary>
        /// <returns>Lista com todos os tipos usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            //Chama o método
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

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
            //Promove a exclusão do usuário
            _tipoUsuarioRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="NovoTipo">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario NovoTipo)
        {
            //Faz atualização
            _tipoUsuarioRepository.Atualizar(id, NovoTipo);

            //Retorna atualização sucedida
            return StatusCode(200);
        }


    }
}
