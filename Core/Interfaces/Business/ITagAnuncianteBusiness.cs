using Core.Model;
using System.Threading.Tasks;

namespace Core.Interfaces.Business
{
    public interface ITagAnuncianteBusiness
    {
        Task CreateAsync(TagAnunciante tagAnunciante);

        Task DeleteByIdAsync(int id);

        Task<System.Collections.Generic.List<TagAnunciante>> GetAllAsync();
    }
}