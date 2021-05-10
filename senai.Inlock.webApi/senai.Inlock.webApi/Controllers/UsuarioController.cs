using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.Inlock.webApi.Domains;
using senai.Inlock.webApi.Interfaces;
using senai.Inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Controllers
{
    //define que a resposta será em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        /// <summary>
        /// O objeto que irá receber todos os métodos
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }


        /// <summary>
        /// Instância o usuario repository para ter os métodos
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto cadastrado</param>
        /// <returns>O novo objeto</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            //Faz a chamada para a execução do método de cadastro
            _usuarioRepository.Cadastrar(novoUsuario);

            //Retorna que o cadastro foi criado
            return StatusCode(201);
        }


        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>A lista </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria  a lista chamada lista usuario
            List<UsuarioDomain> listaUsuario = _usuarioRepository.ListarTodos();

            //Retorna um status code 200 com a lista 
            return Ok(listaUsuario);
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
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            //Verifica se tem dado para ser lido
            if (usuarioBuscado == null)
            {
                //Retorna que não foi encontrado
                return NotFound("Usuario não encontrado");
            }
            //Se ele não for nulo, devolve o usuario encontrado
            return Ok(usuarioBuscado);

        }


        /// <summary>
        /// Atualiza pelo corpo
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto a ser atualizado</param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut]
        public IActionResult PutIdBody(UsuarioDomain usuarioAtualizado)
        {
            //Cria o jogo Buscado que vai procurar no BD
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(usuarioAtualizado.idUsuario);

            //Verifica se tem dados
            if (usuarioBuscado != null)
            {
                //Tentativa de atualização
                try
                {
                    //Chama o método
                    _usuarioRepository.AtualizarIdCorpo(usuarioAtualizado);

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
                   mensagem = "Usuario não encontrado"
               }
           );
        }


        /// <summary>
        /// Método que faz o delete
        /// </summary>
        /// <param name="id">Identificador do usuario</param>
        /// <returns>Objeto que será deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Mostra a chamada do método de deletar o usuario
            _usuarioRepository.Deletar(id);

            //Retorna um status code que mostra que não tem conteúdo
            return StatusCode(204);
        }


        /// <summary>
        /// Método para login
        /// </summary>
        /// <param name="login">Objeto</param>
        /// <returns>O usuário logado na sua conta</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            //Cria o usuario buscado que vai receber os parâmetros do BD
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            //Verifica se tem dados para serem lidos
            if (usuarioBuscado == null)
            {
                //Retorna que não tem conteúdo encontrado e passa mensagem
                return NotFound("Dados incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti,   usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role,               usuarioBuscado.idTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("games-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:             "Inlock.webApi",
                audience:           "Inlock.webApi",
                claims:             claims,
                expires:            DateTime.Now.AddHours(12),
                signingCredentials: creds
            );
            //Retorna um statuscode e o token
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
