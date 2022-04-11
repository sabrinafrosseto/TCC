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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaBusiness _categoriaBusiness;

        public CategoriaController(ICategoriaBusiness categoriaBusiness)
        {
            _categoriaBusiness = categoriaBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Categoria categoria)
        {
            await _categoriaBusiness.CreateAsync(categoria);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoriaBusiness.GetAllAsync();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {      
            await _categoriaBusiness.DeleteByIdAsync(id);

            return Ok();
        }
    }
}
