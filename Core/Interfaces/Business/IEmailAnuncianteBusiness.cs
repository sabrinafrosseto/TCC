using Core.Model;
using System.Threading.Tasks;

namespace Core.Interfaces.Business
{
    public interface IEmailAnuncianteBusiness
    {
        Task CreateAsync(EmailAnunciante emailAnunciante);
        Task DeleteByIdAsync(int id);
    }
}