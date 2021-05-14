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
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(TiposUsuarios tipoAtualizado, int id)
        {
            //Instância do tipoProcurado, busca através do id
            TiposUsuarios tipoProcurado = ctx.TiposUsuarios.Find(id);

            //Verificação de existência, diferente de nulo
            if (tipoAtualizado.Tipos != null)
            {
                //Atribuição de valores
                tipoProcurado.Tipos = tipoAtualizado.Tipos;

            }
            //Devolve a atualização
            ctx.TiposUsuarios.Update(tipoProcurado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public TiposUsuarios BuscarPorId(int id)
        {
            //Faz a busca através do id, e retorna o que foi encontrado
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTiposUsuario == id);
        }

        public void Cadastrar(TiposUsuarios novoTipoU)
        {
            //Executa o método
            ctx.TiposUsuarios.Add(novoTipoU);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método
            ctx.TiposUsuarios.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<TiposUsuarios> ListarTodos()
        {
            //Retorna a lista
            return ctx.TiposUsuarios.ToList();
        }
    }
}
