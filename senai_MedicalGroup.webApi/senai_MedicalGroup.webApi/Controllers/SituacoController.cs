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
    public class SituacoController : ControllerBase
    {
        //Vai receber os métodos definidos na interface
        private ISituacoRepository  _situacoRepository {get; set;}

        //Instância o repository para ter refer~encia dos métodos
        public SituacoController()
        {
            _situacoRepository = new SituacoRepository();
        }

        /// <summary>
        /// Faz a listagem  
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a listagem
            return Ok(_situacoRepository.ListarTodos());
        }


        /// <summary>
        /// Faz a busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna o objeto buscado
            return Ok(_situacoRepository.BuscarPorId(id));

        }

        /// <summary>
        /// Faz o cadastro
        /// </summary>
        /// <param name="novaSituacao">Objeto cadastrado</param>
        /// <returns>Novo objeto com sua informações</returns>
        [HttpPost]
        public IActionResult Post(Situaco novaSituacao)
        {
            //Chama o método
            _situacoRepository.Cadastrar(novaSituacao);

            //retorna um status
            return StatusCode(201);
        }

        /// <summary>
        /// Faz a atualização
        /// </summary>
        /// <param name="situacaoAtualizada">Objeto atualizado</param>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Situaco situacaoAtualizada ,int id)
        {
            //Chama o método
            _situacoRepository.Atualizar(situacaoAtualizada, id);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Faz a exclusão
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Sem conteúdo, objeto deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método
            _situacoRepository.Deletar(id);

            //Retorna um status
            return StatusCode(204);
        }


    }
}
