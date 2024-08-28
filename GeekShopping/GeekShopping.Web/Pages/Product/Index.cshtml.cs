using GeekShopping.Web.DTO;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Web.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IList<ProductDto> Products { get; set; }


        public IndexModel(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task OnGet()
        {
            var products = await _productService.FindAllProducts();
        }
    }
}
