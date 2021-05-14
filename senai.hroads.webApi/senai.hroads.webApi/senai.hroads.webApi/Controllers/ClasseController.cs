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

    //rota = http://localhost:5000/api/Classe
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class ClasseController : ControllerBase
    {
        /// <summary>
        /// Vai receber todos os métodos definidos na interface
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }
        
        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Lista com todas as classes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_classeRepository.Listar());
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
            return Ok(_classeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novaClasse">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            //Chama o método
            _classeRepository.Cadastrar(novaClasse);

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
            //Promove a exclusão da classe
            _classeRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="novaClasse">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Classe novaClasse)
        {
            //Chama o método
            _classeRepository.Atualizar(id, novaClasse);

            //Retorna um status code
            return StatusCode(204);
        }

    }
}
