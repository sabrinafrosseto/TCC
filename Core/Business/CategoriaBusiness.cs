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
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly ICategoriaData _categoriaData;

        public CategoriaBusiness(ICategoriaData categoriaData)
        {
            _categoriaData = categoriaData;
        }

        public async Task CreateAsync(Categoria categoria)
        {
            await _categoriaData.CreateAsync(categoria);
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _categoriaData.GetAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _categoriaData.DeleteByIdAsync(id);
        }
    }
}
