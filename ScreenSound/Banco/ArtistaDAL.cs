using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "SELECT * FROM Artistas";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Artista artista = new Artista(dataReader["Nome"].ToString()!, dataReader["Bio"].ToString()!)
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    FotoPerfil = dataReader["FotoPerfil"].ToString()!
                };
                lista.Add(artista);
            }
            return lista;
        }

        public void Adicionar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "INSERT INTO Artistas (Nome, Bio, FotoPerfil) VALUES (@nome, @bio, @foto)";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", artista.Nome);
            command.Parameters.AddWithValue("@Bio", artista.Bio);
            command.Parameters.AddWithValue("@foto", artista.FotoPerfil);

            int retorno = command.ExecuteNonQuery();
            if (retorno == 0)
            {
                throw new Exception("Erro ao inserir o artista no banco de dados.");
            }
            Console.WriteLine("Linhas afetadas: " + retorno);
        }

        public void Deletar(int id)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "DELETE FROM Artistas WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            int retorno = command.ExecuteNonQuery();
            if (retorno == 0)
            {
                throw new Exception("Erro ao deletar o artista no banco de dados.");
            }
            Console.WriteLine("Linhas afetadas: " + retorno);
        }

        public void Atualizar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);
            command.Parameters.AddWithValue("@id", artista.Id);

            int retorno = command.ExecuteNonQuery();
            if (retorno == 0)
            {
                throw new Exception("Erro ao atualizar o artista no banco de dados.");
            }
            Console.WriteLine("Linhas afetadas: " + retorno);
        }
    }
}
