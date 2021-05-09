using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelos gêneros
    /// </summary>
    //(:)Base que faz a herança de classes (Introdução de métodos)
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão do banco de dados com a API, recebendo os parâmetros: Nome do servidor (Data Source); Nome do bd que se quer fazer conexão (Initial catalog); usuário (user); e a senha usada para entrar no sql (pwd)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-FCHJ4RD\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa1365";

        /// <summary>
        /// Atualização de um id pelo corpo
        /// </summary>
        /// <param name="genero">Objeto que vai ser atualizado</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            //Declara a con e passa a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara qual é a query que vai ser executada
                string queryUpdateBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abrea a conexão com  o bd
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza o gênero passando o id pela url
        /// </summary>
        /// <param name="id">número do gênero atualizado</param>
        /// <param name="genero">Objeto com informações novas</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            //Declara a con e passa a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
               //Declara qual é a query que vai ser executada
                string queryUpdateUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abrea a conexão com  o bd
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero através do seu id 
        /// </summary>
        /// <param name="id">número que será usado na busca do gênero</param>
        /// <returns>um gênero ou um null(não existente)</returns>
        public GeneroDomain BuscasPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                //Abre conexão com o banco de dados
                con.Open();

                //Faz a leitura dos dados
                SqlDataReader rdr;

                //Declara o parâmetro e usa a query que será executada, e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor para o @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                   //Executa a query de busca, e armazena informação
                    rdr = cmd.ExecuteReader();

                    //Verifica se existe algum dado para a leitura
                    if (rdr.Read())
                    {
                        //Se tiver, instância um novo objeto
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            //atribui a propriedade o valor idGenero da tabela do bd
                            idGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade o nome da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        //Retorna o gênero com os dados
                        return generoBuscado;
                    }

                    //Se não tiver retorna nulo
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão inseridas para cadastro</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo gênero, passando a stringConexao(Reaproveitamento de código) como parâmentro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Método para a inserção de dados usando o comando usado no bd mais a concatenação para um novo gênero 
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES ('"+novoGenero.nome+"')";

                //Esse método faz a mesma ação que oa cima, apenas permite que qualquer nome possa ser usado na inserção de gêneros/filmes, sem trazer erro de sintaxe, nem acesso ao bd
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                //O efeito Joana d'arc é causado por erros de sintaxe, acaba permitindo o SqlInjection, da acesso ao banco de dados
                //INSERT INTO Generos(Nome) VALUES('Joana D'arc')

                //Declara o cmd, mostra qual comando será executado(queryInsert), e a conexão(con)
                //O using não usa um método de looping, ele executa o método declarado, depois fecha a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o parâmetro @Nome definido acima na inserção
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    //Conexão com o banco de dados, sem ele não há conexão
                    con.Open();

                    //Executa a query declarada (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método que vai deletar um gênero através do seu id 
        /// </summary>
        /// <param name="id">id (número) do gênero que vai ser deletado</param>
        public void Deletar(int id)
        {
            //Declara a sql passando a string de conexão 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara que a query a ser executada vai ser a de deletar um gênero
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                //Está passando a query que vai ser executada, mais a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Define que o valor que será deletado o id 
                    cmd.Parameters.AddWithValue("@ID", id);

                    //Abre conexão com o banco de dados
                    con.Open();

                    //Executa a query de delete
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros existentes na tabela Filmes
        /// </summary>
        /// <returns>Lista dos gêneros</returns>
        public List<GeneroDomain> ListaGeral()
        {
            //Método para a criação de uma lista para o armazenamento dos dados desejáveis
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Método declarando a string de conexão como parâmetro (SqlConnection con)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Método que declara a query como um método de listagem que irá ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //Método que faz a conexão direto com o banco de dados
                con.Open();

                //Método que vai fazer a leitura das informações contidas no banco de dados 
                SqlDataReader rdr;

                //Método que declara o cmd passando a query que irá ser executada e o parâmetro de conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query definida e armazena os dados 
                    rdr = cmd.ExecuteReader();

                    //Método que percorre as linhas existentes a serem lidas, enquanto tiver dados nas linhas seguintes o método se repete
                    while (rdr.Read())
                    {
                        //Instancia um objeto generoDomain 
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui ao id o valor da primeira coluna do bd
                            idGenero = Convert.ToInt32(rdr[0]),

                            //Atribui ao nome o valor(informações) da segunda coluna do bd
                            nome = rdr[1].ToString()
                        };

                        //Adiciona o genero criado a lista de gêneros
                        listaGeneros.Add(genero);

                    }
                }
            }
            //Traz o retorno da lista de gêneros esperada pela instância
            return listaGeneros;
        }

    }
}
