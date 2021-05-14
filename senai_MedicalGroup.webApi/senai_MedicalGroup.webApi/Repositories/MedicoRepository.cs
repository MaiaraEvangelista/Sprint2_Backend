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
    public class MedicoRepository : IMedicoRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(Medico medicoAtualizado, int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            //Verifica se é existente, e atualiza
            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }

            if (medicoAtualizado.Crm != null)
            {
                medicoBuscado.Crm = medicoAtualizado.Crm;

            }

            if (medicoAtualizado.IdEspecialidade != null)
            {

                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            }

            if (medicoAtualizado.IdClinica != null)
            {
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
            }

            if (medicoAtualizado.IdUsuario != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
            }

            //Devolve com as alterações feitas
            ctx.Medicos.Update(medicoBuscado);

            //Salva as alteraões 
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            //Faz a busca e retorna o que foi encontrado
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            //Executa o método e cadastra
            ctx.Medicos.Add(novoMedico);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método de exclusão
            ctx.Medicos.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            //Retorna a listagem
            return ctx.Medicos.ToList();
        }
    }
}
