using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core.Shared.RequestFeatures;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CatalogController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCpuAsync([FromQuery] CatalogParameters parameters)
        {
            try
            {
                var productsResult = await _service.ProductService.GetAllProductsAsync(trackChanges: false, parameters);
                return Ok(productsResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProduct(Guid Id)
        {
            var cpu = await _service.ProductService.GetProductAsync(Id, trackChanges: false);
            return Ok(cpu);
        }
    }
}
