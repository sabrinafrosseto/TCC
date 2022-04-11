using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface ICategoriaData
    {
        Task CreateAsync(Categoria categoria);

        Task<List<Categoria>> GetAllAsync();

        Task DeleteByIdAsync(int id);
    }
}