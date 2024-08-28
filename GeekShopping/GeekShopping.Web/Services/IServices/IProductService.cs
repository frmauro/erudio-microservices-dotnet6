using GeekShopping.Web.DTO;
using GeekShopping.Web.Pages;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> FindAllProducts();
    Task<ProductDto> FindProductById(long id);
    Task<ProductDto> CreateProduct(ProductDto model);
    Task<ProductDto> UpdateProduct(ProductDto model);
    Task<bool> DeleteProductById(long id);
}
