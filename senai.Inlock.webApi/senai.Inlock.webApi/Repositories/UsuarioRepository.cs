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
    /// Classe responsável pelos usuarios
    /// </summary>
    //(:)Base que faz a herança de classes (Introdução de métodos)
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão do banco de dados com a API, recebendo os parâmetros: Nome do servidor (Data Source); Nome do bd que se quer fazer conexão (Initial catalog); usuário (user); e a senha usada para entrar no sql (pwd)
        /// </summary>
        string stringConexao = "Data Source=DESKTOP-FCHJ4RD\\SQLEXPRESS; initial catalog=Inlock; user Id=sa; pwd=sa1365 ";


        /// <summary>
        /// Método de atualização
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto atualizado</param>
        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo usuario, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryUpdate = "UPDATE Usuario SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @Id";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    //Passa os valores que seriam atualizados
                    cmd.Parameters.AddWithValue("@email",         usuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha",         usuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuarioAtualizado.idTipoUsuario);

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
        public UsuarioDomain BuscarPorId(int id)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo usuario, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string querySelectAll = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario WHERE idUsuario = @Id";

                //Abre conexão com o BD
                con.Open();

                //Faz a leitura
                SqlDataReader rdr;

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Define o valor 
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Executa a query definida e armazena os dados 
                    rdr = cmd.ExecuteReader();

                    //Método que percorre as linhas existentes a serem lidas, enquanto tiver dados nas linhas
                    while (rdr.Read())
                    {
                        //Se tiver, instância um novo usuario
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            //Atribui os valores
                            idUsuario =     Convert.ToInt32(rdr[0]),
                            email =         rdr[1].ToString(),
                            senha =         rdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[3])
                        };
                        //Retorna o usuario
                        return usuario;
                    }
                }
            }
            //Se não tiver retorna nulo
            return null;
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações que serão inseridas para cadastro</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo Usuario, passando a stringConexao(Reaproveitamento de código) como parâmentro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryCreate = "INSERT INTO Usuario (email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryCreate, con))
                {
                    //Passa os valores
                    cmd.Parameters.AddWithValue("@email",         novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha",         novoUsuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

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
            //Método que declara a conexão com o banco para o cadastramento de um novo usuario, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @Id";

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
        public List<UsuarioDomain> ListarTodos()
        {
            //Método para a criação de uma lista para o armazenamento dos dados
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            //Método que declara a conexão com o banco para o cadastramento de um novo usuario, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string querySelectAll = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario";

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
                        //Se tiver, instância um novo usuario
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            //Atribui os valores
                            idUsuario =     Convert.ToInt32(rdr[0]),
                            email =         rdr[1].ToString(),
                            senha =         rdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[3])
                        };
                        //Adiciona o usuario criado a lista de usuarios
                        listaUsuario.Add(usuario);
                    }
                }
            }
            //Retorna lista usuario
            return listaUsuario;
        }

        /// <summary>
        /// Método de login
        /// </summary>
        /// <param name="email">Parâmetro</param>
        /// <param name="senha">Conexão do usuário</param>
        /// <returns>Objeto logado</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            //Método que declara a conexão com o banco para o cadastramento de um novo usuario, passando a stringConexao(Reaproveitamento de código) como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query e seus parâmetros
                string queryLogin = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario WHERE email = @email AND senha = @senha";

                //Faz a leitura
                SqlDataReader rdr;

                //Declara o cmd e passa a query que vai ser executada
                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    //Passa os valores
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    //Abre conexão com o BD
                    con.Open();

                    //Executa a query definida e armazena os dados 
                    rdr = cmd.ExecuteReader();

                    //Verifica se existe algum dado para a leitura
                    if (rdr.Read())
                    {
                        //Se tiver, instância um novo usuario
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            //Atribui os valores
                            idUsuario =     Convert.ToInt32(rdr[0]),
                            email =         rdr[1].ToString(),
                            senha =         rdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[3])
                        };
                        //Retorna o usuario...
                        return usuarioBuscado;
                    }
                    //Se não tiver retorna nulo
                    return null;
                }
            }
        }
    }
}
