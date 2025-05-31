using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        private string conctionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(conctionString);
        }

        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = ObterConexao();
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
    }
}
