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
    public class AnuncianteBusiness : IAnuncianteBusiness
    {
        private readonly IAnuncianteData _anuncianteData;

        public AnuncianteBusiness(IAnuncianteData anuncianteData)
        {
            _anuncianteData = anuncianteData ?? throw new ArgumentNullException(nameof(anuncianteData));
        }

        public async Task CreateAsync(Anunciante anunciante)
        {
            await _anuncianteData.CreateAsync(anunciante);
        }

        public async Task<List<Anunciante>> GetAllAsync()
        {
            return await _anuncianteData.GetAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _anuncianteData.DeleteByIdAsync(id);
        }

    }
}
