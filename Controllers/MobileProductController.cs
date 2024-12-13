using ApiWithDapper.Model;
using ApiWithDapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileProductController : ControllerBase
    {
        private readonly IProductService _service;

        public MobileProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult ApiValue()
        {
            var value = new
            {
               Value1=1,
               Value2 = 2
            };

            return Ok(value);
        }

        [HttpGet]
        [Route("/SelectAllProduct")]
        public async Task<IEnumerable<Mobile>> SelectAllProduct()
        {
           return await _service.SelectAllProduct();
        }


    }
}
