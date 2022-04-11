using Core.Interfaces.Data;
using Core.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CategoriaData : ICategoriaData
    {

        private readonly MySqlConnection _connection;

        public CategoriaData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(Categoria categoria)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO CATEGORIA VALUES (NULL, @NOME)", _connection);

            command.Parameters.AddWithValue("@NOME", categoria.Nome);
            command.ExecuteNonQuery();
        }
                
        public async Task<List<Categoria>> GetAllAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, NOME FROM CATEGORIA", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<Categoria>();

            while (dr.Read())
            {
                var categoria = new Categoria();
                categoria.Id = Convert.ToInt32(dr["ID"].ToString());
                categoria.Nome = dr["NOME"].ToString();

                result.Add(categoria);
            }

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("DELETE FROM CATEGORIA WHERE ID = @ID", _connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

        }

    }
}
