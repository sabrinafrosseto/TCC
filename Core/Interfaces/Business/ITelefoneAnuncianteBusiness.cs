using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Business
{
    public interface ITelefoneAnuncianteBusiness
    {
        Task CreateAsync(TelefoneAnunciante telefoneAnunciante);
        Task DeleteByIdAsync(int id);
        Task<List<TelefoneAnunciante>> GetAllAsync();
    }
}