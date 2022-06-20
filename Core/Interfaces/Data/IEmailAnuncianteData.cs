using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IEmailAnuncianteData
    {
        Task CreateAsync(EmailAnunciante EmailAnunciante);
        Task DeleteByIdAsync(int id);
        Task<List<EmailAnunciante>> GetAllAsync();
        Task<List<EmailAnunciante>> GetByIdAnuncianteAsync();
    }
}