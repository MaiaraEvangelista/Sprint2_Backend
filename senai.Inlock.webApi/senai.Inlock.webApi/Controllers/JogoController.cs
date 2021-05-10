using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Inlock.webApi.Domains;
using senai.Inlock.webApi.Interfaces;
using senai.Inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Controllers
{
    //define que a resposta será em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class JogoController : ControllerBase
    {
        /// <summary>
        /// O objeto que irá receber todos os métodos
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }


        /// <summary>
        /// Instância o jogo repository para ter os métodos
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto cadastrado</param>
        /// <returns>O novo objeto</returns>
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            //Faz a chamada para a execução do método de cadastro
            _jogoRepository.Cadastrar(novoJogo);

            //Retorna que o cadastro foi criado
            return StatusCode(201);
        }


        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>A lista </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria  a lista chamada lista jogo
            List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();

            //Retorna um status code 200 com a lista 
            return Ok(listaJogo);
        }


        /// <summary>
        /// Busca através do id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria o objeto para buscar o id
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            //Verifica se tem dado para ser lido
            if (jogoBuscado == null)
            {
                //Retorna que não foi encontrado
                return NotFound("Jogo não encontrado");
            }
            //Se ele não for nulo, devolve o jogo encontrado
            return Ok(jogoBuscado);
        }


        /// <summary>
        /// Atualiza pelo corpo
        /// </summary>
        /// <param name="jogoAtualizado">Objeto a ser atualizado</param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut]
        public IActionResult PutIdBody(JogoDomain jogoAtualizado)
        {
            //Cria o jogo Buscado que vai procurar no BD
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.idJogo);

            //Verifica se tem dados
            if (jogoBuscado != null)
            {
                //Tentativa de atualização
                try
                {
                    //Chama o método
                    _jogoRepository.AtualizarIdCorpo(jogoAtualizado);

                    //Retorna um status code
                    return NoContent();
                }

                //Caso dê erro
                catch (Exception codErro)
                {
                    //Retorna o BadRequest
                    return BadRequest(codErro);
                }
            }
            //Retorna que não foi encontrado
            return NotFound
           (
                //Passa uma mensagem
               new
               {
                   mensagem = "Jogo não encontrado"
               }
           );
        }


        /// <summary>
        /// Método que faz o delete
        /// </summary>
        /// <param name="id">Identificador do jogo</param>
        /// <returns>Objeto que será deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Mostra a chamada do método de deletar o jogo
            _jogoRepository.Deletar(id);

            //Retorna um status code que mostra que não tem conteúdo
            return StatusCode(204);
        }
    }
}
