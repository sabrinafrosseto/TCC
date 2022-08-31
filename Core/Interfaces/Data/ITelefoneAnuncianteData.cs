using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface ITelefoneAnuncianteData
    {
        Task CreateAsync(TelefoneAnunciante telefoneAnunciante);
        Task DeleteByIdAsync(int id);
        Task<List<TelefoneAnunciante>> GetAllAsync();
        Task<List<TelefoneAnunciante>> GetByIdAnuncianteAsync();
    }
}