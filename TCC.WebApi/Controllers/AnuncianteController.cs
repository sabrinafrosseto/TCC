using Core.Interfaces.Business;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncianteController : ControllerBase
    {
        private readonly IAnuncianteBusiness _anuncianteBusiness;

        public AnuncianteController(IAnuncianteBusiness anuncianteBusiness)
        {
            _anuncianteBusiness = anuncianteBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Anunciante anunciante)
        {
            await _anuncianteBusiness.CreateAsync(anunciante);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _anuncianteBusiness.GetAllAsync();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            await _anuncianteBusiness.DeleteByIdAsync(id);

            return Ok();
        }




    }
}
