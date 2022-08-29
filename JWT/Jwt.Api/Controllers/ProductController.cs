using Jwt.Api.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Jwt.Api.Resources;
using Jwt.Api.Extensions;
using Jwt.Api.Domain.Model;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Properties

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Ctor

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        #endregion Ctor

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var res = await _productService.ListAsync();
            if (res.Success)
                return Ok(res.Data);
            return BadRequest(res.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _productService.GetAsync(id);
            if (res.Success)
                return Ok(res.Data);
            return BadRequest(res.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductResource product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var prod = _mapper.Map<ProductResource, Product>(product);

            var res = await _productService.AddProduct(prod);

            if (res.Success)
                return Ok(res.Data);
            return BadRequest(res.Message);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _productService.DeleteAsync(id);

            if (res.Success)
                return Ok();
            return BadRequest(res.Message);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(ProductResource product, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var prod = _mapper.Map<ProductResource, Product>(product);

            var res = await _productService.UpdateAsync(prod, id);

            if (res.Success)
                return Ok(res.Data);
            return BadRequest(res.Message);
        }

        #endregion Methods
    }
}
