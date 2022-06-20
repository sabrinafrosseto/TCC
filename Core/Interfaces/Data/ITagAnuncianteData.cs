using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface ITagAnuncianteData
    {
        Task CreateAsync(TagAnunciante tagAnunciante);
        Task DeleteByIdAsync(int id);
        Task<List<TagAnunciante>> GetAllAsync();
    }
}