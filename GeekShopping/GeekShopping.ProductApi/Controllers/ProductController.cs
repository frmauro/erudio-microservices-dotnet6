using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var productsVo = await _repository.FindAll();
            if (productsVo == null) return NotFound();
            return Ok(productsVo);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var vo = await _repository.FindById(id);
            if (vo.Id <= 0) return NotFound();
            return Ok(vo);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Post([FromBody]ProductVO vo)
        {
            if (vo == null) return BadRequest();
            vo = await _repository.Create(vo);
            return Ok(vo);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody]ProductVO vo)
        {
            if (vo == null) return BadRequest();
            vo = await _repository.Update(vo);
            return Ok(vo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);  
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
