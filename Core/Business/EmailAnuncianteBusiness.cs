using Core.Interfaces.Business;
using Core.Interfaces.Data;
using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.Business
{
    public class EmailAnuncianteBusiness : IEmailAnuncianteBusiness
    {
        private readonly IEmailAnuncianteData _emailAnuncianteData;

        public EmailAnuncianteBusiness(IEmailAnuncianteData emailAnuncianteData)
        {
            _emailAnuncianteData = emailAnuncianteData ?? throw new ArgumentNullException(nameof(emailAnuncianteData)); ;
        }

        public async Task CreateAsync(EmailAnunciante emailAnunciante)
        {
            await _emailAnuncianteData.CreateAsync(emailAnunciante);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _emailAnuncianteData.DeleteByIdAsync(id);
        }

    }
}
