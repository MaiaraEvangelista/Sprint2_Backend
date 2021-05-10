using senai.Inlock.webApi.Domains;
using senai.Inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Inlock.webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelos jogos
    /// </summary>
    //(:)Base que faz a herança de classes (Introdução de métodos)
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão do banco de dados com a API, recebendo os parâmetros: Nome do servidor (Data Source); Nome do bd que se quer fazer conexão (Initial catalog); usuário (user); e a senha usada para entrar no sql (pwd)
        /// </summary>
        /// DESKTOP-FCHJ4RD\SQLEXPRESS
        string stringConexao = "Data Source=DESKTOP-FCHJ4RD\\SQLEXPRESS; initial catalog=Inlock; user Id=sa; pwd=sa1365 ";

        /// <summary>
        /// Método de atualização
        /// </summary>
        /// <param name="jogoAtualizado">Objeto atualizado</param>
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo jogo, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryUpdate = "UPDATE Jogos SET nomeJogo = @nomeJogo, descricao = @descricao, dataLancamento = @dataLancamento, valor = @valor, idEstudio = @idEstudio WHERE idJogo = @Id";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@nomeJogo",       jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao",      jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor",          jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@idEstudio",      jogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@ID",             jogoAtualizado.idJogo);

                    //Abre conexão com o BD
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }

        }


        /// <summary>
        /// Método de busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto e suas informações</returns>
        public JogoDomain BuscarPorId(int id)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo jogo, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryReadById = "SELECT * FROM Jogo WHERE idJogo = @Id";

                //Abre conexão com o BD
                con.Open();

                //Faz a leitura
                SqlDataReader rdr;

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryReadById, con))
                {
                    //Define  o valor 
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Executa a query definida e armazena os dados 
                    rdr = cmd.ExecuteReader();

                    //Verifica se existe algum dado para a leitura
                    if (rdr.Read())
                    {
                        //Se tiver, instância um novo jogo
                        JogoDomain jogo = new JogoDomain()
                        {
                            //Atribui os valores
                            idJogo =         Convert.ToInt32(rdr[0]),
                            nomeJogo =       rdr[1].ToString(),
                            descricao =      rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor =          Convert.ToDouble(rdr[4]),
                            idEstudio =      Convert.ToInt32(rdr[5])
                        };
                        //Retorna o jogo
                        return jogo;
                    }
                    //Se não tiver retorna nulo
                    return null;
                }
            }
        }


        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações que serão inseridas para cadastro</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo jogo, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryCreate = "INSERT INTO Jogo (nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryCreate, con))
                {
                    //Passa os valores
                    cmd.Parameters.AddWithValue("@nomeJogo",       novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao",      novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor",          novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio",      novoJogo.idEstudio);

                    //Abre conexão com o BD
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Método de exclusão
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Deletar(int id)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo jogo, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryDelete = "DELETE FROM Jogo WHERE idJogo = @Id";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Define que o valor que será deletado o id 
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Abre conexão com o BD
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <returns>Objetos e suas informações</returns>
        public List<JogoDomain> ListarTodos()
        {
            //Método para a criação de uma lista para o armazenamento dos dados
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            //Método que declara a conexão com o banco para o cadastramento de um novo jogo, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM Jogo";

                //Abre conexão com o BD
                con.Open();

                //Faz a leitura
                SqlDataReader rdr;

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query definida e armazena os dados 
                    rdr = cmd.ExecuteReader();

                    //Método que percorre as linhas existentes a serem lidas, enquanto tiver dados nas linhas
                    while (rdr.Read())
                    {
                        //Se tiver, instância um novo jogo
                        JogoDomain jogo = new JogoDomain()
                        {
                            //Atribui os valores
                            idJogo =         Convert.ToInt32(rdr[0]),
                            nomeJogo =       rdr[1].ToString(),
                            descricao =      rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor =          Convert.ToDouble(rdr[4]),
                            idEstudio =      Convert.ToInt32(rdr[5])
                        };
                        //Adiciona o jogo criado a lista de jogos
                        listaJogos.Add(jogo);
                    }
                }
            }
            //Retorna lisata jogos
            return listaJogos;
        }
    }
}
