using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.ViewModels
{
    /// <summary>
    /// Responsável pelo modelo de login
    /// </summary>
    public class LoginViewModel
    {
        //Mostra que a propriedade é obrigatória
        [Required(ErrorMessage ="O Email do usário é obrigatório!")]
        public string Email { get; set; }


        //Mostra que a propriedade é obrigatória
        [Required(ErrorMessage ="A senha do usuário é obrigatória!")]
        public string Senha { get; set; }
    
    }
}
