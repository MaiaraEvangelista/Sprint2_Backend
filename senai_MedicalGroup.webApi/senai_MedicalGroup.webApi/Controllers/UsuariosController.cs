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
    public class UsuariosController : ControllerBase
    {
        //Instância a interface para ter os métodos
        private IUsuariosRepository _usuariosRepository { get; set; }


        //Instância o usuário repository para ter referência aos métodos
        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }


        /// <summary>
        /// Faz a listagem
        /// </summary>
        /// <returns>Objetos com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a lista
            return Ok(_usuariosRepository.ListarTodos());
        }

        /// <summary>
        /// Faz a busca pelo id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Executa o método  
            return Ok(_usuariosRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Faz o cadastro
        /// </summary>
        /// <param name="novoUsuario">Objeto cadastrado</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            //Chama o método
            _usuariosRepository.Cadastrar(novoUsuario);

            //Retorna um status
            return StatusCode(201);
        }


        /// <summary>
        /// Faz a atualização
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto atualizado</param>
        /// <param name="email">acesso</param>
        /// <returns>Objeto atualizado com suas infromações</returns>
        [HttpPut("{email}")]
        public IActionResult Atualizar(  string email ,Usuarios usuarioAtualizado)
        {
            //Chama o método
            _usuariosRepository.AtualizarEmail( email ,usuarioAtualizado);

            //Retorna um status
            return StatusCode(204);

        }


        /// <summary>
        /// Faz a atualização
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto atualizado</param>
        /// <param name="senha">Passe</param>
        /// <returns>Objeto atualizado com suas infromações</returns>
        [HttpPut("{senha}")]
        public IActionResult AtualizarSenha(string senha, Usuarios usuarioAtualizado)
        {
            //Chama o método
            _usuariosRepository.AtualizarSenha(senha, usuarioAtualizado);

            //Retorna um status
            return StatusCode(204);

        }

        /// <summary>
        /// Faz a exclusão 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Sem conteúdo, objeto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método
            _usuariosRepository.Deletar(id);

            //retorna um status
            return StatusCode(404);
        }



    }
}
