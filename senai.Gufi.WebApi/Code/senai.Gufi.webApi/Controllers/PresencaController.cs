using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Gufi.webApi.Domains;
using senai.Gufi.webApi.Interfaces;
using senai.Gufi.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é um contrlador de Api
    [ApiController]
    public class PresencaController : ControllerBase
    {
        /// <summary>
        /// Cria o _presencaRepository que vai receber os métodos da interface
        /// </summary>
        private IPresencaRepository _presencaRepository;


        /// <summary>
        /// Faz a instância para ter referência aos métodos do repositório
        /// </summary>
        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }


        /// <summary>
        /// Método que faz a listagem
        /// </summary>
        /// <returns>Todos os objetos com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                //Retorna a resposta da requisião chamando o método
                return Ok(_presencaRepository.ListarTodos());
            }
            catch (Exception CodErro)
            {

                return BadRequest(CodErro);
            }
        }


        /// <summary>
        /// Método que faz a busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Os objetos com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Faz a chamada do método buscando pelo id
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception CodErro)
            {

                return BadRequest(CodErro);
            }
        }


        /// <summary>
        /// Método que faz o cadastro de uma presença
        /// </summary>
        /// <param name="novaPresenca">Objeto cadastrado</param>
        /// <returns>O objeto criado e suas informações</returns>
        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            try
            {
                //Faz a chamada para o método
                _presencaRepository.Cadastrar(novaPresenca);

                //Faz o retorno de um status code
                return StatusCode(201);
            }
            catch (Exception CodErro)
            {

                return BadRequest(CodErro);
            }
        }



        /// <summary>
        /// Método que faz a atualização de uma presença
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="presencaAtualizada">Objeto atualizado</param>
        /// <returns>Objeto atualizado com suas informações</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            try
            {
                //Faz a chamada para o método de atualização
                _presencaRepository.Atualizar(id, presencaAtualizada);

                //Retorna um status code
                return StatusCode(204);
            }
            catch (Exception CodErro)
            {

                return BadRequest(CodErro);
            }
        }


        /// <summary>
        /// Método que faz a exclusão de uma presença
        /// </summary>
        /// <param name="id">Identificador usado para a procura e exclusão</param>
        /// <returns>Objeto deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Faz a hamada para o método de exclusão
                _presencaRepository.Deletar(id);

                //Retorna um status code
                return StatusCode(204);
            }
            catch (Exception CodErro)
            {

                return BadRequest(CodErro);
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                //Cria uma variável idUsuario que recebe o Identificador do usuário logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //Retorn aum Ok e chama o método de lista
                return Ok(_presencaRepository.MinhasPresencas(idUsuario));
            }
            catch (Exception error)
            {
                //Retorna uma resposta e qual o erro cometido 
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado",
                    error
                });
            }

        }


        /// <summary>
        /// Método que faz a inscriçaõ de um usuário em um evento
        /// </summary>
        /// <param name="idEvento">Identificador do evento</param>
        /// <returns>Objeto e suas iformações</returns>
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {

                Presenca inscricao = new Presenca()
                {
                    //Armazena no IdUsuario da presença o Id do usuário logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),

                    //Armazena na propriedade IdEvento o id do evento recebido pela url
                    IdEventto = idEvento,

                    //Define a situaão da presença como não confirmada
                    Situacao = "Não Confirmada"
                };

                //Faz a chamada para o método
                _presencaRepository.MarcarEvento(inscricao);

                //Retorna um status code
                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    mansagem = "Não é possível se inscrever sem o usuário estar logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Método que faz a alteração de uma presença 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="status">Objeto que atualiza a situação da presença</param>
        /// <returns>Objeto com suas informaões</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Presenca status)
        {
            try
            {
                //Faz a chamada para o método
                _presencaRepository.AprovarRecusar(id, status.Situacao);
            
                //Retorna uma resosta
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
