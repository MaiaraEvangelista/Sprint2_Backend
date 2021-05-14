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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(Especialidade especialidadeAtualizada, int id)
        {
            //Instância a especialidade buscada, busca o id
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            //Verifica se é existente
            if (especialidadeAtualizada.Tipos != null)
            {
                //Atribui valores para a atualização
                especialidadeBuscada.Tipos = especialidadeAtualizada.Tipos;
            }

            //Executa o método atribuido
            ctx.Especialidades.Update(especialidadeBuscada);

            //Salva as alteraçõs
            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            //Executa o método, busca pelo id e devolve
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            //Executa o método, cadastra
            ctx.Especialidades.Add(novaEspecialidade);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método, exclui 
            ctx.Especialidades.Remove(BuscarPorId(id));

            //Salva as alterações, deleta
            ctx.SaveChanges();
        }

        public List<Especialidade> ListarTodos()
        {
            //Lista todas as especialidades
            return ctx.Especialidades.ToList();
        }
    }
}
