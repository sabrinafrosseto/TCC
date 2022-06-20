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
    public class AnuncianteData : IAnuncianteData
    {

        private readonly MySqlConnection _connection;

        public AnuncianteData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateAsync(Anunciante anunciante)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("INSERT INTO ANUNCIANTE VALUES (NULL, @NOME, @NUMERO_FISCAL, @REFERENCIA_IMAGEM_PERFIL, @EMAIL, @TAGS); SELECT LAST_INSERT_ID();", _connection) ;

            command.Parameters.AddWithValue("@NOME", anunciante.Nome);
            command.Parameters.AddWithValue("@NUMERO_FISCAL", anunciante.NumeroFiscal);
            command.Parameters.AddWithValue("@REFERENCIA_IMAGEM_PERFIL", anunciante.ReferenciaImagemPerfil);
            command.Parameters.AddWithValue("@EMAIL", anunciante.Email);
            command.Parameters.AddWithValue("@TAGS", anunciante.Tags);

            var id = command.ExecuteScalar();

            await _connection.CloseAsync();

            return Convert.ToInt32(id);
        }
                
        public async Task<List<Anunciante>> GetAllAsync()
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("SELECT ID, NOME,  NUMERO_FISCAL, REFERENCIA_IMAGEM_PERFIL, EMAIL, TAGS FROM ANUNCIANTE", _connection);

            using var dr = await command.ExecuteReaderAsync();

            var result = new List<Anunciante>();

            while (dr.Read())
            {
                var anunciante = new Anunciante();
                anunciante.Id = Convert.ToInt32(dr["ID"].ToString());
                anunciante.Nome = dr["NOME"].ToString();
                anunciante.NumeroFiscal = dr["NUMERO_FISCAL"].ToString();
                anunciante.ReferenciaImagemPerfil = dr["REFERENCIA_IMAGEM_PERFIL"].ToString();
                anunciante.Email = dr["EMAIL_an"].ToString();
                anunciante.Tags = Convert.List<"TAGS">(dr["TAGS"].ToString());

                result.Add(anunciante);
            }
            await _connection.CloseAsync();

            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _connection.OpenAsync();

            using var command = new MySqlCommand("DELETE FROM ANUNCIANTE WHERE ID = @ID", _connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            await _connection.CloseAsync();
        }
    }
}
