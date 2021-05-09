using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos generos
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    //Define que a resposta dada vai ser em json
    [Produces("application/json")]

    //Define quea rota da requisição será no formato domínio/api/Controller
    //EXEMPLO: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o _generoRepository para ter a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// lista todos os gêneros
        /// </summary>
        /// <returns>A lista dos gêneros e um status code</returns>
        /// http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            //Cria a lista chamada listaGeneros que vai receber a informação do bd
            List<GeneroDomain> listaGeneros = _generoRepository.ListaGeral();

            //Retorna um status code 200 com a lista de gêneros no formato json
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca o gênero através do id
        /// </summary>
        /// <param name="id">O número do gênero buscado</param>
        /// <returns>O gênero buscado, ou o NotFound(não encontrado)</returns>
        /// http://localhost:5000/api/generos/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria o objeto para buscar o id que vai receber o gênero buscado do bd
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(id);

            //Verifica se é null
            if (generoBuscado == null)
            {
                //Retorna que o gênero não foi encontrado
                return NotFound("Gênero não encontrado");
            }

            //Se ele não for nulo, devolve o gênero encontrado
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastramento de um novo gênero
        /// </summary>
        /// <returns>Um status code 201 (Created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Faz a chamada para a execução do método cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //Retorna que o cadastro foi criado
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o gênero existente pela url
        /// </summary>
        /// <param name="id">Identificador do gênero</param>
        /// <param name="generoAtualizado">Objeto que será atualizado com as novas informações</param>
        /// <returns>Status code </returns>
        /// http://localhost:5000/api/generos/2
        [HttpPut("{id}")]
        public IActionResult PutIdURL(int id, GeneroDomain generoAtualizado)
        {
            //Cria o genero buscado que vai receber o genero procurado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(id);

            //Caso não seja encontrado vai retornar a mensagem
            if (generoBuscado == null)
            {
                return NotFound
                (
                    new
                    { 
                        mensagem = "Gênero não encontrado!"
                    }
                );
            }

            //Atualiza o registro
            try
            {
                //Faz a achamada para atualização
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                //Retorna um status code 
                return NoContent();
            }
            //Caso dê erro
            catch (Exception codErro)
            {
                //retorna um 400 e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero pelo corpo
        /// </summary>
        /// <param name="generoAtualizado">Objeto que vai ser atualizado</param>
        /// <returns>Status Code </returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            //Cria o genero buscado que vai receber o genero procurado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscasPorId(generoAtualizado.idGenero);

            //Verificação se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                //Tenativa de atualização
                try
                {
                    //chama o método
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    //retorna um status
                    return NoContent();
                }

                //Caso de erro
                catch (Exception codErro)
                {
                    //Retorna o BadRequest e o cód do erro
                    return BadRequest(codErro);
                }
            }

            return  NotFound
            (
                new
                {
                    mensagem = "Gênero não encontrado"
                 }
            );

        }


        /// <summary>
        /// Método que deleta um gênero
        /// </summary>
        /// <param name="id">número do gênero que será deletado</param>
        /// <returns>Um 204 No Content</returns>
        /// http://localhost:5000/api/generos/5
        /// Aqui fiz uma alteração na rota para conseguir fazer o método de delete
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            //Mostra a chamada do métodod de deletar um gênero
            _generoRepository.Deletar(id);

            //Retorna um statusCode que mostra que não se tem o conteúdo ou seja (Foi excluído)
            return StatusCode(204);
        }
    }
}
