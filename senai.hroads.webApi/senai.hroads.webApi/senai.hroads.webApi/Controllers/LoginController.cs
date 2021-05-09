using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    //Define que a resposta será em json
    [Produces("application/json")]

    //Define a rota
    [Route("api/[controller]")]

    //Define que é controlador
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Recebe os métodos da interface
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instância o repository para ter referência dos métodos
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            //Instância método login
            Usuario LoginBuscado = _usuarioRepository.Login(login.EmailUsuario, login.SenhaUsuario);

            //Verifica se existe conteúdo
            if (LoginBuscado == null)
            {
                //Retorna que não tem conteúdo
                return NotFound("Email ou Usuário não encontrados!");
            }


            var Clamis = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, LoginBuscado.EmailUsuario.ToString()),
                new Claim(ClaimTypes.Role,               LoginBuscado.IdUsuario .ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuario-chave-autenticacao"));

            // Define as credenciais do token 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken
            (
                issuer: "HRoads.webApi",
                audience: "HRoads.webApi",
                claims: Clamis,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(Token)
                });

        }









    }
}
