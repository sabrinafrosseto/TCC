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
    public class TelefoneAnuncianteData : ITelefoneAnuncianteData
    {
        private readonly MySqlConnection _connection;

        public TelefoneAnuncianteData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(TelefoneAnunciante telefoneAnunciante)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO TELEFONE_ANUNCIANTE VALUES (NULL, @DDD, @TELEFONE, @WHATSAPP, @ID_ANUNCIANTE)", _connection);

            command.Parameters.AddWithValue("@DDD", telefoneAnunciante.DDD);
            command.Parameters.AddWithValue("@TELEFONE", telefoneAnunciante.Telefone);
            command.Parameters.AddWithValue("@WHATSAPP", telefoneAnunciante.Whatsapp);
            command.Parameters.AddWithValue("@ID_ANUNCIANTE", telefoneAnunciante.IdAnunciante);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }

        public async Task<List<TelefoneAnunciante>> GetAllAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, DDD, TELEFONE, WHATSAPP, ID_ANUNCIANTE FROM TELEFONE_ANUNCIANTE");

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<TelefoneAnunciante>();

            while (dr.Read())
            {
                var telefoneAnunciante = new TelefoneAnunciante();
                telefoneAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                telefoneAnunciante.DDD = dr["DDD"].ToString();
                telefoneAnunciante.Telefone = dr["TELEFONE"].ToString();
                telefoneAnunciante.Whatsapp = Convert.ToBoolean(dr["WHATSAPP"].ToString());
                telefoneAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(telefoneAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task<List<TelefoneAnunciante>> GetByIdAnuncianteAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, DDD, TELEFONE, WHATSAPP, ID_ANUNCIANTE FROM TELEFONE_ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<TelefoneAnunciante>();

            while (dr.Read())
            {
                var telefoneAnunciante = new TelefoneAnunciante();
                telefoneAnunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                telefoneAnunciante.DDD = dr["DDD"].ToString();
                telefoneAnunciante.Telefone = dr["TELEFONE"].ToString();
                telefoneAnunciante.Whatsapp = Convert.ToBoolean(dr["WHATSAPP"].ToString());
                telefoneAnunciante.IdAnunciante = Convert.ToInt32(dr["ID_ANUNCIANTE"].ToString());

                result.Add(telefoneAnunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("DELETE FROM TELEFONE_ANUNCIANTE WHERE ID = @ID", _connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }
    }
}
