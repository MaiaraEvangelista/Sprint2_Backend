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

    //rota = http://localhost:5000/api/Usuario
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        /// <summary>
        /// Vai receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Lista com todos os usuarios </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta com o conteúdo
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Faz um novo cadastro
        /// </summary>
        /// <param name="novoUsuario">Objeto que será cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //Chama o método
            _usuarioRepository.Cadastrar(novoUsuario);

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
            _usuarioRepository.Deletar(id);

            //Retorna que não tem conteúdo
            return StatusCode(204);
        }

       /// <summary>
       /// Atualização por id
       /// </summary>
       /// <param name="id">Identificador</param>
       /// <param name="NovoUsuario">Objeto atualizado</param>
       /// <returns>Objeto atualizado com suas informações</returns>
        [HttpPut("Email/{id}")]
        public IActionResult AtualizarEmail(int id, Usuario NovoUsuario)
        {
            //Faz atualizãção
            _usuarioRepository.AtualizarEmail (id, NovoUsuario);

            //Retorno atualização sucedida
            return StatusCode(200);
        }


        /// <summary>
        /// Método de atualização por id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="  NovoUsuario">Objeto que vai ser atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("Senha/{id}")]
        public IActionResult AtualizarSenha(int id, Usuario NovoUsuario)
        {
            //Faz atualização
            _usuarioRepository.AtualizarSenha(id, NovoUsuario);

            //Retorno da atualização sucedida
            return StatusCode(200);
        }
    }
}
