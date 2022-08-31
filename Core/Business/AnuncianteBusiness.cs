using Core.Interfaces.Business;
using Core.Interfaces.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class AnuncianteBusiness : IAnuncianteBusiness
    {
        private readonly IAnuncianteData _anuncianteData;

        private readonly ITagAnuncianteBusiness _tagAnuncianteBusiness;

        private readonly ICategoriaBusiness _categoriaBusiness;

        private readonly ITelefoneAnuncianteBusiness _telefoneAnuncianteBusiness;

        private readonly IEmailAnuncianteBusiness _emailAnuncianteBusiness;

        public AnuncianteBusiness(
            IAnuncianteData anuncianteData,
            ITagAnuncianteBusiness tagAnuncianteBusiness,
            ICategoriaBusiness categoriaBusiness,
            ITelefoneAnuncianteBusiness telefoneAnuncianteBusiness,
            IEmailAnuncianteBusiness emailAnuncianteBusiness)
        {
            _anuncianteData = anuncianteData ?? throw new ArgumentNullException(nameof(anuncianteData));
            _tagAnuncianteBusiness = tagAnuncianteBusiness;
            _categoriaBusiness = categoriaBusiness;
            _telefoneAnuncianteBusiness = telefoneAnuncianteBusiness;
            _emailAnuncianteBusiness = emailAnuncianteBusiness;
        }

        public async Task CreateAsync(Anunciante anunciante)
        {
            var idAnunciante = await _anuncianteData.CreateAsync(anunciante);

            //todo ´podem haver tags repetida. validar tag repetidas
            foreach (var item in anunciante.Tags)
            {
                item.IdAnunciante = idAnunciante;

                await _tagAnuncianteBusiness.CreateAsync(item);
            }
            //chamar os metodos de inserção de telefone, endereço e email
            foreach (var item in anunciante.Telefones)
            {
                item.IdAnunciante = idAnunciante;

                await _telefoneAnuncianteBusiness.CreateAsync(item);
            }
            //COMO INCLUIR CATEGORIA_ANUNCIANTE AQUI?

            anunciante.Email.IdAnunciante = idAnunciante;
            await _emailAnuncianteBusiness.CreateAsync(anunciante.Email);
        }

        public async Task<List<Anunciante>> GetAllAsync()
        {
            return await _anuncianteData.GetAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _anuncianteData.DeleteByIdAsync(id);
        }

    }
}
