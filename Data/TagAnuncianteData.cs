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
    public class TagAnuncianteData : ITagAnuncianteData
    {
        private readonly MySqlConnection _connection;

        public TagAnuncianteData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(TagAnunciante tagAnunciante)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO TAG_ANUNCIANTE VALUES (NULL, @NOME, @ID_ANUNCIANTE)", _connection);

            command.Parameters.AddWithValue("@NOME", tagAnunciante.Nome);
            command.Parameters.AddWithValue("@ID_ANUNCIANTE", tagAnunciante.IdAnunciante);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }

        public async Task<List<TagAnunciante>> GetAllAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, NOME, ID_ANUNCIANTE FROM TAG_ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<TagAnunciante>();

            while (dr.Read())
            {
                var tagAnunciante = new TagAnunciante();
                tagAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                tagAnunciante.Nome = dr["NOME"].ToString();
                tagAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(tagAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task<List<TagAnunciante>> GetByIdAnuncianteAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, NOME, ID_ANUNCIANTE FROM TAG_ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<TagAnunciante>();

            while (dr.Read())
            {
                var tagAnunciante = new TagAnunciante();
                tagAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                tagAnunciante.Nome = dr["NOME"].ToString();
                tagAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(tagAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("DELETE FROM TAG_ANUNCIANTE WHERE ID = @ID", _connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }
    }
}
