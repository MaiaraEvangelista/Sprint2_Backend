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
    public class PacienteRepository : IPacienteRepository
    {

        //Instância o ctx que tem a conexão com o BD
        MedicalContext ctx = new MedicalContext();

       
        public void Atualizar(Paciente pacienteAtualizado, int id)
        {
            //Instância o paciente buscado e faz a procura
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            //Verifica se é nulo
            if (pacienteAtualizado.Consulta != null)
            {
                pacienteAtualizado.Consulta = pacienteAtualizado.Consulta;
            }

            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteAtualizado.NomePaciente = pacienteBuscado.NomePaciente;
            }

            if (pacienteAtualizado.Rg != null)
            {
                pacienteAtualizado.Rg = pacienteBuscado.Rg;
            }

            if (pacienteAtualizado.Cpf != null)
            {
                pacienteAtualizado.Cpf = pacienteBuscado.Cpf;
            }

            if (pacienteAtualizado.Endereco != null)
            {
                pacienteAtualizado.Endereco = pacienteBuscado.Endereco;
            }

            if (pacienteAtualizado.DataNascimento != null)
            {
                pacienteAtualizado.DataNascimento = pacienteBuscado.DataNascimento;
            }

            if (pacienteAtualizado.Telefone != null)
            {
                pacienteAtualizado.Telefone = pacienteBuscado.Telefone;
            }

            if (pacienteAtualizado.IdUsuario != null)
            {
                pacienteAtualizado.IdUsuario = pacienteBuscado.IdUsuario;
            }

            //Faz as alterações
            ctx.Pacientes.Update(pacienteBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            //Retorna o que foi encontrado na busca
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            //Executa o método e faz o cadastro de um paciente
            ctx.Pacientes.Add(novoPaciente);

            //Salva as alterações
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Executa o método e exclui
            ctx.Pacientes.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            //Retorna a lista
            return ctx.Pacientes.ToList();
        }
    }
}
