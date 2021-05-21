using Microsoft.EntityFrameworkCore;
using senai.Gufi.webApi.Contexts;
using senai.Gufi.webApi.Domains;
using senai.Gufi.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Gufi.webApi.Repositories
{
    /// <summary>
    /// Responsável pelas presenças
    /// </summary>
    /// Herda da base interface para obter os métodos
    public class PresencaRepository : IPresencaRepository
    {
        /// <summary>
        /// Instância o ctx que vai chamar os métodos do Entity Framework Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Responsável por alterar o status de um apresença
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença</param>
        public void AprovarRecusar(int id, string status)
        {
            //Busca a presença para o identificador informado e armazena as informações
            Presenca presencaBuscada = ctx.Presencas

                //Adiciona as informações do usuário que participa deste evento
                .Include(p => p.IdUsuarioNavigation)

                //Adiciona as informações sobre o evento que o usuário está participando
                .Include(p => p.IdEventtoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            //Faz a verificação de qual status que foi informado
            switch (status)
            {
                //Para a presença recusada
                case "0":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                //Para a presença confirmada
                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                //Para a presença não confirmada
                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                //Se nenhuma das opções acima não forem as atribuídas, a situação da presença não será alterada 
                default:
                    break;
            }

            //Faz a atualização dos dados buscado
            ctx.Presencas.Update(presencaBuscada);

            //Salva as atualizações 
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a atualização de uma presença 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="presencaAtualizada">Objeto atualizado</param>
        public void Atualizar(int id, Presenca presencaAtualizada)
        {
            //Faz a busca de uma presença através do identificador
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            //Verifica se o identificador do usuário foi informado / diferente de nulo
            if (presencaAtualizada.IdUsuario != null)
            {
                //Atribui os valores
                presencaBuscada.IdUsuario = presencaAtualizada.IdUsuario;
            }

            //Faz a verificaçaão de se a situação de presença foi informada
            if (presencaAtualizada.Situacao != null)
            {
                //Atribui os valores
                presencaBuscada.Situacao = presencaAtualizada.Situacao;
            }

            //Verifica se o identificador do evento foi informado
            if (presencaAtualizada.IdEventto != null)
            {
                //Atribi os valores
                presencaBuscada.IdEventto = presencaAtualizada.IdEventto;
            }

            //Atualiza a presença que foi buscada
            ctx.Presencas.Update(presencaBuscada);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca a presença através do identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        public Presenca BuscarPorId(int id)
        {
            //Retorna a presença encontrada atribuída ao identificador buscado
            return ctx.Presencas.FirstOrDefault(p => p.IdPresenca == id);
        }

        /// <summary>
        /// Faz o cadastramento de uma nova presença 
        /// </summary>
        /// <param name="novaPresenca">Objeto cadastrado</param>
        public void Cadastrar(Presenca novaPresenca)
        {
            //Faz o cadastro/Adiciona de uma nova presença
            ctx.Presencas.Add(novaPresenca);

            //Salva as informações no BD
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de uma presença existente
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Deletar(int id)
        {
            //Faz a busca da presença através do seu identificador
            Presenca presencaBuscada = ctx.Presencas.Find(id);

            //Faz a exclusão da presença buscada
            ctx.Presencas.Remove(presencaBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem de todas as presenças
        /// </summary>
        /// <returns>A lista de presenças</returns>
        public List<Presenca> ListarTodos()
        {
            //Faz o retorno da lista
            return ctx.Presencas.ToList();
        }

        /// <summary>
        /// Faz a inscrição
        /// </summary>
        /// <param name="marcar">Ojeto com todas as informações</param>
        public void MarcarEvento(Presenca marcar)
        {
            //Faz a adiçaõ de uma nova presença
            ctx.Presencas.Add(marcar);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem das presenças de um usuário de forma individual
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto com as informações</returns>
        public List<Presenca> MinhasPresencas(int id)
        {
            //Faz o retrno de uma lista com todas as informações
            return ctx.Presencas

                //Adiciona as informações sobre os eventos que o usuário participa
                .Include(p => p.IdEventtoNavigation)

                //Adiciona as informações sobre o tipo de evento
                .Include(p => p.IdEventtoNavigation.IdTipoEventoNavigation)
                
                //Adiciona as informações da Instituição do evento
                .Include(p => p.IdEventtoNavigation.IdInstituicaoNavigation)

                //Estabele que o parâmetro de busca será o identificador
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
