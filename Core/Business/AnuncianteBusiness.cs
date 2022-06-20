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

        private readonly ITagAnuncianteBusiness _tagAnuncianteBusiness;

        public AnuncianteBusiness(IAnuncianteData anuncianteData, ITagAnuncianteBusiness tagAnuncianteBusiness)
        {
            _anuncianteData = anuncianteData ?? throw new ArgumentNullException(nameof(anuncianteData));
            _tagAnuncianteBusiness = tagAnuncianteBusiness;
        }

        public async Task CreateAsync(Anunciante anunciante)
        {
            var idAnunciante = await _anuncianteData.CreateAsync(anunciante);

            foreach (var item in anunciante.Tags)
            {
                item.IdAnunciante = idAnunciante;

                await _tagAnuncianteBusiness.CreateAsync(item);
            }
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
