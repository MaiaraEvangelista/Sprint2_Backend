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

    //rota = http://localhost:5000/api/Habilidade
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        /// <summary>
        /// Vai receber todos os métodos definidos na interface
        /// </summary>
        private IHabilidadeRepository _HabilidadeRepository { get; set; }


        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista as habilidades
        /// </summary>
        /// <returns>A lista com os objetos e suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_HabilidadeRepository.Listar());
        }


        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_HabilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz o cadastro de uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Novo objeto cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            //Chama o método
            _HabilidadeRepository.Cadastrar(novaHabilidade);

            //Retorna um status
            return StatusCode(201);
        }

        /// <summary>
        /// Faz a exclusão de um objeto
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        /// <returns>Objeto deletado, sem retorno de conteúdo, apenas confirmação de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Promove a exclusão do usuário
            _HabilidadeRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

        /// <summary>
        /// Faz a atualização do objeto pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="novaHabilidade">Objeto atualizado</param>
        /// <returns>Objeto atualizado com novas informações</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Habilidade novaHabilidade)
        {
            //Chama o método
            _HabilidadeRepository.Atualizar(id, novaHabilidade);

            //Retorna um status code 
            return StatusCode(200);
        }

    }
}
