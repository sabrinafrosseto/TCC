using Core.Interfaces.Business;
using Core.Interfaces.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class TelefoneAnuncianteBusiness : ITelefoneAnuncianteBusiness
    {
        private readonly ITelefoneAnuncianteData _telefoneAnuncianteData;

        public TelefoneAnuncianteBusiness(ITelefoneAnuncianteData telefoneAnuncianteData)
        {
            _telefoneAnuncianteData = telefoneAnuncianteData ?? throw new ArgumentNullException(nameof(telefoneAnuncianteData));
        }

        public async Task CreateAsync(TelefoneAnunciante telefoneAnunciante)
        {
            await _telefoneAnuncianteData.CreateAsync(telefoneAnunciante);
        }

        public async Task<List<TelefoneAnunciante>> GetAllAsync()
        {
            return await _telefoneAnuncianteData.GetAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _telefoneAnuncianteData.DeleteByIdAsync(id);
        }

    }
}
