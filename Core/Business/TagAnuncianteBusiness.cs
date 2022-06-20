using Core.Interfaces.Business;
using Core.Interfaces.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business
{
    public class TagAnuncianteBusiness : ITagAnuncianteBusiness
    {
        private readonly ITagAnuncianteData _tagAnuncianteData;

        public TagAnuncianteBusiness(ITagAnuncianteData tagAnuncianteData)
        {
            _tagAnuncianteData = tagAnuncianteData ?? throw new ArgumentNullException(nameof(tagAnuncianteData));
        }

        public async Task CreateAsync(TagAnunciante tagAnunciante)
        {
            await _tagAnuncianteData.CreateAsync(tagAnunciante);
        }

        public async Task<List<TagAnunciante>> GetAllAsync()
        {
            return await _tagAnuncianteData.GetAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _tagAnuncianteData.DeleteByIdAsync(id);
        }

    }
}

