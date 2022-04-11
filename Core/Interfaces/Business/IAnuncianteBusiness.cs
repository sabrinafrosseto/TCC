using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Business
{
    public interface IAnuncianteBusiness
    {
        Task CreateAsync(Anunciante anunciante);

        Task<List<Anunciante>> GetAllAsync();

        Task DeleteByIdAsync(int id);
    }
}