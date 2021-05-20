using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.Gufi.webApi.Domains;
using senai.Gufi.webApi.Interfaces;
using senai.Gufi.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //Define a rota (domínio/api/nomeController)
    [Route("api/[controller]")]

    //Define que é um controlador de Api
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Cria o _usuário... que vai receber os métodos
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Faz a instância do repository para ter a referência dos métodos
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {

            try
            {
                //Faz a busca do usuário pelo seu endereço de email e pela sua senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                //Caso não encontrar um usuário com as informações declaradas, será nulo
                if (usuarioBuscado == null)
                {
                    //Retorna uma mensagem de erro
                    return NotFound("Email e senha não encontrados, usuário inexistente ou inválidos");
                }

                //---------- Caso o usuário seja encontrado, prossegue para a criação do token----------------

                /*
                    Dependências

                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */


                //Atribui os dados fornecidos no token
                var claims = new[]
                {
                    //Armazena na Claim o email do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    //Armazena na Claim o Identificador do usuário
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    //Armazena na Claim o tipo de usuário autenticado(ADMINISTRADOR/COMUM)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString() )

                };

                //Faz a definição da chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                //Faz a definiçaõ de quais são as chaves do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Faz a geração do token que vai ser utilizado
                var token = new JwtSecurityToken
                (
                    issuer:             "gufi.webApi",                      //emissor do token     
                    audience:           "gufi.webApi",                     //destinatários do token
                    claims:             claims,                           //dados definidos acima
                    expires:            DateTime.Now.AddMinutes(30),     //tempo de expiração do token gerado
                    signingCredentials: creds                           //credenciais do token
                );


                //Faz o retorno do token (OK)
                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }





    }
}
