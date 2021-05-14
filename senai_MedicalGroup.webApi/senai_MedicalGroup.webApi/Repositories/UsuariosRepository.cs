using senai_MedicalGroup.webApi.Contexts;
using senai_MedicalGroup.webApi.Domains;
using senai_MedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroup.webApi.Repositories
{
    /// <summary>
    /// Faz a herança com a interface para receber os métodos
    /// </summary>
    public class UsuariosRepository : IUsuariosRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();


        public void AtualizarEmail(string email, Usuarios usuarioAtualizado)
        {
            //Busca através do id
            Usuarios UsuarioBuscado = ctx.Usuarios.Find(email);

            //Verifica se é diferente de nulo
            if (usuarioAtualizado.Email != null)
            {
                //Atribui os valores
                UsuarioBuscado.Email = usuarioAtualizado.Email;
            }

            //Faz a atualização
            ctx.Usuarios.Update(UsuarioBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

       

        public void AtualizarSenha(string senha, Usuarios usuarioAtualizado)
        {
            //Busca através do id
            Usuarios UsuarioBuscado = ctx.Usuarios.Find(senha);

            //Verifica se é diferente de nulo
            if (usuarioAtualizado.Senha != null)
            {
                //Atribui os valores
                UsuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            //Faz a atualização
            ctx.Usuarios.Update(UsuarioBuscado);

            //Salva a atualização
            ctx.SaveChanges();
        }


        public Usuarios BuscarPorId(int id)
        {
            //Retorna o identificador procurado e as informações
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            //Executa o método
            ctx.Usuarios.Add(novoUsuario);

            //Salva as alterações e atualizações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método
            ctx.Usuarios.Remove(BuscarPorId(id));

            //Salva o que foi feito
            ctx.SaveChanges();
        }

        public List<Usuarios> ListarTodos()
        {
            //Retorna uma lista
            return ctx.Usuarios.ToList();
        }

        public Usuarios Login(string email, string senha)
        {
            //Verifica a veracidade, e loga
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
