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
    public class SituacoRepository : ISituacoRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(Situaco situacaoAtualizada, int id)
        {
            //Instância o situação buscada e busca através do id
            Situaco situacaoBuscada = ctx.Situacoes.Find(id);

            //Verifica se é nulo
            if (situacaoAtualizada.Situacao != null)
            {
                //Atribui os valores para a busca
                situacaoBuscada.Situacao = situacaoAtualizada.Situacao;
            }
            //Devolve o que foi atualizado
            ctx.Situacoes.Update(situacaoBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public Situaco BuscarPorId(int id)
        {
            //Retorna o que foi achado na busca
            return ctx.Situacoes.FirstOrDefault(s => s.IdSituacao == id);
        }

        public void Cadastrar(Situaco novaSituacao)
        {
            //Executa o cadastro
            ctx.Situacoes.Add(novaSituacao);

            //Salva as inserções
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método de exclusão
            ctx.Situacoes.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Situaco> ListarTodos()
        {
            //Retorna s listagem
            return ctx.Situacoes.ToList();
        }
    }
}
