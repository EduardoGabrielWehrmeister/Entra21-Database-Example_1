using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repositorio
{
    public class FilmeRepositorio
    {
        string CadeiaConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65973\Documents\ExemploBancoDados02.mdf;Integrated Security=True;Connect Timeout=30";
        /*
         * Método que irá retornar os dados dos 
         * filmes(List<Filme>) da tablea de filmes
         */

        public List<Filme> ObterTodos()
        {
            //Cria conexão com banco de datdos e abre.
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            /*
            * Cria o comando para ser executado no Banco De Dados
            * E diz para este comando qual é a conexão que está aberta
            */
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM filmes";

            /*
             * Cria uma tabela em memória para obter os dados que são 
             * retornados no Banco de Dados executando o comando Banco De Dados
            */
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            //Cria uma lista para adicionar os Filmes no Banco De Dados
            List<Filme> filmes = new List<Filme>();

            //Percoree todos os registros lidos no Banco de Dados
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                //Cria um objeto com as imformações obtidas em Banco de Dados
                Filme filme = new Filme();
                filme.Id = Convert.ToInt32(linha["id"]);
                filme.Nome = linha["nome"].ToString();
                filme.Avaliacao = Convert.ToDecimal(linha["avaliacao"]);
                filme.Duracao = Convert.ToDateTime(linha["duracao"]);
                filme.Curtiu = Convert.ToBoolean(linha["curtiu"]);
                filme.Categoria = linha["categoria"].ToString();
                filme.TemSequencia = Convert.ToBoolean(linha["tem_sequencia"]);
                // Adiciona o objeto que foi criado a lista de filmes
                filmes.Add(filme);
            }
            // Fecha a conexão do Banco De Dados
            conexao.Close();
            // Retorna a Lista de filmes
            return filmes;
        }

        public Filme ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM filme WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", id);

            DataTable dataTable = new DataTable();
            dataTable.Load(comando.ExecuteReader());
            conexao.Close();
            if (dataTable.Rows.Count == 1)
            {
                DataRow linha = dataTable.Rows[0];
                Filme filme = new Filme();
                filme.Id = Convert.ToInt32(linha["id"]);
                filme.Nome = linha["nome"].ToString();
                filme.Categoria = linha["categoria"].ToString();
                filme.Curtiu = Convert.ToBoolean(linha["curtiu"]);
                filme.Duracao = Convert.ToDateTime(linha["duracao"]);
                filme.Avaliacao = Convert.ToDecimal(linha["avaliacao"]);
                filme.TemSequencia = Convert.ToBoolean(linha["tem_sequencia"]);
                return filme;
            }
            return null;
        }

        public void Inserir(Filme filme)

        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;

            comando.CommandText = @"INSERT INTO filmes (nome, categoria, curtiu, duracao, avaliacao, tem_sequencia) VALUES (@NOME, @CATEGORIA, @CURTIU, @DURACAO, @AVALIACAO, @TEM_SEQUENCIA)";
            comando.Parameters.AddWithValue("@NOME", filme.Nome);
            comando.Parameters.AddWithValue("@CATEGORIA", filme.Categoria);
            comando.Parameters.AddWithValue("@CURTIU", filme.Curtiu);
            comando.Parameters.AddWithValue("@DURACAO", filme.Duracao);
            comando.Parameters.AddWithValue("@AVALIACAO", filme.Avaliacao);
            comando.Parameters.AddWithValue("@TEM_SEQUENCIA", filme.TemSequencia);
            comando.ExecuteNonQuery();
            conexao.Close();

        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "DELETE FROM filmes WHERE id = @ID";
            comando.Parameters.AddWithValue("ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Atualizar(Filme filme)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE filmes SET nome = @NOME, categoria = @CATEGORIA, curtiu = @CURTIU, duracao = @DURACAO, avaliacao = @AVALIACAO, tem_sequencia = @TEM_SEQUENCIA WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", filme.Nome);
            comando.Parameters.AddWithValue("@CATEGORIA", filme.Categoria);
            comando.Parameters.AddWithValue("@CURTIU", filme.Curtiu);
            comando.Parameters.AddWithValue("@DURACAO", filme.Duracao);
            comando.Parameters.AddWithValue("@AVALIACAO", filme.Avaliacao);
            comando.Parameters.AddWithValue("@TEM_SEQUENCIA", filme.TemSequencia);
            comando.Parameters.AddWithValue("@ID", filme.Id);
            comando.ExecuteNonQuery();
            conexao.Close();

        }
        

    }
}
