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
    public class EspecialidadeController : ControllerBase
    {
        //Recebe os métodos da interface
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        //Instância o repository para ter referência aos métodos
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todos as especialidades
        /// </summary>
        /// <returns>Lista com todas as especialidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_especialidadeRepository.ListarTodos());
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
            return Ok(_especialidadeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novaEspecialidade">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            //Chama o método
            _especialidadeRepository.Cadastrar(novaEspecialidade);

            //Retorna um status
            return StatusCode(201);
        }

        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="especialidadeAtualizada">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            //Chama o método
            _especialidadeRepository.Atualizar(especialidadeAtualizada, id);

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
            //Promove a exclusão da especialidade
            _especialidadeRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }
    }
}
