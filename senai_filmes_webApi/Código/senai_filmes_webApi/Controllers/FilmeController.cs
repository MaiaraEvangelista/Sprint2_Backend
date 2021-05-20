using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// O objeto que irá receber todos os métodos
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instância o filme repository para ter os métodos
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();

        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>A lista com todos os filmes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria  a lista chamada lista filme 
            List<FilmeDomain> listaFilme = _filmeRepository.ListaGeral();

            //Retorna um status code 200 com a lista filmes
            return Ok(listaFilme);
        }

        /// <summary>
        /// Busca o filme através do id
        /// </summary>
        /// <param name="id">Identificador do filme</param>
        /// <returns>O objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria o objeto para buscar o id do filme
            FilmeDomain filmeBuscado = _filmeRepository.BuscasPorId(id);

            //Verifica se tem dado para ser lido
            if (filmeBuscado == null)
            {
                //Retorna que o filme não foi encontrado
                return NotFound("Filme não encontrado");
            }
            //Se ele não for nulo, devolve o filme encontrado
            return Ok(filmeBuscado);
        }


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto cadastrado</param>
        /// <returns>O novo objeto</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            //Faz a chamada para a execução do método de cadastro
            _filmeRepository.Cadastrar(novoFilme);

            //Retorna que o cadastro foi criado
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza pela url
        /// </summary>
        /// <param name="id">Identificador do filme</param>
        /// <param name="filmeAtualizado">Objeto a ser atualizado</param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            //Cria o filme buscado que vai receber o filme procurado no BD
            FilmeDomain filmeBuscado = _filmeRepository.BuscasPorId(id);

            //Verifica se tem dado para ser lido
            if (filmeBuscado == null)
            {
                return NotFound
                (
                   new
                   { 
                      mensagem = "Filme não encontrado"
                   }
                 );
            }

            //Atualiza o registro
            try
            {
                //Faz a chamada para a atualização
                _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                //Retorna um status code
                return NoContent();
            }
            //Caso dê erro
            catch (Exception codErro)
            {
                //retorna um 400 e o código
                return BadRequest(codErro);
            }
        }


        /// <summary>
        /// Atualiza o filme pelo corpo da url
        /// </summary>
        /// <param name="filmeAtualizado">O objeto atualizado</param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filmeAtualizado)
        {
            //Cria o filme Buscado que vai procurar no BD
            FilmeDomain filmeBuscado = _filmeRepository.BuscasPorId(filmeAtualizado.idFilme);

            //Verifica se tem dados
            if (filmeBuscado != null)
            {
                //Tentativa de atualização
                try
                {
                    //Chama o método
                    _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

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
            return NotFound
            (
                new
                {
                    mensagem = "Filme não encontrado"
                }
            );
        }


        /// <summary>
        /// Método que faz o delete
        /// </summary>
        /// <param name="id">Identificador do filme</param>
        /// <returns>Objeto que será deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Mostra a chamada do método de deletar o filme
            _filmeRepository.Deletar(id);

            //Retorna um status code que mostra que não tem conteúdo
            return StatusCode(204);
        }

    }
}
