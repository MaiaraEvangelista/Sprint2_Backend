using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// Essa é a via de conexão com o banco de dados que permite a leitura das informações  
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-FCHJ4RD\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa1365";


        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            //Declara a con e passa a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara qual é a query que vai ser executada
                string queryUpdateBody = "UPDATE Filmes SET Nome = @Nome, Titulo = @Titulo, idGenero = @idGenero WHERE idFilme = @ID";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@ID",       filme.idFilme);
                    cmd.Parameters.AddWithValue("@Titulo",   filme.titulo);
                    cmd.Parameters.AddWithValue("@idGenero", filme.idGenero);

                    //Abrea a conexão com  o bd
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            //Declara a con e passa a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara qual é a query que vai ser executada
                string queryUpdateUrl = "UPDATE Filmes SET Nome = @Nome WHERE idFilme = @ID";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.idGenero);

                    //Abrea a conexão com  o bd
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscasPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idFilme, Nome FROM Filmes WHERE idFilme = @ID";

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
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            //atribui a propriedade o valor idFilme da tabela do bd
                            idFilme = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade o nome da tabela do banco de dados
                           titulo = rdr[1].ToString(),

                           //Atribui a propriedade idGenero na tabela
                           idGenero = Convert.ToInt32(rdr[2])
                        };

                        //Retorna o filme com os dados
                        return filmeBuscado;
                    }

                    //Se não tiver retorna nulo
                    return null;
                }
            }
               
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo filme, passando a stringConexao(Reaproveitamento de código) como parâmentro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                // permite que qualquer nome possa ser usado na inserção de gêneros/filmes, sem trazer erro de sintaxe, nem acesso ao bd
                string queryInsert = "INSERT INTO Filmes(Titulo) VALUES (@Titulo)";

                //Declara o cmd, mostra qual comando será executado(queryInsert), e a conexão(con)
                //O using não usa um método de looping, ele executa o método declarado, depois fecha a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa os parâmetros definidos para cadastro
                    cmd.Parameters.AddWithValue("@ID", novoFilme.idFilme);
                    cmd.Parameters.AddWithValue("@idGenero", novoFilme.idGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.titulo);

                    //Conexão com o banco de dados, sem ele não há conexão
                    con.Open();

                    //Executa a query declarada (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            //Declara a sql passando a string de conexão 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara que a query a ser executada vai ser a de deletar um gênero
                string queryDelete = "DELETE FROM Filmes WHERE idFilme = @ID";

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

        public List<FilmeDomain> ListaGeral()
        {
            //Método para a criação de uma lista para o armazenamento dos dados desejáveis
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Método declarando a string de conexão como parâmetro (SqlConnection con)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Método que declara a query como um método de listagem que irá ser executada
                string querySelectAll = "SELECT idFilme, Titulo, idGenero FROM Filmes";

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
                        //Instancia um objeto filmeDomain 
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),

                            //Atribui ao id o valor da tabela do bd
                            idGenero = Convert.ToInt32(rdr[1]),

                            //Atribui ao nome o valor(informações) da segunda coluna do bd
                            titulo = rdr[2].ToString()
                        };

                        //Adiciona o filme criado a lista de filmes
                        listaFilmes.Add(filme);

                    }
                }
            }
            //Traz o retorno da lista de filmes esperada pela instância
            return listaFilmes;
        }
    }
}
