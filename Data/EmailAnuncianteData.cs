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
    public class EmailAnuncianteData : IEmailAnuncianteData
    {
        private readonly MySqlConnection _connection;

        public EmailAnuncianteData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(EmailAnunciante EmailAnunciante)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO Email_ANUNCIANTE VALUES (NULL, @EMAIL, @ID_ANUNCIANTE)", _connection);

            command.Parameters.AddWithValue("@EMAIL", EmailAnunciante.Email);
            command.Parameters.AddWithValue("@ID_ANUNCIANTE", EmailAnunciante.IdAnunciante);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }

        public async Task<List<EmailAnunciante>> GetAllAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, EMAIL, ID_ANUNCIANTE FROM EMAIL_ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<EmailAnunciante>();

            while (dr.Read())
            {
                var EmailAnunciante = new EmailAnunciante();
                EmailAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                EmailAnunciante.Email = dr["EMAIL"].ToString();
                EmailAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(EmailAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task<List<EmailAnunciante>> GetByIdAnuncianteAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, EMAIL, ID_ANUNCIANTE FROM EMAIL_ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<EmailAnunciante>();

            while (dr.Read())
            {
                var EmailAnunciante = new EmailAnunciante();
                EmailAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                EmailAnunciante.Email = dr["EMAIL"].ToString();
                EmailAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(EmailAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("DELETE FROM EMAIL_ANUNCIANTE WHERE ID = @ID", _connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }
    }
}
