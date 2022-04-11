using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IAnuncianteData
    {
        Task CreateAsync(Anunciante anunciante);

        Task<List<Anunciante>> GetAllAsync();

        Task DeleteByIdAsync(int id);
    }
}