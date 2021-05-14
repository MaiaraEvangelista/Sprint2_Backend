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
    public class ClinicaRepository : IClinicaRepository
    {
        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Clinica ClinicaAtualizada)
        {
            //Instância a clinica buscada e procura pelo id
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            //Verifica se é nulo
            if (ClinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = ClinicaAtualizada.Endereco;
            }

            if (ClinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }

            if (ClinicaAtualizada.HorarioAbertura != null)
            {
                clinicaBuscada.HorarioAbertura = ClinicaAtualizada.HorarioAbertura;
            }

            if (ClinicaAtualizada.HorarioFechamento != null)
            {
                clinicaBuscada.HorarioFechamento = ClinicaAtualizada.HorarioFechamento;
            }

            if (ClinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
            }

            if (ClinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }

            if (ClinicaAtualizada.Telefone != null)
            {
                clinicaBuscada.Telefone = ClinicaAtualizada.Telefone;
            }

            //Faz a atualização
            ctx.Clinicas.Update(clinicaBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            //Retorna o que foi buscado
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            //Executa o método e cadastra
            ctx.Clinicas.Add(novaClinica);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método e exclui
            ctx.Clinicas.Remove(BuscarPorId(id));

            //Salva as salterações
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            //Retorna uma lista
            return ctx.Clinicas.ToList();
        }
    }
}
