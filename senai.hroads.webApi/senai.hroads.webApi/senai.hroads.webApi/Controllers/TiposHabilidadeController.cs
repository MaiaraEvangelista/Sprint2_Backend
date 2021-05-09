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

    //rota = http://localhost:5000/api/TiposHabilidade
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class TiposHabilidadeController : ControllerBase
    {

        /// <summary>
        /// Vai receber todos os métodos definidos na interface
        /// </summary>
        private ITiposHabilidadeRepository _tiposHabilidadeRepository { get; set; }


        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public TiposHabilidadeController()
        {
            _tiposHabilidadeRepository = new TiposHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos 
        /// </summary>
        /// <returns>Lista com todos os tipos habilidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_tiposHabilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposHabilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(TiposHabilidade novoTipoHabilidade)
        {
            //Chama o método
            _tiposHabilidadeRepository.Cadastrar(novoTipoHabilidade);

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
            _tiposHabilidadeRepository.Deletar(id);

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
        public IActionResult Atualizar(int id, TiposHabilidade NovoTipo)
        {
            //Faz atualização
            _tiposHabilidadeRepository.Atualizar(id, NovoTipo);

            //Retorno bem sucedido
            return StatusCode(204);
        }


    }
}
